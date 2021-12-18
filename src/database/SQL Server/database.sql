--Step 2 - Create Database Tables
CREATE TABLE [operational].[adjustment] (
    [adjustment_id] uniqueidentifier NOT NULL,
	[type] varchar(50) NOT NULL,
	[details] varchar(max) NOT NULL,
	[adjustment_set_id] uniqueidentifier NOT NULL,
	[created_by_id] uniqueidentifier NOT NULL,
	[created_on] datetime NOT NULL,
	[last_modified_by_id] uniqueidentifier NOT NULL,
	[last_modified_on] datetime NOT NULL,
	PRIMARY KEY ([adjustment_id]));

CREATE TABLE [operational].[adjustment_set] (
    [adjustment_set_id] uniqueidentifier NOT NULL,
	[rule_id] uniqueidentifier NOT NULL,
	[created_by_id] uniqueidentifier NOT NULL,
	[created_on] datetime NOT NULL,
	PRIMARY KEY ([adjustment_set_id]));
	
CREATE TABLE [operational].[asset] (
	[asset_id] uniqueidentifier NOT NULL,
	[name] varchar(255) NOT NULL,
	[description] varchar(255),
	[status] varchar(5),
	[host_name] varchar(255),
	[contact_employee_id] uniqueidentifier,
	[owning_department_id] uniqueidentifier,
	[parent_asset_id] uniqueidentifier,
	[asset_type_id] uniqueidentifier NOT NULL,
	[created_by_id] uniqueidentifier NOT NULL,
	[created_on] datetime NOT NULL,
	[last_modified_by_id] uniqueidentifier NOT NULL,
	[last_modified_on] datetime NOT NULL,
	PRIMARY KEY ([asset_id]));

CREATE TABLE [operational].[asset_group] (
    [asset_group_id] uniqueidentifier NOT NULL,
	[name] varchar(255) NOT NULL,
	[created_by_id] uniqueidentifier NOT NULL,
	[created_on] datetime NOT NULL,
	[last_modified_by_id] uniqueidentifier NOT NULL,
	[last_modified_on] datetime NOT NULL,
	PRIMARY KEY ([asset_group_id]));

CREATE TABLE [operational].[asset_history] (
    [asset_history_id] uniqueidentifier NOT NULL,
	[action_date] datetime NOT NULL,
	[action] varchar(50) NOT NULL,
	[user_id] uniqueidentifier NOT NULL,
	[asset_id] uniqueidentifier NOT NULL,
	PRIMARY KEY ([asset_history_id]));

CREATE TABLE [operational].[asset_type] (
    [asset_type_id] uniqueidentifier NOT NULL,
	[name] varchar(255) NOT NULL,
	[description] varchar(255),
	[manufacturer] varchar(255),
	[model] varchar(255),
	[version] varchar(50),
	[implementation_guide_id] uniqueidentifier,
	[asset_group_id] uniqueidentifier NOT NULL,
	[created_by_id] uniqueidentifier NOT NULL,
	[created_on] datetime NOT NULL,
	[last_modified_by_id] uniqueidentifier NOT NULL,
	[last_modified_on] datetime NOT NULL,
	PRIMARY KEY ([asset_type_id]));

CREATE TABLE [operational].[audit] (
    [audit_id] uniqueidentifier NOT NULL,
	[start_date] datetime,
	[end_date] datetime,
	[status] VARCHAR(5) NOT NULL,
	[summary] VARCHAR(max),
	[assigned_user_id] uniqueidentifier,
	[implementation_id] uniqueidentifier NOT NULL,
	[created_by_id] uniqueidentifier NOT NULL,
	[created_on] datetime NOT NULL,
	[last_modified_by_id] uniqueidentifier NOT NULL,
	[last_modified_on] datetime NOT NULL,
	PRIMARY KEY ([audit_id]));

CREATE TABLE [operational].[audit_rule] (
    [audit_rule_id] uniqueidentifier NOT NULL,
	[comment] VARCHAR(max),
	[status] VARCHAR(5) NOT NULL,
	[rule_id] uniqueidentifier NOT NULL,
	[evidence_set_id] uniqueidentifier,
	[audit_id] uniqueidentifier NOT NULL,
	[created_by_id] uniqueidentifier NOT NULL,
	[created_on] datetime NOT NULL,
	[last_modified_by_id] uniqueidentifier NOT NULL,
	[last_modified_on] datetime NOT NULL,
	PRIMARY KEY ([audit_rule_id]));

