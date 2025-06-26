using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.Domain.Entities
{
    public class CommentQuestion
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public Guid QuestionId { get; set; }
        public Question Question { get; set; } = null!;
        public Guid ProfileUserId { get; set; }
        public UserProfile ProfileUser { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public CommentQuestion() { }

        public CommentQuestion(string content, Guid questionId, Guid profileUserId)
        {
            Id = Guid.NewGuid();
            Content = content;
            QuestionId = questionId;
            ProfileUserId = profileUserId;
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }

    }
}
