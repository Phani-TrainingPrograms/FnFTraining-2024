# Database programming using EntityFrameworkCore
### Steps for Creating the Project
1. Create a new .NET CORE ClassLibrary Project.
2. Add the required Nuget packages required for the EF core. 
3. Create the Entity Class under the folder called Models. This class represents the table of the database.  
4. Create a folder called Data and inside it, create a DataContext class derived from Microsoft.EntityFrameworkCore.DbContext and implement the following methods:
	- override the OnConfiguring method where U define the connection string required for your Db Connection that is used to generate the classes.
	- Create a Property with Pluralized name of the Entity Class belonging to the type DbSet<T>.
5. Create an interface with all the Crud Operations required for UR App and implement them inside a Class. This class is refered as service class. This is usually created under a seperate folder called services.
6. Open the Package Manager Console and run the following commands to generate the tables in the database
```
add-migration mig1
update-database
```
7. Build the Dll and Test it on any Console, WebAPI or Web Application. 
### Important Nuget packages
1. Microsoft.EntityFrameworkCore
2. Microsoft.EntityFrameworkCore.Tools
3. Microsoft.EntityFrameworkCore.SqlServer 