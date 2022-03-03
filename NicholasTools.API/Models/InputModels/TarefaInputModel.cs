using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NicholasTools.API.Models.InputModels
{
    public class TarefaInputModel
    {
        public string Nome { get; set; }
        public string Detalhes { get; set; }
        public bool? Concluido { get; set; }
    }
}
