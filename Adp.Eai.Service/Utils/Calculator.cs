using Adp.Eai.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adp.Eai.Service.Utils
{
    public class Calculator
    {
        public static Task<decimal> PerformCalculation(string? operation, long left, long right)
        {
            if(string.IsNullOrEmpty(operation))
                throw new ArgumentException($"Operation not found: {operation}");

            _ = Enum.TryParse(operation.ToUpper(), out MathOperation operationEnum);

            decimal result;

            switch (operationEnum)
            {
                case MathOperation.ADDITION:
                    result = left + right;
                    break;
                case MathOperation.SUBTRACTION:
                    result = left - right;
                    break;
                case MathOperation.MULTIPLICATION:
                    result = left * right;
                    break;
                case MathOperation.DIVISION:
                    if (right != 0)
                        result = (decimal)left / right;
                    else
                        throw new DivideByZeroException($"Unsupported operation: division of {left} by {right}");
                    break;
                case MathOperation.REMAINDER:
                    result = (decimal)left % right;
                    break;
                default:
                    throw new ArgumentException($"Operation not found: {operation}");
            }

            return Task.FromResult(result);
        }
    }
}