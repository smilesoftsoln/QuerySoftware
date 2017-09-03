------------JOIN--------------------
--SELECT  c.dept_name, o.manage_name
--FROM tbl_dept_master c
--INNER JOIN tbl_manage_master o
--ON c.manage_id = o.id
----------------------------------
create database tn_CAREE_bita
use tn_CAREE_bita
drop table tbl_ticket_master
use tn_CAREE_bita
----------------------------------

----------------------------------
select * from tbl_ticket_master
insert into tbl_ticket_master values
	(
		1,
		'sub_1',
		'subidasdasd',
		'NO',
		1,
		'suraj',
		getdate(),
		'DE',
		1,
		'IT',
		1,
		'TradeNet',
		'Normal',
		'Inbox',
		'Outbox'
	)
----------------------------------
create table tbl_dept_master
	(
		id int primary key,
		dept_name varchar(100),
		manage_id int,
		manage_name varchar(50)
	)
----------------------------------
insert into tbl_dept_master values (1,'IT',1,'manage 1')
----------------------------------
SELECT  c.username_,o.dept_name
FROM tbl_loginer_master c
INNER JOIN tbl_dept_master o
ON c.forign_id = o.id

select * from tbl_loginer_master
----------------------------------
create table tbl_loginer_master
	(
		id int primary key,
		username_ nvarchar(100),
		password_ nvarchar(100),
		name_ nvarchar(100),
		post_ nvarchar(100),
		phone_number nvarchar(50),
		email_id nvarchar(50),
		forign_id int,
		block_ nvarchar(10)
	)
----------------------------------
insert into tbl_loginer_master values
	(
		1,
		'123',
		'123',
		'suraj',
		'DE',
		'12',
		'fsdfs',
		1,
		'IT',
		'd'	
	)
select * from tbl_loginer_master
----------------------------------
create table tbl_comments_master
	(
		id int primary key,
		ticket_id int,
		comment_ nvarchar(500),
		date_ smalldatetime,
		creater_id int,
		creater_name nvarchar(100),
		creater_post nvarchar(50),
		attch_url nvarchar(100)
	)
----------------------------------
			--START
----------------------------------
create table tbl_loginer_master
	(
		id int primary key,
		username_ nvarchar(100),
		password_ nvarchar(100),
		name_ nvarchar(100),
		post_ nvarchar(100),
		phone_number nvarchar(50),
		email_id nvarchar(50),
		forign_id int,
		forign_name nvarchar(100),
		block_ nvarchar(10)
	)
----------------------------------

create table tbl_ticket_master
	(
		id int primary key,	
		t_sub nvarchar(500),
		t_desc nvarchar(1000),
		attatchment_url nvarchar(100),
		creater_id int,
		last_update_date smalldatetime,
		now_hand_in nvarchar(25),
		to_dept_id int,
		from_branch_id int,
		q_typ nvarchar(25),
		t_stts nvarchar(50),
		folder_crtr nvarchar(100),
		folder_reciver nvarchar(100),
		disp_id bigint, 
	)
----------------------------------
create table tbl_comments_master
	(
		id int primary key,
		t_id int,
		comment_ nvarchar(500),
		date_ smalldatetime,
		creater_id int,
		creater_post nvarchar(50),
		attch_url nvarchar(100)
	)
----------------------------------
create table tbl_dept_master
	(
		id int primary key,
		dept_name nvarchar(100),
		manage_id int,
		hod_loginer_id int,
	)
----------------------------------
create table tbl_branch_master
	(
		id int primary key,
		branch_name nvarchar(100),
		branch_address nvarchar(500) 
	)
----------------------------------
create table tbl_deptemp_ranking_master
	(
	id int primary key,
	Dept_id int,
	emp_id int,
	emp_stt varchar(25),
	CONSTRAINT fk_ranking_to_dept FOREIGN KEY (dept_id) REFERENCES tbl_dept_name(id),
	CONSTRAINT fk_ranking_to_emp_id FOREIGN KEY (emp_id) REFERENCES tbl_loginer_master(id)
	)
----------------------------------
create table tbl_last_login
	(
		id int primary key,
		loginerID int,
		time_value varchar(150),
		CONSTRAINT fk_lasT_login_loginer_id_to_loginer_master_tbl FOREIGN KEY (loginerID) REFERENCES tbl_loginer_master(id)	
	)
----------------------------------
create table tbl_ticket_history_master
	(
		id int primary key,
		t_id int,
		date_ smalldatetime,
		comment_ nvarchar(500)
	)
----------------------------------
create table tbl_levels
	(
		id int primary key,
		level_name nvarchar(100),
		short_key	nvarchar(50),
	)
----------------------------------
create table tbl_sttss
	(
	id int primary key,
	stts_name nvarchar(100)
	)
----------------------------------
create table tbl_manage_master
	(
		id int primary key,
		manage_name nvarchar(100),
		manage_desc nvarchar(100),
		opening_date smalldatetime
	)
----------------------------------
create table tbl_last_login
	(
		id int primary key,
		loginerID int,
		time_value nvarchar(150),
		CONSTRAINT fk_lasT_login_loginer_id_to_loginer_master_tbl FOREIGN KEY (loginerID) REFERENCES tbl_loginer_master(id)	
	)
----------------------------------
select * from tbl_loginer_master
select * from tbl_ticket_master
select * from tbl_branch_master
select * from tbl_comments_master
select * from tbl_dept_master
select * from tbl_manage_master
select * from tbl_ticket_history_master
----------------------------------
insert into tbl_loginer_master values
	(
		1,
		'admin',
		'12',
		'admin',
		'ADMIN',
		'12346',
		'admin@admin.com',
		'0',
		'No'
	)
----------------------------------
insert into tbl_loginer_master values
	(
		2,
		'TnEmp01',
		'12',
		'abcd efg',
		'BE',
		'122346',
		'TnEmp01@TnEmp01.com',
		'1',
		'No'
	)
----------------------------------
insert into tbl_branch_master values
	(
		1,
		'TradeNet',
		'Mangalvar peth'
	)
----------------------------------
create procedure sp_ticket
as
select * from tbl_ticket_master where t_stts='UNSOLVED'
----------------------------------
--SELECT  c.name_, o.branch_name
--FROM tbl_loginer_master c
--INNER JOIN tbl_branch_master o
--ON c.forign_id = o.id
--where c.post_='BE'

