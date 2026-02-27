import { Routes } from '@angular/router';
import { Employees } from './components/employees/employees';
import { Attendance } from './components/attendance/attendance';
import { Report } from './components/report/report';

export const routes: Routes = [
  { path: '', redirectTo: 'employees', pathMatch: 'full' },    // default page
  { path: 'employees', component: Employees },
  { path: 'attendance', component: Attendance },
  { path: 'report', component: Report }
];