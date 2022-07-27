using CodingChallengeApi.Core.Models;
using System.Collections.Concurrent;

namespace CodingChallengeApi.Data;
public static class SimulatedDatabase
{
    static SimulatedDatabase()
    {
        Employees = new ConcurrentDictionary<int, Employee>();
        Employees.TryAdd(1, new Employee { EmployeeId = 1, FirstName = "Roger", LastName = "Rabbit" });
        Employees.TryAdd(2, new Employee
        {
            EmployeeId = 2,
            FirstName = "Adam",
            LastName = "West",
            Dependents = new List<Person> {
                new Person { FirstName = "Bat", LastName = "Man" }
            }
        });
        Employees.TryAdd(3, new Employee
        {
            EmployeeId = 3,
            FirstName = "Homily",
            LastName = "Clock",
            Dependents = new List<Person> {
                new Person { FirstName = "Pod", LastName = "Clock" },
                new Person { FirstName = "Arietty", LastName = "Clock"}
            }
        });
        Employees.TryAdd(4, new Employee
        {
            EmployeeId = 4,
            FirstName = "Allison",
            LastName = "Chou Harrington",
            Dependents = new List<Person> {
                new Person { FirstName = "Alfred", LastName = "Harrington" },
                new Person { FirstName = "Honor", MiddleInitial = "S", LastName = "Harrington"}
            }
        });
    }
    public static ConcurrentDictionary<int, Employee> Employees { get; set; }
}
