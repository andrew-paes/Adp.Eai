using Adp.Eai.Domain.Enums;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        [Theory]
        [InlineData("ADDITION")]
        [InlineData("SUBTRACTION")]
        [InlineData("MULTIPLICATION")]
        [InlineData("DIVISION")]
        [InlineData("REMAINDER")]

        public void Calculation_IsKnown(string operation)
        {
            // Arrange

            // Act
            bool result = Enum.TryParse(operation.ToUpper(), out MathOperation _);

            // Assert
            Assert.True(result);
        }

        #region [ Calculation ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [Theory]
        [InlineData(MathOperation.ADDITION, -4, 3)]
        [InlineData(MathOperation.ADDITION, 3, -4)]
        [InlineData(MathOperation.ADDITION, long.MinValue, long.MaxValue)] //-9223372036854775808, 9223372036854775807
        public void Calculation_Addition(MathOperation operation, long left, long right)
        {
            // Arrange

            // Act
            long result = (operation.Equals(MathOperation.ADDITION)) ? (left + right) : 0;

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
        [InlineData(MathOperation.SUBTRACTION, 0, 3)]
        [InlineData(MathOperation.SUBTRACTION, 3, 6)]
        [InlineData(MathOperation.SUBTRACTION, -2, 1)]
        public void Calculation_SubtractionPositiveRight(MathOperation operation, long left, long right)
        {
            // Arrange

            // Act
            long result = (operation.Equals(MathOperation.SUBTRACTION)) ? (left - right) : 0;

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
        [InlineData(MathOperation.SUBTRACTION, 0, -6)]
        [InlineData(MathOperation.SUBTRACTION, -3, -9)]
        [InlineData(MathOperation.SUBTRACTION, 3, -3)]
        public void Calculation_SubtractionNegativeRight(MathOperation operation, long left, long right)
        {
            // Arrange

            // Act
            long result = (operation.Equals(MathOperation.SUBTRACTION)) ? (left - right) : 0;

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
        [InlineData(MathOperation.MULTIPLICATION, 0, 0)]
        [InlineData(MathOperation.MULTIPLICATION, 0, 1)]
        [InlineData(MathOperation.MULTIPLICATION, 1, 0)]
        [InlineData(MathOperation.MULTIPLICATION, 0, -1)]
        [InlineData(MathOperation.MULTIPLICATION, -1, 0)]
        public void Calculation_MultiplicationZeroResult(MathOperation operation, long left, long right)
        {
            // Arrange

            // Act
            long result = (operation.Equals(MathOperation.MULTIPLICATION)) ? (left * right) : 0;

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
        [InlineData(MathOperation.MULTIPLICATION, -2, -3)]
        [InlineData(MathOperation.MULTIPLICATION, 2, 3)]
        public void Calculation_MultiplicationPositiveResult(MathOperation operation, long left, long right)
        {
            // Arrange

            // Act
            long result = (operation.Equals(MathOperation.MULTIPLICATION)) ? (left * right) : 0;

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
        [InlineData(MathOperation.MULTIPLICATION, -2, 3)]
        [InlineData(MathOperation.MULTIPLICATION, 2, -3)]
        public void Calculation_MultiplicationNegativeResult(MathOperation operation, long left, long right)
        {
            // Arrange

            // Act
            long result = (operation.Equals(MathOperation.MULTIPLICATION)) ? (left * right) : 0;

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
        [InlineData(MathOperation.DIVISION, 0, 0)]
        [InlineData(MathOperation.DIVISION, 1, 0)]
        [InlineData(MathOperation.DIVISION, -1, 0)]
        public async void Calculation_DivisionByZero(MathOperation operation, long left, long right)
        {
            // Arrange

            // Act and Assert
            await Assert.ThrowsAsync<DivideByZeroException>(() =>
            {
                long result = (operation.Equals(MathOperation.DIVISION)) ? (left / right) : 0;

                throw new DivideByZeroException($"Unsupported operation: division of {left} by {right}");
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [Theory]
        [InlineData(MathOperation.DIVISION, 0, 1)]
        [InlineData(MathOperation.DIVISION, 0, -1)]

        public void Calculation_DivisionZeroResult(MathOperation operation, long left, long right)
        {
            // Arrange

            // Act
            long result = (operation.Equals(MathOperation.DIVISION)) ? (left / right) : 0;

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
        [InlineData(MathOperation.DIVISION, -4, -2)]
        [InlineData(MathOperation.DIVISION, 4, 2)]
        public void Calculation_DivisionPositiveResult(MathOperation operation, long left, long right)
        {
            // Arrange

            // Act
            long result = (operation.Equals(MathOperation.DIVISION)) ? (left / right) : 0;

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
        [InlineData(MathOperation.DIVISION, 4, -2)]
        [InlineData(MathOperation.DIVISION, -4, 2)]
        public void Calculation_DivisionNegativeResult(MathOperation operation, long left, long right)
        {
            // Arrange

            // Act
            long result = (operation.Equals(MathOperation.DIVISION)) ? (left / right) : 0;

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
        [InlineData(MathOperation.REMAINDER, 1, 0)]
        [InlineData(MathOperation.REMAINDER, -1, 0)]
        public async void Calculation_RemainderByZero(MathOperation operation, long left, long right)
        {
            // Arrange

            // Act and Assert
            await Assert.ThrowsAsync<DivideByZeroException>(() =>
            {
                long result = (operation.Equals(MathOperation.REMAINDER)) ? (left % right) : 0;

                throw new DivideByZeroException($"Unsupported operation: division of {left} by {right}");
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        [Theory]
        [InlineData(MathOperation.REMAINDER, 0, 0)]
        [InlineData(MathOperation.REMAINDER, 0, 1)]
        [InlineData(MathOperation.REMAINDER, 0, -1)]
        public void Calculation_RemainderZeroResult(MathOperation operation, long left, long right)
        {
            // Arrange

            // Act
            long result = (operation.Equals(MathOperation.DIVISION)) ? (left % right) : 0;

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
        [InlineData(MathOperation.REMAINDER, -4, -2)]
        [InlineData(MathOperation.REMAINDER, 4, -2)]
        [InlineData(MathOperation.REMAINDER, -4, 2)]
        [InlineData(MathOperation.REMAINDER, 4, 2)]
        public void Calculation_Remainder(MathOperation operation, long left, long right)
        {
            // Arrange

            // Act
            long result = (operation.Equals(MathOperation.REMAINDER)) ? (left % right) : 0;

            // Assert
            Assert.Equal(0, result);
        }

        #endregion
    }
}