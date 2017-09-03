alter procedure sp_ticket
as
select	id,
		t_sub,
		t_desc,
		attatchment_url,
		creater_id,
		last_update_date,
		now_hand_in,
		to_dept_id,
		from_branch_id,
		q_typ,
		t_stts,
		folder_crtr,
		folder_reciver
		 from tbl_ticket_master where t_stts='UNSOLVED'
------------------------------------------------------------------
alter procedure sp_get_loginer
@uname varchar(150),
@pwd   varchar(150)
as
select 
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_
from tbl_loginer_master where username_=@uname and password_=@pwd
------------------------------------------------------------------
alter procedure sp_read_last_login_by_id
@id int
as
select 
		id,
		loginerID,
		time_value
from tbl_last_login where id=@id
------------------------------------------------------------------
alter procedure sp_get_loginer_details
@id int
as
select 
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_
from  tbl_loginer_master where id=@id
------------------------------------------------------------------
alter procedure sp_get_ticket_stts_by_id
@tid int
as
select 
		id,
		t_sub,
		t_desc,
		attatchment_url,
		creater_id,
		last_update_date,
		now_hand_in,
		to_dept_id,
		from_branch_id,
		q_typ,
		t_stts,
		folder_crtr,
		folder_reciver,
		disp_id,
		Pro_to_emp_id
from tbl_ticket_master  where id=@tid
------------------------------------------------------------------
alter procedure sp_get_username_
@id int 
as
select 
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_
from  tbl_loginer_master where id=@id
------------------------------------------------------------------
alter procedure sp_get_ticket
@tid as int
as
select 
		id,
		t_sub,
		t_desc,
		attatchment_url,
		creater_id,
		last_update_date,
		now_hand_in,
		to_dept_id,
		from_branch_id,
		q_typ,
		t_stts,
		folder_crtr,
		folder_reciver,
		disp_id,
		Pro_to_emp_id
from tbl_ticket_master  where id=@tid
------------------------------------------------------------------
alter procedure sp_get_ticket_by_t_id
@t_id int 
as
select 
		id,
		t_sub,
		t_desc,
		attatchment_url,
		creater_id,
		last_update_date,
		now_hand_in,
		to_dept_id,
		from_branch_id,
		q_typ,
		t_stts,
		folder_crtr,
		folder_reciver,
		disp_id,
		Pro_to_emp_id
from tbl_ticket_master where id=@t_id
------------------------------------------------------------------
alter procedure sp_write_last_login_by_id
@id int,
@time_value varchar(150)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_last_login)
insert into tbl_last_login (id,loginerID,time_value) values (@N_id,@id,@time_value)
------------------------------------------------------------------
alter procedure sp_insert_comment_
@t_id int,
@comm_ nvarchar(4000),
@crtr_id int,
@attch_url nvarchar(200)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_comments_master)
insert into tbl_comments_master
			(id,t_id,comment_,date_,creater_id,creater_post,attch_url) 
			values(@N_id,@t_id,@comm_,getdate(),@crtr_id,'NN',@attch_url)
------------------------------------------------------------------
alter procedure sp_get_dept_by_id
@id int
as
select 
		id,
		dept_name,
		manage_id,
		hod_loginer_id,
		dept_desc		
from tbl_dept_master where id=@id
------------------------------------------------------------------
alter procedure sp_get_user_by_id
@uid bigint 
as
select 
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_
from tbl_loginer_master where id=@uid
------------------------------------------------------------------
alter procedure sp_get_dept_id_by_dept_name
@dept_name varchar(50)
as
select 
		id,
		dept_name,
		manage_id,
		hod_loginer_id,
		dept_desc
from tbl_dept_master where dept_name=@dept_name
------------------------------------------------------------------
alter procedure sp_get_departments
as
select 
		id,
		dept_name,
		manage_id,
		hod_loginer_id ,
		dept_desc
