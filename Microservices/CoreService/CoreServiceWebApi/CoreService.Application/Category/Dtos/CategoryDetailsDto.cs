using CoreService.Application.Questions.Dtos;
using CoreService.Application.UserProfiles.Dtos;

namespace CoreService.Application.Categories.Dtos
{
    public class CategoryDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<UserProfileDto> UserProfiles { get; set; } = new List<UserProfileDto>();
        public ICollection<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
    }

}