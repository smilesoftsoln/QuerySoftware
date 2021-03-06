create database sri_sri_projecter

-----------------------------------
create table tbl_user_master
	(
		u_id int primary key,
		f_name varchar(100),
		m_name varchar(100),
		l_name varchar(100),
		phone_number bigint,	
		e_mail_id varchar(100),
		website varchar(100),
		Realition_w_co varchar(500),
		username_ varchar(100),
		password_ varchar(100)
	)
---------------------------------
--
select * from tbl_user_master
select * from tbl_loginers_master 

select l.username_,l.display_name,u.e_mail_id,u.branch_name,l.id,l.who_is
from tbl_loginers_master l
inner join tbl_user_master u
on l.forign_id=u.id
where l.who_is='BE'
-----------------------------------
insert into tbl_user_master values
	(
		2,
		'aa',
		'',
		'',
		 ,
		'TnCAREe2012@yahoo.in',
		' ',
		' ',
		' ',
		' '
	)
-----------------------------------
insert into tbl_user_master values
	(
		3,
		'aa',
		'',
		'',
		 ,
		'TnCAREe2012@yahoo.in',
		' ',
		' ',
		' ',
		' '
	)
-----------------------------------
create table tbl_ticket_master
	(
		t_id int primary key,	
		t_sub varchar(500),
		t_desc varchar(1000),
		emergency_ smalldatetime,
		attatchment_url varchar(100),
		creater_id int,
		date_ smalldatetime,	
		t_stts varchar(50)
	)
-----------------------------------
alter table tbl_ticket_master add  last_update_date smalldatetime
select * from tbl_ticket_master  
-----------------------------------
insert into tbl_ticket_master values 
	(
		2,
		'2Understanding security and privacy features',
		'2Internet Explorer provides a number of features that help to protect your privacy and make your computer and your personally identifiable information more secure. Privacy features allow you to protect your personally identifiable information by helping you to understand how Web sites you view may be using this information and by allowing you to specify privacy settings that determine whether or not you want to allow Web sites to save cookies on your computer.',
		07/08/2010,
		'No',
		1,
		getdate(),
		'UNREAD',
		getdate()
	)
-----------------------------------
select * from tbl_ticket_master 
select * from tbl_ticket_master
-----------------------------------
alter procedure sp_get_ticket_by_id
@uid bigint
as
select * from tbl_ticket_master where creater_id=@uid order by last_update_date desc 
-----------------------------------
create procedure sp_get_ticket
@tid as int
as
select * from tbl_ticket_master  where t_id=@tid
select * from tbl_ticket_master  where t_id=1
-----------------------------------
create procedure sp_get_ticket_by_unread
as
select * from tbl_ticket_master  where t_stts='STILL UNREAD' order by date_ desc
-----------------------------------
create table tbl_posts_master
	(
		tp_id bigint primary key,
		ticket_id int,
		post_ varchar(750),
		tp_date smalldatetime,
		creater_id bigint,
		CONSTRAINT fk_postID_to_ticketID FOREIGN KEY (ticket_id) REFERENCES tbl_ticket_master(t_id)
	)
-----------------------------------
insert into tbl_posts_master values (@N_id,@ticket_id,@post_,getdate(),@creater_id)
select * from tbl_posts_master
-----------------------------------
create table tbl_admin_ 
	(
	aid int primary key,
	username_ varchar(150),
	password_ varchar(150)
	)
-----------------------------
insert into tbl_admin_ values (0,'admin','12')
-----------------------------
create procedure sp_get_admin
@uname varchar(150),
@pwd   varchar(150)
as
select * from tbl_admin_ where username_=@uname and password_=@pwd
-----------------------------
create table user_updates_master
	(
	up_id int primary key,
	userID int,
	update_ varchar(750),
	update_stts varchar(50),
	)
-----------------------------
select * from user_updates_master
-----------------------------
create procedure sp_user_update_fill
@userID int,
@update_ varchar(750)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(up_id)+1,1)from user_updates_master)
insert into user_updates_master values (61,0,'dadasda','UN')
-----------------------------
create procedure sp_get_unread_ups_for_user
@uid int
as
select * from user_updates_master where update_stts='UN' and userID=@uid
-----------------------------
create procedure sp_update_user_upp
@uid int
as
update user_updates_master set update_stts='RD' where up_id=@uid
-----------------------------
create table admin_updates_master
	(
	up_id int primary key,
	update_ varchar(750),
	update_stts varchar(50),
	)
-----------------------------
create procedure sp_admin_update_fill
@upd varchar(750)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(up_id)+1,1)from admin_updates_master)
insert into admin_updates_master  values (@N_id,@upd,'NO')
-----------------------------
create procedure sp_get_un_admin_updates
as
select * from admin_updates_master where update_stts='NO' order by up_id desc
-----------------------------
create procedure sp_update_admin_upp_stts
@uid int
as
update admin_updates_master set update_stts='RD' where up_id=@uid
-----------------------------
create procedure sp_get_ticket_stts_by_id
@tid int
as
select * from tbl_ticket_master  where t_id=@tid
-----------------------------
create procedure sp_update_un_stts
@tid int
as
update tbl_ticket_master set t_stts='READ' where t_id=@tid
-----------------------------
----------------------------------------
alter procedure sp_get_al_tickets
as
select * from tbl_ticket_master where t_stts !='COMPLETED'and now_hand_in='EMP' order by date_ desc
----------------------------------------
create table tbl_sttss
	(
	stt_id int primary key,
	stts_name varchar(100),
	stts_img_url varchar(100)
	)
----------------------------------------
select * from tbl_sttss
insert into tbl_sttss values(1,'UNREAD','NO')
insert into tbl_sttss values(2,'READ','NO')
insert into tbl_sttss values(3,'WORK IN PROGRESS','NO')
insert into tbl_sttss values(4,'FINISHING','NO')
insert into tbl_sttss values(5,'WATING FOR HELP','NO')
insert into tbl_sttss values(4,'SOLVED','NO')
insert into tbl_sttss values(4,'STILL UNREAD','NO')
----------------------------------------
insert into tbl_sttss values (7,'STILL UNREAD','no')
----------------------------------------
create procedure sp_get_stttss
as
select * from tbl_sttss
----------------------------------------
create procedure sp_change_stts_by_tid
@tid int,
@stts varchar(100)
as
update tbl_ticket_master set t_stts=@stts where t_id=@tid
----------------------------------------
create procedure sp_change_emer_date_by_tid
@tid int,
@date_ smalldatetime
as
update tbl_ticket_master set emergency_=@date_ where t_id=@tid
----------------------------------------
create procedure sp_ticks_by_emer
as
select * from tbl_ticket_master  where t_stts ! = 'COMPLETED' and emergency_ > getdate() order by emergency_
----------------------------------------
create procedure sp_get_all_admin_updates
as
select * from admin_updates_master  order by up_id desc
----------------------------------------
create procedure sp_ticks_by_emer_late
as
select * from tbl_ticket_master  where t_stts ! = 'COMPLETED' and emergency_ < getdate() and emergency_ !='1900-01-01 00:00:00' order by emergency_
----------------------------------------
create procedure sp_get_all_user_updates
@uid int
as
select * from user_updates_master where userID=@uid  order by up_id desc
----------------------------------------
alter procedure sp_get_unsolved_ticks
@uid int
as
select * from tbl_ticket_master where creater_id=@uid and t_stts!='SOLVED'
----------------------------------------
create procedure sp_get_solved_ticks
@uid int
as
select * from tbl_ticket_master where creater_id=@uid and t_stts='SOLVED'
select * from tbl_ticket_master where creater_id=1022 and t_stts='SOLVED'

