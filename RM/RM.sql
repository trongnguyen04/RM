create database RM
use Rm
go
create table users(
userID int primary key identity,
username varchar(50) not null,
upass varchar(10) not null,
uName varchar(50) not null,
uphone varchar(20)
)
go

create table tables
(
tid int primary key identity,
tname varchar(15)
)
create table category
(
catID int primary key identity,
catName varchar(50)
)
insert into users
values('admin',123,'User1','256-253666')