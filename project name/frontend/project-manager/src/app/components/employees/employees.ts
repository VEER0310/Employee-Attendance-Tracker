import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from '../../services/employee';
import { Employee, Policy } from '../../models/models';

@Component({
  selector: 'app-employees',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './employees.html'
})
export class Employees implements OnInit {

  employees: Employee[] = [];    
  policies: Policy[] = [];       
  employeeForm: FormGroup;       
  errorMessage = '';             
  successMessage = '';          

  constructor(
    private employeeService: EmployeeService,
    private fb: FormBuilder,
    private cdr: ChangeDetectorRef 
  ) {
    // Define form with validators
    this.employeeForm = this.fb.group({
      policyId: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  ngOnInit(): void {
    this.loadEmployees();
    this.loadPolicies();
  }

 
  loadEmployees(): void {
    this.employeeService.getAll().subscribe({
      next: (data) => {
        this.employees = data;
        this.cdr.detectChanges();
      },
      error: () => {
        this.errorMessage = 'Failed to load employees.';
        this.cdr.detectChanges();
      }
    });
  }

  loadPolicies(): void {
    this.employeeService.getPolicies().subscribe({
      next: (data) => {this.policies = data;
        this.cdr.detectChanges();
      },
      error: () => {this.errorMessage = 'Failed to load policies.';
        this.cdr.detectChanges();
      }
    });
  }

  
  onSubmit(): void {
    if (this.employeeForm.invalid) return;  // stop if form has errors

    this.errorMessage = '';
    this.successMessage = '';

    this.employeeService.create(this.employeeForm.value).subscribe({
      next: () => {
        this.successMessage = 'Employee created successfully!';
        this.employeeForm.reset();   
        this.loadEmployees();
        this.cdr.detectChanges();      
      },
      error: (err) => {
        
        this.errorMessage = err.error?.message || 'Failed to create employee.';
        this.cdr.detectChanges();
      }
    });
  }
}