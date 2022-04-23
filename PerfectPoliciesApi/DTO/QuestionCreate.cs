using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectPoliciesApi.DTO
{
    public class QuestionCreate
    {
        public string Topic { get; set; }
        public string QuestionText { get; set; }
        public string? Image { get; set; }
        public int QuizId { get; set; }
    }
}
