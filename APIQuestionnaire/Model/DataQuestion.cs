namespace APIQuestionnaire.Model
{
    public class DataQuestion
    {
        public string? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; } = string.Empty;
        public string House { get; set; } = string.Empty;
        public string Work { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string BusinessType { get; set; } = string.Empty;
    }
}
