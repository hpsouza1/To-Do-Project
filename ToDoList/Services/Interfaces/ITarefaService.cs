using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Services.Interfaces
{
    public interface ITarefaService
    {
        List<Tarefa> GetAll();
        Tarefa GetById(int id);
        void Add(Tarefa tarefa);
        bool Delete(int id);             // Retorno ajustado para bool
        Task<bool> Update(int id, Tarefa updatedTask); // Assinatura do método de atualização
        bool CompleteTask(int id); // Adiciona o método CompleteTask
        List<Tarefa> GetCompletedTasks();

    }
}