CREATE TABLE [operational].[department] (
	[department_id] uniqueidentifier NOT NULL,
	[name] varchar(255) NOT NULL,
	[created_by_id] uniqueidentifier NOT NULL,
	[created_on] datetime NOT NULL,
	[last_modified_by_id] uniqueidentifier NOT NULL,
	[last_modified_on] datetime NOT NULL,
	PRIMARY KEY ([department_id]));

CREATE TABLE [operational].[employee] (
	[employee_id] uniqueidentifier NOT NULL,
	[given_name] varchar(50) NOT NULL,
	[family_name] varchar(50) NOT NULL,
	[email] varchar(255) NOT NULL,
	[job_title] varchar(50),
	[start_date] datetime NOT NULL,
	[end_date] datetime,
	[department_id] uniqueidentifier NOT NULL,
	[created_by_id] uniqueidentifier NOT NULL,
	[created_on] datetime NOT NULL,
	[last_modified_by_id] uniqueidentifier NOT NULL,
	[last_modified_on] datetime NOT NULL,
	PRIMARY KEY ([employee_id]));

CREATE TABLE [operational].[evidence_set] (
    [evidence_set_id] uniqueidentifier NOT NULL,
	[type] CHAR(1) NOT NULL,
	[created_by_id] uniqueidentifier NOT NULL,
	[created_on] datetime NOT NULL,
	PRIMARY KEY ([evidence_set_id]));

CREATE TABLE [operational].[evidence] (
	[evidence_id] uniqueidentifier NOT NULL,
	[data_location] varchar(500) NOT NULL,
	[mime_type] varchar(50) NOT NULL,
	[evidence_set_id] uniqueidentifier NOT NULL,
	[created_by_id] uniqueidentifier NOT NULL,
	[created_on] datetime NOT NULL,
	PRIMARY KEY ([evidence_id]));

CREATE TABLE [operational].[implementation] (
    [implementation_id] uniqueidentifier NOT NULL,
	[start_date] datetime,
	[end_date] datetime,
	[status] varchar(5) NOT NULL,
	[summary] VARCHAR(max),
	[assigned_user_id] uniqueidentifier,
	[asset_id] uniqueidentifier NOT NULL,
	[implementation_guide_id] uniqueidentifier NOT NULL,
	[created_by_id] uniqueidentifier NOT NULL,
	[created_on] datetime NOT NULL,
	[last_modified_by_id] uniqueidentifier NOT NULL,
	[last_modified_on] datetime NOT NULL,
	PRIMARY KEY ([implementation_id]));

CREATE TABLE [operational].[implementation_guide] (
    [implementation_guide_id] uniqueidentifier NOT NULL,
	[number] VARCHAR(100) NOT NULL,
	[type] VARCHAR(50) NOT NULL,
	[created_by_id] uniqueidentifier NOT NULL,
	[created_on] datetime NOT NULL,
	[last_modified_by_id] uniqueidentifier NOT NULL,
	[last_modified_on] datetime NOT NULL,
	PRIMARY KEY ([implementation_guide_id]));

CREATE TABLE [operational].[implementation_rule] (
	[implementation_rule_id] uniqueidentifier NOT NULL,
	[status] VARCHAR(5) NOT NULL,
	[finding_details] VARCHAR(max),
	[comments] VARCHAR(max),
	[severity_override] CHAR(1),
	[severity_justification] VARCHAR(max),
	[adjustment_set_id] uniqueidentifier,
	[rule_id] uniqueidentifier NOT NULL,
	[evidence_set_id] uniqueidentifier,
	[implementation_id] uniqueidentifier NOT NULL,
	[created_by_id] uniqueidentifier NOT NULL,
	[created_on] datetime NOT NULL,
	[last_modified_by_id] uniqueidentifier NOT NULL,
	[last_modified_on] datetime NOT NULL,
	PRIMARY KEY ([implementation_rule_id]));

