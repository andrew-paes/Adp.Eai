using Adp.Eai.Domain.Models;
using Adp.Eai.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Eai.Service.Services
{
    public abstract class GenericService<E> : IGenericService<E> where E : GenericModel
    {
        public E Add(E entity)
        {
            E result = null;

            entity.CreatedDate = DateTime.Now;

            return result;
        }

        public E Get(Guid id)
        {
            E result = null;

            return result;
        }

        public IList<E> Get()
        {
            IList<E> result = new List<E>();

            

            return result;
        }
    }
}