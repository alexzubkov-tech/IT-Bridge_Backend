namespace CoreService.Domain.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TaxId { get; set; }
        public string Address { get; set; }
        public DateTime FoundationDate { get; set; }
        public int EmployeeCount { get; set; }
        public string Industry { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<UserProfile> UserProfiles { get; set; } = new();

        public Company() { }

        public Company(Guid id, string name, string taxId, string address, DateTime foundationDate, int employeeCount,
                       string industry, string phoneNumber, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            TaxId = taxId;
            Address = address;
            FoundationDate = foundationDate;
            EmployeeCount = employeeCount;
            Industry = industry;
            PhoneNumber = phoneNumber;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
