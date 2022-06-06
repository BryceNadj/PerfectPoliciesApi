using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerfectPoliciesApi.Entities;
using System.Collections.Generic;

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
        /// <summary>
        /// Receives a HTTP Get request to get all quizzes
        /// </summary>
        /// <returns>A list of quizzes</returns>
        [HttpGet]
        public IEnumerable<Quiz> Get()
        {
            return _context.Quizzes;
        }

        // GET api/<QuizController>/5
        /// <summary>
        /// Receives an HTTP Get request to retrive one quiz with a specified Id
        /// </summary>
        /// <param name="id">The Id of the quiz to return, if it exists</param>
        /// <returns>A quiz entity</returns>
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
        /// <summary>
        /// Sends an HTTP Post request with a Quiz Entity
        /// </summary>
        /// <param name="quiz">The quiz to add to the database</param>
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
        /// <summary>
        /// Receives an HTTP Put request to update a Quiz entity
        /// </summary>
        /// <param name="id">The Id of the quiz to update</param>
        /// <param name="quiz">The entity to replace the old quiz</param>
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
        /// <summary>
        /// Receives an HTTP Delete request to remove a quiz entity from the database
        /// </summary>
        /// <param name="id">The Id of the quiz to remove</param>
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