----------------------------------------
create procedure sp_delete_post_by_tID
@tid int
as
delete from tbl_posts_master where tp_id=@tid
----------------------------------------
create procedure sp_get_post_by_TPID
@tid int
as
select * from tbl_posts_master where tp_id=@tid
----------------------------------------
create procedure sp_delete_ticket
@tid int
as
delete from tbl_posts_master where ticket_id=@tid

----------------------------------------
create table tbl_levels
	(
		id int primary key,
		level_name varchar(100),
		short_key	varchar(50),
	)
----------------------------------------
select * from tbl_levels
----------------------------------------
create procedure sp_get_short_key_by_level_name
@leelName varchar(100)
as
select * from tbl_levels where level_name=@leelName
----------------------------------------
insert into tbl_levels values(3,'DEPART EMPLOYEE','EMP')
insert into tbl_levels values(4,'HOD','HOD')
insert into tbl_levels values(5,'ADMIN','ADMIN')
----------------------------------------
create procedure sp_get_ticket_by_t_id
@t_id int 
as
select * from tbl_ticket_master where t_id=@t_id
----------------------------------------
create procedure sp_change_stts_as_solved
@t_id int
as
update tbl_ticket_master set t_stts='SOLVED' where t_id=@t_id
----------------------------------------
create procedure sp_get_leveld
as
select * from tbl_levels

----------------------------------------
create table tbl_hod_ 
	(
	id int primary key,
	username_ varchar(150),
	password_ varchar(150)
	)
-----------------------------
insert into tbl_hod_ values (1000,'hod','hod12')
-----------------------------
-----------------------------
update tbl_admin_ set username_='emp' , password_='emp12'
-----------------------------
select * from tbl_ticket_master

-----------------------------
insert into tbl_user_master values
	(
		1000,
		'aa',
		'',
		'',
		 ,
		'TnCAREe2012@yahoo.in',
		' ',
		' ',
		' ',
		' '
	)
-----------------------------
insert into tbl_user_master values
	(
		1001,
		'Main Admin',
		' ',
		' ',
		02316686880,
		'TnCAREe2012@yahoo.in',
		'shrishri',
		'',
		'hod12345679',
		'hod12345679'
	)
-----------------------------
create table tbl_main_admin_ 
	(
	id int primary key,
	username_ varchar(150),
	password_ varchar(150)
	)
-----------------------------
insert into tbl_main_admin_ values (1001,'admin','admin12')
-----------------------------
-----------------------------
alter procedure sp_get_al_tickets_for_admin
as
select * from tbl_ticket_master where t_stts !='SOLVED'and now_hand_in='ADMIN' order by date_ desc
-----------------------------
alter table tbl_ticket_master add now_hand_in varchar(50)
alter table tbl_ticket_master add disp_id bigint
update  tbl_ticket_master set now_hand_in ='EMP'
---------------unpublished--------------
select * from tbl_hod_
select * from tbl_admin_
select * from tbl_posts_master
-----------------------------
create table tbl_dept_master
	(
		id int primary key,
		dept_name varchar(50),
		dept_desc varchar(150),
	)
-----------------------------
insert into tbl_dept_master values (1,'IT','IT DEPARTMENT')
insert into tbl_dept_master values (2,'MARKETING','MARKETING DEPARTMENT')
-----------------------------
create table tbl_dept_emp_master
	(
		id int primary key,
		dept_id int,
		name_ varchar(100),
		joining_date smalldatetime,
		username_ varchar(100),
		password_ varchar(100),
		secq_q varchar(100),
		secq_ans	varchar(100),
		dept_post	varchar(50),
		CONSTRAINT fk_dept_emp_to_dept FOREIGN KEY (dept_id) REFERENCES tbl_dept_master(id),
	)
-----------------------------
insert into tbl_dept_emp_master values
	(
		1,
		1,
		'emp one',
		getdate(),
		'empone',
		'empone',
		'??',
		'??',
		'DE'
	)
-----------------------------
insert into tbl_dept_emp_master values
	(
		2,
		1,
		'emp two',
		getdate(),
		'emptwo',
		'emptwo',
		'??',
		'??',
		'EMP'
	)
-----------------------------

-----------------------------
alter table tbl_posts_master add creater_type varchar(50)
-----------------------------
alter procedure sp_insert_podt
@ticket_id int,
@post_ varchar(750),
@creater_id bigint,
@crtr_typ varchar(50)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(tp_id)+1,1)from tbl_posts_master)
insert into tbl_posts_master values (@N_id,@ticket_id,@post_,getdate(),@creater_id,@crtr_typ)
-----------------------------
create table tbl_HOD_master
	(
		id int primary key,
		name_ varchar(100),
		username_ varchar(100),
		password_ varchar(100),
		joining_date smalldatetime,
		phone_number varchar(20),
		email_id varchar(50),
		dept_id int,
		CONSTRAINT fk_HOD_to_dept FOREIGN KEY (dept_id) REFERENCES tbl_dept_master(id),
	)
-----------------------------
insert into tbl_HOD_master values
	(
		1,
		'HOD Name',
		'hod',
		'hod12',
		getdate(),
		'123456',
		'email@id.com',
		1
	)
-----------------------------
create table tbl_deptemp_ranking_master
	(
	id int primary key,
	Dept_id int,
	emp_id int,
	emp_stt varchar(25),
	CONSTRAINT fk_ranking_to_dept FOREIGN KEY (Dept_id) REFERENCES tbl_dept_master(id),
	CONSTRAINT fk_ranking_to_emp_id FOREIGN KEY (emp_id) REFERENCES tbl_dept_emp_master(id)
	)
-----------------------------
--insert into tbl_deptemp_ranking_master values(id,Dept_id,emp_id,'NO')
insert into tbl_deptemp_ranking_master values(15,11,15,'NO')
select * from tbl_dept_emp_master
select * from tbl_deptemp_ranking_master
-----------------------------
alter table tbl_ticket_master add  to_dept_id int,
	CONSTRAINT fk_query_to_dept_id FOREIGN KEY (to_dept_id) REFERENCES tbl_dept_master(id)
-----------------------------
alter table tbl_ticket_master add  from_branch varchar(100)
-----------------------------
alter table tbl_ticket_master add  pro_to_dept_emoID  int,
	CONSTRAINT fk_query_to_to_dept_emp_id FOREIGN KEY (pro_to_dept_emoID) REFERENCES tbl_dept_emp_master(id)
