using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContatosWebAPI.Models;

namespace ContatosWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Contato")]
    public class ContatoController : Controller
    {
        private readonly ContatoDbContext _context;

        public ContatoController(ContatoDbContext context)
        {
            _context = context;
        }

        // GET: api/Contato
        [HttpGet]
        public IEnumerable<Contato> GetContatos()
        {
            return _context.Contatos;
        }

        // GET: api/Contato/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContato([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contato = await _context.Contatos.SingleOrDefaultAsync(m => m.Id == id);

            if (contato == null)
            {
                return NotFound();
            }

            return Ok(contato);
        }

        // PUT: api/Contato/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContato([FromRoute] string id, [FromBody] Contato contato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contato.Id)
            {
                return BadRequest();
            }

            _context.Entry(contato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Contato
        [HttpPost]
        public async Task<IActionResult> PostContato([FromBody] Contato contato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContato", new { id = contato.Id }, contato);
        }

        // DELETE: api/Contato/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContato([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contato = await _context.Contatos.SingleOrDefaultAsync(m => m.Id == id);
            if (contato == null)
            {
                return NotFound();
            }

            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();

            return Ok(contato);
        }

        private bool ContatoExists(string id)
        {
            return _context.Contatos.Any(e => e.Id == id);
        }
    }
}