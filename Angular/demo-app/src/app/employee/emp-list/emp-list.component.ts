import { Component, OnInit } from '@angular/core';
import { Employee } from '../Models/employee';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-emp-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './emp-list.component.html',
  styleUrl: './emp-list.component.css'
})
export class EmpListComponent implements OnInit {
  ngOnInit(): void {
    //Use ngOnInit to initialize the data of UR component.
    this.empList.push({
      empId : 123, empName : "Phaniraj", empAddress : "Bangalore", empSalary : 56000, empPic : 'assets/images/pic1.png'
    });
    this.empList.push({
      empId : 124, empName : "Banu Prakash", empAddress : "Mysore", empSalary : 16000, empPic : 'assets/images/pic6.png'
    });
    this.empList.push({
      empId : 125, empName : "Vinod Kumar", empAddress : "Shimogga", empSalary : 56000, empPic : 'assets/images/pic5.png'
    });
    this.empList.push({
      empId : 126, empName : "Joydip Mondal", empAddress : "Kolkatta", empSalary : 56000, empPic : 'assets/images/pic4.png'
    });
    this.empList.push({
      empId : 127, empName : "Ramnath Nishad", empAddress : "Patna", empSalary : 56000, empPic : 'assets/images/pic3.png'
    });
    this.empList.push({
      empId : 128, empName : "Phaniraj", empAddress : "Bangalore", empSalary : 56000, empPic : 'assets/images/pic2.png'
    });

  }

  //constructors are needed to perform DI...
  empList : Employee[] = [];


}
