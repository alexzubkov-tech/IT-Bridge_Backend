//namespace CoreService.Application.Questions.Dtos
//{
//    public class QuestionWithDetailsDto
//    {
//        public int Id { get; set; }
//        public string Title { get; set; } = string.Empty;
//        public string Content { get; set; } = string.Empty;
//        public bool IsUrgent { get; set; }
//        public DateTime CreatedAt { get; set; }
//        public DateTime UpdatedAt { get; set; }
//        public int UserProfileId { get; set; }

//        // Связанные данные
//        public List<AnswerInQuestionDto> Answers { get; set; } = new();
//        public List<TagInQuestionDto> Tags { get; set; } = new();
//        public List<CategoryInQuestionDto> Categories { get; set; } = new();
//        public List<RatingInQuestionDto> Ratings { get; set; } = new();
//        public List<CommentInQuestionDto> Comments { get; set; } = new();
//    }

//    // Под-DTO для ответов
//    public class AnswerInQuestionDto
//    {
//        public int Id { get; set; }
//        public string Content { get; set; } = string.Empty;
//        public int UserProfileId { get; set; }
//        public DateTime CreatedAt { get; set; }
//        public DateTime UpdatedAt { get; set; }
//    }

//    // Под-DTO для тэгов
//    public class TagInQuestionDto
//    {
//        public int Id { get; set; }
//        public string Name { get; set; } = string.Empty;
//    }

//    // Под-DTO для категорий
//    public class CategoryInQuestionDto
//    {
//        public int Id { get; set; }
//        public string Name { get; set; } = string.Empty;
//    }

//    // Под-DTO для рейтинга
//    public class RatingInQuestionDto
//    {
//        public int Id { get; set; }
//        public int UserProfileId { get; set; }
//        public bool IsUpvote { get; set; }
//        public DateTime CreatedAt { get; set; }
//    }

//    // Под-DTO для комментариев
//    public class CommentInQuestionDto
//    {
//        public int Id { get; set; }
//        public string Text { get; set; } = string.Empty;
//        public int UserProfileId { get; set; }
//        public DateTime CreatedAt { get; set; }
//    }
//}