CREATE TABLE [operational].[rule] (
    [rule_id] uniqueidentifier NOT NULL,
	[number] VARCHAR(30) NOT NULL,
	[severity] CHAR(1) NOT NULL,
	[version] VARCHAR(50) NOT NULL,
	[title] VARCHAR(max) NOT NULL,
	[discussion] varchar(max),
	[fix] VARCHAR(max) NOT NULL,
	[check] VARCHAR(max) NOT NULL,
	[cci] VARCHAR(20),
	[version_id] uniqueidentifier NOT NULL,
	[created_by_id] uniqueidentifier NOT NULL,
	[created_on] datetime NOT NULL,
	[last_modified_by_id] uniqueidentifier NOT NULL,
	[last_modified_on] datetime NOT NULL,
	PRIMARY KEY ([rule_id]));

CREATE TABLE [operational].[user] (
    [user_id] uniqueidentifier NOT NULL,
	[user_role_id] uniqueidentifier NOT NULL,
	[is_enabled] bit NOT NULL,
	[password_hash] varchar(50) NOT NULL,
	[password_salt] varchar(50) NOT NULL,
	[employee_id] uniqueidentifier NOT NULL,
	[created_by_id] uniqueidentifier NOT NULL,
	[created_on] datetime NOT NULL,
	[last_modified_by_id] uniqueidentifier NOT NULL,
	[last_modified_on] datetime NOT NULL,
	PRIMARY KEY ([user_id]));

CREATE TABLE [operational].[user_role] (
    [user_role_id] uniqueidentifier NOT NULL,
	[name] varchar(50) NOT NULL,
	[created_by_id] uniqueidentifier NOT NULL,
	[created_on] datetime NOT NULL,
	[last_modified_by_id] uniqueidentifier NOT NULL,
	[last_modified_on] datetime NOT NULL,
	PRIMARY KEY ([user_role_id]));

CREATE TABLE [operational].[version] (
    [version_id] uniqueidentifier NOT NULL,
	[number] VARCHAR(5) NOT NULL,
	[status] VARCHAR(5) NOT NULL,
	[status_date] DATETIME NOT NULL,
	[title] VARCHAR(max) NOT NULL,
	[description] VARCHAR(max) NOT NULL,
	[publisher] VARCHAR(100) NOT NULL,
	[source] VARCHAR(100) NOT NULL,
	[filename] VARCHAR(255) NOT NULL,
	[implementation_guide_id] uniqueidentifier NOT NULL,
	[created_by_id] uniqueidentifier NOT NULL,
	[created_on] datetime NOT NULL,
	[last_modified_by_id] uniqueidentifier NOT NULL,
	[last_modified_on] datetime NOT NULL,
	PRIMARY KEY ([version_id]));

-- Add alternate key constraints
ALTER TABLE [operational].[audit_rule]
	ADD CONSTRAINT ak_audit_rule_id_rule UNIQUE ([audit_id], [rule_id]);

ALTER TABLE [operational].[adjustment_set]
	ADD CONSTRAINT ak_adjustment_set_id UNIQUE ([rule_id]);

ALTER TABLE [operational].[adjustment]
    ADD CONSTRAINT ak_adjustment_asid_type UNIQUE ([adjustment_set_id], [type]);

ALTER TABLE [operational].[asset_group]
	ADD CONSTRAINT ak_asset_group_name UNIQUE ([name]);

ALTER TABLE [operational].[asset_type]
	ADD CONSTRAINT ak_asset_type UNIQUE ([name]);

ALTER TABLE [operational].[department]
	ADD CONSTRAINT ak_department UNIQUE ([name]);

ALTER TABLE [operational].[evidence]
	ADD CONSTRAINT ak_evidence_set_location UNIQUE ([evidence_set_id], [data_location]);

ALTER TABLE [operational].[implementation_rule]
    ADD CONSTRAINT ak_implementation_rule_id_rule UNIQUE ([implementation_id], [rule_id]);

ALTER TABLE [operational].[rule]
    ADD CONSTRAINT ak_rule_version_rulenum UNIQUE ([version_id], [number]);

ALTER TABLE [operational].[implementation_guide]
    ADD CONSTRAINT ak_ig_number UNIQUE ([number]);

ALTER TABLE [operational].[user]
    ADD CONSTRAINT ak_user_employee_id UNIQUE ([employee_id]);

ALTER TABLE [operational].[version]
    ADD CONSTRAINT ak_version_ig_number UNIQUE ([implementation_guide_id], [number]);

-- Add check constraints
-- Pending, Active, Retired
ALTER TABLE [operational].[asset]
	ADD CONSTRAINT chk_asset_status CHECK ([status] IN ('P', 'A', 'R'));

