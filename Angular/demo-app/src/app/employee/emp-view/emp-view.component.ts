import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Employee } from '../Models/employee';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-emp-view',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './emp-view.component.html',
  styleUrl: './emp-view.component.css'
})
export class EmpViewComponent {
  //When we want to transfer any data from the parent component to the child component, we can use Input Directive with the variable name. When this component is refered in the parent UI, it shall use the selector and pass a property bound value to this component. 
  @Input() empObj = {} as Employee; 
  @Output() onUpdate : EventEmitter<Employee> = new EventEmitter<Employee>();
  @Output() onDelete : EventEmitter<Number> = new EventEmitter<Number>();

  onUpdateClick(){
    debugger;
    alert(JSON.stringify(this.empObj));
    this.onUpdate.emit(this.empObj);
  }  

  onDeleteClick(){
    
    this.onDelete.emit(this.empObj.empId);
  }
}