select * from tbl_dept_master
insert into tbl_loginer_master values 	(		3,		'CCemp01',		'12',		'abcd efsag',		'DE',		'1222346',		'dept.com',		'1',		'No'	)
insert into tbl_loginer_master values 	(		4,		'IThod',		'12',		'abcd efsagds',		'HOD',		'12223462',		'hod.com',		'1',		'No'	)
insert into tbl_dept_master values (1,'IT',1,4)
----------------------------------
create procedure sp_get_loginer
@uname varchar(150),
@pwd   varchar(150)
as
select * from tbl_loginer_master where username_=@uname and password_=@pwd
----------------------------------
create procedure sp_read_last_login_by_id
@id int
as
select * from tbl_last_login where id=@id
----------------------------------
create procedure sp_write_last_login_by_id
@id int,
@time_value varchar(150)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_last_login)
insert into tbl_last_login values (@N_id,@id,@time_value)
----------------------------------
create procedure sp_get_loginer_details
@id int
as
select * from  tbl_loginer_master where id=@id
----------------------------------
alter procedure sp_get_loginer_and_branch_details_join
@id int
as
SELECT  c.name_,c.username_,c.post_, o.branch_name
FROM tbl_loginer_master c
INNER JOIN tbl_branch_master o
ON c.forign_id = o.id
where c.id=@id
----------------------------------
select * from tbl_ticket_master
insert into tbl_ticket_master values
	(
	1,
	'sample',
	'sample asdsd',
	'NO',
	2,
	getdate(),
	'DE',
	1,
	1,
	'NORMAL',
	'UNREAD',
	'INBOX',
	'INBOX',
	123456
	)
----------------------------------
alter procedure sp_get_unsolved_tickets_to_be
@id int
as
SELECT  t.id,t.t_sub,d.dept_name,t.t_stts,t.last_update_date,t.q_typ,t.disp_id
FROM tbl_ticket_master t
INNER JOIN tbl_dept_master d
ON t.to_dept_id=d.id
where t.creater_id=@id and t.t_stts !='SOLVED' order by id desc
----------------------------------
create procedure sp_get_solved_tickets_to_be
@id int
as
SELECT  t.id,t.t_sub,d.dept_name,t.t_stts,t.last_update_date,t.q_typ,t.disp_id
FROM tbl_ticket_master t
INNER JOIN tbl_dept_master d
ON t.to_dept_id=d.id
where t.creater_id=@id and t.t_stts ='SOLVED'
----------------------------------
create procedure sp_get_ticket_stts_by_id
@tid int
as
select * from tbl_ticket_master  where id=@tid
----------------------------------
alter procedure sp_view_ticket
@t_id int
as
SELECT  t.t_sub,t.disp_id,b.branch_name,t.t_desc,t.t_stts,d.dept_name,l.name_,t.attatchment_url,t.last_update_date,t.pro_to_emp_id
FROM tbl_ticket_master t
INNER JOIN tbl_branch_master b
ON t.from_branch_id = b.id
INNER JOIN tbl_dept_master d
On t.to_dept_id=d.id
INNER JOIN tbl_loginer_master l
On t.creater_id=l.id
where t.id=@t_id
----------------------------------
create table tbl_short_key_desc_master
	(
		id int primary key,
		short_key nvarchar(50),
		desc_ nvarchar(250)
	)
----------------------------------
create procedure sp_get_username_
@id int 
as
select * from  tbl_loginer_master where id=@id
----------------------------------
insert into tbl_short_key_desc_master values (1,'BE','BRANCH EMPLOYEE')
insert into tbl_short_key_desc_master values (2,'DE','DEPARTMENT EMPLOYEE')
insert into tbl_short_key_desc_master values (3,'HOD','HEAD OF DEPARTMENT')
insert into tbl_short_key_desc_master values (4,'BH','BRANCH HEAD')
insert into tbl_short_key_desc_master values (5,'ADMIN','ADMINISTRATOR')
insert into tbl_short_key_desc_master values (6,'MNG','MANAGEMENT')
select
----------------------------------
alter procedure sp_get_comments
@t_id int
as
SELECT c.comment_,l.id,l.name_,l.post_,s.desc_,c.attch_url,c.date_
from tbl_comments_master c
INNER JOIN  tbl_loginer_master l
On c.creater_id=l.id
INNER JOIN  tbl_short_key_desc_master S
On l.post_=s.short_key
where c.t_id=@t_id order by c.date_ desc
----------------------------------
alter procedure sp_insert_comment_
@t_id int,
@comm_ nvarchar(4000),
@crtr_id int,
@attch_url nvarchar(200)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_comments_master)
insert into tbl_comments_master values(@N_id,@t_id,@comm_,getdate(),@crtr_id,'NN',@attch_url)

----------------------------------
create procedure sp_get_ticket
@tid as int
as
select * from tbl_ticket_master  where id=@tid
----------------------------------
create procedure sp_get_ticket_by_t_id
@t_id int
as
select * from tbl_ticket_master where id=@t_id
----------------------------------
create procedure sp_resend_tick
@tid int,
@res_to varchar(50)
as
update tbl_ticket_master set now_hand_in=@res_to ,  t_stts='UNSOLVED' where id=@tid
----------------------------------
create procedure sp_chage_q_stts_by_tid
@tid int
as
update tbl_ticket_master set q_typ='ESCALATED' where id=@tid
----------------------------------
create procedure sp_get_dept_by_id
@id int
as
select * from tbl_dept_master where id=@id
----------------------------------
create procedure sp_get_user_by_id
@uid bigint 
as
select * from tbl_loginer_master where id=@uid
----------------------------------
create table tbl_deptemp_ranking_master
	(
	id int primary key,
	Dept_id int,
	emp_id int,
	emp_stt varchar(25),
	CONSTRAINT fk_ranking_to_dept FOREIGN KEY (Dept_id) REFERENCES tbl_dept_master(id),
	CONSTRAINT fk_ranking_to_loginer_id FOREIGN KEY (emp_id) REFERENCES tbl_loginer_master(id)
	)
----------------------------------
insert into tbl_deptemp_ranking_master values(1,1,3,'NO')
insert into tbl_deptemp_ranking_master values(2,1,5,'NO')
insert into tbl_loginer_master values(5,'CCEmp02','12','cc emp 02','DE','5645','gghj',1,'NO')
----------------------------------
create procedure sp_get_ranking_dept_wise
@dept_id int
as
select * from tbl_deptemp_ranking_master where Dept_id=@dept_id
----------------------------------
alter procedure sp_get_BE_name_and_branch_name_by_id
@uid int
as
SELECT l.name_,b.branch_name,b.id
from tbl_loginer_master l
INNER JOIN tbl_branch_master b
On l.forign_id=b.id
where l.id=@uid
-----------------------------------
create procedure sp_get_dept_id_by_dept_name
@dept_name varchar(50)
as
select * from tbl_dept_master where dept_name=@dept_name
-----------------------------------
create procedure sp_get_departments
as
select * from tbl_dept_master
----------------------------------
create procedure sp_get_details_by_loginer_ID
@loginerID int
as
select * from  tbl_loginer_master where id=@loginerID
----------------------------------
create procedure sp_update_stt_yes
@dept_id int
as
update tbl_deptemp_ranking_master set emp_stt='NO' where Dept_id=@dept_id
----------------------------------
create procedure sp_get_details_from_dept_master_by_id
@id		 int
as
select * from tbl_loginer_master where id=@id
----------------------------------
select * from tbl_ticket_master 

----------------------------------
alter procedure sp_insert_tbl_ticket_master
		@t_sub nvarchar(500),
		@t_desc nvarchar(4000),
		@attatchment_url nvarchar(100),
		@creater_id int,
		@to_dept_id int,
		@from_branch_id int,
		@disp_id bigint,
		@hand_in nvarchar(20),
		@Pro_to_emp_id int
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_ticket_master)
insert into tbl_ticket_master values 
	(
		@N_id,
		@t_sub,
		@t_desc,
		@attatchment_url,
		@creater_id,
		getdate(),
		@hand_in,
		@to_dept_id,
		@from_branch_id,
		'NORMAL',
		'UNSOLVED',
		'INBOX',
		'INBOX',
		@disp_id,
		@Pro_to_emp_id
	)
