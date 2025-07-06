
namespace CoreService.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxID { get; set; }
        public string Address { get; set; }
        public DateOnly FoundationDate { get; set; }
        public int EmployeeCount { get; set; }
        public Industry Industry { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
    }
}

public enum Industry
{
    IT = 1,
    Backend = 2,
    Frontend = 3,
    Disign = 4,
}