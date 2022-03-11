using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectPoliciesApi.Entities
{
    public class Quiz
    {
        // Primary Key
        public int QuizId { get; set; }
        
        // Attributes
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Author { get; set; }
        public DateTime? DateCreated { get; set; }
        public int PassingGrade { get; set; }

        // Navigation Property
        public ICollection<Question> Questions { get; set; }
    }
}
