using System.ComponentModel;

namespace Adp.Eai.Domain.Enums
{
    public enum MathOperation
    {
        [Description("Addition")]
        ADDITION = 1,

        [Description("Subtraction")]
        SUBTRACTION = 2,

        [Description("Multiplication")]
        MULTIPLICATION = 3,

        [Description("Division")]
        DIVISION = 4,

        [Description("Remainder")]
        REMAINDER = 5
    }
}