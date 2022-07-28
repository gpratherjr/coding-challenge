import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject, switchMap, takeUntil } from 'rxjs';
import { EmployeesService } from '../employees.service';
import { Employee } from '../models/employee';
import { Person } from '../models/person';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit, OnDestroy {
  private ngUnsubscribe: Subject<void> = new Subject<void>(); 
  employee = new Employee(null);
  displayedColumns: string[] = ['firstName', 'lastName', 'delete'];
  adding = false;
  newDependent = new Person(null);
  dependentDataSource = new MatTableDataSource<Person>();
  updateButtonText!: string;

  constructor(private router: Router,
     private route: ActivatedRoute,
     private employeesService: EmployeesService) { }

  ngOnInit(): void {
    const employeeId = parseInt(this.route.snapshot.paramMap.get('id') ?? '0');
    this.employee = this.employeesService.employees.find((e) => e.id === employeeId) ?? new Employee(null);
    this.dependentDataSource.data = this.employee.dependents;
    this.updateButtonText = employeeId > 0 ? 'Update Employee' : 'Create Employee';
  }
  
  ngOnDestroy(): void {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  removeDependent(dependent: Person): void {
    this.employee.dependents = this.employee.dependents.filter((d) => d !== dependent);
    this.dependentDataSource.data = this.employee.dependents;
  }

  updateEmployee(): void {
    this.employeesService.updateEmployee(this.employee)
      .pipe(
        switchMap(() => this.employeesService.getEmployee(this.employee.id)),
        takeUntil(this.ngUnsubscribe),
      )
      .subscribe((employee) => this.employee = employee);
  }

  createEmployee(): void {
    this.employeesService.createEmployee(this.employee)
      .pipe(
        switchMap((id) => this.employeesService.getEmployee(id)),
        takeUntil(this.ngUnsubscribe),
      )
      .subscribe((employee) => {
        this.employee = employee;
        this.employeesService.employees.push(employee);
      });

  }

  activateAdd(): void {
    this.adding = true;
    this.newDependent = new Person(null);
  }

  addDependent(): void {
    this.adding = false;
    this.employee.dependents.push(this.newDependent);
    this.dependentDataSource.data = this.employee.dependents;
  }

  backToEmployees(): void {
    this.router.navigate(['employees']);
  }
}
