using System.Collections.Generic;

namespace PerfectPoliciesApi.Entities
{
    public class Question
    {
        // Primary Key
        public int QuestionId { get; set; }

        // Attributes
        public string Topic { get; set; }
        public string QuestionText { get; set; }
        public string? Image { get; set; }

        // Foreign Key
        public int QuizId { get; set; }

        // Navigation Property
        public Quiz Quiz { get; set;  }
        public ICollection<Option> Options { get; set; }
    }
}
