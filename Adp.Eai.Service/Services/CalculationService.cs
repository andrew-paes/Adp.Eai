using Adp.Eai.Domain.Models;
using Adp.Eai.Domain.ViewModels;
using Adp.Eai.Service.Interfaces;
using Adp.Eai.Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Eai.Service.Services
{
    public class CalculationService : GenericService<Calculation>, ICalculationService
    {
        public async Task<CalculationVM> GetCalculationResult()
        {
            Calculation calculation = new()
            {
                Id = Guid.NewGuid(),
                Operation = "addition",
                Left = 3,
                Right = 5,
                CreatedDate = DateTime.Now
            };

            CalculationVM result = new()
            {
                Id = calculation.Id,
                Result = await Calculator.PerformCalculation(calculation.Operation, calculation.Left, calculation.Right)
            };

            return result;
        }
    }
}