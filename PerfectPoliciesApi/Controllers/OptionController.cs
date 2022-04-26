using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerfectPoliciesApi.DTO;
using PerfectPoliciesApi.Entities;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfectPoliciesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        #region Setup

        private readonly PerfectPoliciesContext _context;

        public OptionController(PerfectPoliciesContext context)
        {
            _context = context;
        }

        #endregion

        // GET: api/<OptionsController>
        [HttpGet]
        public IEnumerable<Option> Get()
        {
            return _context.Options;
        }

        // GET api/<OptionsController>/5
        [HttpGet("{id}")]
        public ActionResult<Option> Get(int id)
        {
            var option = _context.Options.Find(id);
            if (option == null)
            {
                return NotFound();
            }
            return option;
        }

        // POST api/<OptionsController>
        [Authorize]
        [HttpPost]
        public ActionResult<Option> Post(OptionCreate option)
        {
            if (option == null)
            {
                return BadRequest();
            }

            // convert the DTO to an entity
            Option createdOption = new Option()
            {
                OptionText = option.OptionText,
                Order = option.Order,
                IsCorrect = option.IsCorrect,
                QuestionId = option.QuestionId
            };

            // Save the entity
            _context.Options.Add(createdOption);

            _context.SaveChanges();

            return CreatedAtAction("Post", createdOption);
        }

        // PUT api/<OptionsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Option> Put(int id, [FromBody] Option option)
        {
            if (id != option.OptionId)
            {
                return BadRequest();
            }

            _context.Options.Update(option);
            _context.SaveChanges();

            return Ok(option);
        }

        // DELETE api/<OptionsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var option = _context.Options.Find(id);

            if (option != null)
            {
                _context.Options.Remove(option);
                _context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }
    }
}
