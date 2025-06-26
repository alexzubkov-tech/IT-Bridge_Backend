using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.Domain.Entities
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public Guid ProfileUserId { get; set; }
        public UserProfile ProfileUser { get; set; } = null!;
        public bool IsUrgent { get; set; }
        public int ViewCount { get; set; }

        public List<QuestionRating> Ratings { get; set; } = new();
        public List<Answer> Answers { get; set; } = new();
        public List<CommentQuestion> Comments { get; set; } = new();
        public List<CategoryQuestion> CategoryQuestions { get; set; } = new();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Question() { }

        public Question(string title, string content, Guid profileUserId, bool isUrgent)
        {
            Id = Guid.NewGuid();
            Title = title;
            Content = content;
            ProfileUserId = profileUserId;
            IsUrgent = isUrgent;
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }
    }
}
