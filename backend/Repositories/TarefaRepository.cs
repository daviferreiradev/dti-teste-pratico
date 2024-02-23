using Microsoft.EntityFrameworkCore;
using SIstemaDeTarefas.Data;
using SIstemaDeTarefas.Models;
using SIstemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly SistemaTarefasDBContext _dbContext;

        public TarefaRepository(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }

        public async Task<TarefaModel> FindTaskById(int id)
        {
            return await _dbContext.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> GetAllTasks()
        {
            return await _dbContext.Tarefas.ToListAsync();
        }

        public async Task<TarefaModel> AddTask(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task<bool> DeleteTask(int id)
        {
            TarefaModel tarefaPorId = await FindTaskById(id);

            if(tarefaPorId == null)
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            

            _dbContext.Tarefas.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
