using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerfectPoliciesApi.Entities;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfectPoliciesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        #region Setup

        private readonly PerfectPoliciesContext _context;

        public QuizController(PerfectPoliciesContext context)
        {
            _context = context;
        }

        #endregion

        // GET: api/<QuizController>
        [HttpGet]
        public IEnumerable<Quiz> Get()
        {
            return _context.Quizzes;// .Include(c => c.Questions);
        }

        // GET api/<QuizController>/5
        [HttpGet("{id}")]
        public ActionResult<Quiz> Get(int id)
        {
            var quiz = _context.Quizzes.Find(id);
            if (quiz == null)
            {
                return NotFound();
            }
            return quiz;
        }

        // POST api/<QuizController>
        [Authorize]
        [HttpPost]
        public ActionResult<Quiz> Post(Quiz quiz)
        {
            if (quiz == null)
            {
                return BadRequest();
            }

            _context.Quizzes.Add(quiz);
            _context.SaveChanges();

            return CreatedAtAction("Post", quiz);
        }

        // PUT api/<QuizController>/5
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Quiz> Put(int id, [FromBody] Quiz quiz)
        {
            if (id != quiz.QuizId)
            {
                return BadRequest();
            }

            _context.Quizzes.Update(quiz);
            _context.SaveChanges();

            return Ok(quiz);
        }

        // DELETE api/<QuizController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var quiz = _context.Quizzes.Find(id);

            if (quiz != null)
            {
                _context.Quizzes.Remove(quiz);
                _context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }
    }
}
