namespace Application.Questions.DTOs;

public class CreateQuestionDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsUrgent { get; set; }

    // Пока JWT не внедрен, симулируем Id пользователя:
    public Guid ProfileUserId { get; set; }
}
