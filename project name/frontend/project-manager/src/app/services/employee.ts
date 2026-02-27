import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee, CreateEmployee, Policy } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  // backend API url
  private apiUrl = 'https://localhost:7236/api/Employees';
  private policyUrl = 'https://localhost:7236/api/Policies';

  constructor(private http: HttpClient) { }

  
  getAll(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.apiUrl);
  }

  create(employee: CreateEmployee): Observable<any> {
    return this.http.post(this.apiUrl, employee);
  }

  // dropdown policies
  getPolicies(): Observable<Policy[]> {
    return this.http.get<Policy[]>(this.policyUrl);
  }
}