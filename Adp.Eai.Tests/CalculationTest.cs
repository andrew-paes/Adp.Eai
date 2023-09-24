using Adp.Eai.Domain.Enums;

namespace Adp.Eai.Tests
{
    /// <summary>
    /// Calculation Is Known
    /// Addition
    /// Subtraction
    /// Multiplication
    /// Division
    /// Remainder
    /// Status Code Is Known
    /// </summary>
    public class CalculationTest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [Theory]
        [InlineData(MathOperation.Addition, -4, 3)]
        [InlineData(MathOperation.Addition, -3, 2)]
        [InlineData(MathOperation.Addition, long.MinValue, long.MaxValue)] //-9223372036854775808, 9223372036854775807
        public void Calculation_Addition(MathOperation operation, long left, long right)
        {
            // Arrange

            // Act
            long result = (operation.Equals(MathOperation.Addition)) ? (left + right) : 0;

            // Assert
            Assert.Equal(-1, result);
        }
    }
}