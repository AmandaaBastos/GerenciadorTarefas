using ProcessadorTarefas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessadorTarefas.Servicos
{
    internal interface IProcessadorDeTarefas
    {
        Task IniciarSubTarefa(Subtarefa subtarefa);
        Task IniciarTarefa(Tarefa tarefa);
        Task ExecutarTarefa(int nTarefasEmParalelo);
        Task CancelarTarefa(int idTarefa);
        Task Encerrar();
    }
}