-- Open, In Progress, Complete
ALTER TABLE [operational].[implementation]
	ADD CONSTRAINT chk_implementation_status CHECK ([status] IN ('O', 'I', 'C'));

-- Open, In Progress, Complete, Failed
ALTER TABLE [operational].[audit]
	ADD CONSTRAINT chk_audit_status CHECK ([status] IN ('O', 'I', 'C', 'F'));

ALTER TABLE [operational].[audit_rule]
    ADD CONSTRAINT chk_audit_rule_status CHECK ([status] IN ('O', 'P', 'F'));

-- Not a Finding, Open, Not Applicable, Not Reviewed
ALTER TABLE [operational].[implementation_rule]
    ADD CONSTRAINT chk_implementation_rule_status CHECK ([status] IN ('NF', 'O', 'NA', 'NR'));

-- Accepted, Deprecated, Draft, Incomplete, Interim
ALTER TABLE [operational].[version]
    ADD CONSTRAINT chk_version_status CHECK ([status] IN ('A', 'DP', 'DR', 'IC', 'IN', 'UN'));

-- Low, Medium, High
ALTER TABLE [operational].[RULE]
    ADD CONSTRAINT chk_rule_severity CHECK ([severity] IN ('L', 'M', 'H'));

-- Add Default
ALTER TABLE [operational].[implementation_rule]
    ADD CONSTRAINT df_implementation_rule_status
    DEFAULT 'NF' FOR [status];

-- Add Foreign Keys
ALTER TABLE [operational].[asset_type]
	ADD CONSTRAINT fk_asset_type_asset_group FOREIGN KEY ([asset_group_id])
	REFERENCES [operational].[asset_group] ([asset_group_id]);

ALTER TABLE [operational].[asset_type]
	ADD CONSTRAINT fk_asset_type_ig FOREIGN KEY ([implementation_guide_id])
	REFERENCES [operational].[implementation_guide] ([implementation_guide_id]);

ALTER TABLE [operational].[asset]
	ADD CONSTRAINT fk_asset_asset_type FOREIGN KEY ([asset_type_id])
	REFERENCES [operational].[asset_type] (asset_type_id);

ALTER TABLE [operational].[asset]
	ADD CONSTRAINT fk_asset_employee FOREIGN KEY ([contact_employee_id])
	REFERENCES [operational].[employee] ([employee_id]);

ALTER TABLE [operational].[asset]
	ADD CONSTRAINT fk_asset_department FOREIGN KEY ([owning_department_id])
	REFERENCES [operational].[department] ([department_id]);

ALTER TABLE [operational].[asset]
	ADD CONSTRAINT fk_asset_asset FOREIGN KEY ([parent_asset_id])
	REFERENCES [operational].[asset] ([asset_id]);

ALTER TABLE [operational].[asset_history]
    ADD CONSTRAINT fk_asset_history_asset FOREIGN KEY ([asset_id])
	REFERENCES [operational].[asset] ([asset_id]);

ALTER TABLE [operational].[asset_history]
    ADD CONSTRAINT fk_asset_history_user FOREIGN KEY ([user_id])
	REFERENCES [operational].[user] ([user_id]);

ALTER TABLE [operational].[employee]
	ADD CONSTRAINT fk_employee_department FOREIGN KEY ([department_id])
	REFERENCES [operational].[department] ([department_id]);

ALTER TABLE [operational].[user]
	ADD CONSTRAINT fk_user_employee FOREIGN KEY ([employee_id])
	REFERENCES [operational].[employee] ([employee_id]);

ALTER TABLE [operational].[user]
    ADD CONSTRAINT fk_user_user_role FOREIGN KEY ([user_role_id])
	REFERENCES [operational].[user_role] ([user_role_id]);

ALTER TABLE [operational].[implementation]
	ADD CONSTRAINT fk_implementation_asset FOREIGN KEY ([asset_id])
	REFERENCES [operational].[asset] ([asset_id]);

ALTER TABLE [operational].[implementation]
	ADD CONSTRAINT fk_implementation_ig FOREIGN KEY ([implementation_guide_id])
	REFERENCES [operational].[implementation_guide] ([implementation_guide_id]);

ALTER TABLE [operational].[implementation]
	ADD CONSTRAINT fk_implementation_user FOREIGN KEY ([assigned_user_id])
	REFERENCES [operational].[user] ([user_id]);

