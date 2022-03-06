using Microsoft.AspNetCore.Mvc;
using NicholasTools.API.Data.Repositories;
using NicholasTools.API.Models;
using NicholasTools.API.Models.InputModels;
using System;
using System.Net;

namespace NicholasTools.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private ITarefasRepository _tarefasRepository;
        public TarefasController(ITarefasRepository tarefasRepository)
        {
            _tarefasRepository = tarefasRepository;
        }

        // GET: api/tarefas
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var tarefas = _tarefasRepository.Buscar();
                return Ok(tarefas);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro ao processar a requisição.");
            }
        }

        // GET api/tarefas/{id}
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                var tarefa = _tarefasRepository.Buscar(id);

                if (tarefa == null)
                    return NotFound();

                return Ok(tarefa);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro ao processar a requisição.");
            }
        }

        // POST api/tarefas
        [HttpPost]
        public ActionResult Post([FromBody]TarefaInputModel novaTarefa)
        {
            try
            {
                var tarefa = new Tarefa(novaTarefa.Nome, novaTarefa.Detalhes);

                _tarefasRepository.Adicionar(tarefa);
                return Created("", tarefa);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro ao processar a requisição.");
            }
        }

        // PUT api/tarefas/
        [HttpPut]
        public ActionResult Put([FromBody]TarefaInputModel tarefaAtualizada)
        {
            try
            {
                var tarefa = _tarefasRepository.Buscar(tarefaAtualizada.Id);
                if (tarefa == null)
                    return NotFound();

                tarefa.AtualizarTarefa(tarefaAtualizada.Nome, tarefaAtualizada.Detalhes, tarefaAtualizada.Concluido);

                _tarefasRepository.Atualizar(tarefa);

                return Ok(tarefa);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro ao processar a requisição.");
            }
        }

        // DELETE api/tarefas/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(string id) 
        {
            try
            {
                var tarefa = _tarefasRepository.Buscar(id);

                if (tarefa == null)
                    return NotFound();

                _tarefasRepository.RemoverTarefa(id);

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro ao processar a requisição.");
            }
        }
    }
}
