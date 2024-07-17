--Functions are similar to stored procedures. Functions can be used as expressions within a SQL statement. Stored procedures cannot be used like that. 
-- There are 2 types of functions in SQL: SVF(Scalar value functions)  and TVF(Table Value Functions). SVF returns single value and TVF returns a collection of data that could be represented as a Table. 
Create Function getEmpCount()
RETURNS Integer
AS
BEGIN
  DECLARE @count INT
  Set @count = (Select Count(*) from EmpTable)
  RETURN @count
END

Select dbo.getEmpCount() as EmpCount

--Create a SVF that gets the DeptName based on Id. 

Create Function GetDeptName(@id int)
RETURNS VARCHAR(50)
AS
BEGIN
DECLARE @deptName varchar(50)
Set @deptName = (Select deptName from DeptTable where deptId = @id)
RETURN @deptName
END

Select EmpName, dbo.GetDeptName(DeptId) as Dept from EmpTable

---------------------Working with DateTime Functions----------------
PRINT GetDate()

--cast is function that is used to typecast from one type to another
Create Function CreateDate(@date date)
RETURNS VARCHAR(50)
AS
BEGIN
DECLARE @retVal varchar(50)
set @retVal = '' + Cast(Day(@date) as varchar(5)) + '/' + Cast(MONTH(@date) as varchar(20)) + '/' + Cast(Year(@date) as varchar(4))
RETURN @retval
END

Print dbo.CreateDate(GetDate())

--Get the age for a given date-------
create function getAge(@dob Date)
RETURNS INT
AS
BEGIN
DECLARE @age INT
Set @Age = DATEDIFF(year, @dob, GETDATE())
RETURN @age
END

PRINT dbo.getAge('01/12/1976')
-------------------Table value functions-------------------
Alter Function GetEmployeesByCity(@city varchar(50))
RETURNS TABLE
AS
RETURN (SELECT * FROM EMPTABLE WHERE empAddress LIKE '%' + @city + '%')

Select EmpName, empAddress from dbo.GetEmployeesByCity('en')