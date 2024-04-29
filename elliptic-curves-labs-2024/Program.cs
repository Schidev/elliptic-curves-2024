using elliptic_curves_labs_2024.Models.Curves;
using elliptic_curves_labs_2024.Models.Points;
using elliptic_curves_labs_2024.Services;
using System.Numerics;

public class Program
{
    public static void Main(string[] args)
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
            actual.Add(EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(P, i + 1, elliptic_curve)));

            str_expected += String.Format("({0},{1})", expected.Last().x, expected.Last().y);
            str_actual += String.Format("({0},{1})", actual.Last().x, actual.Last().y);
        }
    }
}