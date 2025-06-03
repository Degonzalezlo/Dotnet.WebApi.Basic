namespace MyVaccine.WebApi.Models
{
    public class User : BaseTable
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AspNetUserId { get; set; }
        public ApplicationUser AspNetUser { get; set; }
        
        public List<Dependent> Dependents { get; set; }
        public List<FamilyGroup> FamilyGroups { get; set; }
        public List<VaccineRecord> VaccineRecords { get; set; }
        public List<Allergy> Allergies { get; set; }
    }
}
