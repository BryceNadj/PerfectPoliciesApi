using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class OptionsController : ControllerBase
    {
        #region Setup

        private readonly PerfectPoliciesContext _context;

        public OptionsController(PerfectPoliciesContext context)
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
        [HttpPost]
        public ActionResult<Option> Post(Option option)
        {
            if (option == null)
            {
                return BadRequest();
            }

            _context.Options.Add(option);
            _context.SaveChanges();

            return CreatedAtAction("Post", option);
        }

        // PUT api/<OptionsController>/5
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
