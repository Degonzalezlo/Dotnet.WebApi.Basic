namespace MyVaccine.WebApi.Models
{
    public class Vaccine : BaseTable
    {
        public int VaccineId { get; set; }
        public string Name { get; set; }
        public List<VaccineCategory> Categories { get; set; } = new List<VaccineCategory>();
        public bool RequiresBooster { get; set; }
    }
}
