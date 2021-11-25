CREATE TABLE dbo.asset_group (
    asset_group_id uniqueidentifier NOT NULL,
	name varchar(255) NOT NULL,
	PRIMARY KEY (asset_group_id));

CREATE TABLE dbo.asset_type (
    asset_type_id uniqueidentifier NOT NULL,
	name varchar(255) NOT NULL,
	description varchar(255),
	manufacturer varchar(255),
	model varchar(255),
	stig_id uniqueidentifier,
	asset_group_id uniqueidentifier NOT NULL,
	PRIMARY KEY (asset_type_id));

CREATE TABLE dbo.department (
	department_id uniqueidentifier NOT NULL,
	name varchar(255) NOT NULL,
	PRIMARY KEY (department_id));

CREATE TABLE dbo.employee (
	employee_id uniqueidentifier NOT NULL,
	given_name varchar(50) NOT NULL,
	family_name varchar(50) NOT NULL,
	email varchar(255) NOT NULL,
	job_title varchar(50),
	department_id uniqueidentifier NOT NULL,
	PRIMARY KEY (employee_id));

CREATE TABLE dbo.asset (
	asset_id uniqueidentifier NOT NULL,
	name varchar(255) NOT NULL,
	description varchar(255),
	status varchar(5),
	contact_employee_id uniqueidentifier,
	owning_department_id uniqueidentifier,
	parent_asset_id uniqueidentifier,
	asset_type_id uniqueidentifier NOT NULL,
	purchase_date datetime,
	in_service_date datetime,
	retired_date datetime,
	PRIMARY KEY (asset_id));

CREATE TABLE dbo.[user] (
    [user_id] uniqueidentifier NOT NULL,
	[role] char(1) NOT NULL,
	is_enabled bit NOT NULL,
	password_hash varchar(50) NOT NULL,
	password_salt varchar(50) NOT NULL,
	employee_id uniqueidentifier NOT NULL,
	PRIMARY KEY (user_id));

CREATE TABLE dbo.stig (
    stig_id uniqueidentifier NOT NULL,
	number VARCHAR(50) NOT NULL,
	PRIMARY KEY (stig_id));

CREATE TABLE dbo.version (
    version_id uniqueidentifier NOT NULL,
	stig_id uniqueidentifier NOT NULL,
	number VARCHAR(5) NOT NULL,
	status VARCHAR(5) NOT NULL,
	status_date DATETIME NOT NULL,
	title VARCHAR(max) NOT NULL,
	description VARCHAR(max) NOT NULL,
	publisher VARCHAR(100) NOT NULL,
	source VARCHAR(100) NOT NULL,
	filename VARCHAR(255) NOT NULL,
	PRIMARY KEY (version_id));

CREATE TABLE dbo.[rule] (
    rule_id uniqueidentifier NOT NULL,
	version_id uniqueidentifier NOT NULL,
	number VARCHAR(30) NOT NULL,
	severity CHAR(1) NOT NULL,
	version VARCHAR(50) NOT NULL,
	title VARCHAR(max) NOT NULL,
	fix VARCHAR(max) NOT NULL,
	[check] VARCHAR(max) NOT NULL,
	cci VARCHAR(20) NOT NULL,
	PRIMARY KEY (rule_id));

CREATE TABLE dbo.implementation (
    implementation_id uniqueidentifier NOT NULL,
	start_date datetime,
	end_date datetime,
	status varchar(5) NOT NULL,
	summary VARCHAR(max),
	assigned_user_id uniqueidentifier,
	asset_id uniqueidentifier NOT NULL,
	stig_id uniqueidentifier NOT NULL,
	PRIMARY KEY (implementation_id));

CREATE TABLE dbo.implementation_rule (
	implementation_rule_id uniqueidentifier NOT NULL,
	rule_id uniqueidentifier NOT NULL,
	implementation_id uniqueidentifier NOT NULL,
	status VARCHAR(5) NOT NULL,
	finding_details VARCHAR(max),
	comments VARCHAR(max),
	severity_override CHAR(1),
	severity_justification VARCHAR(max),
	evidence_set_id uniqueidentifier,
	PRIMARY KEY (implementation_rule_id));

