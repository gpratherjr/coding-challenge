export class Employee {
    id: number;
    firstName: string;
    lastName: string;

    constructor(params: any){
        this.id = params?.id ?? 0;
        this.firstName = params?.firstName ?? '';
        this.lastName = params?.lastName ?? ''
    }

    buildEmployeeArray(params: any[]): Employee[] {
        const employees: Employee[] = [];
        params.forEach(element => {
            employees.push(new Employee(element))
        });
        return employees;
    }
}