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
update accounts SET
	fristName = @fName,
	lastName = @lName,
	email = @email,
	phoneNumber = @phone,
	gender = @gender
		WHERE ID = @ID;

select * from accounts;
-- insert quiry

Select * from accounts where fristName like '%@fName%';

insert into accounts (firstName, lastName,email,phoneNumber,gender)
                                            values
                                            (@fName, @lName, @email, @phone, @gender)