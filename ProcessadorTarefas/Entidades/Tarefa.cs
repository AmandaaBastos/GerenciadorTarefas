using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessadorTarefas.Entidades
{
    public interface ITarefa
    {
        int Id { get; }
        EstadoTarefa Estado { get; }
        DateTime IniciadaEm { get; }
        DateTime EncerradaEm { get; }
        ICollection<Subtarefa>? SubtarefasPendentes { get; }
        ICollection<Subtarefa>? SubtarefasExecutadas { get; }
    }

    public class Tarefa : ITarefa
    {
        public int Id { get; set; }
        public EstadoTarefa Estado { get; set; }
        public DateTime IniciadaEm { get; set; }
        public DateTime EncerradaEm { get; set; }
        public ICollection<Subtarefa>? SubtarefasPendentes { get; set; }
        public ICollection<Subtarefa>? SubtarefasExecutadas { get; set; }

        private static int nextId = 0;
        public Tarefa()
        {
            Id = ++nextId;
            Estado = EstadoTarefa.Criada;
            IniciadaEm = DateTime.Now;
            SubtarefasPendentes = new List<Subtarefa>();
            SubtarefasExecutadas = new List<Subtarefa>();
        }
     
    }
}
