using elliptic_curves_labs_2024.Models.Curves;
using elliptic_curves_labs_2024.Models.Points;
using elliptic_curves_labs_2024.Services;
using elliptic_curves_labs_2024.Variants;
using System.Globalization;
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
                // P, P + P, P + P + P, ...
                expected.Add(EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.AddPoints(EllipticCurvePointService.EllipticCurvePoint_A2P(expected[i - 1]), P, elliptic_curve)));
                str_expected += String.Format("({0},{1})", expected.Last().x, expected.Last().y);

                // P, 2P, 3P, ....
                actual.Add(EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(P, i + 1, elliptic_curve)));
                str_actual += String.Format("({0},{1})", actual.Last().x, actual.Last().y);
            }

            // Assert
            Assert.True(str_expected == str_actual);
        }

        [Fact]
        public void Calculator_PointMultiplyByScalar_P192_G_n()
        {
            // Arrange
            var curve = Variants.P192_curve;
            
            BigInteger G_X = BigInteger.Parse("0" + "188da80eb03090f67cbf20eb43a18800f4ff0afd82ff1012", NumberStyles.HexNumber);
            BigInteger G_Y = BigInteger.Parse("0" + "7192b95ffc8da78631011ed6b24cdd573f977a11e794811", NumberStyles.HexNumber);

            var G = new EllipticCurvePointA(G_X, G_Y, curve.module);
            BigInteger expected_order = BigInteger.Parse("6277101735386680763835789423176059013767194773182842284081");

            // Act 
            var nG = EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(G), expected_order, curve));

            // Assert
            Assert.True(nG == EllipticCurvePointService.POINT_AT_INFINITY_A(curve.module));
        }

        [Fact]
        public void Calculator_PointMultiplyByScalar_P224_G_n()
        {
            // Arrange
            var curve = Variants.P224_curve;

            BigInteger G_X = BigInteger.Parse("0" + "b70e0cbd6bb4bf7f321390b94a03c1d356c21122343280d6115c1d21", NumberStyles.HexNumber);
            BigInteger G_Y = BigInteger.Parse("0" + "bd376388b5f723fb4c22dfe6cd4375a05a07476444d5819985007e34", NumberStyles.HexNumber);

            var G = new EllipticCurvePointA(G_X, G_Y, curve.module);
            BigInteger expected_order = BigInteger.Parse("0" + "ffffffffffffffffffffffffffff16a2e0b8f03e13dd29455c5c2a3d", NumberStyles.HexNumber);

            // Act 
            var nG = EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(G), expected_order, curve));

            // Assert
            Assert.True(nG == EllipticCurvePointService.POINT_AT_INFINITY_A(curve.module));
        }

        [Fact]
        public void Calculator_PointMultiplyByScalar_P256_G_n()
        {
            // Arrange
            var curve = Variants.P256_curve;

            BigInteger G_X = BigInteger.Parse("0" + "6b17d1f2e12c4247f8bce6e563a440f277037d812deb33a0f4a13945d898c296", NumberStyles.HexNumber);
            BigInteger G_Y = BigInteger.Parse("0" + "4fe342e2fe1a7f9b8ee7eb4a7c0f9e162bce33576b315ececbb6406837bf51f5", NumberStyles.HexNumber);

            var G = new EllipticCurvePointA(G_X, G_Y, curve.module);
            BigInteger expected_order = BigInteger.Parse("0" + "ffffffff00000000ffffffffffffffffbce6faada7179e84f3b9cac2fc632551", NumberStyles.HexNumber);

            // Act 
            var nG = EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(G), expected_order, curve));

            // Assert
            Assert.True(nG == EllipticCurvePointService.POINT_AT_INFINITY_A(curve.module));
        }

        [Fact]
        public void Calculator_PointMultiplyByScalar_P384_G_n()
        {
            // Arrange
            var curve = Variants.P384_curve;

            BigInteger G_X = BigInteger.Parse("0" + "aa87ca22be8b05378eb1c71ef320ad746e1d3b628ba79b9859f741e082542a385502f25dbf55296c3a545e3872760ab7", NumberStyles.HexNumber);
            BigInteger G_Y = BigInteger.Parse("0" + "3617de4a96262c6f5d9e98bf9292dc29f8f41dbd289a147ce9da3113b5f0b8c00a60b1ce1d7e819d7a431d7c90ea0e5f", NumberStyles.HexNumber);

            var G = new EllipticCurvePointA(G_X, G_Y, curve.module);
            BigInteger expected_order = BigInteger.Parse("0" + "ffffffffffffffffffffffffffffffffffffffffffffffffc7634d81f4372ddf581a0db248b0a77aecec196accc52973", NumberStyles.HexNumber);

            // Act 
            var nG = EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(G), expected_order, curve));

            // Assert
            Assert.True(nG == EllipticCurvePointService.POINT_AT_INFINITY_A(curve.module));
        }

        [Fact]
        public void Calculator_PointMultiplyByScalar_P521_G_n()
        {
            // Arrange
            var curve = Variants.P521_curve;

            BigInteger G_X = BigInteger.Parse("0" + "00c6858e06b70404e9cd9e3ecb662395b4429c648139053fb521f828af606b4d3dbaa14b5e77efe75928fe1dc127a2ffa8de3348b3c1856a429bf97e7e31c2e5bd66", NumberStyles.HexNumber);
            BigInteger G_Y = BigInteger.Parse("0" + "011839296a789a3bc0045c8a5fb42c7d1bd998f54449579b446817afbd17273e662c97ee72995ef42640c550b9013fad0761353c7086a272c24088be94769fd16650", NumberStyles.HexNumber);

            var G = new EllipticCurvePointA(G_X, G_Y, curve.module);
            BigInteger expected_order = BigInteger.Parse("0" + "01fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffa51868783bf2f966b7fcc0148f709a5d03bb5c9b8899c47aebb6fb71e91386409", NumberStyles.HexNumber);

            // Act 
            var nG = EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(G), expected_order, curve));

            // Assert
            Assert.True(nG == EllipticCurvePointService.POINT_AT_INFINITY_A(curve.module));
        }

        [Fact]
        public void Calculator_PointMultiplyByScalar_P192_Random()
        {
            // Arrange
            var curve = Variants.P192_curve;


            BigInteger G_X = BigInteger.Parse("0" + "188da80eb03090f67cbf20eb43a18800f4ff0afd82ff1012", NumberStyles.HexNumber);
            BigInteger G_Y = BigInteger.Parse("0" + "7192b95ffc8da78631011ed6b24cdd573f977a11e794811", NumberStyles.HexNumber);

            var G = new EllipticCurvePointA(G_X, G_Y, curve.module);

            Random random = new Random();
            var seed1 = random.Next(10000);
            var seed2 = random.Next(10000);

            var R = EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.AddPoints(
                Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(G), seed1, curve),
                Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(G), seed2, curve),
                curve));

            BigInteger expected_order = BigInteger.Parse("6277101735386680763835789423176059013767194773182842284081");

            // Act 
            var nR = EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(R), expected_order, curve));

            // Assert
            Assert.True(nR == EllipticCurvePointService.POINT_AT_INFINITY_A(curve.module));
        }

        [Fact]
        public void Calculator_PointMultiplyByScalar_P224_Random()
        {
            // Arrange
            var curve = Variants.P224_curve;

            BigInteger G_X = BigInteger.Parse("0" + "b70e0cbd6bb4bf7f321390b94a03c1d356c21122343280d6115c1d21", NumberStyles.HexNumber);
            BigInteger G_Y = BigInteger.Parse("0" + "bd376388b5f723fb4c22dfe6cd4375a05a07476444d5819985007e34", NumberStyles.HexNumber);

            var G = new EllipticCurvePointA(G_X, G_Y, curve.module);

            Random random = new Random();
            var seed1 = random.Next(10000);
            var seed2 = random.Next(10000);

            var R = EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.AddPoints(
                Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(G), seed1, curve),
                Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(G), seed2, curve),
                curve));

            BigInteger expected_order = BigInteger.Parse("0" + "ffffffffffffffffffffffffffff16a2e0b8f03e13dd29455c5c2a3d", NumberStyles.HexNumber);

            // Act 
            var nR = EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(R), expected_order, curve));

            // Assert
            Assert.True(nR == EllipticCurvePointService.POINT_AT_INFINITY_A(curve.module));
        }

        [Fact]
        public void Calculator_PointMultiplyByScalar_P256_Random()
        {
            // Arrange
            var curve = Variants.P256_curve;

            BigInteger G_X = BigInteger.Parse("0" + "6b17d1f2e12c4247f8bce6e563a440f277037d812deb33a0f4a13945d898c296", NumberStyles.HexNumber);
            BigInteger G_Y = BigInteger.Parse("0" + "4fe342e2fe1a7f9b8ee7eb4a7c0f9e162bce33576b315ececbb6406837bf51f5", NumberStyles.HexNumber);

            var G = new EllipticCurvePointA(G_X, G_Y, curve.module);

            Random random = new Random();
            var seed1 = random.Next(10000);
            var seed2 = random.Next(10000);

            var R = EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.AddPoints(
                Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(G), seed1, curve),
                Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(G), seed2, curve),
                curve));

            BigInteger expected_order = BigInteger.Parse("0" + "ffffffff00000000ffffffffffffffffbce6faada7179e84f3b9cac2fc632551", NumberStyles.HexNumber);

            // Act 
            var nR = EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(R), expected_order, curve));

            // Assert
            Assert.True(nR == EllipticCurvePointService.POINT_AT_INFINITY_A(curve.module));
        }

        [Fact]
        public void Calculator_PointMultiplyByScalar_P384_Random()
        {
            // Arrange
            var curve = Variants.P384_curve;

            BigInteger G_X = BigInteger.Parse("0" + "aa87ca22be8b05378eb1c71ef320ad746e1d3b628ba79b9859f741e082542a385502f25dbf55296c3a545e3872760ab7", NumberStyles.HexNumber);
            BigInteger G_Y = BigInteger.Parse("0" + "3617de4a96262c6f5d9e98bf9292dc29f8f41dbd289a147ce9da3113b5f0b8c00a60b1ce1d7e819d7a431d7c90ea0e5f", NumberStyles.HexNumber);

            var G = new EllipticCurvePointA(G_X, G_Y, curve.module);

            Random random = new Random();
            var seed1 = random.Next(10000);
            var seed2 = random.Next(10000);

            var R = EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.AddPoints(
                Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(G), seed1, curve),
                Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(G), seed2, curve),
                curve));

            BigInteger expected_order = BigInteger.Parse("0" + "ffffffffffffffffffffffffffffffffffffffffffffffffc7634d81f4372ddf581a0db248b0a77aecec196accc52973", NumberStyles.HexNumber);

            // Act 
            var nR = EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(R), expected_order, curve));

            // Assert
            Assert.True(nR == EllipticCurvePointService.POINT_AT_INFINITY_A(curve.module));
        }

        [Fact]
        public void Calculator_PointMultiplyByScalar_P521_Random()
        {
            // Arrange
            var curve = Variants.P521_curve;

            BigInteger G_X = BigInteger.Parse("0" + "00c6858e06b70404e9cd9e3ecb662395b4429c648139053fb521f828af606b4d3dbaa14b5e77efe75928fe1dc127a2ffa8de3348b3c1856a429bf97e7e31c2e5bd66", NumberStyles.HexNumber);
            BigInteger G_Y = BigInteger.Parse("0" + "011839296a789a3bc0045c8a5fb42c7d1bd998f54449579b446817afbd17273e662c97ee72995ef42640c550b9013fad0761353c7086a272c24088be94769fd16650", NumberStyles.HexNumber);

            var G = new EllipticCurvePointA(G_X, G_Y, curve.module);

            Random random = new Random();
            var seed1 = random.Next(10000);
            var seed2 = random.Next(10000);

            var R = EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.AddPoints(
                Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(G), seed1, curve),
                Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(G), seed2, curve),
                curve));

            BigInteger expected_order = BigInteger.Parse("0" + "01fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffa51868783bf2f966b7fcc0148f709a5d03bb5c9b8899c47aebb6fb71e91386409", NumberStyles.HexNumber);

            // Act 
            var nR = EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(EllipticCurvePointService.EllipticCurvePoint_A2P(R), expected_order, curve));

            // Assert
            Assert.True(nR == EllipticCurvePointService.POINT_AT_INFINITY_A(curve.module));
        }

    }
}
