create database QuanLyDeThi
go

use QuanLyDeThi
go

create table UserRole(
	Id int identity(1,1) primary key,
	RoleName nvarchar(200),
	CreateDate DateTime default CURRENT_TIMESTAMP,
	ModifyDate DateTime default CURRENT_TIMESTAMP
)
go
insert into UserRole(RoleName) values(N'Administrator')
go
insert into UserRole(RoleName) values(N'User')
go
create table Users(
	Id int identity(1,1) primary key,
	UserName nvarchar(200),
	DisplayName nvarchar(250),
	Password nvarchar(250),
	IdRole int not null,
	CreateDate DateTime default CURRENT_TIMESTAMP,
	ModifyDate DateTime default CURRENT_TIMESTAMP

	foreign key (IdRole) references UserRole(Id)
)
go
create table Lesson(
	Id int identity(1,1) primary key,
	LessonName nvarchar(max),
	AnswerTime int,
	CreateDate DateTime default CURRENT_TIMESTAMP,
	ModifyDate DateTime default CURRENT_TIMESTAMP,
	UserCreatedId int

	foreign key (UserCreatedId) references Users(Id)
)

go
create table Questions(
	Id int identity(1,1) primary key,
	LessonId int,
	QuestionTitle nvarchar(max),
	QuestionContent nvarchar(max),
	QuestionType int,
	Level int,
	A nvarchar(1000),
	B nvarchar(1000),
	C nvarchar(1000),
	D nvarchar(1000),
	Answer nvarchar(2),
	CreateDate DateTime default CURRENT_TIMESTAMP,
	ModifyDate DateTime default CURRENT_TIMESTAMP

	foreign key (LessonId) references Lesson(Id)
)
go
create table Produce(
	Id int identity(1,1) primary key,
	UserId int not null,
	Correct int,
	Wrong int,
	Point int,
	AnswerDate DateTime

	foreign key (UserId) references Users(Id)
)
go
create table ClassRoom(
	Id int identity(1,1) primary key,
	Name nvarchar(200),
)

go
create table Student(
	StudentCode int identity(1,1) primary key,
	StudentName nvarchar(200),
	BirthDay DateTime,
	TeacherName nvarchar(200),
	IdentityNumber nvarchar(200),
	ClassId int,
	Mobile nvarchar(20),
	Email nvarchar(150),
	CreateDate DateTime default CURRENT_TIMESTAMP,
	ModifyDate DateTime default CURRENT_TIMESTAMP

	foreign key (ClassId) references ClassRoom(Id)
)
