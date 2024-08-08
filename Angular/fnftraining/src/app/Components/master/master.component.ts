import { Component, OnInit } from '@angular/core';
import { Employee } from '../../Models/employee';

@Component({
  selector: 'app-master',
  templateUrl: './master.component.html'
})


export class MasterComponent implements OnInit {
  //Function that gets invoked when the component is initialized.
  ngOnInit(): void {
    this.empList.push({ empId : 123, empName : "Phaniraj", empAddress : "Bangalore", empSalary : 45000, empPic :'Phani.png' });
    this.empList.push({ empId : 124, empName : "Banu Prakash", empAddress : "Bangalore", empSalary : 45000, empPic :'pic6.png' });
    this.empList.push({ empId : 125, empName : "JoyDip Mondal", empAddress : "Kolkata", empSalary : 45000, empPic :'pic2.png' });
    this.empList.push({ empId : 126, empName : "Ramnath Nishad", empAddress : "Lucknow", empSalary : 45000, empPic :'pic3.png' });
    this.empList.push({ empId : 127, empName : "Murali Shetty", empAddress : "Mangalore", empSalary : 45000, empPic :'pic4.png' });
  }
  //In Angular, if U want a fn to be invoked when the component is crreated, we can implement an interface called OnNgInit
  onEdit = (rec : Employee) =>{
    
  };

  onDelete(emp : Employee){
    const index = this.empList.indexOf(emp);
    this.empList.splice(index, 1);
  }
  //Array of the type Employee[] and assigning it to blank Array
  empList : Employee[] = []
}
