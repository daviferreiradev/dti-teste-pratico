using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIstemaDeTarefas.Models;
using SIstemaDeTarefas.Repositories.Interfaces;

namespace SIstemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(ITarefaRepository _tarefaRepository)
        {
            this._tarefaRepository = _tarefaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> BuscarTodasTarefas()
        {
            List<TarefaModel> tarefas = await _tarefaRepository.GetAllTasks();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarTarefaPorId(int id)
        {
            TarefaModel tarefa = await _tarefaRepository.FindTaskById(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> AdicionarTarefa([FromBody] TarefaModel tarefa)
        {
            TarefaModel tarefaAdicionada = await _tarefaRepository.AddTask(tarefa);
            return Ok(tarefaAdicionada);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeletarTarefa(int id)
        {
            bool tarefaDeletada = await _tarefaRepository.DeleteTask(id);
            return Ok(tarefaDeletada);
        }
    }
}