from tbl_dept_master
------------------------------------------------------------------
alter procedure sp_get_details_by_loginer_ID
@loginerID int
as
select 
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_
from  tbl_loginer_master where id=@loginerID
-----------------------------------------------------------------
alter procedure sp_get_details_from_dept_master_by_id
@id		 int
as
select 
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_
from tbl_loginer_master where id=@id
-----------------------------------------------------------------
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
insert into tbl_ticket_master 
	(
		id,
		t_sub,
		t_desc,
		attatchment_url,
		creater_id,
		last_update_date,
		now_hand_in,
		to_dept_id,
		from_branch_id,
		q_typ,
		t_stts,
		folder_crtr,
		folder_reciver,
		disp_id,
		Pro_to_emp_id
	)
values 
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
-----------------------------------------------------------------
alter procedure sp_get_details_by_loginerID
@loginerID int
as
select 
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_	
from  tbl_loginer_master where id=@loginerID
-----------------------------------------------------------------
alter procedure sp_get_only_ticket
as
select 
				id,
		t_sub,
		t_desc,
		attatchment_url,
		creater_id,
		last_update_date,
		now_hand_in,
		to_dept_id,
		from_branch_id,
		q_typ,
		t_stts,
		folder_crtr,
		folder_reciver,
		disp_id,
		Pro_to_emp_id
from tbl_ticket_master
-----------------------------------------------------------------
alter procedure sp_get_deleted_ticks_by_emp_id
@emp_id int
as
select 
				id,
		t_sub,
		t_desc,
		attatchment_url,
		creater_id,
		last_update_date,
		now_hand_in,
		to_dept_id,
		from_branch_id,
		q_typ,
		t_stts,
		folder_crtr,
		folder_reciver,
		disp_id,
		Pro_to_emp_id
from tbl_ticket_master where Pro_to_emp_id=@emp_id and q_typ ='DELETE'  order by last_update_date desc
-----------------------------------------------------------------
alter procedure sp_get_ticket_by_t_id
@t_id int 
as
select 
		id,
		t_sub,
		t_desc,
		attatchment_url,
		creater_id,
		last_update_date,
		now_hand_in,
		to_dept_id,
		from_branch_id,
		q_typ,
		t_stts,
		folder_crtr,
		folder_reciver,
		disp_id,
		Pro_to_emp_id
from tbl_ticket_master where id=@t_id
-----------------------------------------------------------------
alter procedure sp_get_short_key_by_level_name
@leelName varchar(100)
as
select 
		id,
		level_name,
		short_key
from tbl_levels where short_key=@leelName
-----------------------------------------------------------------
alter procedure sp_get_dept_employee
@uname varchar(150),
@pwd   varchar(150)
as
select 
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_	
from tbl_loginer_master where username_=@uname and password_=@pwd
-----------------------------------------------------------------
alter procedure sp_get_hod_depts
@id int
as
select 
		id,
		dept_name,
		manage_id,
		hod_loginer_id,
		dept_desc
from tbl_dept_master where hod_loginer_id=@id
-----------------------------------------------------------------
alter procedure sp_get_user_info_by_loginer_id
@lofiner_id int
as
select 
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_	
from tbl_loginer_master where id=@lofiner_id 
-----------------------------------------------------------------
alter procedure sp_get_dept_id_by_name
@dept_name varchar(100)
as
select 
		id,
		dept_name,
		manage_id,
		hod_loginer_id,
		dept_desc
from tbl_dept_master where dept_name=@dept_name
-----------------------------------------------------------------
alter procedure sp_insert_tbl_Favorites_master
@title nvarchar(100),
@url nvarchar(400)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_Favorites_master)
insert into tbl_Favorites_master
	(id,title,url) 
	values 
	(@N_id,@title,@url)
-----------------------------------------------------------------
alter procedure sp_get_tbl_Favorites_master
as
select 
	id,title,url
