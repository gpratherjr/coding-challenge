import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { EmployeesService } from '../employees.service';
import { Employee } from '../models/employee';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
})
export class EmployeeComponent implements OnInit{
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  backToEmployees(): void {
    this.router.navigate(['employees']);
  }
}
