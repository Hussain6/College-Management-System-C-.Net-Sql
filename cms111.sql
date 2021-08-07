use CMS1


select * from studentinfo
insert into teacherinfo values(@tname,@tcnic,@tgender,@treligion,@tdateofjoining,@taddress,@tnationality,@tcontact,@tdob,@tclass,@tsection);

select t_id as 'Teacher ID' , t_name as 'Name' , t_cnic as 'CNIC' , t_gender as 'Gender', t_religion as 'Religion', t_dateofjoining as 'Date of Joining', t_homeaddress as 'Home Address', t_nationality as 'Natinality' , t_contact as 'Contact', t_dob as 'DOB' , t_class as 'Class' , t_section as 'Section' from teacherinfo

update teacherinfo set t_class='Fs.c' where t_id='1'

create table feedeposit(
f_id int identity(1,1) primary key,
s_ID int foreign key references studentinfo(s_ID),
s_submittedfee int,
s_arrears int,
s_Dateofsubmission date,
)
select * from feedeposit
insert into feedeposit values(@sid,sfee,@sarrears,@sdate)
delete from feedeposit where f_id='2'

DBCC CHECKIDENT ('feedeposit', RESEED, 0)

create view feerecords as 
select feedeposit.f_id as 'Fee ID', studentinfo.s_ID as 'Student ID',
studentinfo.s_Name as 'Student Name',studentinfo.s_CNIC as 'CNIC',
studentinfo.s_Class as 'Class',studentinfo.s_Section as 'Section',
feedeposit.s_submittedfee as 'Submitted Fee',feedeposit.s_arrears as 'Arrears',
feedeposit.s_Dateofsubmission as 'Date of Submission'
from feedeposit inner join studentinfo on feedeposit.s_ID=studentinfo.s_ID

select * from feerecords

drop view feedetails

create view basicinfo as 
select s_ID as 'Student ID',s_Name as 'Student Name',s_FatherName as 'Father Name',s_Gender as 'Gender',s_FatherContactNo as 'Father Contact No.',s_StudentContactNo as 'Student Contact No.',
s_DOB as 'Date of Birth' from studentinfo

alter view basicinfo as
select s_ID as 'Student ID',s_Name as 'Student Name',s_FatherName as 'Father Name'
,s_Gender as 'Gender',s_FatherContactNo as 'Father Contact No.',s_StudentContactNo as 'Student Contact No.',
s_DOB as 'Date of Birth' ,s_Class as 'Class', s_Section as 'Section' from studentinfo

select * from basicinfo

create proc sectionalview @class varchar(25),@section varchar(25) as 
select [Student ID],[Student Name],[Father Name],Gender,[Father Contact No.],[Student Contact No.],[Date of Birth] from basicinfo
where Class=@class and Section=@section

exec sectionalview 'Fs.c' ,'Section - A'

create table librarybooks(
b_id int identity(1,1) primary key,
b_isbn varchar(50),
b_title varchar(200),
b_author varchar(200),
b_publishers varchar(200),
b_publishingyear date,
)
drop table librarybooks
insert into librarybooks values(@b_isbn,@b_title,@b_author,@b_publisher,@b_date)
select * from librarybooks

select * from books where [Book ID] Like '%3%'
delete from librarybooks where b_isbn=@b_isbn
create view books as 
select b_id as 'Book ID',b_isbn as 'ISBN' , b_title as 'Book Title' ,
b_author as 'Book Author',b_publishers as 'Publishers',b_publishingyear as 'Publication Date'  from librarybooks

update librarybooks set b_isbn=@b_isbn , b_title=@b_title,b_author=@b_author,b_publishers=@b_publishers,b_publishingyear=@b_publishingyear where b_isbn=@b_isbn

create table bookissue(
issue_id int identity(1,1) primary key,
b_id int foreign key references librarybooks(b_id),
b_title varchar(200),
b_isbn varchAR(100),
s_ID int foreign key references studentinfo(s_ID),
s_Name varchar(100),
s_Class varchar(25),
s_Section varchar(25),
issue_date date,
return_date date,
)
DROP TABLE bookissue
insert into bookissue values('2','Twilight (The Twilight Saga, Book 1)','0316015849','1','Waqas','IC.s (Physics)','Section - A','2021-06-10','2021-06-30')

select * from studentinfo
select * from books
select * from bookissue
select * from librarybooks
select * from bookissueview
select * from basicbooksinfo
select * from basicstudentinfo

drop view bookissueview
create view basicbooksinfo as
select b_id as 'Book ID',b_isbn as 'ISBN',b_title as 'Book Title' from librarybooks

create view basicstudentinfo as
select s_ID as 'Student ID' ,s_Name as 'Student Name',s_Class as 'Class',s_Section as 'Section' from studentinfo

create view bookissueview as
select issue_id as 'Issue ID',b_id as 'Book ID' ,s_ID as 'Student ID' , s_Name as 'Student Name',b_title as 'Book Title',b_isbn as 'ISBN',s_Class as 'Class' ,s_Section as 'Section' ,issue_date as 'Issue Date' , return_date as 'Return Date'  from bookissue
