import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, of } from 'rxjs';
import { ApiResponse } from './models/api-response';
import { Employee } from './models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {
  employees: Employee[] = [];

  constructor(private httpClient: HttpClient) { }

  getEmployees(): Observable<Employee[]> {
    if (this.employees.length > 0) { return of(this.employees); }
    return this.httpClient.get<ApiResponse>('https://localhost:7242/api/employees')
      .pipe(map((response: ApiResponse) => {
        const employees = Employee.prototype.buildEmployeeArray(response.data);
        this.employees = employees;
        return employees;
      }));
  }
}
