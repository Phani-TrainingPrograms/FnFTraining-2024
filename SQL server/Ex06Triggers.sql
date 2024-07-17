--Triggers are like events(Actions) that is invoked automatically when a condition is met(insert, delete, update).

Create table Customer
(
	CstId int primary key identity(1,1),
	CstName varchar(50) NOT NULL, 
	CstAddress varchar(200) NOT NULL, 
	BillDate Date default GetDate(),
	BillAmount money
)

Create Table Customer_Audit
(
 id int primary key identity(1,1),
 description varchar(200) NOT NULL
)

----------------insertion trigger---------
Alter trigger OnNewCustomer
ON Customer
FOR INSERT
AS
BEGIN
DECLARE @id int
Select @id = CstId from inserted --inserted in a predefined object that represents the inserted row.
DECLARE @desc varchar(200)
DECLARE @name varchar(50)
Select @name = CstName from inserted
set @desc = 'Customer with Id ' + Cast(@id as varchar(4)) + 'and name as ' + @name +' inserted successfully on ' + dbo.CreateDate(GetDate())
Insert into Customer_Audit values(@desc)
END

Insert into Customer(CstName, CstAddress, BillAmount) values('Phaniraj', 'Bangalore' , 5000)

-------------------------------Update Trigger--------------------
Create trigger OnUpdateCustomer
ON Customer
After update
as
begin
Declare @id int
Declare @Oldname varchar(50)
Declare @newName varchar(50)
Select @id = CstId from inserted
Select @newName = CstName from inserted
Select @Oldname = CstName from deleted
Insert into Customer_Audit values('The Customer with Id ' + cast(@id as varchar(4)) + ' has been updated with the new Name as ' + @newName + ' from the Old Name ' + @Oldname + ' on '+ dbo.CreateDate(GetDate()))
end


Update Customer
Set CstName ='Phani Raj B.N.'  where CstName = 'Phaniraj'
SElect * from Customer_Audit

--Todo: Create a delete trigger after deleting a record from the Customer table. 