----------------------------------
create procedure sp_update_single_stt_yes
@empid int
as
update tbl_deptemp_ranking_master set emp_stt='YES' where emp_id=@empid
----------------------------------
create procedure sp_get_details_by_loginerID
@loginerID int
as
select * from  tbl_loginer_master where id=@loginerID
----------------------------------
create procedure sp_get_only_ticket
as
select * from tbl_ticket_master
----------------------------------
alter procedure sp_get_name_username_Department
@loginerID int
as
select l.name_,l.username_,d.dept_name,d.id
from tbl_loginer_master l
inner join tbl_dept_master d
On l.forign_id=d.id
where l.id=@loginerID
----------------------------------
alter procedure sp_get_tickets_to_de
@emp_id int
as
select t.t_sub,t.id,t.t_stts,t.last_update_date,b.branch_name,t.now_hand_in,t.disp_id,l.name_
from tbl_ticket_master t
inner join tbl_branch_master b
on t.from_branch_id=b.id
inner join tbl_loginer_master l
on t.pro_to_emp_id=l.id
where Pro_to_emp_id=@emp_id  and t_stts !='SOLVED' and t.now_hand_in='DE' order by id desc
----------------------------------
alter procedure sp_get_all_tickets_to_de
@emp_id int
as
select t.t_sub,t.id,t.t_stts,t.last_update_date,b.branch_name,t.now_hand_in,t.disp_id,l.name_,t.creater_id
from tbl_ticket_master t
inner join tbl_branch_master b
on t.from_branch_id=b.id
inner join tbl_loginer_master l
on t.creater_id=l.id
where Pro_to_emp_id=@emp_id and q_typ !='DELETE' and now_hand_in ='DE' order by id desc
----------------------------------
select * from tbl_ticket_master

create procedure sp_get_all_deleted_tickets_to_de
@emp_id int
as
select t.t_sub,t.id,t.t_stts,t.last_update_date,b.branch_name,t.now_hand_in,t.disp_id,l.name_
from tbl_ticket_master t
inner join tbl_branch_master b
on t.from_branch_id=b.id
inner join tbl_loginer_master l
on t.pro_to_emp_id=l.id
where Pro_to_emp_id=@emp_id and q_typ ='DELETE'
----------------------------------
create procedure sp_restore_ticket
@tid int
as
update tbl_ticket_master set q_typ='NORMAL' where id= @tid
----------------------------------
select t.t_sub,t.id,t.t_stts,t.last_update_date,b.branch_name,t.now_hand_in,t.disp_id,l.name_
from tbl_ticket_master t
inner join tbl_branch_master b
on t.from_branch_id=b.id
inner join tbl_loginer_master l
on t.pro_to_emp_id=l.id
where Pro_to_emp_id=3 
----------------------------------
create procedure sp_get_deleted_ticks_by_emp_id
@emp_id int
as
select * from tbl_ticket_master where Pro_to_emp_id=@emp_id and q_typ ='DELETE'  order by last_update_date desc
----------------------------------
alter procedure sp_change_tick_by_typ
@tid int
as
update tbl_ticket_master set q_typ='DELETE' where id=@tid and t_stts='SOLVED'
----------------------------------
create procedure sp_change_stts_as_solved
@t_id int
as
update tbl_ticket_master set t_stts='SOLVED' where id=@t_id
----------------------------------------
create procedure sp_get_ticket_by_t_id
@t_id int 
as
select * from tbl_ticket_master where id=@t_id
----------------------------------
alter procedure sp_get_short_key_by_level_name
@leelName varchar(100)
as
select * from tbl_levels where short_key=@leelName
----------------------------------
alter procedure sp_change_leve
@tid int,
@short_key varchar(50)
as
update tbl_ticket_master set now_hand_in=@short_key, last_update_date=getdate()  where id=@tid
update tbl_ticket_master set q_typ='Transferred' where id=@tid
----------------------------------
select t.t_sub,t.id as 'ticket_id',d.dept_name,l.name_ as 'hod',d.id as 'dept_id'
from tbl_ticket_master t
inner join tbl_dept_master d
On t.to_dept_id=d.id
inner join tbl_loginer_master l
On d.hod_loginer_id=l.id
----------------------------------
alter procedure sp_get_hod_details
@loginerid int
as
select l.name_,l.username_,d.dept_name,l.id,d.id as 'dept_id'
from tbl_loginer_master l
inner join tbl_dept_master d
On d.hod_loginer_id=l.id
where l.id=@loginerid
----------------------------------
alter procedure sp_get_ticketsby_dept_id
as
select t.disp_id ,t.t_sub,t.last_update_date,l.name_ as 'auther',d.dept_name,t.last_update_date,t.id,b.branch_name,t.t_stts,l.id as 'l_id',t.to_dept_id,l2.name_ as 'rec_',l3.name_ as 'hod_name'
from tbl_ticket_master t
inner join tbl_branch_master b
on t.from_branch_id=b.id
inner join tbl_loginer_master l
on t.creater_id=l.id
inner join tbl_dept_master d
on t.to_dept_id=d.id 
inner join tbl_loginer_master l2
on t.pro_to_emp_id=l2.id
inner join tbl_loginer_master l3
on d.hod_loginer_id=l.id
where t.now_hand_in='HOD' and t.t_stts !='SOLVED'
----------------------------------
select * from tbl_dept_master
alter procedure sp_get_all_ticks_hod
as
select t.disp_id ,t.t_sub,t.last_update_date,l.name_ as 'auther',d.dept_name,t.last_update_date,t.id,b.branch_name,t.t_stts,l.id as 'l_id',t.to_dept_id,t.now_hand_in,l2.name_ as 'username_',t.q_typ
from tbl_ticket_master t
inner join tbl_branch_master b
on t.from_branch_id=b.id
inner join tbl_loginer_master l
on t.creater_id=l.id
inner join tbl_dept_master d
on t.to_dept_id=d.id 
inner join tbl_loginer_master l2
on t.Pro_to_emp_id=l2.id order by id desc
----------------------------------
alter procedure sp_get_all_ticks_hod_2
@typ varchar(100)
as
select t.disp_id ,t.t_sub,t.last_update_date,l.name_ as 'auther',d.dept_name,t.last_update_date,t.id,b.branch_name,t.t_stts,l.id as 'l_id',t.to_dept_id,t.now_hand_in,l2.name_ as 'username_'
from tbl_ticket_master t
inner join tbl_branch_master b
on t.from_branch_id=b.id
inner join tbl_loginer_master l
on t.creater_id=l.id
inner join tbl_dept_master d
on t.to_dept_id=d.id
inner join tbl_loginer_master l2
on t.Pro_to_emp_id=l2.id
where t.t_stts like @typ order by id desc
----------------------------------
alter procedure sp_get_tickets_by_dept_id_running
as
select t.disp_id ,t.t_sub,t.last_update_date,l.username_ as 'reciver',l.name_,d.dept_name,t.last_update_date,t.id,b.branch_name,t.t_stts,l.id as 'l_id',t.to_dept_id,t.now_hand_in
from tbl_ticket_master t
inner join tbl_branch_master b
on t.from_branch_id=b.id
inner join tbl_loginer_master l
on t.Pro_to_emp_id=l.id
inner join tbl_dept_master d
on t.to_dept_id=d.id 
where t.t_stts !='SOLVED'  order by id desc
----------------------------------
create procedure sp_get_dept_employee
@uname varchar(150),
@pwd   varchar(150)
as
select * from tbl_loginer_master where username_=@uname and password_=@pwd
----------------------------------
alter procedure sp_get_hod_depts
@id int
as
select * from tbl_dept_master where hod_loginer_id=@id
----------------------------------
create procedure sp_change_pwd_by_l_id
@l_id int,
@new_pwd varchar(100)
as
update tbl_loginer_master set password_=@new_pwd where id=@l_id
----------------------------------
create table tbl_managements_master
	(
		id int primary key,
		mng_name nvarchar(100),
		mng_desc nvarchar(500),
		manager_loginer_id int
	)
