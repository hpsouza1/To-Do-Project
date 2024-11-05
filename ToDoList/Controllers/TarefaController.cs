using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;
        private readonly AppDbContext _context;

        // Construtor para injeção de dependência de ITarefaService e AppDbContext
        public TarefaController(ITarefaService tarefaService, AppDbContext context)
        {
            _tarefaService = tarefaService;
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Tarefa>> Get()
        {
            return _tarefaService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Tarefa> Get(int id)
        {
            var tarefa = _tarefaService.GetById(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return tarefa;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Tarefa novaTarefa)
        {
            _tarefaService.Add(novaTarefa);
            return CreatedAtAction(nameof(Get), new { id = novaTarefa.Id }, novaTarefa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] Tarefa updatedTask)
        {
            if (id != updatedTask.Id)
            {
                return BadRequest("ID mismatch.");
            }

            var result = await _tarefaService.Update(id, updatedTask);
            if (!result)
            {
                return NotFound("Task not found.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var tarefaExistente = _tarefaService.GetById(id);
            if (tarefaExistente == null)
            {
                return NotFound();
            }
            _tarefaService.Delete(id);
            return NoContent();
        }

        [HttpPut("complete/{id}")]
        public IActionResult CompleteTask(int id)
        {
            var success = _tarefaService.CompleteTask(id);
            if (!success) return NotFound();

            // Retorna uma resposta de sucesso com uma mensagem
            return Ok(new { success = true, message = "Task completed successfully." });
        }

        [HttpGet("completed")]
        public ActionResult<List<Tarefa>> GetCompletedTasks()
        {
            var completedTasks = _tarefaService.GetCompletedTasks();
            if (completedTasks == null || completedTasks.Count == 0)
            {
                return Ok(new List<Tarefa>()); // Retorna uma lista vazia se não houver tarefas concluídas
            }
            return Ok(completedTasks);
        }

    }
}