--------------------------------------
alter table tbl_ticket_master drop  column emergency_
-----------------------------------
create procedure sp_get_departments
as
select * from tbl_dept_master
-----------------------------------
create procedure sp_get_dept_id_by_dept_name
@dept_name varchar(50)
as
select * from   tbl_dept_master where dept_name=@dept_name
-----------------------------------
create procedure sp_get_ranking_dept_wise
@dept_id int
as
select * from tbl_deptemp_ranking_master where Dept_id=@dept_id
select * from tbl_deptemp_ranking_master where Dept_id=2
-----------------------------------
create procedure sp_update_stt_yes
@dept_id int
as
update tbl_deptemp_ranking_master set emp_stt='NO' where Dept_id=@dept_id
select * from tbl_deptemp_ranking_master where Dept_id=15
-----------------------------------
create procedure sp_update_single_stt_yes
@empid int
as
update tbl_deptemp_ranking_master set emp_stt='YES' where emp_id=@empid
-----------------------------------
update tbl_user_master set branch_name='kolhapur' , branch_desc='kolhapur'

	
-----------------------------------
update tbl_dept_emp_master set dept_post='DE'
-----------------------------------
create table tbl_loginers_master	(		id			int primary key,		username_	varchar(100),		password_	varchar(100),		display_name varchar(100),		who_is		varchar(100),		forign_id int	)
-----------------------------------
drop table tbl_user_master
-----------------------------------
create table tbl_user_master 	(		id int primary key,		f_name varchar(100),		m_name varchar(100),		l_name varchar(100),		phone_number bigint,		e_mail_id varchar(100),		branch_name varchar(100),		branch_Desc varchar(850),		desegnitio_ varchar(25)	)
-----------------------------------
insert into tbl_user_master values	(		1,		'suraj',		'ramesh',		'mahajan',		123456,		'email',		'kolhapur',		'kop branch',		'BE'	)
-----------------------------------
insert into tbl_user_master values	(		2,		'abhi',		'j',		'tanawase',		123456,		'email',		'kolhapur',		'kop branch',		'BE'	)
-----------------------------------
insert into tbl_loginers_master values 	(		123456,		'srj',		'12',		'suraj mahajan',		'BE',		1	)
-----------------------------------
insert into tbl_loginers_master values 	(		123457,		'empone',		'12',		'suraj mahajan',		'DE',		1	)
-----------------------------------
insert into tbl_loginers_master values 	(		123458,		'emptwo',		'12',		'sdfdsfsfs',		'DE',		2	)
-----------------------------------
insert into tbl_loginers_master values 	(		123459,		'ithod',		'12',		'sdfdsfsfs',		'HOD',		1	)
-----------------------------------
insert into tbl_loginers_master values 	(		123410,		'admin',		'12',		'sdfdsfsfs',		'ADMIN',		1	)
-----------------------------------
insert into tbl_loginers_master values 	(		123411,		'abh',		'12',		'abhi tanawade',		'BE',		2	)
-----------------------------------
select * from tbl_ticket_master
-----------------------------------
update tbl_loginers_master set display_name='Project admin' where id=123410
-----------------------------------
update tbl_loginers_master set display_name='DADA' where id=123457
-----------------------------------
update tbl_loginers_master set display_name='VINAN' where id=123458
update tbl_loginers_master set display_name='HOD OF IT' where id=123459
-----------------------------------
alter procedure sp_get_main_admin
@uname varchar(150),
@pwd   varchar(150)
as
select * from tbl_loginers_master where username_=@uname and password_=@pwd
-----------------------------------
alter procedure sp_get_hod
@uname varchar(150),
@pwd   varchar(150)
as
select * from tbl_loginers_master where username_=@uname and password_=@pwd
-----------------------------------
alter procedure sp_get_dept_employee
@uname varchar(150),
@pwd   varchar(150)
as
select * from tbl_loginers_master where username_=@uname and password_=@pwd
-----------------------------

-----------------------------
alter procedure sp_user_login
@uname varchar(100),
@pass varchar(100)
as
select * from tbl_loginers_master where username_=@uname and password_=@pass
-----------------------------------
alter procedure sp_get_user_info
@uid int
as
select * from tbl_loginers_master where id=@uid
-----------------------------------
alter procedure sp_get_user_by_id
@uid bigint 
as
select * from tbl_loginers_master where id=@uid
-----------------------------------
create procedure sp_get_user_id_by_loginer_forign_id
@forign_id int
as
select * from tbl_user_master where id=@forign_id

-----------------------------------

select * from tbl_user_master where id=3
update tbl_user_master set branch_name='FRANCHISEE' where id=3
-----------------------------------
create procedure sp_get_forign_id_by_loginer_id
@loginer_id int
as
select * from tbl_loginers_master where id=@loginer_id
-----------------------------------
select * from tbl_posts_master
alter table tbl_posts_master add vsto_BE varchar(10)
alter table tbl_posts_master add vsto_DE varchar(10)
alter table tbl_posts_master add vsto_HOD varchar(10)
alter table tbl_posts_master add vsto_ADMIN varchar(10)
alter table tbl_posts_master add attch_url varchar(100)
-----------------------------------
alter procedure sp_insert_podt
@ticket_id int,
@post_ varchar(750),
@creater_id bigint,
@crtr_typ varchar(100),
@BE varchar(10),
@DE varchar(10),
@HOD varchar(10),
@ADMIN varchar(10),
@attch_url varchar(100)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(tp_id)+1,1)from tbl_posts_master)
insert into tbl_posts_master values (@N_id,@ticket_id,@post_,getdate(),@creater_id,@crtr_typ,@BE,@DE,@HOD,@ADMIN,@attch_url)
-----------------------------------
create procedure sp_get_post_count_by_tID_for_DE
@tid int
as
select count(*) as 'count' from tbl_posts_master where ticket_id=@tid and vsto_DE='YES'
-----------------------------------
create procedure sp_get_post_by_tID_for_DE
@tid int
as
select * from tbl_posts_master where ticket_id=@tid and vsto_DE='YES'

----------------------------------
create procedure sp_get_post_count_by_tID_for_BE
@tid int
as
select count(*) as 'count' from tbl_posts_master where ticket_id=@tid and vsto_BE='YES'
-----------------------------------
create procedure sp_get_post_by_tID_for_BE
@tid int
as
select * from tbl_posts_master where ticket_id=@tid and vsto_BE='YES'
----------------------------------
create procedure sp_get_post_count_by_tID_for_HOD
@tid int
as
select count(*) as 'count' from tbl_posts_master where ticket_id=@tid and vsto_HOD='YES'
-----------------------------------
create procedure sp_get_post_by_tID_for_HOD
@tid int
as
select * from tbl_posts_master where ticket_id=@tid and vsto_HOD='YES'
----------------------------------
create procedure sp_get_post_count_by_tID_for_ADMIN
@tid int
as
select count(*) as 'count' from tbl_posts_master where ticket_id=@tid and vsto_ADMIN='YES'
-----------------------------------
create procedure sp_get_post_by_tID_for_ADMIN
@tid int
as
select * from tbl_posts_master where ticket_id=@tid and vsto_ADMIN='YES'
select * from tbl_posts_master where ticket_id=2 and vsto_ADMIN='YES'
----------------------------------
alter procedure sp_get_queryes_by_emp_id
@emp_id int
as
select * from tbl_ticket_master where now_hand_in='DE' and pro_to_dept_emoID=@emp_id and t_stts !='SOLVED'
select * from tbl_ticket_master where now_hand_in='DE' and t_stts !='SOLVED'
-----------------------------
--declare @crtrdate smalldatetime
--set @crtrdate =(select last_update_date from tbl_ticket_master where t_id=3)
--select DATEDIFF(hour,@crtrdate,getdate()) AS NumberOfDays
select * from tbl_ticket_master where now_hand_in='DE' and pro_to_dept_emoID=2 
-----------------------------
update tbl_ticket_master set now_hand_in='DE'
-----------------------------
select * from tbl_ticket_master
-----------------------------
update tbl_levels set short_key='DE' where id=3 

