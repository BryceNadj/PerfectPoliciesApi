using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectPoliciesApi.DTO
{
    public class OptionCreate
    {
        public string OptionText { get; set; }
        public string Order { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
