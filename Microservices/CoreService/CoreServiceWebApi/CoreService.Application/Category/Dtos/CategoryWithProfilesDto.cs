using CoreService.Application.UserProfiles.Dtos;

namespace CoreService.Application.Categories.Dtos
{
    public class CategoryWithProfilesDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<UserProfileDto> UserProfiles { get; set; } = new List<UserProfileDto>();
    }
}