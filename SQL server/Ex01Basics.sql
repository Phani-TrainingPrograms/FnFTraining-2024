--SQL server is a database server provided by MS for developing back end databases for our Apps. Express edition is used for developing light weight local database centric apps. If U want centralized Databases, then U should go for Developer Edition of SQL server which allows db connections using tcp/ip. 
-- SSMS is a tool for developing SQL server components in a IDE based Environment. Its a RAD(Rapid App Development) tool for developing SQL server components. 
-- SQL(Sequel) is a programming language used for developing database centric components for UR Backend App development. 
-- Connecting to SQL server can be either Windows Authentication or SQL Server authentication. Windows Authentication will be used when U want all the Windows users of the machine to access the SQL server. This is default. U can give additional security using SQL server authentication where a new user and password would be provided.Note that the users should also be the part of the Windows group to be authenticated. 
-- Programming of the SQL is done using SQL. With this, U can create databases, tables, stored procedures, triggers, users, groups and few more. U should be having the relevant rights to perform any actions within the SQL server. Atlease U should be a DBCreator role to work with databases and Tables. Normal Dbusers will be able to view and access the database without writing options. 
-- There are various versions of SQL created by various Organizations like MS, Oracle and many more. The SQL version that we are learnin is T-SQL(Transact SQL). Oracle uses Pl-SQL for its database management. 
--Likewise, SQL divides itself into 4 Sub model languages
--DCL: Data Controller Language
--DML: Data Manipulation Language
--TCL: Transcation Controlle Language
--DDL : Data Definition language. 
--Many of the actions that U perform on the databases is possible only if U R the user of the Master Database. 
--------------------------Creating and Deleting Databases-------------------------
use master
Create Database SampleDb --If the DB already exists, it throws an Exception that the Database Exists. 
use SampleDb
Drop Database SampleDb -- If U R using the database, then U cannot drop the database, in such cases, U should move to master database and then delete the required User databases. U cannot delete the system databases of SQL server. 
--SQL server has predefined statements that can be executed to get common operations related to the datbase. It is called as STORED PROCEDURES. All predefined stored procs of SQL server are prefixed with sp_. We also create stored procedures for executing frequently used statements, sno that the parsing of the SQL statement is not required when U use those statements frequently. 

sp_databases -- Its a Stored proc used to get all the databases of the current instance of the SQL server. 
Use FnfTraining
------------------------Adding tables to the SQL server-----
Drop table EmpTable
--SQL is not case sensitive. 
CREATE taBLE EmpTable
(
	empId int primary key identity(1000, 1),
	empName nvarchar(50) NOT NULL,
	empAddress nvarchar(MAX) NOT NULL, 
	empSalary money NOT NULL
)

sp_tables --Stored Proc to get all the tables of the selected database.

--create a new table called DeptTable which has 2 cols: DeptId, DeptName
create table DeptTable
(
	DeptId int primary key identity(1, 1),
	Deptname varchar(50) not null
)

--SQL server is a relational database: The data is stored in the form of rows and columns. The data is related and linkable to another table. This is called as Relational data. IN this example, we shall add a new column in the Emptable that references to the DeptId of the DeptTable. This is called as Foreign key relation. Here the EmpTable's column would refer the Primary key column of the DeptTable. 
-- The Entry for the Column Dept in EmpTable must have the value from the DeptId of the DeptTable. 

-------------Modifying the columns of the table---------------------------------
Alter table EmpTable
Add Dept int Not null --Use null if U already have records in the EmpTable.
REFERENCES DeptTable(DeptId)

sp_columns Emptable --Displays the column information of the specified Table. 

-----------------------------Inserting records to the table-------------------
Insert into DeptTable values('Training')
Insert into DeptTable values('Development')
Insert into DeptTable values('Transport')
Insert into DeptTable values('Sales')
Insert into DeptTable values('Admin')


Insert into EmpTable values('Phaniraj', 'Bangalore', 56000, 1) --When U dont mention the columns, then U should place the values in the same order of the Table defn. 

--Inserting to specified columns of the table.
Insert into EmpTable(empAddress, empName, empSalary, Dept) values('Vinod Kumar', 'Shimoga', 60000, 2)

insert into EmpTable values('Joy Dip', 'Kolkata', 35000, 2)
insert into EmpTable values('Shom Patnaik', 'Cuttuck', 35000, 2)
insert into EmpTable values('Agarkar', 'Pune', 45000, 3)

insert into EmpTable values('Jai Guru', 'Tata Nagar', 35000, 4)

Alter table EmpTable
Drop column Dept --Drops the Column from the table. 

Alter table EmpTable
Drop constraint FK__EmpTable__Dept__286302EC --Drop the constraint.
--If a column is having a relation with another table, the relation has to be dropped before U drop the column.

Alter table EmpTable
Alter column empAddress nvarchar(200) NOT NULL

sp_columns EmpTable

--todo: Add the column called Dept into the EmpTable.
Alter table Emptable
Add DeptId int
References DeptTable(DeptId)

--Truncate is used to delete the records of the table. It retains the schema of the table. 
truncate table Emptable
---------Commands of DDL: Create, Drop, Alter, Truncate---
----------------Data Query Language-------------------------
Select * from Emptable