from tbl_Favorites_master
-----------------------------------------------------------------
alter procedure sp_chk_username_availabality
as
select 
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_
from tbl_loginer_master
-----------------------------------------------------------------
alter procedure sp_insert_loginer_stape_one
@username_ nvarchar(100),
@password_ nvarchar(100),
@name_ nvarchar(200),
@post_ nvarchar(50),
@phone_number nvarchar(50),
@email_id nvarchar(50)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_loginer_master)
insert into tbl_loginer_master 
	(
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_
	)
values 	
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
-----------------------------------------------------------------
alter procedure sp_get_loginer_by_username
@username_ nvarchar(100)
as
select 
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_
from tbl_loginer_master where username_=@username_
-----------------------------------------------------------------
alter procedure sp_get_branches
as
select 
		id,
		branch_name,
		branch_address
from tbl_branch_master
-----------------------------------------------------------------

-----------------------------------------------------------------
alter procedure sp_get_depts
as
select 
		id,
		dept_name,
		manage_id,
		hod_loginer_id,
		dept_desc
from tbl_dept_master
-----------------------------------------------------------------
alter procedure sp_get_dept_by_name
@dept_name nvarchar(100)
as
select 
		id,
		dept_name,
		manage_id,
		hod_loginer_id,
		dept_desc
from tbl_dept_master where dept_name=@dept_name
-----------------------------------------------------------------
alter procedure sp_insert_rankings
@dept_id int,
@emp_id int
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_deptemp_ranking_master) 
insert into tbl_deptemp_ranking_master 
		(id,Dept_id,emp_id,emp_stt)
		values 
		(@N_id,@dept_id,@emp_id,'NO')
-----------------------------------------------------------------
alter procedure sp_chk_dept_hod_by_dept_name
@dept_name nvarchar(100)
as
select 
		id,
		dept_name,
		manage_id,
		hod_loginer_id,
		dept_desc
from tbl_dept_master where dept_name=@dept_name
-----------------------------------------------------------------
alter procedure sp_chk_branch_name_available_or_not
@branch_name nvarchar(100)
as
select 
		id,
		branch_name,
		branch_address
from tbl_branch_master where branch_name=@branch_name
-----------------------------------------------------------------
alter procedure sp_insert_branch
@branch_name nvarchar(100),
@branch_desc nvarchar(400)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_branch_master) 
insert into tbl_branch_master 
		(id,branch_name,branch_address)
		values 
		(@N_id,@branch_name,@branch_desc)
-----------------------------------------------------------------
alter procedure sp_dept_available_or_not
@dept_name nvarchar(100)
as
select 
		id,
		dept_name,
		manage_id,
		hod_loginer_id,
		dept_desc
from tbl_dept_master where dept_name=@dept_name
-----------------------------------------------------------------
alter procedure sp_insert_dept
@dept_name nvarchar(100),
@dept_desc nvarchar(500),
@mng_id int,
@hod_loginer_id int
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_dept_master)
insert into tbl_dept_master 
		(id,dept_name,manage_id,hod_loginer_id,dept_desc)
		values 
		(@N_id,@dept_name,@mng_id,@hod_loginer_id,@dept_desc)
-----------------------------------------------------------------
alter procedure sp_get_managements
as
select 
		id,
		mng_name,
		mng_desc,
		manager_loginer_id
from  tbl_managements_master
-----------------------------------------------------------------
alter procedure sp_get_managements_by_name
@mng_name nvarchar(100)
as
select 
		id,
		mng_name,
		mng_desc,
		manager_loginer_id
from  tbl_managements_master where mng_name=@mng_name
-----------------------------------------------------------------
alter procedure sp_get_alert_from_loginer
as
select 
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_	
from tbl_loginer_master where forign_id=0
-----------------------------------------------------------------
alter procedure sp_get_alert_from_dept
as
select 
		id,
		dept_name,
		manage_id,
		hod_loginer_id,
		dept_desc