select * from tbl_ticket_master
-----------------------------
select * from tbl_dept_emp_master  
-----------------------------


-----------------------------
alter procedure sp_get_al_tickets_for_hod
as
select * from tbl_ticket_master where t_stts !='COMPLETED' order by date_ desc
-----------------------------
------------currecting department problame-----------------
select * from tbl_dept_master
-----------------------------
create procedure sp_get_details_by_loginerID
@loginerID int
as
select * from  tbl_loginers_master where id=@loginerID
select * from  tbl_loginers_master where id=1022

-----------------------------
create procedure sp_get_details_from_dept_master_by_id
@id		 int
as
select * from tbl_dept_emp_master where id=@id
-----------------------------
create procedure sp_get_details_from_dept_master_by_id_f_hod
@id		 int
as
select * from tbl_HOD_master where id=@id
-----------------------------
insert into tbl_dept_emp_master values
	(
		4,
		2,
		'emp four',
		getdate(),
		'empfour',
		'12',
		'??',
		'??',
		'DE'
	)
-----------------------------
select * from tbl_deptemp_ranking_master
select * from tbl_ticket_master
drop table tbl_hod_
select * from tbl_HOD_master
select * from tbl_loginers_master
insert into tbl_loginers_master values 	(		12345612,		'empthree',		'12',		'emp three',		'DE',		3	)
insert into tbl_loginers_master values 	(		12345613,		'empfour',		'12',		'emp four',		'DE',		4	)
insert into tbl_loginers_master values 	(		12345614,		'markhod',		'12',		'marketing hod',		'HOD',		2	)
-----------------------------
insert into tbl_deptemp_ranking_master values(3,2,3,'NO')
insert into tbl_deptemp_ranking_master values(4,2,4,'NO')
-----------------------------
insert into tbl_HOD_master values
	(
		2,
		'HOD Name',
		'markhod',
		'12',
		getdate(),
		'123456',
		'email@id.com',
		2
	)
-----------------------------
alter procedure sp_get_al_tickets_for_hod_by_dept_id
@dept_id int
as
select * from tbl_ticket_master where to_dept_id=@dept_id and t_stts !='SOLVED' order by date_ desc

-----------------------------
create procedure sp_get_hod_by_loginer_id
@loginerid int
as
select * from tbl_loginers_master where id=@loginerid
-----------------------------
create procedure sp_get_dept_id_by_hod_id
@hod_id int
as
select * from tbl_HOD_master where id=@hod_id
-----------------------------
create procedure sp_dept_get_details_by_id
@id int
as
select * from tbl_dept_master where id=@id
-----------------------------
create table tbl_last_login
	(
		id int primary key,
		loginerID int,
		time_value varchar(150),
		CONSTRAINT fk_lasT_login_loginer_id_to_loginer_master_tbl FOREIGN KEY (loginerID) REFERENCES tbl_loginers_master(id)	
	)
-----------------------------
insert into tbl_last_login values 	(		1,123410,'NOT SET'	)
insert into tbl_last_login values 	(		2,123411,'NOT SET'	)
insert into tbl_last_login values 	(		3,123456,'NOT SET'	)
insert into tbl_last_login values 	(		4,123457,'NOT SET'	)
insert into tbl_last_login values 	(		5,123458,'NOT SET'	)
insert into tbl_last_login values 	(		6,123459,'NOT SET'	)
insert into tbl_last_login values 	(		7,12345612,'NOT SET'	)
insert into tbl_last_login values 	(		8,12345613,'NOT SET'	)
insert into tbl_last_login values 	(		9,12345614,'NOT SET'	)
insert into tbl_last_login values 	(		10,12345615,'NOT SET'	)
-----------------------------
create procedure sp_read_last_login_by_loginer_id
@loginerID int
as
select * from tbl_last_login where loginerID=@loginerID
select * from tbl_last_login where loginerID=1031
-----------------------------
alter procedure sp_get_ticket_by_emp_id
@emp_id int
as
select * from tbl_ticket_master where pro_to_dept_emoID=@emp_id order by date_ desc
-----------------------------
create procedure sp_get_dept_by_id
@id int
as
select * from tbl_dept_master where id=@id
-----------------------------
create procedure sp_get_depts
as
select * from tbl_dept_master
-----------------------------
create procedure sp_get_dept_id_by_name
@dept_name varchar(100)
as
select * from tbl_dept_master where dept_name=@dept_name
-----------------------------
alter procedure sp_change_dept_by_t_id
@new_dept_id int,
@t_id int,
@pro_to_dept_emoID int
as
update tbl_ticket_master set to_dept_id=@new_dept_id ,  last_update_date=getdate(),pro_to_dept_emoID=@pro_to_dept_emoID where t_id=@t_id
-----------------------------
create procedure sp_get_user_details_by_id
@id int
as
select * from tbl_user_master where id=@id
select * from tbl_user_master where id=2

-----------------------------
insert into tbl_user_master values
	(
		3,
		'DADA',
		'N',
		'TAWADE',
		9326885514,
		'TnCAREe2012@yahoo.in',
		'KOLHAPUR',
		'kop branch',
		'BH'
	)
-----------------------------
insert into tbl_loginers_master values 	(		12345615,		'dada',		'12',		'dadasaheb tawade',		'BH',		3	)
-----------------------------
alter procedure sp_get_tickets_by_dept_id
@deptid int
as
select * from tbl_ticket_master where to_dept_id=@deptid and now_hand_in='DE' and t_stts!='SOLVED' order by date_ desc

-----------------------------
select * from tbl_ticket_master
-----------------------------
create procedure sp_get_DE_loginer_ids_by_forign_ids
@f_id int
as
select * from tbl_loginers_master where who_is='DE' and forign_id=@f_id
-----------------------------
create procedure sp_get_emp_by_dept
@dept_id int
as
select * from tbl_dept_emp_master where dept_post='DE' and dept_id=@dept_id
-----------------------------
alter procedure sp_update_reciver_by_disp_id
@disp_id bigint,
@new_recv_id int
as
update tbl_ticket_master set last_update_date=getdate() ,  pro_to_dept_emoID=@new_recv_id where disp_id=@disp_id
-----------------------------
select * from tbl_ticket_master 
-------------messeging system----------------

create table tbl_msgbox_master 
	(
	msg_id bigint primary key,
	from_id int,
	to_id int,
	subject varchar(500),
	mail_ varchar(2000),
	attatchment_url varchar(200),
	read_stts varchar(10),
	folder varchar(10),
	date_ smalldatetime
	CONSTRAINT fk_inbox_from_to_cid FOREIGN KEY (from_id) REFERENCES tbl_loginers_master(id),
	CONSTRAINT fk_inbox_to_to_cid FOREIGN KEY (to_id) REFERENCES tbl_loginers_master(id)
	)
