using CoreService.Application.Companies.Dtos;
using CoreService.Domain.Entities;

namespace CoreService.Application.Companies.Mapper
{
    public static class CompanyMapper
    {
        public static Company ToEntity(this CreateCompanyDto dto)
        {
            return new Company
            {
                Name = dto.Name,
                TaxID = dto.TaxID,
                Address = dto.Address,
                FoundationDate = dto.FoundationDate,
                EmployeeCount = dto.EmployeeCount,
                Industry = dto.Industry,
                PhoneNumber = dto.PhoneNumber,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public static void UpdateEntityFromDto(this Company entity, UpdateCompanyDto dto)
        {
            if (!string.IsNullOrEmpty(dto.Name)) entity.Name = dto.Name;
            if (!string.IsNullOrEmpty(dto.TaxID)) entity.TaxID = dto.TaxID;
            if (!string.IsNullOrEmpty(dto.Address)) entity.Address = dto.Address;
            if (dto.FoundationDate.HasValue) entity.FoundationDate = dto.FoundationDate.Value;
            if (dto.EmployeeCount.HasValue && dto.EmployeeCount.Value > 0)
                entity.EmployeeCount = dto.EmployeeCount.Value;
            if (dto.Industry.HasValue) entity.Industry = dto.Industry.Value;
            if (!string.IsNullOrEmpty(dto.PhoneNumber)) entity.PhoneNumber = dto.PhoneNumber;

            entity.UpdatedAt = DateTime.UtcNow;
        }

        public static CompanyDto ToDto(this Company entity)
        {
            return new CompanyDto
            {
                Id = entity.Id,
                Name = entity.Name,
                TaxID = entity.TaxID,
                Address = entity.Address,
                FoundationDate = entity.FoundationDate,
                EmployeeCount = entity.EmployeeCount,
                Industry = entity.Industry,
                PhoneNumber = entity.PhoneNumber,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}