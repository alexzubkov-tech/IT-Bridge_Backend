namespace CoreService.Application.Companies.Dtos
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxID { get; set; }
        public string Address { get; set; }
        public DateTime FoundationDate { get; set; }
        public int EmployeeCount { get; set; }
        public Industry Industry { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}