-----------------------------
create procedure sp_insert_mail
@from_id bigint,
@to_id bigint,
@subject varchar(500),
@mail_ varchar(2000),
@attatchment_url varchar(200)
as
declare @N_id int;
set @N_id=(select isnull (max(msg_id)+1,1) from tbl_msgbox_master)
insert into tbl_msgbox_master values(@N_id,@from_id,@to_id,@subject,@mail_,@attatchment_url,'UN','INBOX',getdate())
-----------------------------
create procedure sp_get_mails
@cid bigint
as
select * from tbl_msgbox_master where to_id=@cid and folder='INBOX'
-----------------------------
create procedure sp_get_mails_count
@cid bigint
as
select count(*) 'count'  from tbl_msgbox_master  where to_id=@cid and read_stts='UN'
-----------------------------
alter procedure sp_get_mails_count_all
@cid bigint
as
select count(*) 'count'  from tbl_msgbox_master  where to_id=@cid  and folder='INBOX'
-----------------------------
select count(*) 'count'  from tbl_msgbox_master  where to_id=123456 
select * from tbl_msgbox_master
-----------------------------
alter procedure sp_get_mails
@cid bigint
as
select * from tbl_msgbox_master where to_id=@cid and folder='INBOX' order by date_ desc
-----------------------------
create procedure update_mailbox
@msgid bigint
as
update tbl_msgbox_master set read_stts ='RD' where msg_id=@msgid
-----------------------------
create procedure sp_read_mail
@msgid bigint
as
select * from tbl_msgbox_master where msg_id =@msgid
-----------------------------
create procedure sp_save_as_draft
@msgid bigint
as
update tbl_msgbox_master set folder='DRAFT' where msg_id=@msgid
-----------------------------
create procedure sp_mail_to_folder_delete
@msgid bigint
as
update tbl_msgbox_master set folder='DELETE' where msg_id=@msgid
-----------------------------
create procedure sp_get_draft_count
@cid bigint
as
select count(*) 'count'  from tbl_msgbox_master  where to_id=@cid and folder='DRAFT'
------------------------------
create procedure sp_get_mails_from_draft
@cid bigint
as
select * from tbl_msgbox_master where to_id=@cid and folder='DRAFT'
-----------------------------
create procedure sp_get_deleted_count
@cid bigint
as
select count(*) 'count'  from tbl_msgbox_master  where to_id=@cid and folder='DELETE'
-----------------------------
create procedure sp_get_mails_from_deleted
@cid bigint
as
select * from tbl_msgbox_master where to_id=@cid and folder='DELETE'
-------------------------------
create procedure sp_sent_count
@cid bigint
as
select count(*) 'count'   from tbl_msgbox_master where from_id=@cid
-----------------------------
create procedure sp_get_sent_mails
@cid bigint
as
select * from tbl_msgbox_master where from_id=@cid
-----------------------------
create procedure sp_chk_fldr_dlt
@msgid bigint
as
select * from tbl_msgbox_master where msg_id=@msgid
-----------------------------
create procedure sp_delete_mail
@msgid bigint
as
delete from tbl_msgbox_master  where msg_id=@msgid
----------------------------------
create procedure sp_login_mailbox
@uname varchar(100),
@pwd varchar(100)
as
select * from tbl_loginers_master where username_=@uname and password_=@pwd
----------------------------------
alter table tbl_loginers_master add  disp_photo varchar(500)
---------------------------------
update tbl_loginers_master set disp_photo='dp\notav.jpg'
---------------------------------
create procedure sp_disp_rcrd_as_mid
@mid int
as
select * from tbl_loginers_master where id=@mid
---------------------------------
create procedure sp_get_tot_unread_msgs_by_to_id
@to_id int
as
select count(*) as count_ from tbl_msgbox_master where to_id=@to_id and read_stts='UN'

---------------------------------
select * from tbl_user_master
---------------------------------

	

---------------------------------
create table tbl_branch_master
	(
		id int primary key,
		branchName varchar(100),
		branch_desc varchar(750)
	
	)
---------------------------------
insert into tbl_branch_master values
	(
		1,
		'kolhapur',
		'kop branch'
	)
---------------------------------
create procedure sp_get_branches
as 
select * from tbl_branch_master
---------------------------------
create procedure sp_chk_username_av_or_not
@thisuname varchar(100)
as
select * from tbl_loginers_master where username_=@thisuname
---------------------------------
create procedure sp_chk_email_av_or_not
@thisemail varchar(100)
as
select * from tbl_user_master where e_mail_id=@thisemail
---------------------------------
create procedure sp_get_count_of_loginers
as
select count(*) as count_ from tbl_loginers_master 
---------------------------------
create procedure sp_count_of_users_ids
as
select count(*) as count_ from tbl_user_master

---------------------------------
create procedure sp_insert_tbl_last_login
@loginerID int
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_last_login)
insert into tbl_last_login values
	(
		@N_id,
		@loginerID,
		'NOT SET'
	)
---------------------------------
alter table tbl_dept_emp_master add e_mel varchar(50)
update tbl_dept_emp_master set e_mel='emel'
---------------------------------
select * from tbl_dept_emp_master

create table tbl_dept_emp_master
	(
		id int primary key,
		dept_id int,
		name_ varchar(100),
		joining_date smalldatetime,
		username_ varchar(100),
		password_ varchar(100),
		secq_q varchar(100),
		secq_ans	varchar(100),
		dept_post	varchar(50),
		CONSTRAINT fk_dept_emp_to_dept FOREIGN KEY (dept_id) REFERENCES tbl_dept_master(id),
	)
---------------------------------
create procedure sp_insert_tbl_dept_emp_master
		@dept_id int,
		@name_ varchar(100),
		@username_ varchar(100),
		@password_ varchar(100),
		@dept_post	varchar(50),
		@e_mel varchar(50)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_dept_emp_master)
insert into tbl_dept_emp_master values
	(
		@N_id,
		@dept_id,
		@name_,
		getdate(),
		@username_,
		@password_,
		'NOT SET',
		'NOT SET',
		@dept_post,
		@e_mel
	)
---------------------------------

select * from tbl_dept_emp_master
---------------------------------
alter procedure sp_get_count_of_dept_emps
as
select count(*) as count_ from tbl_dept_emp_master
---------------------------------

---------------------------------
create procedure sp_insert_insert_ranking
@dept_id int,
@emp_id int
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_deptemp_ranking_master)
insert into tbl_deptemp_ranking_master values (@N_id,@dept_id,@emp_id,'NO')
---------------------------------
create procedure sp_insert_branch
		@branchName varchar(100),
		@branch_desc varchar(750)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_branch_master)
insert into tbl_branch_master values (@N_id,@branchName,@branch_desc)
---------------------------------
create procedure sp_insert_department
		@dept_name varchar(50),
		@dept_desc varchar(150)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_dept_master)
insert into tbl_dept_master values(@N_id,@dept_name,@dept_desc)
---------------------------------

---------------------------------
create procedure sp_insert_HOD
		@name_ varchar(100),
		@username_ varchar(100),
		@password_ varchar(100),
		@phone_number varchar(20),
		@email_id varchar(50),
		@dept_id int
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_HOD_master)
insert into tbl_HOD_master values
	(
		@N_id,
		@name_,
		@username_,
		@password_,
		getdate(),
		@phone_number,
		@email_id,
		@dept_id
	)
---------------------------------
create procedure sp_get_count_oDf_hod
as
select count(*) as count_ from tbl_HOD_master
--------------------------------
ALTER procedure sp_get_addressbook
as
select * from tbl_loginers_master ORDER BY ID DESC