----------------------------------
create procedure sp_get_user_info_by_loginer_id
@lofiner_id int
as
select * from tbl_loginer_master where id=@lofiner_id 
----------------------------------
create procedure sp_get_depts_by_mng_id
@mng_id int
as
select d.dept_name,d.manage_id,d.hod_loginer_id,d.id as 'dept_id',l.username_,l.name_
from tbl_dept_master d
inner join tbl_loginer_master l
On d.hod_loginer_id=l.id
where d.manage_id=@mng_id
----------------------------------
create procedure sp_get_mng_details
@loginerid int
as
select l.name_,l.username_,d.dept_name,l.id,d.id as 'dept_id'
from tbl_loginer_master l
inner join tbl_dept_master d
On d.hod_loginer_id=l.id
where l.id=@loginerid
----------------------------------
create procedure sp_get_ticketsby_dept_id_to_mng
as
select t.disp_id ,t.t_sub,t.last_update_date,l.name_ as 'auther',d.dept_name,t.last_update_date,t.id,b.branch_name,t.t_stts,l.id as 'l_id',t.to_dept_id
from tbl_ticket_master t
inner join tbl_branch_master b
on t.from_branch_id=b.id
inner join tbl_loginer_master l
on t.creater_id=l.id
inner join tbl_dept_master d
on t.to_dept_id=d.id 
where t.now_hand_in='MNG' and t.t_stts !='SOLVED'
----------------------------------

alter procedure sp_view_all_queryes
@t_stts varchar(25),
@to_dept_id varchar,
@date_from smalldatetime,
@date_to smalldatetime,
@q_typ varchar(100)
as
select t.disp_id ,t.t_sub,t.last_update_date,l.name_ as 'auther',d.dept_name,t.last_update_date,t.id,b.branch_name,t.t_stts,l.id as 'l_id',t.to_dept_id,t.now_hand_in,l2.name_ as 'username_',t.q_typ
from tbl_ticket_master t
inner join tbl_branch_master b
on t.from_branch_id=b.id
inner join tbl_loginer_master l
on t.creater_id=l.id
inner join tbl_dept_master d
on t.to_dept_id=d.id
inner join tbl_loginer_master l2
on t.Pro_to_emp_id=l2.id
where t.t_stts like @t_stts and t.to_dept_id like @to_dept_id and t.q_typ like @q_typ and t.last_update_date between @date_from and @date_to order by id desc
-----------------------------
create procedure sp_get_dept_id_by_name
@dept_name varchar(100)
as
select * from tbl_dept_master where dept_name=@dept_name
----------------------------------
create procedure sp_update_hand_stts_by_tid
@tid int,
@hnd_stts varchar(50)
as
update tbl_ticket_master set now_hand_in=@hnd_stts where id=@tid and t_stts !='FOLLOW UP'
----------------------------------
create table tbl_Favorites_master
	(id int primary key,title nvarchar(100),url nvarchar(400))
----------------------------------
create procedure sp_insert_tbl_Favorites_master
@title nvarchar(100),
@url nvarchar(400)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_Favorites_master)
insert into tbl_Favorites_master values (@N_id,@title,@url)
----------------------------------
create procedure sp_get_tbl_Favorites_master
as
select * from tbl_Favorites_master
----------------------------------
create procedure sp_update_Favorites
@title nvarchar(100),
@new_title nvarchar(100),
@new_url nvarchar(400)
as
update tbl_Favorites_master set title=@new_title,url=@new_url where title=@title
----------------------------------
create procedure sp_delete_Favorites
@title nvarchar(100)
as
delete from tbl_Favorites_master where title=@title
----------------------------------
create procedure sp_chk_username_availabality
as
select * from tbl_loginer_master
----------------------------------
create procedure sp_insert_loginer_stape_one
@username_ nvarchar(100),
@password_ nvarchar(100),
@name_ nvarchar(200),
@post_ nvarchar(50),
@phone_number nvarchar(50),
@email_id nvarchar(50)
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
		'0',
		'No'
	)
