using System.ComponentModel;

namespace Adp.Eai.Domain.Enums
{
    public enum MathOperation
    {
        [Description("Addition")]
        Addition = 1,

        [Description("Subtraction")]
        Subtraction = 2,

        [Description("Multiplication")]
        Multiplication = 3,

        [Description("Division")]
        Division = 4,

        [Description("Remainder")]
        Remainder = 5
    }
}