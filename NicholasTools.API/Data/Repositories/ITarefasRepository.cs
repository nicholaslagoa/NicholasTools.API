using NicholasTools.API.Models;
using System.Collections.Generic;

namespace NicholasTools.API.Data.Repositories
{
    public interface ITarefasRepository
    {
        void Adicionar(Tarefa tarefa);
        void RemoverTarefa(string id);
        void Atualizar(Tarefa tarefaAtualizada);
        IEnumerable<Tarefa> Buscar();
        Tarefa Buscar(string id);
    }
}
