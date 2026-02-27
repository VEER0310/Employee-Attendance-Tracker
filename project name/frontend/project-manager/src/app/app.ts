import { Component } from '@angular/core';
import { RouterOutlet, RouterLink } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink],
  template: `
    
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
      <div class="container">
        <span class="navbar-brand">Attendance Tracker</span>
        <div class="navbar-nav">
          
          <a class="nav-link" routerLink="/employees">Employees</a>
          <a class="nav-link" routerLink="/attendance">Mark Attendance</a>
          <a class="nav-link" routerLink="/report">Daily Report</a>
        </div>
      </div>
    </nav>

    
    <div class="container mt-4">
      <router-outlet></router-outlet>
    </div>
  `
})
export class App { }