ALTER TABLE [operational].[audit]
	ADD CONSTRAINT fk_audit_implementation FOREIGN KEY ([implementation_id])
	REFERENCES [operational].[implementation] ([implementation_id]);

ALTER TABLE [operational].[audit]
	ADD CONSTRAINT fk_audit_user FOREIGN KEY ([assigned_user_id])
	REFERENCES [operational].[user] ([user_id]);

ALTER TABLE [operational].[version]
    ADD CONSTRAINT fk_version_ig FOREIGN KEY ([implementation_guide_id])
	REFERENCES [operational].[implementation_guide] ([implementation_guide_id]);

ALTER TABLE [operational].[rule]
    ADD CONSTRAINT fk_rule_version FOREIGN KEY ([version_id])
	REFERENCES [operational].[version] ([version_id]);

ALTER TABLE [operational].[implementation_rule]
    ADD CONSTRAINT fk_implementation_rule_rule FOREIGN KEY ([rule_id])
	REFERENCES [operational].[rule] ([rule_id]);

ALTER TABLE [operational].[implementation_rule]
    ADD CONSTRAINT fk_implementation_rule_implementation FOREIGN KEY ([implementation_id])
	REFERENCES [operational].[implementation] ([implementation_id]);

ALTER TABLE [operational].[implementation_rule]
    ADD CONSTRAINT fk_implementation_rule_evidence_set FOREIGN KEY ([evidence_set_id])
	REFERENCES [operational].[evidence_set] ([evidence_set_id]);

ALTER TABLE [operational].[implementation_rule]
    ADD CONSTRAINT fk_implementation_rule_adjustment_set FOREIGN KEY ([adjustment_set_id])
	REFERENCES [operational].[adjustment_set] ([adjustment_set_id]);

ALTER TABLE [operational].[audit_rule]
    ADD CONSTRAINT fk_audit_rule_rule FOREIGN KEY ([rule_id])
	REFERENCES [operational].[rule] ([rule_id]);

ALTER TABLE [operational].[audit_rule]
    ADD CONSTRAINT fk_audit_rule_audit FOREIGN KEY ([audit_id])
	REFERENCES [operational].[audit] ([audit_id]);

ALTER TABLE [operational].[audit_rule]
    ADD CONSTRAINT fk_audit_rule_evidence_set FOREIGN KEY ([evidence_set_id])
	REFERENCES [operational].[evidence_set] ([evidence_set_id]);

ALTER TABLE [operational].[evidence]
    ADD CONSTRAINT fk_evidence_evidence_set FOREIGN KEY ([evidence_set_id])
	REFERENCES [operational].[evidence_set] ([evidence_set_id]);

ALTER TABLE [operational].[adjustment_set]
    ADD CONSTRAINT fk_adjustment_set_rule FOREIGN KEY ([rule_id])
	REFERENCES [operational].[rule] ([rule_id]);

ALTER TABLE [operational].[adjustment]
    ADD CONSTRAINT fk_adjustment_adjustment_set FOREIGN KEY ([adjustment_set_id])
	REFERENCES [operational].[adjustment_set] ([adjustment_set_id]);


--Logging
CREATE TABLE [logging].[system_event] (
    [system_event_id] bigint NOT NULL identity,
	[customer_id] bigint,
	[received_at] datetime,
	[device_reported_time] datetime,
	[facility] smallint,
	[priority] smallint,
	[from_host] varchar(60),
	[message] varchar(max),
	[nt_severity] int,
	[importance] int,
	[event_source] varchar(60),
	[event_user] varchar(60),
	[event_category] int,
	[event_id] int,
	[event_binary_data] varchar(max),
	[maximum_available] int,
	[current_usage] int,
	[minimum_usage] int,
	[maximum_usage] int,
	[info_unit_id] int,
	[sys_log_tag] varchar(60),
	[event_log_type] varchar(60),
	[generic_file_name] varchar(60),
	[system_id] int,
    PRIMARY KEY ([system_event_id]));

CREATE TABLE [logging].[system_event_property] (
    [system_event_property_id] bigint NOT NULL identity,
	[system_event_id] bigint NULL,
	[parameter_name] varchar(255) NULL,
	[parameter_value] varchar(max) NULL,
    PRIMARY KEY ([system_event_property_id]));