CREATE TABLE dbo.audit (
    audit_id uniqueidentifier NOT NULL,
	start_date datetime,
	end_date datetime,
	status VARCHAR(5) NOT NULL,
	summary VARCHAR(max),
	assigned_user_id uniqueidentifier,
	asset_id uniqueidentifier NOT NULL,
	stig_id uniqueidentifier NOT NULL,
	PRIMARY KEY (audit_id));

CREATE TABLE dbo.audit_rule (
    audit_rule_id uniqueidentifier NOT NULL,
	comment VARCHAR(max),
	status VARCHAR(5) NOT NULL,
	rule_id uniqueidentifier NOT NULL,
	audit_id uniqueidentifier NOT NULL,
	evidence_set_id uniqueidentifier NOT NULL,
	PRIMARY KEY (audit_rule_id));

CREATE TABLE dbo.evidence_set (
    evidence_set_id uniqueidentifier NOT NULL,
	type CHAR(1) NOT NULL,
	PRIMARY KEY (evidence_set_id));

CREATE TABLE dbo.evidence (
	evidence_id uniqueidentifier NOT NULL,
	data_location varchar(500) NOT NULL,
	mime_type varchar(50) NOT NULL,
	evidence_set_id uniqueidentifier NOT NULL,
	PRIMARY KEY (evidence_id));

-- Add alternate key constraints
ALTER TABLE dbo.asset_group
	ADD CONSTRAINT ak_asset_group_name UNIQUE (name);

ALTER TABLE dbo.asset_type
	ADD CONSTRAINT ak_asset_type UNIQUE (name);

ALTER TABLE dbo.department
	ADD CONSTRAINT ak_department UNIQUE (name);

ALTER TABLE dbo.stig
    ADD CONSTRAINT ak_stig_number UNIQUE (number);

ALTER TABLE dbo.version
    ADD CONSTRAINT ak_version_stig_number UNIQUE (stig_id, number);

ALTER TABLE dbo.[rule]
    ADD CONSTRAINT AK_RULE_VERSION_RULENUM UNIQUE (version_id, number);

ALTER TABLE dbo.implementation_rule
    ADD CONSTRAINT ak_implementation_rule_id_rule UNIQUE (implementation_id, rule_id);

ALTER TABLE dbo.audit_rule
	ADD CONSTRAINT ak_audit_rule_id_rule UNIQUE (audit_id, rule_id);

ALTER TABLE dbo.evidence
	ADD CONSTRAINT ak_evidence_set_location UNIQUE (evidence_set_id, data_location);

-- Add check constraints
-- Pending, Active, Retired
ALTER TABLE dbo.asset
	ADD CONSTRAINT chk_asset_status CHECK ([status] IN ('P', 'A', 'R'));

-- Open, In Progress, Complete
ALTER TABLE dbo.implementation
	ADD CONSTRAINT chk_implementation_status CHECK ([status] IN ('O', 'I', 'C'));

-- Open, In Progress, Complete, Failed
ALTER TABLE dbo.audit
	ADD CONSTRAINT chk_audit_status CHECK ([status] IN ('O', 'I', 'C', 'F'));

ALTER TABLE dbo.audit_rule
    ADD CONSTRAINT chk_audit_rule_status CHECK ([status] IN ('O', 'P', 'F'));

-- Not a Finding, Open, Not Applicable, Not Reviewed
ALTER TABLE dbo.implementation_rule
    ADD CONSTRAINT chk_implementation_rule_status CHECK ([status] IN ('NF', 'O', 'NA', 'NR'));

-- Accepted, Deprecated, Draft, Incomplete, Interim
ALTER TABLE dbo.version
    ADD CONSTRAINT chk_version_status CHECK ([status] IN ('A', 'DP', 'DR', 'IC', 'IN'));

-- Low, Medium, High
ALTER TABLE dbo.[RULE]
    ADD CONSTRAINT chk_rule_severity CHECK ([severity] IN ('L', 'M', 'H'));

-- Add Default
ALTER TABLE dbo.implementation_rule
    ADD CONSTRAINT df_implementation_rule_status
    DEFAULT 'NF' FOR [status];

-- Add Foreign Keys
ALTER TABLE dbo.asset_type
	ADD CONSTRAINT fk_asset_type_asset_group FOREIGN KEY (asset_group_id)
	REFERENCES dbo.asset_group (asset_group_id);