from tbl_dept_master where hod_loginer_id=0
-----------------------------------------------------------------
alter procedure sp_get_dept_less_hod
as
select 
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_	
from tbl_loginer_master where forign_id=0 and post_='HOD'
-----------------------------------------------------------------
alter procedure sp_get_hods
as
select 
id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_	
from tbl_loginer_master where  post_='HOD'
-----------------------------------------------------------------
alter procedure sp_get_hod_less_depts
as
select 
		id,
		dept_name,
		manage_id,
		hod_loginer_id,
		dept_desc
from tbl_dept_master where hod_loginer_id=0
-----------------------------------------------------------------
alter procedure sp_get_loginer_by_username
@username_ nvarchar(100)
as
select 
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_
from tbl_loginer_master where username_ =@username_
-----------------------------------------------------------------
alter procedure sp_search_user
@kw nvarchar(100)
as
select 
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_
from tbl_loginer_master
where username_ like @kw or name_ like @kw or phone_number like @kw or email_id like @kw

-----------------------------------------------------------------
alter procedure sp_get_al_tickets
as
select 
		id,
		t_sub,
		t_desc,
		attatchment_url,
		creater_id,
		last_update_date,
		now_hand_in,
		to_dept_id,
		from_branch_id,
		q_typ,
		t_stts,
		folder_crtr,
		folder_reciver,
		disp_id,
		Pro_to_emp_id
from tbl_ticket_master where t_stts !='COMPLETED'and now_hand_in='EMP' order by last_update_date desc

-----------------------------------------------------------------
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
insert into tbl_approval_master 
		(id,t_id,date,id_crtr,note_crtr,to_,stts,id_rcvr,note_rcvr,dept_id)
		values 
		(@N_id,@t_id,getdate(),@id_crtr,@note_crtr,@to_,'FREEZ',@id_rcvr,'BLANK',@dept_id)

-----------------------------------------------------------------
alter procedure sp_get_approvals
as
select 
		id,
		t_id,
		date,
		id_crtr,
		note_crtr,
		to_,
		stts,
		id_rcvr,
		note_rcvr,
		dept_id
from tbl_approval_master where stts='FREEZ'
-----------------------------------------------------------------
alter procedure sp_get_approvals_to_mng
as
select 
		id,
		t_id,
		date,
		id_crtr,
		note_crtr,
		to_,
		stts,
		id_rcvr,
		note_rcvr,
		dept_id
from tbl_approval_master where stts='FREEZ' and to_='MNG'
-----------------------------------------------------------------

-----------------------------------------------------------------
alter procedure sp_get_approvals_id
@id int
as
select 
		id,
		t_id,
		date,
		id_crtr,
		note_crtr,
		to_,
		stts,
		id_rcvr,
		note_rcvr,
		dept_id
from tbl_approval_master where stts='FREEZ' and id=@id
-----------------------------------------------------------------
alter procedure sp_get_app_by_t_id
@tid int
as
select 
		id,
		t_id,
		date,
		id_crtr,
		note_crtr,
		to_,
		stts,
		id_rcvr,
		note_rcvr,
		dept_id
from tbl_approval_master where t_id=@tid
-----------------------------------------------------------------
alter procedure sp_insert_management
@mng_name nvarchar(100),
@mng_desc nvarchar(500)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_managements_master)
insert into tbl_managements_master 
		(id,mng_name,mng_desc,manager_loginer_id)
		values
		(@N_id,@mng_name,@mng_desc,0)
-----------------------------------------------------------------
alter procedure sp_get_managements_by_mng_name
@mng_name nvarchar(100)
as
select 
		id,
		mng_name,
		mng_desc,
		manager_loginer_id
from tbl_managements_master where mng_name=@mng_name

-----------------------------------------------------------------
alter procedure sp_get_alert_from_managements
as
select 
		id,
		mng_name,
		mng_desc,
		manager_loginer_id
from tbl_managements_master where manager_loginer_id=0
-----------------------------------------------------------------
alter procedure sp_get_management_by_name
@mng_name nvarchar(100)
as
select 
		id,
		mng_name,
		mng_desc,
		manager_loginer_id
from tbl_managements_master where mng_name=@mng_name
-----------------------------------------------------------------
alter procedure sp_get_branch_by_name
@branch_name nvarchar(100)
as
select 
		id,
		branch_name,
		branch_address
