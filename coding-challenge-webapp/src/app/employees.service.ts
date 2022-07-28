import { HttpClient, HttpHeaders } from '@angular/common/http';
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

  getEmployee(employeeId: number) : Observable<Employee> {
    return this.httpClient.get<ApiResponse>(`https://localhost:7242/api/employees/${employeeId}`)
    .pipe(map((response: ApiResponse) => new Employee(response.data)));
  }

  updateEmployee(employee: Employee): Observable<ApiResponse> {
    return this.httpClient.put<ApiResponse>(`https://localhost:7242/api/employees/${employee.id}`, employee);
  }

  createEmployee(employee: Employee): Observable<number> {
    return this.httpClient.post<ApiResponse>('https://localhost:7242/api/employees', employee)
    .pipe(map((response: ApiResponse) => response.data));

  }
}
