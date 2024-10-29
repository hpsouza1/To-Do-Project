using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data;

namespace WebApplication1.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Tarefa> GetAll()
        {
            return _context.Tarefas.ToList();
        }

        public Tarefa GetById(int id)
        {
            return _context.Tarefas.Find(id); // Ou Use .FirstOrDefault(t => t.Id == id);
        }

        public void Add(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges(); // Salva as alterações no banco de dados
        }

        public void Update(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            _context.SaveChanges(); // Salva as alterações no banco de dados
        }

        public void Delete(int id)
        {
            var tarefa = GetById(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                _context.SaveChanges(); // Salva as alterações no banco de dados
            }
        }
    }
}   
