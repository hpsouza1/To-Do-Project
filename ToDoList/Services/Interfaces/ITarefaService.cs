using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Services.Interfaces
{
    public interface ITarefaService
    {
        List<Tarefa> GetAll();
        Tarefa GetById(int id);
        void Add(Tarefa tarefa);
        bool Delete(int id);           
        Task<bool> Update(int id, Tarefa updatedTask); 
        bool CompleteTask(int id); 
        List<Tarefa> GetCompletedTasks();

    }
}
