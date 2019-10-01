using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using tarefawebapi.Models;

namespace tarefawebapi.Controllers
{
    [Route("api/[Controller]")]
    public class TarefasController : Controller
    {
        private readonly TarefaContext _context;
        public TarefasController(TarefaContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public IEnumerable<Tarefa> GetAll()
        {
            return _context.Tarefas.ToList();
        }

        [HttpGet("{id}", Name="GetTarefa")]
        public IActionResult GetPorId(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(t=> t.Id == id);
            if(tarefa==null)
            {
                return NotFound();
            }

            return new ObjectResult(tarefa);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Tarefa item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Tarefas.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTarefa", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Tarefa item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            tarefa.IsCompleta = item.IsCompleta;
            tarefa.Nome = item.Nome;

            _context.Tarefas.Update(tarefa);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
            return new NoContentResult();
        }

    }
}