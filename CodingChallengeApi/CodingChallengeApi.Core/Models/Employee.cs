namespace CodingChallengeApi.Core.Models;
public class Employee : Person
{
    public int Id { get; set; }
    public static int BaseSalary => 2000;
    public decimal Salary => BaseSalary - Deductions;
    public decimal Deductions { get; set; }
    public IList<Person> Dependents { get; set; } = new List<Person>();
}