----------------------------------
create procedure sp_get_loginer_by_username
@username_ nvarchar(100)
as
select * from tbl_loginer_master where username_=@username_
----------------------------------
create procedure sp_get_branches
as
select * from tbl_branch_master
----------------------------------
create procedure sp_update_tbl_loginer_stape_to
@forign_id int,
@loginer_id int
as
update tbl_loginer_master set forign_id=@forign_id where id=@loginer_id
----------------------------------
create procedure sp_get_branch_by_name
@branch_name nvarchar(100)
as
select * from tbl_branch_master where branch_name=@branch_name
----------------------------------
create procedure sp_get_depts
as
select * from tbl_dept_master
----------------------------------
create procedure sp_get_dept_by_name
@dept_name nvarchar(100)
as
select * from tbl_dept_master where dept_name=@dept_name
----------------------------------
create procedure sp_insert_rankings
@dept_id int,
@emp_id int
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_deptemp_ranking_master) 
insert into tbl_deptemp_ranking_master values (@N_id,@dept_id,@emp_id,'NO')
----------------------------------
create procedure sp_chk_dept_hod_by_dept_name
@dept_name nvarchar(100)
as
select * from tbl_dept_master where dept_name=@dept_name
----------------------------------
create procedure sp_chk_branch_name_available_or_not
@branch_name nvarchar(100)
as
select * from tbl_branch_master where branch_name=@branch_name
----------------------------------
create procedure sp_insert_branch
@branch_name nvarchar(100),
@branch_desc nvarchar(400)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_branch_master) 
insert into tbl_branch_master values (@N_id,@branch_name,@branch_desc)
----------------------------------
create procedure sp_dept_available_or_not
@dept_name nvarchar(100)
as
select * from tbl_dept_master where dept_name=@dept_name
----------------------------------
alter procedure sp_insert_dept
@dept_name nvarchar(100),
@dept_desc nvarchar(500),
@mng_id int,
@hod_loginer_id int
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_dept_master)
insert into tbl_dept_master values (@N_id,@dept_name,@mng_id,@hod_loginer_id,@dept_desc)
----------------------------------
create procedure sp_get_managements
as
select * from  tbl_managements_master
----------------------------------
create procedure sp_get_managements_by_name
@mng_name nvarchar(100)
as
select * from  tbl_managements_master where mng_name=@mng_name
----------------------------------
create procedure sp_get_alert_from_loginer
as
select * from tbl_loginer_master where forign_id=0
----------------------------------
create procedure sp_get_alert_from_dept
as
select * from tbl_dept_master where hod_loginer_id=0
----------------------------------
create procedure sp_get_dept_less_hod
as
select * from tbl_loginer_master where forign_id=0 and post_='HOD'
----------------------------------
create procedure sp_get_hods
as
select * from tbl_loginer_master where  post_='HOD'
----------------------------------
create procedure sp_get_dept_n_hods
as
select d.dept_name,l.username_,l.name_
from tbl_dept_master d
inner join tbl_loginer_master l
On d.hod_loginer_id=l.id
where l.post_='HOD' 
----------------------------------
create procedure sp_get_hod_less_depts
as
select * from tbl_dept_master where hod_loginer_id=0
----------------------------------
create procedure sp_get_loginer_by_username
@username_ nvarchar(100)
as
select * from tbl_loginer_master where username_ =@username_
----------------------------------
create procedure sp_set_hod_to_dept
@dept_id int,
@hod_loginer_id int
as
update tbl_dept_master set hod_loginer_id=@hod_loginer_id where id=@dept_id
----------------------------------
create procedure sp_change_approval
@tiket_id int
as
update tbl_ticket_master set folder_reciver='APPROVAL' where id=@tiket_id
----------------------------------
create procedure sp_chaneg_ticker_stts
@tid int
as
update tbl_ticket_master set t_stts='FOLLOW UP' where id=@tid
----------------------------------

---- view all user
select * from tbl_loginer_master
select l.username_,l.name_
from tbl_loginer_master l
----------------------------------
create procedure sp_get_count_of_loginers
as
select count(*) as 'count' from tbl_loginer_master
----------------------------------
create procedure sp_get_user_full_desc
@id int,
@post_ nvarchar(100),
@post_desc nvarchar(100)
as
DECLARE @intFlag INT
SET @intFlag = 1
DECLARE @post_Desc nvarchar(100)
DECLARE @l_count int;
DECLARE @forign_id int
	BEGIN
		DECLARE @post_ nvarchar(100);
		set @post_=(select post_ from tbl_loginer_master where id=@id)
		if @post_ ='BE' 
			BEGIN
				set @forign_id=(select forign_id from tbl_loginer_master where id=@id)
				set @post_Desc=(select branch_name from tbl_branch_master where id=@forign_id)
				print @post_Desc
			END
		if @post_ ='BH' 
			BEGIN
				set @forign_id=(select forign_id from tbl_loginer_master where id=@id)
				set @post_Desc=(select branch_name from tbl_branch_master where id=@forign_id)
				print @post_Desc
			END
		if @post_ ='DE' 
			BEGIN
				set @forign_id=(select forign_id from tbl_loginer_master where id=@id)
				set @post_Desc=(select dept_name from tbl_dept_master where id=@forign_id)
				print @post_Desc
			END
		if @post_ ='HOD' 
			BEGIN
				set @forign_id=(select forign_id from tbl_loginer_master where id=@id)
				set @post_Desc=(select dept_name from tbl_dept_master where id=@forign_id)
				print @post_Desc
			END
		if @post_ ='MNG' 
			BEGIN
				set @forign_id=(select forign_id from tbl_loginer_master where id=@id)
				set @post_Desc=(select mng_name from tbl_managements_master where id=@forign_id)
				print @post_Desc 
			END
		end
select l.*,@post_Desc as 'post_desc'
from tbl_loginer_master l where l.post_ like @post_ and @post_Desc like @post_desc ;
----------------------------------
create procedure sp_get_user_full_desc
@post_ nvarchar(100),
@post_desc nvarchar(100)
as
from tbl_loginer_master l where l.post_ like @post_ and @post_Desc like @post_desc ;
----------------------------------
alter procedure sp_get_all_users
@post_ nvarchar(100)
as
select l.*,ls.login_stts
from tbl_loginer_master l
inner join tbl_login_stts ls
on l.id=ls.loginerID
where post_ like @post_

----------------------------------
alter procedure sp_get_all_be
@branch nvarchar(100)
as
select l.username_,l.name_,l.phone_number,l.email_id,b.branch_name,l.id,ls.login_stts
from tbl_loginer_master l
inner join tbl_branch_master b
On l.forign_id=b.id 
inner join tbl_login_stts ls
on l.id=ls.loginerID
where l.post_='BE' and b.branch_name like @branch
----------------------------------
alter procedure sp_get_all_bh
@branch nvarchar(100)
as
select l.username_,l.name_,l.phone_number,l.email_id,b.branch_name,l.id,ls.login_stts
from tbl_loginer_master l
inner join tbl_branch_master b
On l.forign_id=b.id 
inner join tbl_login_stts ls
on l.id=ls.loginerID
where l.post_='BH' and b.branch_name like @branch
----------------------------------
alter procedure sp_get_all_de
@dept nvarchar(100)
as
select l.username_,l.name_,l.phone_number,l.email_id,d.dept_name,l.id,ls.login_stts
from tbl_loginer_master l
inner join tbl_dept_master d
On l.forign_id=d.id
inner join tbl_login_stts ls
on l.id=ls.loginerID 
where l.post_='DE' and d.dept_name like @dept
----------------------------------
alter procedure sp_get_all_hod
@dept nvarchar(100)
as
select l.username_,l.name_,l.phone_number,l.email_id,d.dept_name,l.id,ls.login_stts
from tbl_loginer_master l
inner join tbl_dept_master d
On l.forign_id=d.id 
inner join tbl_login_stts ls
on l.id=ls.loginerID
where l.post_='HOD' and d.dept_name like @dept
----------------------------------
alter procedure sp_get_all_mng
@mng nvarchar(100)
as
select l.username_,l.name_,l.phone_number,l.email_id,m.mng_name,l.id,ls.login_stts
from tbl_loginer_master l
inner join tbl_managements_master m
On l.forign_id=m.id 
inner join tbl_login_stts ls
on l.id=ls.loginerID
where l.post_='MNG' and m.mng_name like @mng
----------------------------------
create procedure sp_search_user
@kw nvarchar(100)
as
select * from tbl_loginer_master
where username_ like @kw or name_ like @kw or phone_number like @kw or email_id like @kw
----------------------------------
alter procedure sp_update_user_info
@id int,
@name_ nvarchar(200),
@phone_number nvarchar(100),
@email_id nvarchar(100),
@password_ nvarchar(100),
@username_ nvarchar(100)
as
update tbl_loginer_master set name_=@name_, phone_number=@phone_number,email_id=@email_id,password_=@password_,username_=@username_   where id=@id

