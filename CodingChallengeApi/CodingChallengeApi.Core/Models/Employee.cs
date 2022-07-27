namespace CodingChallengeApi.Core.Models;
public class Employee : Person
{
    public int EmployeeId { get; init; }
    public IList<Person> Dependents { get; set; } = new List<Person>();
}
