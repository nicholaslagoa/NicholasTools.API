namespace NicholasTools.API.Models.InputModels
{
    public class TarefaInputModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Detalhes { get; set; }
        public bool Concluido { get; set; } = false;
    }
}