----------------------------------
create procedure sp_get_al_tickets
as
select * from tbl_ticket_master where t_stts !='COMPLETED'and now_hand_in='EMP' order by last_update_date desc

----------------------------------
create table tbl_approval_master
	(
		id int primary key,
		t_id int,
		date smalldatetime,
		id_crtr int,
		note_crtr nvarchar(500),
		to_ nvarchar(50),
		stts nvarchar(50),
		id_rcvr int,
		note_rcvr nvarchar(500),
		dept_id int
	)
----------------------------------
alter procedure sp_insert_approval
@t_id int,
@id_crtr int,
@note_crtr nvarchar(500),
@to_ nvarchar(50),
@id_rcvr int,
@dept_id int
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_approval_master)
insert into tbl_approval_master values (@N_id,@t_id,getdate(),@id_crtr,@note_crtr,@to_,'FREEZ',@id_rcvr,'BLANK',@dept_id)
----------------------------------
create procedure sp_get_approvals
as
select * from tbl_approval_master where stts='FREEZ'
----------------------------------
create procedure sp_get_approvals_to_mng
as
select * from tbl_approval_master where stts='FREEZ' and to_='MNG'
----------------------------------
create procedure sp_get_approvals_to_hod
as
select * from tbl_approval_master where stts='FREEZ' and to_='HOD'
----------------------------------

create procedure sp_get_approvals_id
@id int
as
select * from tbl_approval_master where stts='FREEZ' and id=@id
----------------------------------
alter procedure sp_update_approve
@app_id int,
@note_ nvarchar(500),
@stts nvarchar(50)
as
update tbl_approval_master set note_rcvr=@note_ , stts=@stts where id=@app_id 
----------------------------------
create procedure sp_get_app_by_t_id
@tid int
as
select * from tbl_approval_master where t_id=@tid
----------------------------------
create procedure sp_get_all_login_report
as
select ll.time_value,l.name_,l.username_
from tbl_last_login ll
inner join tbl_loginer_master l
on ll.loginerID=l.id
----------------------------------
alter procedure sp_get_perticular_login_report
@username_ nvarchar(100),
@date_from nvarchar(50),
@date_to nvarchar(50)
as
select ll.time_value,l.name_,l.username_
from tbl_last_login ll
inner join tbl_loginer_master l
on ll.loginerID=l.id
where l.username_ like @username_ and  ll.time_value between @date_from and @date_to order by time_value
----------------------------------
create procedure sp_insert_management
@mng_name nvarchar(100),
@mng_desc nvarchar(500)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_managements_master)
insert into tbl_managements_master values(@N_id,@mng_name,@mng_desc,0)
----------------------------------
create procedure sp_get_managements_by_mng_name
@mng_name nvarchar(100)
as
select * from tbl_managements_master where mng_name=@mng_name

----------------------------------
create procedure sp_get_alert_from_managements
as
select * from tbl_managements_master where manager_loginer_id=0
----------------------------------
create procedure sp_get_management_by_name
@mng_name nvarchar(100)
as
select * from tbl_managements_master where mng_name=@mng_name
----------------------------------
create procedure sp_update_manager_loginer_id
@id int,
@loginer_id int
as
update tbl_managements_master set manager_loginer_id=@loginer_id where id=@id

update tbl_loginer_master set forign_id=0 where id=21
----------------------------------
create procedure sp_get_branch_by_name
@branch_name nvarchar(100)
as
select * from tbl_branch_master where branch_name != @branch_name
----------------------------------
create procedure sp_get_update_bracnh_name
@ori_branch_name nvarchar(100),
@entered_branch_name nvarchar(100)
as
select * from tbl_branch_master where branch_name != @ori_branch_name and branch_name =@entered_branch_name
----------------------------------
create procedure sp_update_branch
@ori_branch_name nvarchar(100),
@new_branch_name nvarchar(100),
@new_details nvarchar(500)
as
update tbl_branch_master set branch_name=@new_branch_name,branch_address=@new_details where branch_name=@ori_branch_name
----------------------------------

create procedure sp_updte_dept
@ori_dept_name nvarchar(100),
@new_dept_name nvarchar(100)
as
select * from tbl_dept_master where dept_name !=@ori_dept_name and dept_name=@new_dept_name
----------------------------------
alter procedure sp_update_dept_2
@ori_dept_name nvarchar(100),
@new_dept_name nvarchar(100),
@dept_desc nvarchar(500)
as
update tbl_dept_master set dept_name=@new_dept_name,dept_desc=@dept_desc where dept_name=@ori_dept_name
----------------------------------
create procedure sp_get_management
as
select * from tbl_managements_master
----------------------------------
create procedure sp_update_mng_1
@ori_mng_name nvarchar(100),
@new_mng_name nvarchar(100)
as
select * from tbl_managements_master where mng_name !=@ori_mng_name and  mng_name=@new_mng_name
----------------------------------
create procedure sp_update_mng_info
@ori_mng_name nvarchar(100),
@new_mng_name nvarchar(100),
@mng_desc nvarchar(500)
as
update tbl_managements_master set mng_name=@new_mng_name , mng_desc=@mng_desc where mng_name=@ori_mng_name
----------------------------------
create procedure sp_get_app_by_t_id
@tid int
as
select * from tbl_approval_master
----------------------------------
create procedure sp_search_ticket
@keyword nvarchar(500)
as
select t.disp_id ,t.t_sub,t.last_update_date,l.name_ as 'auther',d.dept_name,t.last_update_date,t.id,b.branch_name,t.t_stts,l.id as 'l_id',t.to_dept_id,t.now_hand_in,l2.name_ as 'username_',t.q_typ
from tbl_ticket_master t
inner join tbl_branch_master b
on t.from_branch_id=b.id
inner join tbl_loginer_master l
on t.creater_id=l.id
inner join tbl_dept_master d
on t.to_dept_id=d.id 
inner join tbl_loginer_master l2
on t.Pro_to_emp_id=l2.id
where t.disp_id like @keyword or t.t_sub like @keyword 
----------------------------------
create table tbl_login_stts
	(
		id int primary key,
		loginerID int,
		login_stts nvarchar(50),
		reserv nvarchar(100)
	)
----------------------------------
alter procedure sp_updatye_login_stts
@loginer_id int,
@login_stts nvarchar(50)
as
update tbl_login_stts set login_stts=@login_stts where loginerID=@loginer_id and loginerID !=0