select * from tbl_dept_emp_master
select * from tbl_dept_master

--------------------------------
--------------------------------
select * from tbl_sttss
select * from tbl_loginers_master
insert into tbl_loginers_master values 	(		1051,		'admin',		'12',		'sdfdsfsfs',		'ADMIN',		1,'no'	)

--------------------------------

create procedure sp_insert_loginer
			@id int,
			@username_	varchar(100),
			@password_	varchar(100),
			@display_name varchar(100),
			@who_is		varchar(100),	
			@forign_id int	
as
insert into tbl_loginers_master values 	
	(		@id,
			@username_,
			@password_,
			@display_name,
			@who_is,
			@forign_id,
			'dp/notav.jpg'
	)
---------------------------------
create table tbl_loginers_master	
	(
			id			int primary key,
			username_	varchar(100),
			password_	varchar(100),
			display_name varchar(100),
			who_is		varchar(100),
			forign_id int,
			disp_photo varchar(500)
	)
---------------------------------
alter table tbl_levels add  lvl_code int

---------------------------------
update tbl_levels set lvl_code=101 where id=1
update tbl_levels set lvl_code=102 where id=2
update tbl_levels set lvl_code=103 where id=3
update tbl_levels set lvl_code=104 where id=4
update tbl_levels set lvl_code=105 where id=5
---------------------------------
alter procedure sp_get_lvl_code
@short_key varchar(10)
as
select *  from tbl_levels  where short_key=@short_key
select *  from tbl_levels  where short_key='BE'
---------------------------------
alter procedure sp_count_of_spcil_user
@short_key varchar(10)
as
select* from tbl_loginers_master where who_is=@short_key
select * from tbl_loginers_master where who_is='BE'

--------------------------------- ----------
aLTER procedure sp_get_ticket_by_dept_id
@dept_id int
as
select * from tbl_ticket_master where to_dept_id=@dept_id order by date_  DESC
---------------------------------
create procedure sp_get_loginer_by_id
@l_id int
as
select * from tbl_loginers_master where id=@l_id
update tbl_loginers_master set username_='CCEmp01' where username_='CCeEmp01'
---------------------------------
create procedure sp_get_emp_by_id
@id int
as
select * from tbl_dept_emp_master where id=@id
-------------------------------
alter procedure sp_ticks_by_emer
as
select * from tbl_ticket_master  where t_stts ! = 'SOLVED'
---------------------------------
create procedure sp_get_only_ticket
as
select * from tbl_ticket_master
---------------------------------
create procedure sp_get_loginers_by_whi_is
@wis varchar(10)
as
select * from tbl_loginers_master where who_is=@wis
---------------------------------
alter procedure sp_insert_user	
		@phone_number bigint,		
		@e_mail_id varchar(100),		
		@branch_name varchar(100),		
		@desegnitio_ varchar(25)	
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_user_master)
insert into tbl_user_master values	
	(		@N_id,
			'fName',
			'mName',
			'lName',
			@phone_number,
			@e_mail_id,
			@branch_name,
			'branch Description',
			@desegnitio_
	)

---------------------------------
create procedure sp_hod_exist_or_not
@dept_id int
as
select * from tbl_HOD_master where dept_id=@dept_id
---------------------------------
create procedure sp_chk_dept_exist_or_not
@this_dept_name varchar(100)
as
select * from tbl_dept_master where dept_name=@this_dept_name
---------------------------------
create procedure sp_chk_branch_exist_or_not
@this_branch varchar(100)
as
select * from tbl_branch_master where branchName=@this_branch
---------------------------------
create procedure sp_get_info_by_username
@username varchar(100)
as
select * from tbl_loginers_master where username_=@username

---------------------------------
create procedure sp_update_user_by_forign_id
@fid int ,
@phone_num bigint,
@emel varchar(100)
as
update tbl_user_master set phone_number=@phone_num,e_mail_id=@emel where id=@fid
---------------------------------
create procedure sp_get_info_by_forign_id
@fid int
as
select * from tbl_dept_emp_master where id=@fid
---------------------------------
create procedure sp_update_dept_emp_by_id
@id int,
@email varchar(100)
as
update tbl_dept_emp_master set e_mel=@email where id=@id
---------------------------------
create procedure sp_get_hod_by_id
@f_id int
as
select * from tbl_HOD_master where id=@f_id
---------------------------------
create procedure sp_update_hod_by_id
@fid int,
@phone_num bigint,
@email varchar(100)
as
update tbl_HOD_master set phone_number=@phone_num,email_id=@email where id=@fid
---------------------------------
alter table tbl_admin_ add  email_id varchar(100)
update tbl_admin_ set email_id ='mainadmin@yahoo.com'
---------------------------------
update tbl_admin_ set aid=1
---------------------------------
create procedure sp_get_admin_by_id
@fid int
as
select * from tbl_admin_ where aid=@fid
---------------------------------
create procedure sp_update_admin_by_id
@f_id int,
@new_email varchar(100)
as
update tbl_admin_ set email_id=@new_email where aid=@f_id
---------------------------------

create procedure sp_get_branch_by_branch_name
@branch_name varchar(100)
as
select * from tbl_branch_master where branchName=@branch_name
---------------------------------
create procedure sp_brnach_name_change_exist_or_not
@origin_branch_name varchar(100),
@changed_b_name varchar(100)
as
select * from tbl_branch_master where branchName !=@origin_branch_name and branchName=@changed_b_name
---------------------------------
create procedure sp_dept_name_change_exist_or_not
@origin_dept_name varchar(100),
@changed_d_name varchar(100)
as
select * from tbl_dept_master where dept_name !=@origin_dept_name and dept_name=@changed_d_name
---------------------------------
create procedure sp_get_branch_by_name
@branchName varchar(100)
as
select * from tbl_branch_master where branchName=@branchName
---------------------------------
create procedure sp_update_brnch_info_by_id
@id int,
@new_name varchar(100),
@new_dec varchar(100)
as
update tbl_branch_master set  branchName=@new_name,branch_desc=@new_dec  
---------------------------------
create procedure sp_update_dept_info_by_id
@id int,
@new_name varchar(100),
@new_dec varchar(100)
as
update tbl_dept_master set dept_name=@new_name, dept_desc=@new_dec where id=@id
----------------------unpub-----------------
ALTER procedure sp_get_solved_for_admin
as
select * from tbl_ticket_master where  t_stts='SOLVED' ORDER BY DATE_ DESC
---------------------------------
ALTER procedure sp_get_Unsolved_for_admin
as
select * from tbl_ticket_master where  t_stts !='SOLVED' ORDER BY DATE_ DESC
---------------------------------
create procedure sp_get_dept_emp_by_id
@id int
as
select * from tbl_dept_emp_master  where id=@id
---------------------------------
create procedure sp_get_dept_emp_id_by_username
@uname varchar(100)
as
select * from tbl_dept_emp_master where username_=@uname
---------------------------------
alter procedure sp_get_unsolved_ticks_by_branch
@branch_name varchar(100)
as
select * from tbl_ticket_master where from_branch=@branch_name and t_stts !='SOLVED'
---------------------------------
create procedure sp_get_all_ticks_by_branch_name
@branch_name varchar(100)
as
select * from tbl_ticket_master where from_branch=@branch_name 

