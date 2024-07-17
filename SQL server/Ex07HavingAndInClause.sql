---Using IN Clause
Select * from Emptable where empaddress ='Pune' OR empAddress ='Lucknow' or empAddress ='Hyderabad'

--Short hand for multiple ors and ands U should go for in clause. 
Select * from Emptable where empaddress in ('Pune','Bengaluru','Hyderabad')
--Use IN clause with Where clause where U want to extract the values based on multiple values which can be passed as list of values instead of multiple or conditions. 

------------Having clause-------------------------
--Similar to where clause but with group by clause. It is used with aggregate functions It should be used after group by and before order by clause
--Find all Depts whose SUM of Salaries are more than 25 Lakhs. 
select dbo.GetDeptName(EmpTable.DeptId) as Dept, SUm(EmpTable.empsalary)
From EMptable
Group by DeptId
Having SUM(empSalary) >= 2500000



