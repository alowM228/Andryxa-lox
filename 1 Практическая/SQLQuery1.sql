create database sq1;

create table group_
(
	Id_group_ int identity (1,1) primary key,
	training_course int,
	department_number int,
	head_of_the_department varchar(255)

);

create table student
(
	Id_student  int identity (1,1) primary key,
	FIO varchar (255),
	date_of_birth int,
	group_number_id int NOT NULL

	constraint [FK_Student_Group] foreign key (group_number_id)
		references group_ (Id_group_),

);

INSERT into group_
(training_course, department_number, head_of_the_department)
output inserted.training_course,
		inserted.department_number,
		inserted.head_of_the_department
	values(2,3,'Моргенштрен'),
	      (3,4,'Скриптонит');

INSERT into student
 (FIO, date_of_birth)
 output inserted.FIO,
		inserted.date_of_birth
	values('Смирнов Антон Михайлович' ),




drop table  student,group_
go

select * from student;
go

select * from group_;
go