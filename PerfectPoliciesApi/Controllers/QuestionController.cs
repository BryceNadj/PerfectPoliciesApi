using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectPoliciesApi.DTO;
using PerfectPoliciesApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfectPoliciesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        #region Setup

        private readonly PerfectPoliciesContext _context;

        public QuestionController(PerfectPoliciesContext context)
        {
            _context = context;
        }

        #endregion

        #region CRUD Endpoints
        // GET: api/<QuestionController>
        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return _context.Questions; //.Include(c => c.Options);
        }

        // GET api/<QuestionController>/5
        [HttpGet("{id}")]
        public ActionResult<Question> Get(int id)
        {
            var question = _context.Questions.Find(id);
            if (question == null)
            {
                return NotFound();
            }
            return question;
        }

        // POST api/<QuestionController>
        [HttpPost]
        public ActionResult<Question> Post(QuestionCreate question)
        {
            if (question == null)
            {
                return BadRequest();
            }

            // convert the DTO to an entity
            Question createdQuestion = new Question()
            {
                Topic = question.Topic,
                QuestionText = question.QuestionText,
                Image = question.Image,
                QuizId = question.QuizId
            };

            // Save the entity
            _context.Questions.Add(createdQuestion);

            _context.SaveChanges();

            return CreatedAtAction("Post", createdQuestion);
        }

        // PUT api/<QuestionController>/5
        [HttpPut("{id}")]
        public ActionResult<Question> Put(int id, [FromBody] Question question)
        {
            if (id != question.QuizId)
            {
                return BadRequest();
            }

            _context.Questions.Update(question);
            _context.SaveChanges();

            return Ok(question);
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var question = _context.Questions.Find(id);

            if (question != null)
            {
                _context.Questions.Remove(question);
                _context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }
        #endregion

        #region Custom Endpoints

        /// <summary>
        /// Get all Questions for a given Quiz
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("QuestionsByQuizId")]
        public ActionResult QuestionsByQuizId(int id)
        {
            return Ok(_context.Questions.Where(c => c.QuizId == id));
        }

        #endregion
    }
}
