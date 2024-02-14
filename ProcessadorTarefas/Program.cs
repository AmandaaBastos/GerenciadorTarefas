using ProcessadorTarefas.Repositorios;
using ProcessadorTarefas.Servicos;
namespace ProcessadorTarefas
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //var repository = new Repositorio();
            //var tarefas = repository.GetAll();

            //foreach (var tarefa in tarefas)
            //{
            //    Console.WriteLine($"Tarefa {tarefa.Id} e tenho {tarefa.SubtarefasPendentes.Count}");
            //}



            Repositorio.GerarTarefas(10);

            var repository = new Repositorio();

            var processador = new ProcessadorDeTarefas(repository);

            await processador.ExecutarTarefa(3);

        }
    }
}