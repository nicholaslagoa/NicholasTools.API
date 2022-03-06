using MongoDB.Driver;
using NicholasTools.API.Data.Configurations;
using NicholasTools.API.Models;
using System.Collections.Generic;

namespace NicholasTools.API.Data.Repositories
{
    public class TarefasRepository : BaseRepository, ITarefasRepository
    {
        private readonly IMongoCollection<Tarefa> _tarefas;
        public TarefasRepository(IDatabaseConfig databaseConfig) : base(databaseConfig)
        {
            _tarefas = _database.GetCollection<Tarefa>("tarefas");
        }
        public void Adicionar(Tarefa tarefa)
        {
            _tarefas.InsertOne(tarefa);
        }

        public void Atualizar(Tarefa tarefaAtualizada)
        {
            _tarefas.ReplaceOne(x => x.Id == tarefaAtualizada.Id, tarefaAtualizada);
        }

        public IEnumerable<Tarefa> Buscar()
        {
            return _tarefas.Find(tarefa => true).ToList();
        }

        public Tarefa Buscar(string id)
        {
            return _tarefas.Find(tarefa => tarefa.Id == id).SingleOrDefault();
        }

        public void RemoverTarefa(string id)
        {
            _tarefas.DeleteOne(tarefa => tarefa.Id == id);
        }
    }
}
