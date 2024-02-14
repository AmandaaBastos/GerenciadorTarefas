using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessadorTarefas.Repositorios
{
    public interface IRepository <T>
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        void Add();
        void Update(T entity);
    }
}
