namespace CoreService.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
        public ICollection<QuestionCategory> QuestionCategories { get; set; } = new List<QuestionCategory>();
    }
}
