using elliptic_curves_labs_2024.Models.Curves;
using elliptic_curves_labs_2024.Models.Points;
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


        [Fact]
        public void Calculator_AddPoints_TEST_SymmetricRelation()
        {
            // Checks if P + Q = Q + P
            // Arrange
            BigInteger P_X = new BigInteger(6);
            BigInteger P_Y = new BigInteger(10);
            BigInteger P_Z = new BigInteger(1);

            BigInteger Q_X = new BigInteger(7);
            BigInteger Q_Y = new BigInteger(4);
            BigInteger Q_Z = new BigInteger(7);

            BigInteger module = new BigInteger(11);

            var P = new EllipticCurvePointP(P_X, P_Y, P_Z, module);
            var Q = new EllipticCurvePointP(Q_X, Q_Y, Q_Z, module);

            BigInteger a = new BigInteger(1);
            BigInteger b = new BigInteger(10);

            var elliptic_curve = new EllipticCurveP(a, b, module);

            // Act
            var P_plus_Q = EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.AddPoints(P, Q, elliptic_curve));
            var Q_plus_P = EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.AddPoints(Q, P, elliptic_curve));

            // Assert
            Assert.True(P_plus_Q == Q_plus_P);

        }

        [Fact]
        public void Calculator_AddPoints_TEST_TransitiveRelation()
        {
            // Checks if (P + Q) + R = P + (Q + R)
            // Arrange
            BigInteger P_X = new BigInteger(6);
            BigInteger P_Y = new BigInteger(10);
            BigInteger P_Z = new BigInteger(1);

            BigInteger Q_X = new BigInteger(7);
            BigInteger Q_Y = new BigInteger(4);
            BigInteger Q_Z = new BigInteger(7);

            BigInteger R_X = new BigInteger(5);
            BigInteger R_Y = new BigInteger(9);
            BigInteger R_Z = new BigInteger(8);

            BigInteger module = new BigInteger(11);

            var P = new EllipticCurvePointP(P_X, P_Y, P_Z, module);
            var Q = new EllipticCurvePointP(Q_X, Q_Y, Q_Z, module);
            var R = new EllipticCurvePointP(R_X, R_Y, R_Z, module);

            BigInteger a = new BigInteger(1);
            BigInteger b = new BigInteger(10);

            var elliptic_curve = new EllipticCurveP(a, b, module);

            // Act
            var P_plus_Q_then_R = EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.AddPoints(Calculator.AddPoints(P, Q, elliptic_curve), R, elliptic_curve));
            var Q_plus_R_then_P = EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.AddPoints(Calculator.AddPoints(Q, R, elliptic_curve), P, elliptic_curve));

            // Assert
            Assert.True(P_plus_Q_then_R == Q_plus_R_then_P);
        }

        [Fact]
        public void Calculator_AddPoints_TEST_SmallField()
        {
            // Checks if {P, 2P, 3P, ..., 4P} counted by two ways are equally.
            // Arrange
            BigInteger P_X = new BigInteger(1);
            BigInteger P_Y = new BigInteger(1);
            BigInteger P_Z = new BigInteger(1);

            BigInteger module = new BigInteger(11);

            var P = new EllipticCurvePointP(P_X, P_Y, P_Z, module);
            
            BigInteger a = new BigInteger(1);
            BigInteger b = new BigInteger(10);

            var elliptic_curve = new EllipticCurveP(a, b, module);

            var expected = new List<EllipticCurvePointA>() { EllipticCurvePointService.EllipticCurvePoint_P2A(P) };
            var actual = new List<EllipticCurvePointA>() { EllipticCurvePointService.EllipticCurvePoint_P2A(P) };

            var str_expected = "(1,1)";
            var str_actual = "(1,1)";

            // Act

            for (int i = 1; i < 32; i++)
            {
                expected.Add(EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.AddPoints(EllipticCurvePointService.EllipticCurvePoint_A2P(expected[i - 1]), P, elliptic_curve)));
                //expected.Add());
                actual.Add(EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(P,i+1,elliptic_curve)));

                str_expected += String.Format("({0},{1})", expected.Last().x, expected.Last().y);
                str_actual += String.Format("({0},{1})", actual.Last().x, actual.Last().y);
            }

            // Assert
            Assert.True(str_expected == str_actual);
        }

    }
}