from tbl_branch_master where branch_name != @branch_name
-----------------------------------------------------------------
alter procedure sp_get_update_bracnh_name
@ori_branch_name nvarchar(100),
@entered_branch_name nvarchar(100)
as
select 
		id,
		branch_name,
		branch_address
from tbl_branch_master where branch_name != @ori_branch_name and branch_name =@entered_branch_name
-----------------------------------------------------------------
alter procedure sp_updte_dept
@ori_dept_name nvarchar(100),
@new_dept_name nvarchar(100)
as
select 
		id,
		dept_name,
		manage_id,
		hod_loginer_id,
		dept_desc
from tbl_dept_master where dept_name !=@ori_dept_name and dept_name=@new_dept_name
-----------------------------------------------------------------
alter procedure sp_get_management
as
select 
		id,
		mng_name,
		mng_desc,
		manager_loginer_id
from tbl_managements_master
-----------------------------------------------------------------
alter procedure sp_update_mng_1
@ori_mng_name nvarchar(100),
@new_mng_name nvarchar(100)
as
select 
		id,
		mng_name,
		mng_desc,
		manager_loginer_id
from tbl_managements_master where mng_name !=@ori_mng_name and  mng_name=@new_mng_name
-----------------------------------------------------------------
alter procedure sp_get_app_by_t_id
@tid int
as
select 
		id,
		t_id,
		date,
		id_crtr,
		note_crtr,
		to_,
		stts,
		id_rcvr,
		note_rcvr,
		dept_id
from tbl_approval_master
-----------------------------------------------------------------
alter procedure sp_gel_all_branch
as
select 
		id,
		branch_name,
		branch_address
from tbl_branch_master
-----------------------------------------------------------------
alter procedure sp_gep_all_mnagemnts
as
select
		id,
		mng_name,
		mng_desc,
		manager_loginer_id
from tbl_managements_master
-----------------------------------------------------------------
alter procedure sp_chk_username_2
@ori_username nvarchar(100),
@new_username nvarchar(100)
as
select 
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_
from tbl_loginer_master where username_ !=@ori_username and username_=@new_username
-----------------------------------------------------------------
alter procedure sp_insert_login_stts
@loginer_id int
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_login_stts)
insert into tbl_login_stts 
		(id,loginerID,login_stts,reserv)
		values
		(@N_id,@loginer_id,'OFFLINE','BLANK')
-----------------------------------------------------------------
alter procedure sp_get_sttss
as
select 
		id,
		stts_name
from tbl_sttss
-----------------------------------------------------------------
alter procedure sp_get_dept_emp_by_id
@id int
as
select 
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_
from tbl_loginer_master  where id=@id
-----------------------------------------------------------------
alter procedure sp_get_emp_by_dept
@dept_id int
as
select 
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_
from tbl_loginer_master where post_='DE' and forign_id=@dept_id
-----------------------------------------------------------------
alter procedure sp_get_DE_loginer_ids_by_forign_ids
@f_id int
as
select 
		id,
		username_,
		password_,
		name_,
		post_,
		phone_number,
		email_id,
		forign_id,
		block_
from tbl_loginer_master where post_='DE' and forign_id=@f_id
-----------------------------------------------------------------
alter procedure sp_insert_podt
@ticket_id int,
@post_ varchar(750),
@creater_id bigint,
@crtr_typ varchar(50)
as
Declare @N_id varchar(20) ;
set @N_id=(select isnull(max(id)+1,1)from tbl_comments_master)
insert into tbl_comments_master 
		(id,t_id,comment_,date_,creater_id,creater_post,attch_url)
		values 
		(@N_id,@ticket_id,@post_,getdate(),@creater_id,'NN','NA')
