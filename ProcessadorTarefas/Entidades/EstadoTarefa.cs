using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessadorTarefas.Entidades
{
    public enum EstadoTarefa
    {
        Criada,
        Agendada,
        EmExecucao,
        EmPausa,
        Cancelada,
        Concluida
    }
}
