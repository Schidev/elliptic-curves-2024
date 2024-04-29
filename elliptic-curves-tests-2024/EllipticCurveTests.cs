using elliptic_curves_labs_2024.Models.Curves;
using System.Numerics;

namespace elliptic_curves_tests_2024
{
    public class EllipticCurveTests
    {
        [Fact]
        public void EllipticCurveAToString()
        {
            // Arrange
            BigInteger a = new BigInteger(1);
            BigInteger b = new BigInteger(10);
            BigInteger module = new BigInteger(11);
            var a_elliptic_curve = new EllipticCurveA(a, b, module);

            // Act
            var expected = "y^2 = x^3 + 1 * x + 10 in F_11";
            var actual = a_elliptic_curve.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EllipticCurvePToString()
        {
            // Arrange
            BigInteger a = new BigInteger(1);
            BigInteger b = new BigInteger(10);
            BigInteger module = new BigInteger(11);
            var p_elliptic_curve = new EllipticCurveP(a, b, module);

            // Act 
            var expected = "Y^2 * Z = X^3 + 1 * X * Z^2 + 10 * Z^3 in F_11";
            var actual = p_elliptic_curve.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}