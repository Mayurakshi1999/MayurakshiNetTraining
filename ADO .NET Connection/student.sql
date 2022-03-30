
create table dbo.Student
(
Id int identity(1,1) primary key,
FirstName varchar(20),
Lastname varchar(20),
RollNo int,
Marks decimal(10,2)
)

insert Student
(FirstName, Lastname,RollNo,Marks)
values ('Sangbida','Roy',1234,100.12)

select top 10* from Student
/*
FirstName,
Lastname,
RollNo,
Marks
*/
DECLARE @i int=0, @length int,
@fn varchar(20),
@ln varchar(20),
@rollNo int,
@marks decimal(10,2);

SET @i=1;
SET @length=5;

WHILE(@i<=5)
BEGIN

set @fn=null;
set @ln=null;
set @rollNo=null;
set @marks=null;

select @fn= FirstName,@ln= Lastname,@rollNo= RollNo,@marks= Marks from Student where Id=@i;

print 'FirstName- '+ @fn
print concat('LastName- ',@ln)
print @rollNo
Print 'Roll No- '+convert(varchar(20),@rollNo)

--
/*
Code Block
*/
SET @i=@i+1;
END



go;
create procedure dbo.CreateStudent(
@firstName varchar(20),
@lastname varchar(20),
@rollNo int,
@marks decimal(10,2))
as
begin

insert Student (FirstName,Lastname,RollNo,Marks)
values (@firstName,@lastname,@rollNo,@marks);
select SCOPE_IDENTITY() Id;
end