-----------------------------------------------------------------
create table Inform_To_
(
	Infto_id		int primary key identity	not null,
	Ticket_id		int							not null,
	Comment			nvarchar(500)				not null,
	Date_			Smalldatetime				not null,
	Rd_Stts			varchar(1)					not null,
	To_Dept_ID		int							not null,
	From_Dept_id	int							not null,
	t_stts			varchar(1)							,

	CONSTRAINT Table_Inform_To_2_Ticket_Id FOREIGN KEY (Ticket_id) REFERENCES tbl_ticket_master(id)	,
	CONSTRAINT Table_Inform_To_2_To_Dept_ID FOREIGN KEY (To_Dept_ID) REFERENCES tbl_dept_master(id)	,
	CONSTRAINT Table_Inform_To_2_From_Dept_id FOREIGN KEY (From_Dept_id) REFERENCES tbl_dept_master(id)	
)
-----------------------------------------------------------------


-----------------------------------------------------------------
alter procedure [dbo].[sp_view_ticket]
@t_id int
as
SELECT  t.t_sub,t.disp_id,b.branch_name,t.t_desc,t.t_stts,d.id as 'dept_id',d.dept_name,l.name_,t.attatchment_url,t.last_update_date,t.pro_to_emp_id
FROM tbl_ticket_master t
INNER JOIN tbl_branch_master b
ON t.from_branch_id = b.id
INNER JOIN tbl_dept_master d
On t.to_dept_id=d.id
INNER JOIN tbl_loginer_master l
On t.creater_id=l.id
where t.id=@t_id
-----------------------------------------------------------------
alter procedure Get_Informs
@Ticket_id		int,
@To_Dept_ID		int,
@From_Dept_id	int
as
select 
	Infto_id,
	Ticket_id,
	Comment,
	Date_,
	Rd_Stts,
	To_Dept_ID,
	From_Dept_id,
	t_stts
	from Inform_To_ 
	where 
	Ticket_id=@Ticket_id			and 
	To_Dept_ID=@To_Dept_ID			and
	From_Dept_id=@From_Dept_id			
-----------------------------------------------------------------
alter procedure get_hods_Informs_Count
@hod_loginer_id	int
as
select 
	i.Infto_id,
	i.Ticket_id,
	i.Comment,
	i.Date_,
	i.Rd_Stts,
	i.To_Dept_ID,
	i.From_Dept_id,
	i.t_stts,
	t.t_sub,
	d.dept_name as 'from_dept_name'
	from Inform_To_ i inner join
	tbl_ticket_master t
	on i.Ticket_id=t.id
	inner join 
	tbl_dept_master d
	on i.From_Dept_id=d.id
	where 
	i.To_Dept_ID in(select id from tbl_dept_master where hod_loginer_id=@hod_loginer_id)			and
	i.Rd_Stts ='N'

-----------------------------------------------------------------
alter procedure inform_to_chk_dept
@Ticket_id		int,
@hod_loginer_id  int

as
select i.*,t.t_sub from Inform_To_ i
inner join tbl_ticket_master t
on i.Ticket_id=t.id
where 
i.Ticket_id	=@Ticket_id		and
i.To_Dept_ID	in(select id from tbl_dept_master where hod_loginer_id=@hod_loginer_id)	

-----------------------------------------------------------------
alter procedure change_info_stts
@Infto_id		int,
@new_stts		varchar(1)
as
update Inform_To_ set 
Rd_Stts=@new_stts 
where 
Infto_id=@Infto_id
--------------------------------08-10-2011---------------------------------
create procedure get_all_hods_Informs_Count
@hod_loginer_id	int
as
select 
	i.Infto_id,
	i.Ticket_id,
	i.Comment,
	i.Date_,
	i.Rd_Stts,
	i.To_Dept_ID,
	i.From_Dept_id,
	i.t_stts,
	t.t_sub,
	d.dept_name as 'from_dept_name'
	from Inform_To_ i inner join
	tbl_ticket_master t
	on i.Ticket_id=t.id
	inner join 
	tbl_dept_master d
	on i.From_Dept_id=d.id
	where 
	i.To_Dept_ID in(select id from tbl_dept_master where hod_loginer_id=@hod_loginer_id)			