CREATE TABLE [logging].[system_event_history] (
    [system_event_history_id] bigint NOT NULL,
	[customer_id] bigint,
	[received_at] datetime,
	[device_reported_time] datetime,
	[facility] smallint,
	[priority] smallint,
	[from_host] varchar(60),
	[message] varchar(max),
	[nt_severity] int,
	[importance] int,
	[event_source] varchar(60),
	[event_user] varchar(60),
	[event_category] int,
	[event_id] int,
	[event_binary_data] varchar(max),
	[maximum_available] int,
	[current_usage] int,
	[minimum_usage] int,
	[maximum_usage] int,
	[info_unit_id] int,
	[sys_log_tag] varchar(60),
	[event_log_type] varchar(60),
	[generic_file_name] varchar(60),
	[system_id] int,
    PRIMARY KEY ([system_event_history_id]));

CREATE TABLE [logging].[system_event_property_history] (
    [system_event_property_history_id] bigint NOT NULL,
	[system_event_history_id] bigint NULL,
	[parameter_name] varchar(255) NULL,
	[parameter_value] varchar(max) NULL,
    PRIMARY KEY ([system_event_property_history_id]));

--NOTE THERE IS NO FK on the primary system_event/system_event_property for performance reasons
ALTER TABLE [logging].[system_event_property_history]
    ADD CONSTRAINT fk_seph_seh FOREIGN KEY ([system_event_history_id])
	REFERENCES [logging].[system_event_history] ([system_event_history_id]);


--Warehouse Tables
--Dimension Tables
CREATE TABLE [warehouse].[day_period] (
    [day_period_id] int NOT NULL,
	[year] int NOT NULL,
	[month] int NOT NULL,
	[day] int NOT NULL,
	[day_of_week] tinyint NOT NULL,
	PRIMARY KEY ([day_period_id]));

CREATE TABLE [warehouse].[log_source] (
    [log_source_id] smallint NOT NULL,
	[name] varchar(50) NOT NULL,
    PRIMARY KEY ([log_source_id]));

CREATE TABLE [warehouse].[log_severity] (
    [log_severity_id] tinyint NOT NULL,
	[name] varchar(50) NOT NULL,
    PRIMARY KEY ([log_severity_id]));

--System Event Data Mart
CREATE TABLE [warehouse].[log_daily_fact] (
	[log_daily_fact_id] bigint NOT NULL IDENTITY,
	[asset_id] uniqueidentifier NOT NULL,
	[day_period_id] int NOT NULL,
	[log_severity_id] tinyint NOT NULL,
	[log_source_id] smallint NOT NULL,
	[count] bigint NOT NULL,
	PRIMARY KEY ([log_daily_fact_id]));


--Implementation Fact Data Mart
CREATE TABLE [warehouse].[implementation_fact] (
    [implementation_fact_id] int NOT NULL IDENTITY,
	[implementation_id] uniqueidentifier NOT NULL,
	[asset_id] uniqueidentifier NOT NULL,
	[implementation_guide_id] uniqueidentifier NOT NULL,
	[employee_id] uniqueidentifier NOT NULL,
	[started_on_period_id] int NOT NULL,
	[completed_on_period_id] int NOT NULL,
	[hours_to_complete] float(53) NOT NULL,
	PRIMARY KEY (implementation_fact_id));

--Audit Fact Data Mart
CREATE TABLE [warehouse].[audit_fact] (
	[audit_fact_id] int NOT NULL IDENTITY,
	[audit_id] uniqueidentifier NOT NULL,
	[asset_id] uniqueidentifier NOT NULL,
	[implementation_guide_id] uniqueidentifier NOT NULL,
	[employee_id] uniqueidentifier NOT NULL,
	[started_on_period_id] int NOT NULL,
	[completed_on_period_id] int NOT NULL,
	[hours_to_complete] float(53) NOT NULL,
	PRIMARY KEY ([audit_fact_id]));

--Resource Cost Fact
CREATE TABLE [warehouse].[resource_cost_fact] (
	resource_cost_fact_id int NOT NULL IDENTITY,
	user_role_id uniqueidentifier NOT NULL,
	start_period_id int NOT NULL,
	end_period_id int NOT NULL,
	cost_per_hour float(53) NOT NULL,
	PRIMARY KEY (resource_cost_fact_id));

--Add RI for Log Daily Fact
ALTER TABLE [warehouse].[log_daily_fact]
    ADD CONSTRAINT fk_ldf_asset FOREIGN KEY ([asset_id])
	REFERENCES [operational].[asset] ([asset_id]);

