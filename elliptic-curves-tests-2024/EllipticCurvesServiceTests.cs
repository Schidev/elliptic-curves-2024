using elliptic_curves_labs_2024.Models.Curves;
using elliptic_curves_labs_2024.Models.Points;
using elliptic_curves_labs_2024.Services;
using System.Numerics;
namespace elliptic_curves_tests_2024
{
    public class EllipticCurvesServiceTests
    {
        [Fact]
        public void EllipticCurveIsValid_ReturnsFalse()
        {
            // Arrange
            BigInteger a = new BigInteger(6);
            BigInteger b = new BigInteger(1);
            BigInteger module = new BigInteger(11);
            var a_elliptic_curve = new EllipticCurveA(a, b, module);

            // Act
            var isValid = EllipticCurveService.IsValid(a_elliptic_curve);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void EllipticCurveIsValid_ReturnsTrue()
        {
            // Arrange
            BigInteger a = new BigInteger(1);
            BigInteger b = new BigInteger(10);
            BigInteger module = new BigInteger(11);
            var a_elliptic_curve = new EllipticCurveA(a, b, module);

            // Act
            var isValid = EllipticCurveService.IsValid(a_elliptic_curve);

            // Assert
            Assert.True(isValid);
        }
        
        [Fact]
        public void EllipticCurveAHasPoint_ReturnsTrue()
        {
            // Arrange
            BigInteger module = new BigInteger(11);

            BigInteger x = new BigInteger(6);
            BigInteger y = new BigInteger(1);

            var a_point = new EllipticCurvePointA(x, y, module);

            BigInteger a = new BigInteger(1);
            BigInteger b = new BigInteger(10);
            
            var a_elliptic_curve = new EllipticCurveA(a, b, module);

            // Act
            var hasPoint = EllipticCurvePointService.EllipticCurveA_HasPoint(a_point, a_elliptic_curve);

            // Assert
            Assert.True(hasPoint);
        }

        [Fact]
        public void EllipticCurveAHasPoint_ReturnsFalse()
        {
            // Arrange
            BigInteger module = new BigInteger(11);

            BigInteger x = new BigInteger(6);
            BigInteger y = new BigInteger(7);

            var a_point = new EllipticCurvePointA(x, y, module);

            BigInteger a = new BigInteger(1);
            BigInteger b = new BigInteger(10);

            var a_elliptic_curve = new EllipticCurveA(a, b, module);

            // Act
            var hasPoint = EllipticCurvePointService.EllipticCurveA_HasPoint(a_point, a_elliptic_curve);

            // Assert
            Assert.False(hasPoint);
        }

        [Fact]
        public void EllipticCurvePHasPoint_ReturnsTrue()
        {
            // Arrange
            BigInteger module = new BigInteger(11);

            BigInteger X = new BigInteger(6);
            BigInteger Y = new BigInteger(1);
            BigInteger Z = new BigInteger(1);

            var p_point = new EllipticCurvePointP(X, Y, Z, module);

            BigInteger a = new BigInteger(1);
            BigInteger b = new BigInteger(10);

            var p_elliptic_curve = new EllipticCurveP(a, b, module);

            // Act
            var hasPoint = EllipticCurvePointService.EllipticCurveP_HasPoint(p_point, p_elliptic_curve);

            // Assert
            Assert.True(hasPoint);
        }

        [Fact]
        public void EllipticCurvePHasPoint_ReturnsFalse()
        {
            // Arrange
            BigInteger module = new BigInteger(11);

            BigInteger X = new BigInteger(6);
            BigInteger Y = new BigInteger(7);
            BigInteger Z = new BigInteger(1);

            var p_point = new EllipticCurvePointP(X, Y, Z, module);

            BigInteger a = new BigInteger(1);
            BigInteger b = new BigInteger(10);

            var p_elliptic_curve = new EllipticCurveP(a, b, module);

            // Act
            var hasPoint = EllipticCurvePointService.EllipticCurveP_HasPoint(p_point, p_elliptic_curve);

            // Assert
            Assert.False(hasPoint);
        }

    }
}
