import { Component, Input } from '@angular/core';
import { Employee } from '../../Models/employee';

@Component({
  selector: 'app-emp-detail',
  templateUrl: './emp-detail.component.html'
})
export class EmpDetailComponent {
  //The input Directive is used to inject a value from the outer component. 
    @Input() empObj = {} as Employee
}