ALTER TABLE [warehouse].[log_daily_fact]
    ADD CONSTRAINT fk_ldf_day_period FOREIGN KEY ([day_period_id])
	REFERENCES [warehouse].[day_period] ([day_period_id]);

ALTER TABLE [warehouse].[log_daily_fact]
    ADD CONSTRAINT fk_ldf_lseverity FOREIGN KEY ([log_severity_id])
	REFERENCES [warehouse].[log_severity] ([log_severity_id]);

ALTER TABLE [warehouse].[log_daily_fact]
    ADD CONSTRAINT fk_ldf_lsource FOREIGN KEY ([log_source_id])
	REFERENCES [warehouse].[log_source] ([log_source_id]);

--Add RI for Audit Fact
ALTER TABLE [warehouse].[audit_fact]
    ADD CONSTRAINT fk_audit_fact_asset FOREIGN KEY ([asset_id])
	REFERENCES [operational].[asset] ([asset_id]);

ALTER TABLE [warehouse].[audit_fact]
    ADD CONSTRAINT fk_audit_fact_audit FOREIGN KEY ([audit_id])
	REFERENCES [operational].[audit] ([audit_id]);

ALTER TABLE [warehouse].[audit_fact]
    ADD CONSTRAINT fk_audit_fact_period_start FOREIGN KEY ([started_on_period_id])
	REFERENCES [warehouse].[day_period] ([day_period_id]);

ALTER TABLE [warehouse].[audit_fact]
    ADD CONSTRAINT fk_audit_fact_period_end FOREIGN KEY ([completed_on_period_id])
	REFERENCES [warehouse].[day_period] ([day_period_id]);

ALTER TABLE [warehouse].[audit_fact]
    ADD CONSTRAINT fk_audit_fact_employee FOREIGN KEY ([employee_id])
	REFERENCES [operational].[employee] ([employee_id]);

ALTER TABLE [warehouse].[audit_fact]
    ADD CONSTRAINT fk_audit_fact_ig FOREIGN KEY ([implementation_guide_id])
	REFERENCES [operational].[implementation_guide] ([implementation_guide_id]);

--Add RI for Resource Cost Fact
ALTER TABLE [warehouse].[resource_cost_fact]
    ADD CONSTRAINT fk_rcf_user_role FOREIGN KEY ([user_role_id])
	REFERENCES [operational].[user_role] ([user_role_id]);

ALTER TABLE [warehouse].[resource_cost_fact]
    ADD CONSTRAINT fk_rcf_period_start FOREIGN KEY ([start_period_id])
	REFERENCES [warehouse].[day_period] ([day_period_id]);

ALTER TABLE [warehouse].[resource_cost_fact]
    ADD CONSTRAINT fk_rcf_period_end FOREIGN KEY ([end_period_id])
	REFERENCES [warehouse].[day_period] ([day_period_id]);

--Add RI for Implementation Fact
ALTER TABLE [warehouse].[implementation_fact]
    ADD CONSTRAINT fk_implementation_fact_asset FOREIGN KEY ([asset_id])
	REFERENCES [operational].[asset] ([asset_id]);

ALTER TABLE [warehouse].[implementation_fact]
    ADD CONSTRAINT fk_implementation_fact_implementation FOREIGN KEY ([implementation_id])
	REFERENCES [operational].[implementation] ([implementation_id]);

ALTER TABLE [warehouse].[implementation_fact]
    ADD CONSTRAINT fk_implementation_fact_ig FOREIGN KEY ([implementation_guide_id])
	REFERENCES [operational].[implementation_guide] ([implementation_guide_id]);

ALTER TABLE [warehouse].[implementation_fact]
    ADD CONSTRAINT fk_implementation_fact_employee FOREIGN KEY ([employee_id])
	REFERENCES [operational].[employee] ([employee_id]);

ALTER TABLE [warehouse].[implementation_fact]
    ADD CONSTRAINT fk_implementation_period_start FOREIGN KEY ([started_on_period_id])
	REFERENCES [warehouse].[day_period] ([day_period_id]);

ALTER TABLE [warehouse].[implementation_fact]
    ADD CONSTRAINT fk_implementation_period_complete FOREIGN KEY ([completed_on_period_id])
	REFERENCES [warehouse].[day_period] ([day_period_id]);