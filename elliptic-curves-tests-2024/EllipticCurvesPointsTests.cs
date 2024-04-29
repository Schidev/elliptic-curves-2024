using elliptic_curves_labs_2024.Models.Curves;
using elliptic_curves_labs_2024.Services.IServices;
using elliptic_curves_labs_2024.Services;
using System.Numerics;
using elliptic_curves_labs_2024.Models.Points;

namespace elliptic_curves_tests_2024
{
    public class EllipticCurvesPointsTests
    {
        [Fact]
        public void EllipticCurvesPointAToString()
        {
            // Arrange
            BigInteger x = new BigInteger(6);
            BigInteger y = new BigInteger(1);
            BigInteger module = new BigInteger(11);
            var a_point = new EllipticCurvePointA(x, y, module);

            // Act
            var expected = "Point has the following coordinates: \n\t\t(x, y) = (6, 1) in F_11.";
            var actual = a_point.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EllipticCurvesPointPToString()
        {
            // Arrange
            BigInteger X = new BigInteger(1);
            BigInteger Y = new BigInteger(2);
            BigInteger Z = new BigInteger(3);
            BigInteger module = new BigInteger(17);
            var p_point = new EllipticCurvePointP(X, Y, Z, module);

            // Act
            var expected = "Point has the following coordinates: \n\t\t(X, Y, Z) = (1, 2, 3) in F_17.";
            var actual = p_point.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EllipticCurvesPointA_EqualityOperator_ReturnsFalse()
        {
            // Arrange
            BigInteger x1 = new BigInteger(1);
            BigInteger y1 = new BigInteger(2);

            BigInteger x2 = new BigInteger(4);
            BigInteger y2 = new BigInteger(5);

            BigInteger module = new BigInteger(17);

            var a_point_1 = new EllipticCurvePointA(x1, y1, module);
            var a_point_2 = new EllipticCurvePointA(x2, y2, module);

            // Act
            var actual = (a_point_1 == a_point_2);

            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void EllipticCurvesPointA_UnequalityOperator_ReturnsTrue()
        {
            // Arrange
            BigInteger x1 = new BigInteger(1);
            BigInteger y1 = new BigInteger(2);

            BigInteger x2 = new BigInteger(4);
            BigInteger y2 = new BigInteger(5);

            BigInteger module = new BigInteger(17);

            var a_point_1 = new EllipticCurvePointA(x1, y1, module);
            var a_point_2 = new EllipticCurvePointA(x2, y2, module);

            // Act
            var actual = (a_point_1 != a_point_2);

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void EllipticCurvesPointP_EqualityOperator_ReturnsFalse()
        {
            // Arrange
            BigInteger X1 = new BigInteger(1);
            BigInteger Y1 = new BigInteger(2);
            BigInteger Z1 = new BigInteger(3);

            BigInteger X2 = new BigInteger(4);
            BigInteger Y2 = new BigInteger(5);
            BigInteger Z2 = new BigInteger(6);

            BigInteger module = new BigInteger(17);

            var p_point_1 = new EllipticCurvePointP(X1, Y1, Z1, module);
            var p_point_2 = new EllipticCurvePointP(X2, Y2, Z2, module);

            // Act
            var actual = (p_point_1 == p_point_2);

            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void EllipticCurvesPointP_UnequalityOperator_ReturnsTrue()
        {
            // Arrange
            BigInteger X1 = new BigInteger(1);
            BigInteger Y1 = new BigInteger(2);
            BigInteger Z1 = new BigInteger(3);

            BigInteger X2 = new BigInteger(4);
            BigInteger Y2 = new BigInteger(5);
            BigInteger Z2 = new BigInteger(6);

            BigInteger module = new BigInteger(17);

            var p_point_1 = new EllipticCurvePointP(X1, Y1, Z1, module);
            var p_point_2 = new EllipticCurvePointP(X2, Y2, Z2, module);

            // Act
            var actual = (p_point_1 != p_point_2);

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void EllipticCurve_EllipticCurvePoint_A2P_TEST_01()
        {
            // Arrange
            BigInteger x = new BigInteger(1);
            BigInteger y = new BigInteger(10);
            BigInteger module = new BigInteger(11);
            var a_point = new EllipticCurvePointA(x, y, module);

            IEllipticCurvePointService service = new EllipticCurvePointService();

            // Act
            var expected = new EllipticCurvePointP(x, y, BigInteger.One, module);
            var actual = service.EllipticCurvePoint_A2P(a_point);

            // Assert
            Assert.True(expected == actual);
        }

        [Fact]
        public void EllipticCurve_EllipticCurvePoint_A2P_TEST_02()
        {
            // Arrange
            BigInteger x = new BigInteger(1);
            BigInteger y = new BigInteger(10);
            BigInteger module = new BigInteger(11);
            var a_point = new EllipticCurvePointA(x, y, module);

            IEllipticCurvePointService service = new EllipticCurvePointService();

            // Act
            var expected = new EllipticCurvePointP(y, x, BigInteger.One, module);
            var actual = service.EllipticCurvePoint_A2P(a_point);

            // Assert
            Assert.True(expected != actual);
        }

        [Fact]
        public void EllipticCurve_EllipticCurvePoint_P2A_TEST_01()
        {
            // Arrange
            BigInteger X1 = new BigInteger(1);
            BigInteger Y1 = new BigInteger(2);
            BigInteger Z1 = new BigInteger(3);

            BigInteger module = new BigInteger(17);

            var p_point = new EllipticCurvePointP(X1, Y1, Z1, module);

            IEllipticCurvePointService service = new EllipticCurvePointService();

            // Act
            var expected = new EllipticCurvePointA((1 * 6) % 17, (2 * 6) % 17, module);
            var actual = service.EllipticCurvePoint_P2A(p_point);

            // Assert
            Assert.True(expected == actual);
        }
    }
}
