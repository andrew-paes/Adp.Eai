using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Eai.Domain.Models
{
    public abstract class GenericModel
    {
        protected GenericModel() { }

        protected GenericModel(DateTime? createdDate)
        {
            CreatedDate = createdDate;
        }

        public Guid Id { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}