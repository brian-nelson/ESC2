
--Shared Dimensions
CREATE TABLE dbo.[asset_group] (
    [asset_group_id] uniqueidentifier NOT NULL,
	[name] varchar(255) NOT NULL,
	PRIMARY KEY ([asset_group_id]));

CREATE TABLE dbo.[asset_type] (
    [asset_type_id] uniqueidentifier NOT NULL,
	[asset_group_id] uniqueidentifier NOT NULL,
	[implementation_guide_id] uniqueidentifier NOT NULL,
	[name] varchar(255) NOT NULL,
	PRIMARY KEY ([asset_type_id]));

CREATE TABLE dbo.[asset] (
    [asset_id] uniqueidentifier NOT NULL,
	[asset_type_id] uniqueidentifier NOT NULL,
	[name] varchar(255) NOT NULL,
	PRIMARY KEY ([asset_id]));

CREATE TABLE dbo.[asset_history] (
    [asset_history_id] uniqueidentifier NOT NULL,
	[asset_id] uniqueidentifier NOT NULL,
	[period_id] bigint NOT NULL,
	[action] varchar(255) NOT NULL,
	PRIMARY KEY ([asset_history_id]));

CREATE TABLE dbo.[employee] (
    [employee_id] uniqueidentifier NOT NULL,
	[role_id] uniqueidentifier NOT NULL,
	[given_name] varchar(50) NOT NULL,
	[family_name] varchar(50) NOT NULL,
	PRIMARY KEY ([employee_id]));

CREATE TABLE dbo.[implementation_guide] (
    implementation_guide_id uniqueidentifier NOT NULL,
	[name] varchar(255) NOT NULL,
	number varchar(255) NOT NULL,
	version varchar(255) NOT NULL,
    number_of_rules int NOT NULL,
	PRIMARY KEY (implementation_guide_id));

CREATE TABLE dbo.[period] (
    period_id bigint NOT NULL,
	[year] int NOT NULL,
	[month] int NOT NULL,
	[day] int NOT NULL,
	[day_of_week] tinyint NOT NULL,
	PRIMARY KEY (period_id));

CREATE TABLE dbo.[role] (
    [role_id] uniqueidentifier NOT NULL,
	[name] varchar(50) NOT NULL,
	PRIMARY KEY ([role_id]));

CREATE TABLE dbo.[rule] (
    [rule_id] uniqueidentifier NOT NULL,
	[number] varchar(30) NOT NULL,
	[severity] char(1) NOT NULL,
	[version] varchar(50),
	[title] varchar(max),
	[discussion] varchar(max),
	[fix] varchar(max),
	[check] varchar(max),
	[cci] varchar(20),
	[implementation_guide_id] uniqueidentifier NOT NULL,
	PRIMARY KEY ([rule_id]));


--ODS for Audit Events
CREATE TABLE dbo.[audit] (
    [audit_id] uniqueidentifier NOT NULL,
	[start_date] datetime,
	[end_date] datetime,
	[status] varchar(5),
	[summary] varchar(max),
	[employee_id] uniqueidentifier,
	[implementation_id] uniqueidentifier,
	PRIMARY KEY ([audit_id]));

CREATE TABLE dbo.[audit_detail] (
    [audit_detail_id] uniqueidentifier NOT NULL,
	[audit_id] uniqueidentifier NOT NULL,
	[rule_id] uniqueidentifier,
	[status] varchar(5),
	[comment] varchar(max),
	PRIMARY KEY ([audit_detail_id]));

--ODS for Implementation
CREATE TABLE dbo.[implementation] (
    [implementation_id] uniqueidentifier NOT NULL,
	[start_date] datetime,
	[end_date] datetime,
	[status] varchar(5),
	[summary] varchar(max),
	[employee_id] uniqueidentifier,
	[asset_id] uniqueidentifier NOT NULL,
	PRIMARY KEY ([implementation_id]));

CREATE TABLE dbo.[implementation_detail] (
	implementation_detail_id uniqueidentifier NOT NULL,
	implementation_id uniqueidentifier NOT NULL,
	rule_id uniqueidentifier NOT NULL,
	status varchar(5),
	finding_details varchar(max),
	comments varchar(max),
	severity_override char(1),
	severity_justification varchar(max),
	PRIMARY KEY (implementation_detail_id));

