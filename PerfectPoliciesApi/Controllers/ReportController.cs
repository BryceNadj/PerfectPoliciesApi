using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectPoliciesApi.DTO.ViewModels;
using PerfectPoliciesApi.Entities;
using System.Linq;

namespace PerfectPoliciesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        // Constructor injection to provide acess to database
        private readonly PerfectPoliciesContext _context;

        public ReportController(PerfectPoliciesContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the number of options for all of the questions in the database
        /// </summary>
        /// <returns>An OptionCountForQuestion object containing each question, its number of options, and the quiz id</returns>
        [HttpGet("OptionQuestionCount")]
        public IActionResult OptionQuestionCount()
        {
            var questions = _context.Questions.Include(c => c.Options);

            var questionOptionCountList = questions.Select(c => new OptionCountForQuestion
            {
                QuestionText = c.QuestionText,
                OptionCount = c.Options.Count,
                QuizId = c.QuizId
            }).ToList();

            // Question   - Text
            // - Option   - +1
            // - Option   - +1
            // - Option   - +1
            // Question   - Text
            // - Option   - +1
            // - Option   - +1

            return Ok(questionOptionCountList);
        }
    }
}
