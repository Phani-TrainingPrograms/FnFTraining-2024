import { Component, OnInit } from '@angular/core';
import { Employee } from '../Models/employee';
import { CommonModule } from '@angular/common';
import { EmpViewComponent } from '../emp-view/emp-view.component';

@Component({
  selector: 'app-emp-list',
  standalone: true,
  imports: [CommonModule, EmpViewComponent],//UR component is using EmpView
  templateUrl: './emp-list.component.html',
  styleUrl: './emp-list.component.css'
})
export class EmpListComponent implements OnInit {
  ngOnInit(): void {
    //Use ngOnInit to initialize the data of UR component.
    this.empList.push({
      empId : 123, empName : "Phaniraj", empAddress : "Bangalore", empSalary : 56000, empPic : 'pic1.png'
    });
    this.empList.push({
      empId : 124, empName : "Banu Prakash", empAddress : "Mysore", empSalary : 16000, empPic : 'pic6.png'
    });
    this.empList.push({
      empId : 125, empName : "Vinod Kumar", empAddress : "Shimogga", empSalary : 56000, empPic : 'pic5.png'
    });
    this.empList.push({
      empId : 126, empName : "Joydip Mondal", empAddress : "Kolkatta", empSalary : 56000, empPic : 'pic4.png'
    });
    this.empList.push({
      empId : 127, empName : "Ramnath Nishad", empAddress : "Patna", empSalary : 56000, empPic : 'pic3.png'
    });
    this.empList.push({
      empId : 128, empName : "Phaniraj", empAddress : "Bangalore", empSalary : 56000, empPic : 'pic2.png'
    });

  }

  onDataUpdated(modifiedData : Employee){debugger;
    const index = this.empList.findIndex(e =>e.empId == modifiedData.empId);
    if(index < 0){
      alert("Not available to update");
    }else{
      this.empList.splice(index, 1, modifiedData);
    }
  }

  onDataDeleted(empId:Number){
    
    const index = this.empList.findIndex(e =>e.empId == empId);
    if(index < 0){
      alert("Not available to delete");
    }else{
      this.empList.splice(index, 1);
      alert("Employee deleted successfully")
    }
  }
  //constructors are needed to perform DI...
  empList : Employee[] = [];


}
