create database db_TN_todo
use db_TN_todo
--------------------------27_02_2011

create table tbl_task_master
	(
		id	int		primary key,
		subject_	nvarchar(200),
		desc_		nvarchar (2000),
		privacy_	nvarchar(50),
		task_from_id int,
		task_to_id	int,	
		stts_		nvarchar(100),
		start_time	smalldatetime,
		mentained_end_time	smalldatetime,
		actual_end_time		smalldatetime,
		rcvr		nvarchar(200),
		attch_url	nvarchar(500)
	
	)
--------------------------
create table tbl_loginer_master
	(
		id			int primary key,	
		username_	nvarchar(150),
		password_	nvarchar(150),
		name_		nvarchar(250),
		post_		nvarchar(50),
		phone_number nvarchar(100),
		email_id	nvarchar(200),
		forign_id	int,	
		block_		nvarchar(50),
		last_login	nvarchar(100),
		rcvr_		nvarchar(100)
	)
--------------------------
create table tbl_login_stts
	(
		id			int primary key,
		loginer_id	int,
		login_stts	nvarchar(100)
	)
--------------------------
create table tbl_mngt_master
	(
		id int primary key,
		mngt_name nvarchar(100),
		mngt_desc nvarchar(500),
		manager_loginer_id int
	)
--------------------------
create table tbl_level_master
	(
		id			int primary key,	
		level_name	nvarchar(100),
		short_key	nvarchar(50)
	)
--------------------------
create table tbl_delly_todo_master
	(
		id			int primary key,
		subject_	nvarchar(100),
		Desc_		nvarchar(500),
		privacy_	nvarchar(50),
		toDo_from_id int,
		toDo_to_id	int,
		assigned_date smalldatetime,
		end_time	smalldatetime,	
		stts_		nvarchar(50),
		rcvr_note	nvarchar(200),
		attch_url	nvarchar(500)
	)
--------------------------
create table tbl_dept_master
	(	
		id int primary key,
		dept_name nvarchar(100),
		dept_Desc nvarchar(500),
		mngt_id int,	
		hod_loginer_id int
	)
--------------------------
create table tbl_weekly_todo_master
	(
		id			int primary key,
		subject_	nvarchar(100),
		Desc_		nvarchar(500),
		privacy_	nvarchar(50),
		toDo_from_id int,
		toDo_to_id	int,
		assigned_date smalldatetime,
			week_day nvarchar(100),
		end_time	smalldatetime,	
		stts_		nvarchar(50),
		rcvr_note	nvarchar(200),
		attch_url	nvarchar(500)
	)
--------------------------
create table tbl_monthly_todo_master
	(
		id			int primary key,
		subject_	nvarchar(100),
		Desc_		nvarchar(500),
		privacy_	nvarchar(50),
		toDo_from_id int,
		toDo_to_id	int,
		assigned_date smalldatetime,
			month_date	int,
		end_time	smalldatetime,	
		stts_		nvarchar(50),
		rcvr_note	nvarchar(200),
		attch_url	nvarchar(500)
	)
--------------------------
create table tbl_last_login
	(
		id int primary key,
		loginerID int,
		time_value varchar(150),
		CONSTRAINT fk_lasT_login_loginer_id_to_loginer_master_tbl FOREIGN KEY (loginerID) REFERENCES tbl_loginer_master(id)	
	)

--------------------------
create procedure sp_chk_username_availabality
@username_ nvarchar(100)
as
select * from tbl_loginer_master where username_=@username_
--------------------------
alter procedure sp_insert_tbl_loginer_master
		@username_	nvarchar(150),
		@password_	nvarchar(150),
		@name_		nvarchar(250),
		@post_		nvarchar(50),
		@phone_number nvarchar(100),
		@email_id	nvarchar(200)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_loginer_master)
insert into tbl_loginer_master values 
(
	@N_id,
	@username_,
	@password_,
	@name_,
	@post_,
	@phone_number,
	@email_id,
	0,
	'NA',
	'Not Set',
	'NA'
)
--------------------------
insert into tbl_loginer_master values(1,'admin','12','ADMINISTRATOR','ADMIN','00000','admin@admin.com',1001,'NA','NA','NA')

--------------------------
create procedure sp_get_loginer
@username_ nvarchar(100),
@password_ nvarchar(100)
as
select * from tbl_loginer_master where username_=@username_ and password_=@password_
--------------------------
create procedure sp_get_alert_from_loginer
as
select * from tbl_loginer_master where forign_id=0
--------------------------
create procedure sp_get_user_by_id
@uid int
as
select * from tbl_loginer_master where id=@uid

--------------------------
create procedure sp_get_depts
as
select * from tbl_dept_master

--------------------------
create procedure sp_dept_available_or_not
@dept_name nvarchar(100)
as
select * from tbl_dept_master where dept_name=@dept_name
--------------------------
create procedure sp_get_managements_by_mng_name
@mng_name nvarchar(100)
as
select * from tbl_mngt_master where mngt_name=@mng_name
--------------------------
create procedure sp_insert_management
@mng_name nvarchar(100),
@mng_desc nvarchar(500)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_mngt_master)
insert into tbl_mngt_master values
	(
		@N_id,
		@mng_name,
		@mng_desc,
		0
	)
--------------------------
create procedure sp_get_alert_from_managements
as
select * from tbl_mngt_master where  manager_loginer_id=0

