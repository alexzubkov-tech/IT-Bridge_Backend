namespace Application.Questions.DTOs;

public class QuestionDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsUrgent { get; set; }

    public int ViewCount { get; set; }
    public DateTime CreatedAt { get; set; }

    public Guid ProfileUserId { get; set; }
    public string ProfileUserName { get; set; } = string.Empty; // можно брать из UserProfile.Name
}
