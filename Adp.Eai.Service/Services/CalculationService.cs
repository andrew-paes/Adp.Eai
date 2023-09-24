using Adp.Eai.Domain.Models;
using Adp.Eai.Domain.ViewModels;
using Adp.Eai.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Eai.Service.Services
{
    public class CalculationService : GenericService<Calculation>, ICalculationService
    {
        public CalculationVM GetCalculationResult(Calculation param)
        {
            throw new NotImplementedException();
        }
    }
}