class Employee{
 constructor(id, name, address, salary) {
    this.empId = id;
    this.empName = name;
    this.empAddress = address;
    this.empSalary= salary
 }   
}

class EmployeeRepo{
   data = []//Represents the data of the Class. 

   constructor(){
      this.loadData();
   } 
   loadData = () => {
      if(localStorage.getItem("empList") != null){
         const json = localStorage.getItem("empList");
         this.data = JSON.parse(json); 
      }      
   }
   saveData = () =>{
      const json = JSON.stringify(this.data);
      localStorage.setItem("empList", json);
   }
   //addNewEmployee = (emp) => this.data = [...this.data, emp]; 
   addNewEmployee = (emp) =>{
      this.loadData();//gets the existing data from the storage...
      this.data = [...this.data, emp];
      this.saveData();
   }
   deleteEmployee = (id) => {
      this.loadData();
      let index = this.data.findIndex((e)=>e.empId == id);
      this.data.splice(index, 1);//removing an element in Js's array.
      this.saveData(); 
   }

   getAllEmployees = () => {
      this.loadData();
      return this.data;
   }

   updateEmployee = (id, emp) => {
      this.loadData();
      let index = this.data.findIndex((e)=>e.empId == id);
      this.data.splice(index, 1, emp);//Removes the no of elements(2nd arg) from the specific index(1st arg) and replaces it with the emp object(3rd arg)
      this.saveData();
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


