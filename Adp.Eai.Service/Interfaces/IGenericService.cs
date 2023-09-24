using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Eai.Service.Interfaces
{
    public interface IGenericService<T>
        where T : class
    {
        T Add(T entity);

        T Get(Guid id);

        IList<T> Get();
    }
}
