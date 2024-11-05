using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;


namespace WebApplication1.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly AppDbContext _context;

        public TarefaService(AppDbContext context)
        {
            _context = context;
        }

        public List<Tarefa> GetAll() => _context.Tarefas.ToList();

        public Tarefa GetById(int id) => _context.Tarefas.Find(id);

        public void Add(Tarefa novaTarefa)
        {
            _context.Tarefas.Add(novaTarefa);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null) return false;
            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> Update(int id, Tarefa updatedTask)
        {
            var existingTask = await _context.Tarefas.FindAsync(id);
            if (existingTask == null) return false;

            // Desanexa a entidade existente para evitar o erro de rastreamento duplicado
            _context.Entry(existingTask).State = EntityState.Detached;

            // Atualiza os dados da tarefa e marca como modificada
            _context.Attach(updatedTask).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool CompleteTask(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null) return false;

            tarefa.Completed = true;
            _context.SaveChanges();
            return true;
        }

        public List<Tarefa> GetCompletedTasks()
        {
            // Filtra tarefas com status "concluído"
            return _context.Tarefas.Where(t => t.Completed == true).ToList();
        }



    }

}
