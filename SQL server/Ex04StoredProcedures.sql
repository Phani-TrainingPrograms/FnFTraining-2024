--Stored Procedures: Pre-parsed statements that are created to be used quite frequently in ur front end app development. 
--variables in Sql server is defined using prefix @. 
Create Procedure CreateEmployee
(
	@ename varchar(50),
	@eaddress varchar(200),
	@esalary money,
	@edept int
)
AS
Insert into EmpTable values(@ename, @eaddress, @esalary, @edept)


-------------Call the stored proc--------------
EXEC [dbo].CreateEmployee
	@ename = 'Robert',
	@eaddress = 'Bangalore',
	@esalary = 56000,
	@edept = 6
GO

Select * from emptable where empname ='Robert'

--todo : Create a stored procedure called UpdateEmployee that takes inputs of all the empdata which has to be updated based on the empid. and finally execute it to see the results. 