----------------------------------
alter procedure sp_view_all_Online_users
as
select l.username_,ls.login_stts
from tbl_loginer_master l
inner join tbl_login_stts ls
On ls.loginerID=l.id order by login_stts desc
----------------------------------
alter procedure sp_view_all_Online_users_de
as
select l.username_,ls.login_stts,l.forign_id,d.dept_name
from tbl_loginer_master l
inner join tbl_login_stts ls
On ls.loginerID=l.id 
inner join tbl_dept_master d
on l.forign_id=d.id
where l.post_='DE' or l.post_='HOD'
order by login_stts desc
----------------------------------
alter procedure sp_get_tickets_by_branch
@branch_id int
as
select t.disp_id ,t.t_sub,t.last_update_date,l.username_ as 'reciver',l.name_,d.dept_name,t.last_update_date,t.id,b.branch_name,t.t_stts,l.id as 'l_id',t.to_dept_id,t.now_hand_in,b.id as 'Branch_id'
from tbl_ticket_master t
inner join tbl_branch_master b
on t.from_branch_id=b.id
inner join tbl_loginer_master l
on t.Pro_to_emp_id=l.id
inner join tbl_dept_master d
on t.to_dept_id=d.id 
where  b.id=@branch_id
----------------------------------
create procedure sp_get_tickets_by_branch_n_stts
@stts nvarchar(100),
@branch_id int
as
select t.disp_id ,t.t_sub,t.last_update_date,l.username_ as 'reciver',l.name_,d.dept_name,t.last_update_date,t.id,b.branch_name,t.t_stts,l.id as 'l_id',t.to_dept_id,t.now_hand_in,b.id as 'Branch_id'
from tbl_ticket_master t
inner join tbl_branch_master b
on t.from_branch_id=b.id
inner join tbl_loginer_master l
on t.Pro_to_emp_id=l.id
inner join tbl_dept_master d
on t.to_dept_id=d.id 
where  b.id=@branch_id and t.t_stts like @stts

----------------------------------
create procedure sp_get_running_tickets_by_branch
@branch_id int
as
select t.disp_id ,t.t_sub,t.last_update_date,l.username_ as 'reciver',l.name_,d.dept_name,t.last_update_date,t.id,b.branch_name,t.t_stts,l.id as 'l_id',t.to_dept_id,t.now_hand_in,b.id as 'Branch_id',t.creater_id,l2.username_ as 'creater_name'
from tbl_ticket_master t
inner join tbl_branch_master b
on t.from_branch_id=b.id
inner join tbl_loginer_master l
on t.Pro_to_emp_id=l.id
inner join tbl_dept_master d
on t.to_dept_id=d.id 
inner join tbl_loginer_master l2
On t.creater_id=l2.id
where  b.id=@branch_id
----------------------------------
select * from tbl_login_stts where login_stts='ONLINE' order by login_stts
----------------------------------
create procedure sp_gel_all_branch
as
select * from tbl_branch_master
----------------------------------
create procedure sp_gep_all_mnagemnts
as
select * from tbl_managements_master

----------------------------------
create procedure sp_chk_username_2
@ori_username nvarchar(100),
@new_username nvarchar(100)
as
select * from tbl_loginer_master where username_ !=@ori_username and username_=@new_username


--8421454225

----------------------------------

insert into tbl_login_stts values (1,1,'OFLINE','BLANK')
insert into tbl_login_stts values (2,2,'OFLINE','BLANK')
insert into tbl_login_stts values (3,3,'OFLINE','BLANK')
insert into tbl_login_stts values (4,4,'OFLINE','BLANK')
insert into tbl_login_stts values (5,5,'OFLINE','BLANK')
insert into tbl_login_stts values (6,6,'OFLINE','BLANK')
insert into tbl_login_stts values (7,7,'OFLINE','BLANK')
insert into tbl_login_stts values (8,8,'OFLINE','BLANK')
insert into tbl_login_stts values (9,9,'OFLINE','BLANK')
insert into tbl_login_stts values (10,10,'OFLINE','BLANK')
insert into tbl_login_stts values (11,11,'OFLINE','BLANK')
insert into tbl_login_stts values (12,12,'OFLINE','BLANK')
insert into tbl_login_stts values (13,13,'OFLINE','BLANK')
insert into tbl_login_stts values (14,14,'OFLINE','BLANK')
insert into tbl_login_stts values (15,15,'OFLINE','BLANK')
insert into tbl_login_stts values (16,16,'OFLINE','BLANK')
insert into tbl_login_stts values (17,17,'OFLINE','BLANK')
insert into tbl_login_stts values (19,19,'OFLINE','BLANK')
insert into tbl_login_stts values (20,20,'OFLINE','BLANK')
insert into tbl_login_stts values (21,21,'OFLINE','BLANK')
insert into tbl_login_stts values (18,18,'OFLINE','BLANK')
----------------------------------
create procedure sp_insert_login_stts
@loginer_id int
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_login_stts)
insert into tbl_login_stts values(@N_id,@loginer_id,'OFFLINE','BLANK')
----------------------------------

-----------------20_01_2011-----------------
create procedure sp_get_users_by_dept
as
select l.*,d.dept_name
from tbl_loginer_master l
inner join tbl_dept_master d
on l.forign_id=d.id
where l.post_='HOD' or l.post_='DE'
----------------------------------
create procedure sp_get_dept_by_mng_name
@mng_name nvarchar(100)
as
select d.*,m.mng_name
from tbl_dept_master d
inner join tbl_managements_master m
On d.manage_id=m.id
where m.mng_name=@mng_name
----------------------------------
create procedure sp_get_hod_by_dept_id
@dept_id int
as
select d.dept_name,l.*
from tbl_dept_master d
inner join tbl_loginer_master l
on d.hod_loginer_id=l.id
where d.id=@dept_id
----------------------------------11_03_2011

alter procedure sp_view_all_queryes_2
@t_stts varchar(25),
@to_dept_id varchar,
@q_typ varchar(100)
as
select t.disp_id ,t.t_sub,t.last_update_date,l.name_ as 'auther',d.dept_name,t.last_update_date,t.id,b.branch_name,b.id as 'branch_id',t.t_stts,l.id as 'l_id',t.to_dept_id,t.now_hand_in,l2.name_ as 'username_',t.q_typ
from tbl_ticket_master t
inner join tbl_branch_master b
on t.from_branch_id=b.id
inner join tbl_loginer_master l
on t.creater_id=l.id
inner join tbl_dept_master d
on t.to_dept_id=d.id
inner join tbl_loginer_master l2
on t.Pro_to_emp_id=l2.id 
where t.t_stts like @t_stts and t.to_dept_id like @to_dept_id and t.q_typ like @q_typ  order by id desc

---------------------------------
alter procedure sp_view_all_queryes_to_BH
@date_from smalldatetime,
@date_to smalldatetime,
@from_branch_id as int

as
select t.disp_id ,t.t_sub,l.name_ as 'auther',d.dept_name,t.id,b.branch_name,b.id as 'branch_id',t.t_stts,l.id as 'l_id',t.to_dept_id,t.now_hand_in,l2.name_ as 'username_',t.q_typ
from tbl_ticket_master t
inner join tbl_branch_master b
on t.from_branch_id=b.id
inner join tbl_loginer_master l
on t.creater_id=l.id
inner join tbl_dept_master d
on t.to_dept_id=d.id
inner join tbl_loginer_master l2
on t.Pro_to_emp_id=l2.id 
where t.t_stts like 'UNSOLVED' and b.id=@from_branch_id and   t.last_update_date between @date_from and @date_to order by id desc





---------------------------------

alter procedure sp_get_all_depts
as
select d.* ,l.email_id
from tbl_dept_master  d
inner join tbl_loginer_master l
on hod_loginer_id=l.id
where l.post_='HOD'
---------------------------------

