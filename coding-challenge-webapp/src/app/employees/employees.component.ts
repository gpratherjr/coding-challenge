import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { EmployeesService } from '../employees.service';
import { Employee } from '../models/employee';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit, OnDestroy {
  private ngUnsubscribe: Subject<void> = new Subject<void>(); 
  employees: Employee[] = [];
  displayedColumns: string[] = ['id', 'firstName', 'lastName'];

  constructor(private employeeService: EmployeesService,
    private router: Router) { }
  

  ngOnInit(): void {
    this.employeeService.getEmployees()
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe((employees) => this.employees = employees);
  }
  
  ngOnDestroy(): void {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  selectEmployee(id: number): void {
    this.router.navigate(['employee', { id }]);
  }

  createNewEmployee(): void {
    this.router.navigate(['employee', { id: 0 }]);
  }
}
