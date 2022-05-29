create database testCrud;
use testCrud;
create table accounts (
	fristName varchar(10) not null,
	lastName varchar(10) not null,
	email varchar(255) not null,
	phoneNumber int not null,
	gender varchar(6) NOT NULL CHECK (gender IN('Male', 'Female'))
);

select * from accounts;
-- insert quiry
insert into accounts(fristName, lastName,email,phoneNumber,gender) values ('test','test','test@gmail.com',20202020,'Male');