alter procedure sp_get_BH_email
as
select l.* ,b.branch_name,b.id as 'branch_id'
from tbl_loginer_master l
inner join tbl_branch_master b
on l.forign_id=b.id
where post_='BH'

---------------------------------
create procedure sp_get_sttss
as
select * from tbl_sttss

---------------------------------
create procedure sp_get_dept_emp_by_id
@id int
as
select * from tbl_loginer_master  where id=@id
---------------------------------
create procedure sp_get_emp_by_dept
@dept_id int
as
select * from tbl_loginer_master where post_='DE' and forign_id=@dept_id
-----------------------------
alter procedure sp_get_DE_loginer_ids_by_forign_ids
@f_id int
as
select * from tbl_loginer_master where post_='DE' and forign_id=@f_id
-----------------------------
create procedure sp_change_dept_by_t_id
@new_dept_id int,
@t_id int,
@pro_to_dept_emoID int
as
update tbl_ticket_master set to_dept_id=@new_dept_id ,  last_update_date=getdate(),pro_to_emp_id=@pro_to_dept_emoID where id=@t_id
-----------------------------
alter procedure sp_insert_podt
@ticket_id int,
@post_ varchar(750),
@creater_id bigint,
@crtr_typ varchar(50)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_comments_master)
insert into tbl_comments_master values (@N_id,@ticket_id,@post_,getdate(),@creater_id,'NN','NA')

select * from tbl_comments_master

-----------------------------

select * from tbl_loginer_master where NAME_ like '%SAN%'
select * from tbl_ticket_master




















update tbl_loginer_master set id=18 where id=1002
select * from tbl_last_login
select * from tbl_managements_master
	delete from tbl_managements_master
select * from tbl_approval_master
delete from  tbl_approval_master where id=3
select * from tbl_managements_master

select * from tbl_deptemp_ranking_master
select * from tbl_short_key_desc_master
select * from tbl_ticket_master
	delete from tbl_ticket_master
select * from tbl_branch_master
select * from tbl_levels
select * from tbl_ticket_master
select * from tbl_Favorites_master


select * from tbl_ticket_master
select * from tbl_branch_master
select * from tbl_loginer_master where post_='BH'




insert into tbl_dept_master values(3,'sample dept',1,0)
update tbl_dept_master set hod_loginer_id=2 where id=1
update tbl_ticket_master set t_stts='UNSOLVED'
select * from tbl_comments_master
update tbl_loginer_master set forign_id=2 where id=5
select l.name_,l.username_,d.dept_name,l.id
from tbl_loginer_master l
inner join tbl_dept_master d
On d.hod_loginer_id=l.id
where l.id=4
update tbl_deptemp_ranking_master set Dept_id=2
update tbl_ticket_master set now_hand_in='MNG' where id=1
insert into tbl_levels values(1,'Department Employee','DE')
insert into tbl_levels values(2,'Head Of Department','HOD')
insert into tbl_levels values(3,'Management','MNG')
insert into tbl_comments_master values(2,1,'asdasdsdfs dfsjkd hfjskd hfjksfj sfshdjfjks',getdate(),3,'sdsd','NO')
insert into tbl_dept_master values(3,'TP',1,4)
select * from tbl_last_login
delete from tbl_dept_master
insert into tbl_ticket_master values
	(
	7,
	'dont display',
	'sdasdsad',
	'NO',
	2,
	getdate(),
	'DE',
	3,
	1,
	'NORMAL',
	'UNSOLVED',
	'INBOX',
	'INBOX',
	11010005,
	5
	)
SELECT l.name_,b.branch_name
from tbl_loginer_master l
INNER JOIN tbl_branch_master b
On l.forign_id=b.id
where l.id=2
--
insert into tbl_managements_master values(1,'NAMAGEMENT 01','MNG Desc',5)
insert into tbl_managements_master values(2,'NAMAGEMENT 02','MNG Desc 02',6)
--
insert into tbl_loginer_master values
(1,	'TPEmp01',	'12',	'Tp emp 01',	'BE',	'12',	'fsdfs',	1,	'NO')
--
insert into tbl_loginer_master values
(2,	'CChod',	'12',	'CC hod',	'HOD',	'12',	'fsdfs',	1,	'NO')
--
insert into tbl_loginer_master values
(3,	'CCemp01',	'12',	'CC D-Emp 01',	'DE',	'12',	'fsdfs',	1,	'NO')
--
insert into tbl_loginer_master values
(4,	'CCemp02',	'12',	'CC D-Emp 02',	'DE',	'12',	'fsdfs',	1,	'NO')
--
insert into tbl_loginer_master values
(5,	'manage01',	'12',	'management 01',	'MNG',	'12',	'fsdssdfs',	1,	'NO')
--
insert into tbl_loginer_master values
(6,	'manage02',	'12',	'management 02',	'MNG',	'12',	'fsdssdfs',	1,	'NO')
--
update tbl_loginer_master  set forign_id=2 where id=6
insert into tbl_branch_master values
(1,'TP Branch','KOL')
--
insert into tbl_dept_master values 
(1,'DEPT OF IT',1,2)
--
insert into tbl_deptemp_ranking_master values(1,1,3,'NO')
insert into tbl_deptemp_ranking_master values(2,1,4,'NO')
--
select * from tbl_short_key_desc_master
insert into tbl_short_key_desc_master values (7,'BH','BRANCH HEAD')
select * from tbl_loginer_master
select * from tbl_dept_master 
insert into tbl_dept_master  values (2,'Dept Of IT',1,2)
update tbl_dept_maste set dept_name='DEPT OF IT' where id=2


insert into tbl_loginer_master values (1000,'admin','12','administrator','ADMIN','123465','email',0,'NO')
update tbl_loginer_master set forign_id=1000 where id=1000

insert into tbl_loginer_master values 	(		7,		'ITEmp01',		'12',		'abcd efsag',		'DE',		'1222346',		'dept.com',		'2',		'No'	)
insert into tbl_deptemp_ranking_master values(3,2,7,'NO')
update tbl_ticket_master set now_hand_in='HOD' where id=1


select * from tbl_loginer_master
select * from tbl_loginer_master where username_='MFEmp01'
delete from tbl_loginer_master where id=60
asas

select * from tbl_last_login
select * from tbl_deptemp_ranking_master

delete from tbl_last_login where loginerID=60 
delete from tbl_last_login 
delete from tbl_deptemp_ranking_master  where emp_id=60
delete from tbl_approval_master 
delete from tbl_branch_master 
delete from tbl_comments_master 
delete from tbl_dept_master 








select * from tbl_loginer_master

select * from tbl_managements_master
-- get dept by mng

select d.*,m.mng_name
from tbl_dept_master d
inner join tbl_managements_master m
On d.manage_id=m.id

--get_users_by_dept
select l.*,d.dept_name
from tbl_loginer_master l
inner join tbl_dept_master d
on l.forign_id=d.id
where l.post_='HOD' or l.post_='DE'




update tbl_dept_master set dept_desc='Department Description'
alter table tbl_dept_master add dept_desc nvarchar(500)

select * from tbl_approval_master where to_ ='MNG'


select * from tbl_approval_master
