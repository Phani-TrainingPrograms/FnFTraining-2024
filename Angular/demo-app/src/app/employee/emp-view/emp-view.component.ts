import { Component, Input } from '@angular/core';
import { Employee } from '../Models/employee';

@Component({
  selector: 'app-emp-view',
  standalone: true,
  imports: [],
  templateUrl: './emp-view.component.html',
  styleUrl: './emp-view.component.css'
})
export class EmpViewComponent {
  //When we want to transfer any data from the parent component to the child component, we can use Input Directive with the variable name. When this component is refered in the parent UI, it shall use the selector and pass a property bound value to this component. 
  @Input() empObj = {} as Employee; 
}