-----------------------------------------------------------------

create procedure sp_get_approvals_by_dept_id
@DeptID int
as
select 
		id,
		t_id,
		date,
		id_crtr,
		note_crtr,
		to_,
		stts,
		id_rcvr,
		note_rcvr,
		dept_id
from tbl_approval_master where stts='FREEZ' and dept_id=@DeptID


-----------------------------------------------------------------
create procedure BackupDB_
@PathbackNm		nvarchar(100)
as

BACKUP DATABASE tn_CAREE
TO DISK = @PathbackNm
---------------------------------------06_12_2011--------------------------

-------------------------------------31_12_2011----------------------------

create procedure get_followUpQrys
as
select	id,
		t_sub,
		t_desc,
		attatchment_url,
		creater_id,
		last_update_date,
		now_hand_in,
		to_dept_id,
		from_branch_id,
		q_typ,
		t_stts,
		folder_crtr,
		disp_id,
		t_sub,
		folder_reciver
		 from tbl_ticket_master where t_stts='FOLLOW UP' and now_hand_in !='HOD'
-----------------------------------------------------------------
create procedure sp_update_hand_stts_by_tid_OnFU
@tid int,
@hnd_stts varchar(50)
as
update tbl_ticket_master set now_hand_in=@hnd_stts where id=@tid 
-----------------------------------------------------------------
create procedure get_senders
as
select id,name_ from tbl_loginer_master where post_='BH' or post_='BE' order by name_
-----------------------------------------------------------------

alter procedure [dbo].[sp_view_all_queryes]
@t_stts varchar(25),
@to_dept_id nvarchar(10),
@date_from smalldatetime,
@date_to smalldatetime,
@q_typ varchar(100),
@SenderID	varchar(10),
@BranchID	varchar(10)
as
select					t.disp_id as  'TicketID',
			t.t_sub as 'Subject',
			t.last_update_date as 'Date',
			t.t_stts as 'Status',
			t.now_hand_in as 'Follower',
			t.q_typ as 'TYPE',
			d.dept_name + ' (' + l2.name_ + ')' as 'TO',
			b.branch_name + ' (' + l.name_ + ')' as 'FROM'


from tbl_ticket_master t
inner join tbl_branch_master b
on t.from_branch_id=b.id
inner join tbl_loginer_master l
on t.creater_id=l.id
inner join tbl_dept_master d
on t.to_dept_id=d.id
inner join tbl_loginer_master l2
on t.Pro_to_emp_id=l2.id
where	t.t_stts like @t_stts and t.to_dept_id like @to_dept_id and t.q_typ like @q_typ and t.last_update_date between @date_from and @date_to 
		and t.creater_id  like @SenderID	and	
			t.from_branch_id like @BranchID
order by t.last_update_date desc

-----------------------------------------------------------------
create procedure get_BEH_by_branchID
@branchID nvarchar(10)
as
select id,name_ from tbl_loginer_master where (forign_id like @branchID) and ((post_='BH') or (post_='BE')) order by name_
-----------------------------------------------------------------
alter procedure get_app_emailID
@l_ID		int,
@post_		nvarchar(100)
as
Declare @lDeptID		int
Declare @mngID			int
Declare @post			varchar(10)
Declare @lID			int
Declare @mngLID			int	
Declare @fireEmailID	nvarchar(50)
Declare @Mypost			nvarchar(10)
Declare @HODID			int

set @lID=@l_ID
set @post=@post_
set @lDeptID =(select forign_id from tbl_loginer_master where id=@lID)
if @post='MNG'
	begin
		set @mngID=(select manage_id from tbl_dept_master where id=@lDeptID)
		set @mngLID=(select manager_loginer_id from tbl_managements_master where id=@mngID)
		set @fireEmailID=(select email_id from tbl_loginer_master where id=@mngLID)
	end
