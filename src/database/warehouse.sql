
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

CREATE TABLE dbo.[audit] (
    [audit_id] uniqueidentifier NOT NULL,
	[start_period_id] bigint,
	[end_period_id] bigint,
	[status] varchar(5),
	[summary] varchar(max),
	[employee_id] uniqueidentifier,
	PRIMARY KEY ([audit_id]));

CREATE TABLE dbo.[audit_detail] (
    [audit_detail_id] uniqueidentifier NOT NULL,
	[audit_id] uniqueidentifier NOT NULL,
	[rule_id] uniqueidentifier,
	[status] varchar(5),
	[comment] varchar(max),
	PRIMARY KEY ([audit_detail_id]));

CREATE TABLE dbo.[audit_fact] (
	[audit_fact_id] uniqueidentifier NOT NULL,
	[audit_id] uniqueidentifier NOT NULL,
	[asset_id] uniqueidentifier NOT NULL,
	[stig_id] uniqueidentifier NOT NULL,
	[employee_id] uniqueidentifier NOT NULL,
	[started_on_period_id] bigint NOT NULL,
	[completed_on_period_id] bigint NOT NULL,
	[hours_to_complete] float(53) NOT NULL,
	PRIMARY KEY ([audit_fact_id]));

CREATE TABLE dbo.[employee] (
    [employee_id] uniqueidentifier NOT NULL,
	[role_id] uniqueidentifier NOT NULL,
	[given_name] varchar(50) NOT NULL,
	[family_name] varchar(50) NOT NULL,
	PRIMARY KEY ([employee_id]));

CREATE TABLE dbo.[implementation] (
    [implementation_id] uniqueidentifier NOT NULL,
	start_period_id bigint,
	end_period_id bigint,
	status varchar(5),
	summary varchar(max),
	employee_id uniqueidentifier,
	PRIMARY KEY (implementation_id));

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

CREATE TABLE dbo.[implementation_fact] (
    implementation_fact_id uniqueidentifier NOT NULL,
	implementation_id uniqueidentifier NOT NULL,
	asset_id uniqueidentifier NOT NULL,
	stig_id uniqueidentifier NOT NULL,
	employee_id uniqueidentifier NOT NULL,
	started_on_period_id bigint NOT NULL,
	completed_on_period_id bigint NOT NULL,
	hours_to_complete float(53) NOT NULL,
	PRIMARY KEY (implementation_fact_id));

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
	PRIMARY KEY (period_id));

CREATE TABLE dbo.[resources_cost_fact] (
	resource_cost_fact_id uniqueidentifier NOT NULL,
	role_id uniqueidentifier NOT NULL,
	start_period_id bigint NOT NULL,
	end_period_id bigint NOT NULL,
	cost_per_hour float(53) NOT NULL,
	PRIMARY KEY (resource_cost_fact_id));

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
	PRIMARY KEY ([rule_id]));

