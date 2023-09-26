using Adp.Eai.Domain.Enums;
using Adp.Eai.Service.Utils;
using System.Threading.Tasks;

namespace Adp.Eai.Tests
{
    /// <summary>
    /// T - Calculation is known
    /// T - Addition
    /// T - Subtraction
    /// T - Multiplication
    /// T - Division
    /// T - Remainder
    /// </summary>
    public class CalculationTest
    {
        #region [ Operation ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        [Theory]
        [InlineData("Addition")]
        [InlineData("Subtraction")]
        [InlineData("Multiplication")]
        [InlineData("Division")]
        [InlineData("Remainder")]

        public void Calculation_IsKnown(string operation)
        {
            // Arrange

            // Act
            bool result = Enum.TryParse(operation.ToUpper(), out MathOperation _);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        [Theory]
        [InlineData("Xyz")]

        public async void Calculation_IsNotKnown(string operation)
        {
            // Arrange

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => Calculator.PerformCalculation(operation, 0, 0));
        }

        #endregion

        #region [ Addition ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        [Theory]
        [InlineData("Addition", -4, 3)]
        [InlineData("Addition", 3, -4)]
        [InlineData("Addition", long.MinValue, long.MaxValue)] //-9223372036854775808, 9223372036854775807
        public async void Calculation_Addition(string operation, long left, long right)
        {
            // Arrange

            // Act
            decimal result = await Calculator.PerformCalculation(operation, left, right);

            // Assert
            Assert.Equal(-1, result);
        }

        #endregion

        #region [ Subtraction ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [Theory]
        [InlineData("Subtraction", 0, 3)]
        [InlineData("Subtraction", 3, 6)]
        [InlineData("Subtraction", -2, 1)]
        public async void Calculation_SubtractionPositiveRight(string operation, long left, long right)
        {
            // Arrange

            // Act
            decimal result = await Calculator.PerformCalculation(operation, left, right);

            // Assert
            Assert.Equal(-3, result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [Theory]
        [InlineData("Subtraction", 0, -6)]
        [InlineData("Subtraction", -3, -9)]
        [InlineData("Subtraction", 3, -3)]
        public async void Calculation_SubtractionNegativeRight(string operation, long left, long right)
        {
            // Arrange

            // Act
            decimal result = await Calculator.PerformCalculation(operation, left, right);

            // Assert
            Assert.Equal(6, result);
        }

        #endregion

        #region [ Multiplication ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [Theory]
        [InlineData("Multiplication", 0, 0)]
        [InlineData("Multiplication", 0, 1)]
        [InlineData("Multiplication", 1, 0)]
        [InlineData("Multiplication", 0, -1)]
        [InlineData("Multiplication", -1, 0)]
        public async void Calculation_MultiplicationZeroResult(string operation, long left, long right)
        {
            // Arrange

            // Act
            decimal result = await Calculator.PerformCalculation(operation, left, right);

            // Assert
            Assert.Equal(0, result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [Theory]
        [InlineData("Multiplication", -2, -3)]
        [InlineData("Multiplication", 2, 3)]
        public async void Calculation_MultiplicationPositiveResult(string operation, long left, long right)
        {
            // Arrange

            // Act
            decimal result = await Calculator.PerformCalculation(operation, left, right);

            // Assert
            Assert.Equal(6, result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [Theory]
        [InlineData("Multiplication", -2, 3)]
        [InlineData("Multiplication", 2, -3)]
        public async void Calculation_MultiplicationNegativeResult(string operation, long left, long right)
        {
            // Arrange

            // Act
            decimal result = await Calculator.PerformCalculation(operation, left, right);

            // Assert
            Assert.Equal(-6, result);
        }

        #endregion

        #region [ Division ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        [Theory]
        [InlineData("Division", 0, 0)]
        [InlineData("Division", 1, 0)]
        [InlineData("Division", -1, 0)]
        public async void Calculation_DivisionByZero(string operation, long left, long right)
        {
            // Arrange

            // Act and Assert
            await Assert.ThrowsAsync<DivideByZeroException>(() => Calculator.PerformCalculation(operation, 0, 0));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [Theory]
        [InlineData("Division", 0, 1)]
        [InlineData("Division", 0, -1)]

        public async void Calculation_DivisionZeroResult(string operation, long left, long right)
        {
            // Arrange

            // Act
            decimal result = await Calculator.PerformCalculation(operation, left, right);

            // Assert
            Assert.Equal(0, result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [Theory]
        [InlineData("Division", -4, -2)]
        [InlineData("Division", 4, 2)]
        public async void Calculation_DivisionPositiveResult(string operation, long left, long right)
        {
            // Arrange

            // Act
            decimal result = await Calculator.PerformCalculation(operation, left, right);

            // Assert
            Assert.Equal(2, result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [Theory]
        [InlineData("Division", 4, -2)]
        [InlineData("Division", -4, 2)]
        public async void Calculation_DivisionNegativeResult(string operation, long left, long right)
        {
            // Arrange

            // Act
            decimal result = await Calculator.PerformCalculation(operation, left, right);

            // Assert
            Assert.Equal(-2, result);
        }

        #endregion

        #region [ Remainder]

        // <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        [Theory]
        [InlineData("Remainder", 0, 0)]
        [InlineData("Remainder", 1, 0)]
        [InlineData("Remainder", -1, 0)]
        public async void Calculation_RemainderByZero(string operation, long left, long right)
        {
            // Arrange

            // Act and Assert
            await Assert.ThrowsAsync<DivideByZeroException>(() => Calculator.PerformCalculation(operation, 0, 0));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        [Theory]
        [InlineData("Remainder", 0, 1)]
        [InlineData("Remainder", 0, -1)]
        public async void Calculation_RemainderZeroResult(string operation, long left, long right)
        {
            // Arrange

            // Act
            decimal result = await Calculator.PerformCalculation(operation, left, right);

            // Assert
            Assert.Equal(0, result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [Theory]
        [InlineData("Remainder", -4, -2)]
        [InlineData("Remainder", 4, -2)]
        [InlineData("Remainder", -4, 2)]
        [InlineData("Remainder", 4, 2)]
        public async void Calculation_Remainder(string operation, long left, long right)
        {
            // Arrange

            // Act
            decimal result = await Calculator.PerformCalculation(operation, left, right);

            // Assert
            Assert.Equal(0, result);
        }

        #endregion
    }
}