---------------------------------
create procedure sp_get_solved_ticks_by_branch_name
@branch_name varchar(100)
as
select * from tbl_ticket_master where from_branch=@branch_name and t_stts='SOLVED'
---------------------------------
create procedure sp_get_Unsolved_ticks_by_branch_name
@branch_name varchar(100)
as
select * from tbl_ticket_master where from_branch=@branch_name and t_stts !='SOLVED'
---------------------------------
create procedure sp_get_disp_name_by_loginer_id
@lid int
as
select * from tbl_loginers_master where id=@lid

---------------------------------
update tbl_dept_master set dept_name='IT' where id=1
update tbl_dept_master set dept_desc='Customercare dept' where id=2



create procedure sp_update_branch_info_by_id
@id int,
@new_name varchar(100),
@new_dec varchar(100)
as
update tbl_branch_master set branchName=@new_name, branch_desc=@new_dec where id=@id
----------------------01_11_2010-----------------
alter procedure sp_write_last_login_by_loginer_id
@loginerID int,
@time_value varchar(150)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_last_login)
insert into tbl_last_login values (@N_id,@loginerID,@time_value)
-----------------------------
create procedure sp_get_login_historu_by_id
@loginerID int
as
select  * from tbl_last_login where loginerID=@loginerID

-----------------------------
create procedure sp_get_tick_by_timespan
@val1 smalldatetime,
@val2 smalldatetime
as
select * from tbl_ticket_master where date_  between @val1 and @val2
-----------------------------02_11_2010------------------
alter table tbl_ticket_master add q_typ varchar(100)
select * from tbl_ticket_master
update tbl_ticket_master set q_typ='NORMAL'
-----------------------------


-----------------------------
create procedure sp_chage_q_stts_by_tid
@tid int
as
update tbl_ticket_master set q_typ='ESCALATED' where t_id=@tid

---------------------------10_11_2010----------------
delete from tbl_levels where id=1
delete from tbl_levels where id=2
---------------------------12_11_2010----------------
delete from admin_updates_master
delete from tbl_branch_master
delete from tbl_posts_master
delete from tbl_ticket_master
delete from tbl_user_master
delete from user_updates_master
delete from tbl_msgbox_master
delete from tbl_last_login
delete from tbl_HOD_master
delete from tbl_deptemp_ranking_master
delete from tbl_dept_emp_master
delete from tbl_dept_master
delete from tbl_branch_master
delete from tbl_branch_master where username_!='ADMIN'
delete from tbl_loginers_master where username_!='ADMIN'

select * from tbl_deptemp_ranking_master
select * from tbl_dept_emp_master
select * from tbl_user_master
select * from tbl_loginers_master
select * from tbl_levels
-------------------13_11_2010--------------
insert into tbl_levels values(1,'BRANCH EMPLOYEE','BE',101)
insert into tbl_levels values(2,'BRANCH HEAD','BH',102)
-------------------16_11_2010------------------------
create procedure sp_get_info_by_id
@id int
as
select * from tbl_loginers_master where id=@id
----------------------19_11_2010---------------------------------
--
select * from tbl_ticket_master where t_stts like '%%' and to_dept_id like '%%' and q_typ like '%%' and date_ between '01/10/2010' and '04/12/2010'


alter procedure sp_view_all_queryes
@t_stts varchar(25),
@to_dept_id varchar,
@date_from smalldatetime,
@date_to smalldatetime,
@q_typ varchar(100)
as
select * from tbl_ticket_master where t_stts like @t_stts and to_dept_id like @to_dept_id and q_typ like @q_typ and date_ between @date_from and @date_to order by t_id desc
 
-----------------------------
alter procedure sp_insert_tbl_ticket_master
		@t_sub varchar(500),
		@t_desc varchar(1000),
		@attatchment_url varchar(100),
		@creater_id int,
		@disp_id bigint,
		@to_dept_id int,
		@from_branch varchar(50),
		@hand_in varchar(50),
		@pro_to_dept_emoID int		
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(t_id)+1,1)from tbl_ticket_master)
insert into tbl_ticket_master values (@N_id,@t_sub,@t_desc,@attatchment_url,@creater_id,getdate(),'UNSOLVED',getdate(),@hand_in,@disp_id,@to_dept_id,@from_branch,@pro_to_dept_emoID,'normal')
-----------------------------
select * from tbl_sttss
delete from tbl_sttss where stt_id=1
delete from tbl_sttss where stt_id=2
update tbl_sttss set stts_name='UNSOLVED' where stt_id=3
update tbl_sttss set stt_id=1 where stt_id=3
update tbl_sttss set stt_id=2 where stt_id=4
----------------------------
update tbl_ticket_master set t_stts='UNSOLVED' where t_stts !='SOLVED'
----------------------------
update tbl_ticket_master set q_typ='Transferred' where t_stts ='TRANSFERED'
update tbl_ticket_master set q_typ='Escalated' where t_id=1
update tbl_ticket_master set q_typ='Normal' where t_id=2

select * from tbl_ticket_master
-------------------------
backup database MyDatabase to disk='D:/my.bak'

restore database MyDatabase from disk='D:/my.bak'
WITH replace
-----------------------------
create table tbl_backup_master
	(
		id int primary key,
		bk_date smalldatetime,
		temp_ varchar(100)
	)
-----------------------------
create procedure sp_backup_feel
@this_date smalldatetime
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_backup_master)
insert into tbl_backup_master values (@N_id,@this_date,'None')
-----------------------------
alter procedure sp_take_backup
as
backup database sri_sri_projecter to disk='D:/my.bak'
-----------------------------
create procedure sp_restore_database
as
restore database sri_sri_projecter from disk='D:/my.bak'
WITH NORECOVERY, STOPAT = 'Apr 15, 2005 12:00 AM' 
  
-----------------------------
create procedure sp_edit_user_master_branch_name
@old_benach_name varchar(100),
@new_branch_name varchar(100)
as
update tbl_user_master set branch_name=@new_branch_name where branch_name=@old_benach_name
-----------------------------
---------------------------------
alter procedure sp_update_loginer_by_username
@username varchar(100),
@disp_name varchar(100),
@password_ varchar(100)
as
update tbl_loginers_master set display_name=@disp_name , password_=@password_ where username_=@username
---------------------------------
select * from tbl_ticket_master
update tbl_ticket_master set q_typ='normal' where  q_typ='NORMAL'
-----------------25_11_2010----------------

alter procedure sp_change_leve
@tid int,
@short_key varchar(50)
as
update tbl_ticket_master set now_hand_in=@short_key, last_update_date=getdate()  where t_id=@tid
update tbl_ticket_master set q_typ='Transferred' where t_id=@tid
---------------------------------
create procedure sp_get_ticket_only
as
select * from tbl_ticket_master where q_typ='Transferred'
---------------------------------
update tbl_ticket_master set q_typ='ESCALATED' where q_typ='Escalated'
---------------------------------27_11_2010
create procedure sp_get_hod_by_dept_id
@dept_id int
as
select * from tbl_HOD_master where dept_id=@dept_id
---------------------------------02_12_2010
create procedure sp_del_ticket_by_id
@tid int
as
delete from tbl_posts_master where ticket_id=@tid
delete from tbl_ticket_master where t_id=@tid
---------------------------------04_12_2010
create procedure sp_err_curr_1
as
update tbl_ticket_master set now_hand_in='DE' where now_hand_in='BE'
---------------------------------
create procedure sp_ticket
as
select * from tbl_ticket_master where t_stts='UNSOLVED'
---------------------------------05_12_2010
create database sri_sri_sample
use sri_sri_sample