ALTER TABLE dbo.asset_type
	ADD CONSTRAINT fk_asset_type_stig FOREIGN KEY (stig_id)
	REFERENCES dbo.stig (stig_id);

ALTER TABLE dbo.asset
	ADD CONSTRAINT fk_asset_asset_type FOREIGN KEY (asset_type_id)
	REFERENCES dbo.asset_type (asset_type_id);

ALTER TABLE dbo.asset
	ADD CONSTRAINT fk_asset_employee FOREIGN KEY (contact_employee_id)
	REFERENCES dbo.employee (employee_id);

ALTER TABLE dbo.asset
	ADD CONSTRAINT fk_asset_department FOREIGN KEY (owning_department_id)
	REFERENCES dbo.department (department_id);

ALTER TABLE dbo.asset
	ADD CONSTRAINT fk_asset_asset FOREIGN KEY (parent_asset_id)
	REFERENCES dbo.asset (asset_id);

ALTER TABLE dbo.employee
	ADD CONSTRAINT fk_employee_department FOREIGN KEY (department_id)
	REFERENCES dbo.department (department_id);

ALTER TABLE dbo.[user]
	ADD CONSTRAINT fk_user_employee FOREIGN KEY (employee_id)
	REFERENCES dbo.employee (employee_id);

ALTER TABLE dbo.implementation
	ADD CONSTRAINT fk_implementation_asset FOREIGN KEY (asset_id)
	REFERENCES dbo.asset (asset_id);

ALTER TABLE dbo.implementation
	ADD CONSTRAINT fk_implementation_stig FOREIGN KEY (stig_id)
	REFERENCES dbo.stig (stig_id);

ALTER TABLE dbo.implementation
	ADD CONSTRAINT fk_implementation_user FOREIGN KEY (assigned_user_id)
	REFERENCES dbo.[user] ([user_id]);


ALTER TABLE dbo.audit
	ADD CONSTRAINT fk_audit_asset FOREIGN KEY (asset_id)
	REFERENCES dbo.asset (asset_id);

ALTER TABLE dbo.audit
	ADD CONSTRAINT fk_audit_stig FOREIGN KEY (stig_id)
	REFERENCES dbo.stig (stig_id);

ALTER TABLE dbo.audit
	ADD CONSTRAINT fk_audit_user FOREIGN KEY (assigned_user_id)
	REFERENCES dbo.[user] ([user_id]);

ALTER TABLE dbo.version
    ADD CONSTRAINT fk_version_stig FOREIGN KEY (stig_id)
	REFERENCES dbo.stig (stig_id);

ALTER TABLE dbo.[RULE]
    ADD CONSTRAINT fk_rule_version FOREIGN KEY (version_id)
	REFERENCES dbo.version (version_id);

ALTER TABLE dbo.implementation_rule
    ADD CONSTRAINT fk_implementation_rule_rule FOREIGN KEY (rule_id)
	REFERENCES dbo.[rule] (rule_id);

ALTER TABLE dbo.implementation_rule
    ADD CONSTRAINT fk_implementation_rule_implementation FOREIGN KEY (implementation_id)
	REFERENCES dbo.implementation (implementation_id);

ALTER TABLE dbo.implementation_rule
    ADD CONSTRAINT fk_implementation_rule_evidence_set FOREIGN KEY (evidence_set_id)
	REFERENCES dbo.evidence_set (evidence_set_id);

ALTER TABLE dbo.audit_rule
    ADD CONSTRAINT fk_audit_rule_rule FOREIGN KEY (rule_id)
	REFERENCES dbo.[rule] (rule_id);

ALTER TABLE dbo.audit_rule
    ADD CONSTRAINT fk_audit_rule_audit FOREIGN KEY (audit_id)
	REFERENCES dbo.implementation (implementation_id);

ALTER TABLE dbo.audit_rule
    ADD CONSTRAINT fk_audit_rule_evidence_set FOREIGN KEY (evidence_set_id)
	REFERENCES dbo.evidence_set (evidence_set_id);

ALTER TABLE dbo.evidence
    ADD CONSTRAINT fk_evidence_evidence_set FOREIGN KEY (evidence_set_id)
	REFERENCES dbo.evidence_set (evidence_set_id);




