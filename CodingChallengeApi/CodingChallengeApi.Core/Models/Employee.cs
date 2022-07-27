namespace CodingChallengeApi.Core.Models;
public class Employee : Person
{
    public int Id { get; set; }
    public IList<Person> Dependents { get; set; } = new List<Person>();
}
