using CoreService.Application.Categories.Dtos;
using CoreService.Application.Tags.Dtos;
using CoreService.Application.UserProfiles.Dtos;
using CoreService.Domain.Entities;

namespace CoreService.Application.Questions.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool IsUrgent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserProfileId { get; set; }

        public List<TagDto> Tags { get; set; } = new();
        public List<CategoryDto> Categories { get; set; } = new();
    }
}