--ODS for System Events
CREATE TABLE dbo.[system_event] (
    [system_event_id] bigint NOT NULL,
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

CREATE TABLE dbo.[system_event_property] (
    [system_event_property_id] bigint NOT NULL,
	[system_event_id] bigint NULL,
	[parameter_name] varchar(255) NULL,
	[parameter_value] varchar(max) NULL,
    PRIMARY KEY ([system_event_property_id]));


--System Event Data Mart
CREATE TABLE dbo.[system_event_fact] (
	[system_event_fact_id] uniqueidentifier NOT NULL,
	[asset_id] uniqueidentifier NOT NULL,
	[period_id] bigint NOT NULL,
	[system_event_severity_id] uniqueidentifier NOT NULL,
	[system_event_facility_id] uniqueidentifier NOT NULL,
	[count] bigint NOT NULL,
	PRIMARY KEY ([system_event_fact_id]));

CREATE TABLE dbo.[system_event_facility] (
    [system_event_facility_id] uniqueidentifier NOT NULL,
	[name] varchar(50) NOT NULL,
    PRIMARY KEY ([system_event_facility_id]));

CREATE TABLE dbo.[system_event_severity] (
    [system_event_severity_id] uniqueidentifier NOT NULL,
	[name] varchar(50) NOT NULL,
    PRIMARY KEY ([system_event_severity_id]));

--Implementation Fact Data Mart
CREATE TABLE dbo.[implementation_fact] (
    [implementation_fact_id] uniqueidentifier NOT NULL,
	[implementation_id] uniqueidentifier NOT NULL,
	[asset_id] uniqueidentifier NOT NULL,
	[implementation_guide_id] uniqueidentifier NOT NULL,
	[employee_id] uniqueidentifier NOT NULL,
	[started_on_period_id] bigint NOT NULL,
	[completed_on_period_id] bigint NOT NULL,
	[hours_to_complete] float(53) NOT NULL,
	PRIMARY KEY (implementation_fact_id));

--Audit Fact Data Mart
CREATE TABLE dbo.[audit_fact] (
	[audit_fact_id] uniqueidentifier NOT NULL,
	[audit_id] uniqueidentifier NOT NULL,
	[asset_id] uniqueidentifier NOT NULL,
	[implementation_guide_id] uniqueidentifier NOT NULL,
	[employee_id] uniqueidentifier NOT NULL,
	[started_on_period_id] bigint NOT NULL,
	[completed_on_period_id] bigint NOT NULL,
	[hours_to_complete] float(53) NOT NULL,
	PRIMARY KEY ([audit_fact_id]));

--Resource Cost Fact
CREATE TABLE dbo.[resource_cost_fact] (
	resource_cost_fact_id uniqueidentifier NOT NULL,
	role_id uniqueidentifier NOT NULL,
	start_period_id bigint NOT NULL,
	end_period_id bigint NOT NULL,
	cost_per_hour float(53) NOT NULL,
	PRIMARY KEY (resource_cost_fact_id));


-- Add Foreign Keys
ALTER TABLE dbo.[asset_type]
	ADD CONSTRAINT fk_asset_type_asset_group FOREIGN KEY ([asset_group_id])
	REFERENCES dbo.[asset_group] ([asset_group_id]);

ALTER TABLE dbo.[asset_type]
	ADD CONSTRAINT fk_asset_type_ig FOREIGN KEY ([implementation_guide_id])
	REFERENCES dbo.[implementation_guide] ([implementation_guide_id]);

ALTER TABLE dbo.[asset]
	ADD CONSTRAINT fk_asset_asset_type FOREIGN KEY ([asset_type_id])
	REFERENCES dbo.[asset_type] ([asset_type_id]);

ALTER TABLE dbo.[asset_history]
	ADD CONSTRAINT fk_asset_history_asset FOREIGN KEY ([asset_id])
	REFERENCES dbo.[asset] ([asset_id]);

ALTER TABLE dbo.[asset_history]
	ADD CONSTRAINT fk_asset_history_period FOREIGN KEY ([period_id])
	REFERENCES dbo.[period] ([period_id]);

ALTER TABLE dbo.[system_event_fact]
    ADD CONSTRAINT fk_sef_asset FOREIGN KEY ([asset_id])
	REFERENCES dbo.[asset] ([asset_id]);

ALTER TABLE dbo.[system_event_fact]
    ADD CONSTRAINT fk_sef_period FOREIGN KEY ([period_id])
	REFERENCES dbo.[period] ([period_id]);

ALTER TABLE dbo.[system_event_fact]
    ADD CONSTRAINT fk_sef_ses FOREIGN KEY ([system_event_severity_id])
	REFERENCES dbo.[system_event_severity] ([system_event_severity_id]);

ALTER TABLE dbo.[system_event_fact]
    ADD CONSTRAINT fk_sef_sefacility FOREIGN KEY ([system_event_facility_id])
	REFERENCES dbo.[system_event_facility] ([system_event_facility_id]);

ALTER TABLE dbo.[audit_fact]
    ADD CONSTRAINT fk_audit_fact_asset FOREIGN KEY ([asset_id])
	REFERENCES dbo.[asset] ([asset_id]);

ALTER TABLE dbo.[audit_fact]
    ADD CONSTRAINT fk_audit_fact_audit FOREIGN KEY ([audit_id])
	REFERENCES dbo.[audit] ([audit_id]);

ALTER TABLE dbo.[audit_fact]
    ADD CONSTRAINT fk_audit_fact_period_start FOREIGN KEY ([started_on_period_id])
	REFERENCES dbo.[period] ([period_id]);

ALTER TABLE dbo.[audit_fact]
    ADD CONSTRAINT fk_audit_fact_period_end FOREIGN KEY ([completed_on_period_id])
	REFERENCES dbo.[period] ([period_id]);

ALTER TABLE dbo.[audit_fact]
    ADD CONSTRAINT fk_audit_fact_employee FOREIGN KEY ([employee_id])
	REFERENCES dbo.[employee] ([employee_id]);

ALTER TABLE dbo.[audit_fact]
    ADD CONSTRAINT fk_audit_fact_ig FOREIGN KEY ([implementation_guide_id])
	REFERENCES dbo.[implementation_guide] ([implementation_guide_id]);

ALTER TABLE dbo.[audit]
	ADD CONSTRAINT fk_audit_employee FOREIGN KEY ([employee_id])
	REFERENCES dbo.[employee] ([employee_id]);

ALTER TABLE dbo.[audit]
	ADD CONSTRAINT fk_audit_implementation FOREIGN KEY ([implementation_id])
	REFERENCES dbo.[implementation] ([implementation_id]);

ALTER TABLE dbo.[audit_detail]
	ADD CONSTRAINT fk_audit_detail_audit FOREIGN KEY ([audit_id])
	REFERENCES dbo.[audit] ([audit_id]);

ALTER TABLE dbo.[audit_detail]
	ADD CONSTRAINT fk_audit_detail_rule FOREIGN KEY ([rule_id])
	REFERENCES dbo.[rule] ([rule_id]);

ALTER TABLE dbo.[employee]
	ADD CONSTRAINT fk_employee_role FOREIGN KEY ([role_id])
	REFERENCES dbo.[role] ([role_id]);

ALTER TABLE dbo.[resource_cost_fact]
    ADD CONSTRAINT fk_rcf_role FOREIGN KEY ([role_id])
	REFERENCES dbo.[role] ([role_id]);

ALTER TABLE dbo.[resource_cost_fact]
    ADD CONSTRAINT fk_rcf_period_start FOREIGN KEY ([start_period_id])
	REFERENCES dbo.[period] ([period_id]);

ALTER TABLE dbo.[resource_cost_fact]
    ADD CONSTRAINT fk_rcf_period_end FOREIGN KEY ([end_period_id])
	REFERENCES dbo.[period] ([period_id]);

ALTER TABLE dbo.[rule]
    ADD CONSTRAINT fk_rule_ig FOREIGN KEY ([implementation_guide_id])
	REFERENCES dbo.[implementation_guide] ([implementation_guide_id]);

ALTER TABLE dbo.[implementation_detail]
    ADD CONSTRAINT fk_id_implementation FOREIGN KEY ([implementation_id])
	REFERENCES dbo.[implementation] ([implementation_id]);

ALTER TABLE dbo.[implementation_detail]
    ADD CONSTRAINT fk_id_rule FOREIGN KEY ([rule_id])
	REFERENCES dbo.[rule] ([rule_id]);

ALTER TABLE dbo.[implementation]
    ADD CONSTRAINT fk_implementation_employee FOREIGN KEY ([employee_id])
	REFERENCES dbo.[employee] ([employee_id]);

ALTER TABLE dbo.[implementation]
    ADD CONSTRAINT fk_implementation_asset FOREIGN KEY ([asset_id])
	REFERENCES dbo.[asset] ([asset_id]);

ALTER TABLE dbo.[implementation_fact]
    ADD CONSTRAINT fk_implementation_fact_asset FOREIGN KEY ([asset_id])
	REFERENCES dbo.[asset] ([asset_id]);

ALTER TABLE dbo.[implementation_fact]
    ADD CONSTRAINT fk_implementation_fact_implementation FOREIGN KEY ([implementation_id])
	REFERENCES dbo.[implementation] ([implementation_id]);

ALTER TABLE dbo.[implementation_fact]
    ADD CONSTRAINT fk_implementation_fact_ig FOREIGN KEY ([implementation_guide_id])
	REFERENCES dbo.[implementation_guide] ([implementation_guide_id]);

ALTER TABLE dbo.[implementation_fact]
    ADD CONSTRAINT fk_implementation_fact_employee FOREIGN KEY ([employee_id])
	REFERENCES dbo.[employee] ([employee_id]);

ALTER TABLE dbo.[implementation_fact]
    ADD CONSTRAINT fk_implementation_period_start FOREIGN KEY ([started_on_period_id])
	REFERENCES dbo.[period] ([period_id]);

ALTER TABLE dbo.[implementation_fact]
    ADD CONSTRAINT fk_implementation_period_complete FOREIGN KEY ([completed_on_period_id])
	REFERENCES dbo.[period] ([period_id]);

ALTER TABLE dbo.[system_event_property]
    ADD CONSTRAINT fk_sep_se FOREIGN KEY ([system_event_id])
	REFERENCES dbo.[system_event] ([system_event_id]);
