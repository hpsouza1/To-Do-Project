using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        List<Tarefa> GetAll(); 
        Tarefa GetById(int id); 
        void Add(Tarefa tarefa); 
        void Update(Tarefa tarefa); 
        void Delete(int id); 
    }
}
