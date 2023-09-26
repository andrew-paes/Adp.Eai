using Adp.Eai.Domain.Models;
using Adp.Eai.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Eai.Service.Interfaces
{
    public interface ICalculationService : IGenericService<Calculation>
    {
        Task<CalculationVM> GetCalculationResult();
    }
}