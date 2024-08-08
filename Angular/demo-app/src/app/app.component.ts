import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmpListComponent } from './employee/emp-list/emp-list.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, EmpListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'demo-app';
}