--------------------------
create procedure sp_get_loginer_by_username
@username_ nvarchar(100)
as
select * from tbl_loginer_master where username_=@username_
--------------------------
create procedure sp_get_managements
as
select * from tbl_mngt_master
--------------------------
create procedure sp_get_management_by_name
@mng_name nvarchar(100)
as
select * from tbl_mngt_master where mngt_name=@mng_name
--------------------------
create procedure sp_update_tbl_loginer_stape_to
@forign_id int,
@loginer_id int
as
update tbl_loginer_master set forign_id=@forign_id where id=@loginer_id
--------------------------
create procedure sp_update_manager_loginer_id
@id int,
@loginer_id int
as
update tbl_mngt_master set manager_loginer_id=@loginer_id where id=@id
--------------------------
create procedure sp_get_managements_by_name
@mngt_name nvarchar(100)
as
select * from  tbl_mngt_master where mngt_name=@mngt_name
--------------------------
create procedure sp_insert_dept
@dept_name nvarchar(100),
@dept_desc nvarchar(500),
@mng_id int
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_dept_master)
insert into tbl_dept_master values	
	(
		@N_id,
		@dept_name,
		@dept_desc,
		@mng_id,
		0
	)

--------------------------
create procedure sp_get_alert_from_dept
as
select * from  tbl_dept_master where hod_loginer_id=0
--------------------------
create procedure sp_chk_dept_hod_by_dept_name
@dept_name nvarchar(100)
as
select * from tbl_dept_master where dept_name=@dept_name
--------------------------
create procedure sp_get_dept_by_name
@dept_name nvarchar(100)
as
select * from tbl_dept_master where dept_name=@dept_name
--------------------------
create procedure sp_update_hod_loginer_id_by_dept_is
@dept_id int,
@loginer_id int
as
update tbl_dept_master set hod_loginer_id=@loginer_id where id=@dept_id
--------------------------
create procedure sp_get_dept_n_hods
as
select d.dept_name,l.username_,l.name_
from tbl_dept_master d
inner join tbl_loginer_master l
On d.hod_loginer_id=l.id
where l.post_='HOD'

--------------------------
create procedure sp_get_hod_less_depts
as
select * from tbl_dept_master where hod_loginer_id=0
--------------------------
create procedure sp_get_dept_less_hod01
as
select * from tbl_loginer_master where forign_id=0 and post_='HOD'
--------------------------
create procedure sp_get_hods
as
select * from tbl_loginer_master where  post_='HOD'
--------------------------
create procedure sp_get_dept_id_by_dept_name
@dept_name varchar(50)
as
select * from   tbl_dept_master where dept_name=@dept_name
--------------------------
create procedure sp_set_hod_to_dept
@dept_id int,
@hod_loginer_id int
as
update tbl_dept_master set hod_loginer_id=@hod_loginer_id where id=@dept_id
--------------------------
create procedure sp_get_users_by_dept
as
select l.*,d.dept_name
from tbl_loginer_master l
inner join tbl_dept_master d
on l.forign_id=d.id
where l.post_='HOD' or l.post_='DE'
--------------------------
create procedure sp_get_dept_by_mng_name
@mngt_name nvarchar(100)
as
select d.*,m.mngt_name
from tbl_dept_master d
inner join tbl_mngt_master m
On d.mngt_id=m.id
where m.mngt_name=@mngt_name
--------------------------
create procedure sp_set_forign_id_dur_transf_dept
@loginer_id int
as
update tbl_loginer_master set forign_id=0 where id=@loginer_id
--------------------------
create procedure sp_get_all_users
@post_ nvarchar(100)
as
select l.*,ls.login_stts
from tbl_loginer_master l
inner join tbl_login_stts ls
on l.id=ls.loginer_id
where post_ like @post_
--------------------------
create procedure sp_insert_tbl_login_stts
@loginer_id int
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_login_stts)
insert into tbl_login_stts values
	(
		@N_id,
		@loginer_id,
		'ONLINE'
	)
--------------------------
create procedure sp_get_all_de
@dept nvarchar(100)
as
select l.username_,l.name_,l.phone_number,l.email_id,d.dept_name,l.id,ls.login_stts
from tbl_loginer_master l
inner join tbl_dept_master d
On l.forign_id=d.id
inner join tbl_login_stts ls
on l.id=ls.loginer_ID
where l.post_='DE' and d.dept_name like @dept
--------------------------
create procedure sp_get_all_hod
@dept nvarchar(100)
as
select l.username_,l.name_,l.phone_number,l.email_id,d.dept_name,l.id,ls.login_stts
from tbl_loginer_master l
inner join tbl_dept_master d
On l.forign_id=d.id 
inner join tbl_login_stts ls
on l.id=ls.loginer_ID
where l.post_='HOD' and d.dept_name like @dept
--------------------------
alter procedure sp_get_all_mng
@mng nvarchar(100)
as
select l.username_,l.name_,l.phone_number,l.email_id,m.mngt_name,l.id,ls.login_stts
from tbl_loginer_master l
inner join tbl_mngt_master m
On l.forign_id=m.id 
inner join tbl_login_stts ls
on l.id=ls.loginer_ID
where l.post_='MNGT' and m.mngt_name like @mng
--------------------------
alter procedure sp_gep_all_mnagemnts
as
select * from tbl_mngt_master
--------------------------
create procedure sp_insert_login_stts
@loginer_id int
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_login_stts)
insert into tbl_login_stts values(@N_id,@loginer_id,'OFFLINE')
--------------------------
create procedure sp_read_last_login_by_id
@id int
as
select * from tbl_last_login where id=@id
--------------------------
create procedure sp_write_last_login_by_id
@id int,
@time_value varchar(150)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_last_login)
insert into tbl_last_login values (@N_id,@id,@time_value)
--------------------------





--====================================
delete from tbl_login_stts
delete from tbl_dept_master
delete from tbl_loginer_master
delete from tbl_mngt_master


select * from tbl_login_stts
select * from tbl_loginer_master













select * from tbl_loginer_master
update tbl_loginer_master set forign_id=2 where id=6
delete from tbl_loginer_master where id=2