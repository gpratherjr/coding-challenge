export class Person {
    firstName: string;
    lastName: string;

    constructor(params: any){
        this.firstName = params?.firstName ?? '';
        this.lastName = params?.lastName ?? ''
    }

    buildPersonArray(params: any[]): Person[] {
        const people: Person[] = [];
        params?.forEach(element => {
            people.push(new Person(element))
        });
        return people;
    }
}