//In JS, a class is created in 4 possible ways: 3 based on old format and 1 on ES6 format. 
//Singleton objects. 
const emp = {
 empName: "Phaniraj", 
 empAddress : "Bangalore",
 empSalary : 56000   
}


//This is an object created directly without a class declaration. 
//An object is a collection of data. 

console.log(emp);

const emp2 = emp;

emp2.empSalary = 76000;//try changing the 2nd emp data...

console.log(emp.empSalary);
console.log(emp2.empSalary);//Note that both are changed as they both refer to the same object. They are singleton(one object across the app)

//Treating the object like a collection and iterating using for...in statement
for (const key in emp) {
    console.log(`Property: ${key}, Value : ${emp[key]}`);
}
//using spread operator to append an object with current object data and adding with additional attributes.
const emp3 = { ...emp, empDesignation : "Trainer"};
console.log(emp3);

/////////////////////////////Creating multiple objects////////////////
//Earlier syntax was to treat a function as an object

const employee = function(id, name, address){
  this.empId = id;
  this.empName = name;
  this.empAddress = address   

  this.display = function(){
    return `${this.empName} is from ${this.empAddress}`
  }
}

console.log(employee);

const employee1 = new employee(123, "Phaniraj", "Bangalore");
const employee2 = new employee(124, "Vinod", "Shimogga");
alert(employee2.display());
employee2.empAddress ="Bhadravathi";
console.log(employee1.empAddress);
console.log(employee2.empAddress);

////////////////////////ES6 syntax of class///////////////////
class Customer{
    constructor(id, name, address, bill){
        this.id =id;
        this.name =name;
        this.address = address;
        this.billAmount = bill       
    }

    display = () => `${this.name} is from ${this.address} and has raised the bill amount of Rs. ${this.billAmount}`;
}

const cst = new Customer(123, "Suresh", "Bangalore", 5000);
alert(cst.display())