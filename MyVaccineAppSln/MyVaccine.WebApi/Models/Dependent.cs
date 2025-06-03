namespace MyVaccine.WebApi.Models;

public class Dependent : BaseTable
{
    public int DependentId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public List<VaccineRecord> VaccineRecords { get; set; }
}
