namespace CoreService.Application.Companies.Dtos
{
    public class UpdateCompanyDto
    {
        public string? Name { get; set; }
        public string? TaxID { get; set; }
        public string? Address { get; set; }
        public DateOnly? FoundationDate { get; set; }
        public int? EmployeeCount { get; set; }
        public Industry? Industry { get; set; }
        public string? PhoneNumber { get; set; }
    }
}