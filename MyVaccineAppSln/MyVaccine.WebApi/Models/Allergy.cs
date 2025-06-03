namespace MyVaccine.WebApi.Models
{
    public class Allergy : BaseTable
    {
        public int AllergyId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } 

    }
}
