class Employee{
 constructor(id, name, address, salary) {
    this.empId = id;
    this.empName = name;
    this.empAddress = address;
    this.empSalary= salary
 }   
}

class EmployeeRepo{
   data = [
      new Employee(111, "Phaniraj", "bangalore", 56000),
      new Employee(112, "Vinod", "Shimoga", 56000),
      new Employee(113, "Venkatesh", "Bellary", 50000),
      new Employee(114, "Banu Prakash", "Bangalore", 46000)
   ];//Represents the data of the Class. 

   addNewEmployee = (emp) => [...this.data, emp]; //new feature of ES7. 

   deleteEmployee = (id) => {
      let index = this.data.findIndex((e)=>e.empId == id);
      this.data.splice(index, 1);//removing an element in Js's array. 
   }

   getAllEmployees = () => [...this.data];

   updateEmployee = (id, emp) => {
      let index = this.data.findIndex((e)=>e.empId == id);
      this.data.splice(index, 1, emp);//Removes the no of elements(2nd arg) from the specific index(1st arg) and replaces it with the emp object(3rd arg)
   }
}

//////////////Global functions/////////////////////////
//const hideElements = (...element) => [...element].forEach(e =>(e.style.display = 'none'));

const hide = function(elements) {
   elements.forEach(element => {
      element.style.display = "none"
   });
}

const show = (id) => document.getElementById(id).style.display = 'block';


