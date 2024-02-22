using SIstemaDeTarefas.Models;

namespace SIstemaDeTarefas.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        Task<TarefaModel> FindTaskById(int id);
        Task<List<TarefaModel>> GetAllTasks();
        Task<TarefaModel> AddTask(TarefaModel tarefa);
        Task<bool> DeleteTask(int id);
    }
}
