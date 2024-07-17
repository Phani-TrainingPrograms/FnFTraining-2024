---------Data Query Language Operations--------------------
select * from emptable
select * from DeptTable

select * from Emptable where empAddress ='Pune'

select * from Emptable where EmpName like '%ha%' --Filtering

select * from EmpTable where empAddress = 'Bangalore' and empSalary > 50000

-------------SQL Server Scalar Value Functions---------------
Select Max(EmpSalary) as MaxSalary, Min(EmpSalary) as MinSalary, Avg(EmpSalary)  as AvgSalary from EmpTable
--SVFs return single value and can be used as Expressions within the SQL statements. 

Select Top(10) EmpName,EmpSalary from EmpTable where empSalary > 40000
ORDER BY empSalary DESC

Select Top 50 PERCENT * from EmpTable

-----------Todo: Get the bottom 50% of employees from the List using ----
SELECT * FROM
(SELECT TOP 50 PERCENT * From EmpTable ORDER BY EmpId DESC) TEMP ORDER BY EmpId ASC

-------------------------Joins Examples----------------------
Select empTable.EmpName, deptTable.DeptName from emptable join deptTable on EmpTable.DeptId = DeptTable.DeptId 
--This is equi-join as it allows to get common data based on a matching condition. 

--Write a query to set the DeptId as null for a random set of employees 
DECLARE @NumberOfRowsToUpdate INT = 25;

WITH RandomRows AS (
    SELECT TOP (@NumberOfRowsToUpdate) *
    FROM EmpTable
    ORDER BY NEWID()
)
UPDATE RandomRows
SET DeptId = NULL;
--get all the rows whose Deptid is null
Select Count(*) from emptable where deptId is null

--Left join is used to get all values of the left side table with only the matching values from the right table. There is possibility of loosing data 
Select EmpTable.*,COALESCE(DeptTable.Deptname, 'Not set') from Emptable left join DeptTable on EmpTable.DeptId = DeptTable.DeptId
--COALESCE is used to replace the value for a given field

Insert into DeptTable values('House Keeping')
Insert into DeptTable values('IT Team')

--Right join is opp of left join.
Select EmpTable.* , DeptTable.Deptname from emptable right join DeptTable on emptable.DeptId = DeptTable.DeptId

----------------------------Group by clause------------
--find count of employees grouped by city. 
Select Count(EmpName), EmpAddress from Emptable group by  empAddress order by empAddress
--when using group by, the select elements should be the part of the group by or it should be an aggregate function.

--I want to get the distribution of salaries in each city displayed on City with highest salary..

select EmpTable.empAddress, Sum(EmpTable.empSalary) as totalSalaries from emptable group by empAddress order by totalSalaries 
--Get the MaxSalary, MinSalary, Avg Salary for each city in the emptable. 
Select empaddress, Max(empsalary) as maxSalary, min(empsalary) as minsalary, avg(empSalary) as AvgSalary from emptable group by empaddress 
order by empAddress

--Get the list of employees who salary is more than the avg salary in their city. 
SELECT e.empname, e.empAddress, e.empSalary, avg_salaries.avg_salary as AvgSalary FROM emptable e
JOIN (
    SELECT empAddress, AVG(empsalary) AS avg_salary
    FROM emptable
    GROUP BY empAddress
) as avg_salaries ON e.empAddress = avg_salaries.empAddress
WHERE e.empsalary > avg_salaries.avg_salary;

