create database razor
use razor

create table student
(
sid int identity primary key,
name varchar(50),
age int,
country int
)

select * from student
truncate table student
alter table student add country int
alter table student add state int

------------------------------------------------

create table country 
(
cid int primary key identity,
cname varchar(50)
)

insert into country (cname) values ('India')
insert into country (cname) values ('Sri Lanka')
insert into country (cname) values ('Nepal')


select * from country
truncate table country
drop table country

---------------------------------------------------

create table state
(
stid int primary key identity,
cntry_id int,
sname varchar(50)
)

insert into state (cntry_id, sname) values (1 , 'Uttrakhand')
insert into state (cntry_id, sname) values (1, 'New Delhi')

insert into state (cntry_id, sname) values (2 , 'Colombo')
insert into state (cntry_id, sname) values (2, 'ad')

insert into state (cntry_id, sname) values (3 , 'bc')
insert into state (cntry_id, sname) values (3, 'cd')

select * from state
drop table state

----------------------------------------------------------



