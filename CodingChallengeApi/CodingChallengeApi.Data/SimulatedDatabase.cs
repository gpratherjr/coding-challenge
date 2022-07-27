using CodingChallengeApi.Core.Models;

namespace CodingChallengeApi.Data;
public static class SimulatedDatabase
{
    static SimulatedDatabase()
    {
        Employees = new Dictionary<int, Employee>();
        Employees.TryAdd(1, new Employee { Id = 1, FirstName = "Roger", LastName = "Rabbit" });
        Employees.TryAdd(2, new Employee
        {
            Id = 2,
            FirstName = "Adam",
            LastName = "West",
            Dependents = new List<Person> {
                new Person { FirstName = "Bat", LastName = "Man" }
            }
        });
        Employees.TryAdd(3, new Employee
        {
            Id = 3,
            FirstName = "Homily",
            LastName = "Clock",
            Dependents = new List<Person> {
                new Person { FirstName = "Pod", LastName = "Clock" },
                new Person { FirstName = "Arietty", LastName = "Clock"}
            }
        });
        Employees.TryAdd(4, new Employee
        {
            Id = 4,
            FirstName = "Allison",
            LastName = "Chou Harrington",
            Dependents = new List<Person> {
                new Person { FirstName = "Alfred", LastName = "Harrington" },
                new Person { FirstName = "Honor", LastName = "Harrington"}
            }
        });
    }
    public static Dictionary<int, Employee> Employees { get; set; }
}