---------------------------------
create table tbl_backup_master
	(
		id int primary key,
		bk_date smalldatetime,
		temp_ varchar(100)
	)
-----------------------------
create procedure sp_backup_feel
@this_date smalldatetime
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_backup_master)
insert into tbl_backup_master values (@N_id,@this_date,'None')
-----------------------------
alter procedure sp_take_backup
as
backup database sri_sri_projecter to disk='D:/sri_sri_bk.bak'

-----------------------------
alter procedure sp_restore_database
as
restore database sri_sri_projecter from disk='D:/sri_sri_bk.bak'
WITH REPLACE   
-----------------------------------------08_12_2010

alter procedure sp_resend_tick
@tid int,
@res_to varchar(50)
as
update tbl_ticket_master set now_hand_in=@res_to ,  t_stts='UNSOLVED' where t_id=@tid
--------------------------------
create table tbl_deleted_ticket_master
	(
		t_id int primary key,
		t_sub varchar(500),
		t_desc varchar(1000),
		attatchment_url varchar(100),
		creater_id int,
		date_ smalldatetime,	
		t_stts varchar(50),
		last_update_date smalldatetime,	
		now_hand_in varchar(50),
		disp_id bigint,
		to_dept_id int,
		from_branch varchar(100),
		pro_to_dept_emoID  int,
		q_typ varchar(100),
		CONSTRAINT fk_del_query_to_dept_id FOREIGN KEY (to_dept_id) REFERENCES tbl_dept_master(id),
		CONSTRAINT fk_del_query_to_to_dept_emp_id FOREIGN KEY (pro_to_dept_emoID) REFERENCES tbl_dept_emp_master(id)
	)
-----------------------------------------
create table tbl_deleted_posts_master
	(
		tp_id bigint primary key,
		ticket_id int,
		post_ varchar(750),
		tp_date smalldatetime,
		creater_id bigint,
		creater_type varchar(50),
		attch_url varchar(100),		
	)
-----------------------------------------
create procedure sp_get_post_by_ticket
@tid int
as
select * from tbl_posts_master where ticket_id=@tid
-----------------------------------------
create procedure sp_transfer_single_posts
@tp_id int,
@ticket_id int
as
Declare @post_ varchar(750);
Declare @tp_date smalldatetime;
Declare @creater_id bigint;
Declare @creater_type varchar(50);
Declare @attch_url varchar(100);	 
set @post_=(select post_ from tbl_posts_master where tp_id=@tp_id)
set @tp_date=(select tp_date from tbl_posts_master where tp_id=@tp_id)
set @creater_id=(select creater_id from tbl_posts_master where tp_id=@tp_id)
set @creater_type=(select creater_type from tbl_posts_master where tp_id=@tp_id)
set @attch_url=(select attch_url from tbl_posts_master where tp_id=@tp_id)
insert into tbl_deleted_posts_master values (@tp_id,@ticket_id,@post_,@tp_date,@creater_id,@creater_type,@attch_url)
delete from tbl_posts_master where tp_id=@tp_id
-----------------------------------------
create procedure sp_transfer_single_ticket
@ticket_id int
as
Declare @t_sub varchar(500);
Declare @t_desc varchar(1000);
Declare @attatchment_url varchar(100);
Declare @creater_id int;
Declare @date_ smalldatetime;	
Declare @t_stts varchar(50);
Declare @last_update_date smalldatetime;	
Declare @now_hand_in varchar(50);
Declare @disp_id bigint;
Declare @to_dept_id int;
Declare @from_branch varchar(100);
Declare @pro_to_dept_emoID  int;
Declare @q_typ varchar(100); 
set @t_sub=(select t_sub from tbl_ticket_master where t_id= @ticket_id)
set @t_desc=(select t_desc from tbl_ticket_master where t_id= @ticket_id)
set @attatchment_url=(select attatchment_url from tbl_ticket_master where t_id= @ticket_id)
set @creater_id=(select creater_id from tbl_ticket_master where t_id= @ticket_id)
set @date_=(select date_ from tbl_ticket_master where t_id= @ticket_id)
set @t_stts=(select t_stts from tbl_ticket_master where t_id= @ticket_id)
set @last_update_date=(select last_update_date from tbl_ticket_master where t_id= @ticket_id)
set @now_hand_in=(select now_hand_in from tbl_ticket_master where t_id= @ticket_id)
set @disp_id=(select disp_id from tbl_ticket_master where t_id= @ticket_id)
set @to_dept_id=(select to_dept_id from tbl_ticket_master where t_id= @ticket_id)
set @from_branch=(select from_branch from tbl_ticket_master where t_id= @ticket_id)
set @pro_to_dept_emoID=(select pro_to_dept_emoID from tbl_ticket_master where t_id= @ticket_id)
set @q_typ=(select q_typ from tbl_ticket_master where t_id= @ticket_id)
insert into tbl_deleted_ticket_master values (@ticket_id,@t_sub,@t_desc,@attatchment_url,@creater_id,@date_,@t_stts,@last_update_date,@now_hand_in,@disp_id,@to_dept_id,@from_branch,@pro_to_dept_emoID,@q_typ)
delete from tbl_ticket_master where t_id= @ticket_id
-----------------------------------------
create procedure sp_get_ticket_by_emp_id_2
@emp_id int
as
select * from tbl_ticket_master where pro_to_dept_emoID=@emp_id and q_typ !='DELETE'  order by date_ desc
-----------------------------------------
alter procedure sp_change_tick_by_typ
@tid int
as
update tbl_ticket_master set q_typ='DELETE' where t_id= @tid and t_stts='SOLVED'
-----------------------------------------
create procedure sp_get_deleted_ticks_by_emp_id
@emp_id int
as
select * from tbl_ticket_master where pro_to_dept_emoID=@emp_id and q_typ ='DELETE'  order by date_ desc
-----------------------------------------
create procedure sp_restore_ticket
@tid int
as
update tbl_ticket_master set q_typ='normal' where t_id= @tid
-----------------------------------------
create procedure sp_change_pwd_by_l_id
@l_id int,
@new_pwd varchar(100)
as
update tbl_loginers_master set password_=@new_pwd where id=@l_id
-----------------------------------------31_12_2010
alter procedure sp_update_hand_stts_by_tid
@tid int,
@hnd_stts varchar(50)
as
update tbl_ticket_master set now_hand_in=@hnd_stts where t_id=@tid and t_stts !='FOLLOW UP'
-----------------------------------------
insert into tbl_sttss values(3,'FOLLOW UP','NO')
-----------------------------------------


select * from tbl_sttss


update tbl_ticket_master set q_typ='normal' where q_typ='NORMAL'



select * from tbl_posts_master where ticket_id=104

select * from tbl_ticket_master where q_typ !='normal' and  q_typ !='ESCALATED'
 
select * from tbl_deleted_ticket_master 

select * from tbl_deleted_posts_master

select * from tbl_loginers_master	
-----------------------------------------
select * from tbl_ticket_master where date_ between '2010-12-15 16:31:00' and '2010-12-30 23:59:59' order by t_id desc
select * from tbl_ticket_master where t_id=27