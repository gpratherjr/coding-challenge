import { Person } from "./person";

export class Employee extends Person {
    id: number;
    salary: number;
    dependents: Person[];
    deductions: number;

    constructor(params: any){
        super(params);
        this.id = params?.id ?? 0;
        this.salary = params?.salary ?? 0;
        this.dependents = Person.prototype.buildPersonArray(params?.dependents) ?? [];
        this.deductions = params?.deductions ?? 0;
    }

    buildEmployeeArray(params: any[]): Employee[] {
        const employees: Employee[] = [];
        params?.forEach(element => {
            employees.push(new Employee(element))
        });
        return employees;
    }
}