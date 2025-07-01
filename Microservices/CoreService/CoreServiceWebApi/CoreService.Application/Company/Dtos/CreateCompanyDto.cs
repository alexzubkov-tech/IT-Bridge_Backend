namespace CoreService.Application.Companies.Dtos
{
    public class CreateCompanyDto
    {
        public required string Name { get; set; }
        public required string TaxID { get; set; }
        public required string Address { get; set; }
        public required DateOnly FoundationDate { get; set; }
        public required int EmployeeCount { get; set; }
        public required Industry Industry { get; set; }
        public required string PhoneNumber { get; set; }
    }
}