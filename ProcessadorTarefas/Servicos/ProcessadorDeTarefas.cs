using ProcessadorTarefas.Entidades;
using ProcessadorTarefas.Repositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessadorTarefas.Servicos
{
    internal class ProcessadorDeTarefas: IProcessadorDeTarefas
    {
        private IRepository<Tarefa> _repository;

        public ProcessadorDeTarefas(IRepository<Tarefa> repository)
        {
            _repository = repository;
        }       

        public async Task ExecutarTarefa(int nTarefasEmParalelo)
        {
            var filaTarefas = new Queue<Tarefa>(_repository.GetAll());

            var tasksEmExecucao = new List<Task>();

            while (tasksEmExecucao.Count < nTarefasEmParalelo)
            {
                var tarefa = filaTarefas.Dequeue();
                tasksEmExecucao.Add(IniciarTarefa(tarefa));                
            }

            while (tasksEmExecucao.Count > 0)
            {
                var tarefaConcluida = await Task.WhenAny(tasksEmExecucao);
                tasksEmExecucao.Remove(tarefaConcluida);

                if (filaTarefas.Count > 0)
                {
                    var proximaTarefa = filaTarefas.Dequeue();
                    tasksEmExecucao.Add(IniciarTarefa(proximaTarefa));
                }
            }   
            await Task.WhenAll(tasksEmExecucao);
        }

        public async Task IniciarSubTarefa(Subtarefa subtarefa)
        {
            await Task.Delay(subtarefa.Duracao);
        }

        public async Task IniciarTarefa(Tarefa tarefa)
        {
            Console.WriteLine($"Iniciando tarefa {tarefa.Id}");
            tarefa.Estado = EstadoTarefa.EmExecucao;
            var tempo = new Stopwatch();
            tempo.Start();
            
            var subtarefasPendentes = tarefa.SubtarefasPendentes.ToList();
            
            foreach (var subtarefa in subtarefasPendentes)
            {
                await IniciarSubTarefa(subtarefa);               
            }

            tempo.Stop();
            tarefa.Estado = EstadoTarefa.Concluida;
            Console.WriteLine($"Tarefa {tarefa.Id} do status {tarefa.Estado} concluída em {tempo.ElapsedMilliseconds} milisegundos");

        }       

        public Task CancelarTarefa(int idTarefa)
        {
            throw new NotImplementedException();
        }

        public Task Encerrar()
        {
            throw new NotImplementedException();
        }
    }
}
