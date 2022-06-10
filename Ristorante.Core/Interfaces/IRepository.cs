using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> Fetch();
        T GetById(int id);
        T Add(T item);
        T Update(T item);
        bool Delete(T item);
    }
}
