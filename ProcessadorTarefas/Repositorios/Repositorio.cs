using ProcessadorTarefas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessadorTarefas.Repositorios
{
    internal class Repositorio: IRepository<Tarefa> 
    {         
       
        public static List<Tarefa> Tarefas { get; set; }

        public static void GerarTarefas(int n_tarefasIniciais)
        {
            Tarefas = new List<Tarefa>();
            var random = new Random();

            for(int i = 0; i < n_tarefasIniciais; i++)
            {
                var tarefa = new Tarefa();
                
                for (int j = 0; j < random.Next(1, 5); j++)
                {
                    var subtarefa = new Subtarefa
                    {
                        Duracao = TimeSpan.FromSeconds(random.Next(1, 5))
                    };
                    tarefa.SubtarefasPendentes.Add(subtarefa);
                }
                Tarefas.Add(tarefa);
            }
        }
       
        private Tarefa GerarTarefa()
        {
            var tarefa = new Tarefa();
            var random = new Random();

            for (int j = 0; j < random.Next(1, 5); j++)
            {
                var subtarefa = new Subtarefa
                {
                    Duracao = TimeSpan.FromSeconds(random.Next(1, 5))
                };
                tarefa.SubtarefasPendentes.Add(subtarefa);
            }

            return tarefa;
        }

        public IEnumerable<Tarefa> GetAll()
        {
            return Tarefas;
        }

        public Tarefa? GetById(int id)
        {
           return Tarefas.FirstOrDefault(t => t.Id == id);
        }

        public void Add()
        {
            Tarefas.Add(GerarTarefa());
        }

        public void Update(Tarefa entity)
        {
            throw new NotImplementedException();
        }
    }
}
