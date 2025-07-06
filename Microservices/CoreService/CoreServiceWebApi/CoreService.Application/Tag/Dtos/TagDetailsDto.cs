using CoreService.Application.Questions.Dtos;
using CoreService.Domain.Entities;

namespace CoreService.Application.Tags.Dtos
{
    public class TagDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<QuestionDto> Questions { get; set; } = new();
    }
}
