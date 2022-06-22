create database testCrud;
use testCrud;
drop table accounts

create table accounts (
	ID int identity(1, 1) primary key,
	firstName varchar(50) not null,
	lastName varchar(50) not null,
	email varchar(255) not null,
	phoneNumber int not null,
	gender varchar(6) NOT NULL CHECK (gender IN('Male', 'Female'))
);