else if @post='HOD'
	begin
		set @HODID=(select hod_loginer_id from tbl_dept_master where id=@lDeptID)
		set @fireEmailID=(select email_id from tbl_loginer_master where id=@HODID)
	end
select @fireEmailID as 'EmailID'
--------------------------------13_01_2012---------------------------------
create procedure get_depts4Both
@LoginerTyp	nvarchar(100),
@FrgnID		int
as
--Declare @LoginerTyp	nvarchar(100)
--set @LoginerTyp='MNG'
if  @LoginerTyp='MNG'
	begin
		select * from  tbl_dept_master where manage_id=@FrgnID
	end
else
	begin
		select * from  tbl_dept_master
	end
-----------------------------------------------------------------
alter procedure [dbo].[sp_get_all_ticks_hod_new]
as
select 
			t.disp_id as  'TicketID',
			t.t_sub as 'Subject',
			t.last_update_date as 'Date',
			t.t_stts as 'Status',
			t.now_hand_in as 'Follower',
			t.q_typ as 'TYPE',
			d.dept_name + ' (' + l2.name_ + ')' as 'TO',
			b.branch_name + ' (' + l.name_ + ')' as 'FROM'

from tbl_ticket_master t
inner join tbl_branch_master b
on t.from_branch_id=b.id
inner join tbl_loginer_master l
on t.creater_id=l.id
inner join tbl_dept_master d
on t.to_dept_id=d.id 
inner join tbl_loginer_master l2
on t.Pro_to_emp_id=l2.id 

where q_typ !='DELETE'order by last_update_date desc
-----------------------------------15_01_2011------------------------------

create procedure chk_branchManageisExistOrNot
@branchName		nvarchar(100)
as

select lm.*,br.Branch_Name from tbl_loginer_master		lm
inner join tbl_branch_master			br
on lm.forign_id=br.id

where lm.post_='BH' and  br.branch_name=@branchName
-----------------------------------------------------------------
alter procedure sp_get_branch_by_name
@branch_name nvarchar(100)
as
select 
		id,
		branch_name,
		branch_address
from tbl_branch_master where branch_name=@branch_name
-----------------------------------------------------------------

-----------------------------------------------------------------



select distinct lm.email_id,lm.id from tbl_ticket_master	t
inner join tbl_branch_master						br
on t.from_branch_id=br.id
inner join tbl_loginer_master						lm
on br.id=lm.forign_id

where	t. t_stts='UNSOLVED'	and
		lm.post_='BH'
-----------------------------------------------------------------
alter procedure insert_Inform_To_
@Ticket_id		int,
@Comment		nvarchar(500),
@To_Dept_ID		int,
@From_Dept_id	int
as
Declare	@RetMsg	nvarchar(100)
Declare @ITexst	int
set @ITexst=0

set @ITexst=(select count(*) from Inform_To_	where 
												Ticket_id=@Ticket_id	and
												To_Dept_ID=@To_Dept_ID	and
												From_Dept_id=@From_Dept_id)
if (@ITexst=0)
	begin
		insert into Inform_To_
			(Ticket_id,Comment,Date_,Rd_Stts,To_Dept_ID,From_Dept_id,t_stts)
			values
			(@Ticket_id,@Comment,getdate(),'N',@To_Dept_ID,@From_Dept_id,'N')
		set @RetMsg	='TRUE'
	end
else
	begin
			set @RetMsg	='FALSE'
	end
select @RetMsg as 'val'
-----------------------------------------------------------------
alter procedure sp_get_approvals_to_hod
as
select 
		ap.id,
		ap.t_id,
		ap.date,
		ap.id_crtr,
		ap.note_crtr,
		ap.to_,
		ap.stts,
		ap.id_rcvr,
		ap.note_rcvr,
		ap.dept_id,
		tk.id		as 'ticketID',
		tk.t_sub
from tbl_approval_master			ap
inner join tbl_ticket_master		tk
on ap.t_id=tk.id


where stts='FREEZ' and to_='HOD'

-----------------------------------------------------------------
select * from tbl_ticket_master
select * from tbl_approval_master