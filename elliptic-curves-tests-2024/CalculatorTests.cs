using elliptic_curves_labs_2024.Services;
using System.Numerics;

namespace elliptic_curves_tests_2024
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculator_GetInverseElementInFieldByExtendedEuclideanAlgorithm_01()
        {
            // Arrange
            var number = new BigInteger(3);
            var module = new BigInteger(3547);

            // Act
            var expected = new BigInteger(2365);
            var actual = Calculator.GetInverseElementInFieldByExtendedEuclideanAlgorithm(number, module);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Calculator_GetInverseElementInFieldByExtendedEuclideanAlgorithm_02()
        {
            // Arrange
            var number = new BigInteger(1743);
            var module = new BigInteger(3547);

            // Act
            var expected = new BigInteger(407);
            var actual = Calculator.GetInverseElementInFieldByExtendedEuclideanAlgorithm(number, module);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Calculator_GetInverseElementInFieldByExtendedEuclideanAlgorithm_03()
        {
            // Arrange
            var number = new BigInteger(3);
            var module = new BigInteger(3547);

            // Act
            var expected = new BigInteger(2365);
            var actual = Calculator.GetInverseElementInFieldByExtendedEuclideanAlgorithm(number, module);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Calculator_GetInverseElementInFieldByExtendedEuclideanAlgorithm_04()
        {
            // Arrange
            var number = new BigInteger(2932);
            var module = new BigInteger(3547);

            // Act
            var expected = new BigInteger(248);
            var actual = Calculator.GetInverseElementInFieldByExtendedEuclideanAlgorithm(number, module);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Calculator_GetInverseElementInFieldByExtendedEuclideanAlgorithm_05()
        {
            // Arrange
            var number = new BigInteger(925);
            var module = new BigInteger(1471);

            // Act
            var expected = new BigInteger(229);
            var actual = Calculator.GetInverseElementInFieldByExtendedEuclideanAlgorithm(number, module);

            // Assert
            Assert.Equal(expected, actual);
        }

    }
}
