using elliptic_curves_labs_2024.Models.Points;
using elliptic_curves_labs_2024.Services;
using elliptic_curves_labs_2024.Variants;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Globalization;
using System.Numerics;
using System.Security.Cryptography;

public class Program
{
    public static void Main(string[] args)
    {
        

        Console.ReadLine();
    }


    //var er = Calculator.PointMultiplyByScalar(BasePoint, expected_order, curve);
    //var fr = EllipticCurvePointService.EllipticCurvePoint_A2P(EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(q_bob, e_alice, curve))).ToString() ==
    //    EllipticCurvePointService.EllipticCurvePoint_A2P(EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(q_alice, e_bob, curve))).ToString();

    //var t1 = Calculator.PointMultiplyByScalar(q_bob, e_alice, curve);
    //var t2 = Calculator.PointMultiplyByScalar(q_alice, e_bob, curve);

    //var frf = Calculator.PointMultiplyByScalar(q_bob, e_alice, curve).ToString() ==
    //    Calculator.PointMultiplyByScalar(BasePoint, 72, curve).ToString();

    //var str1 = EllipticCurvePointService.EllipticCurvePoint_A2P(EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(BasePoint, 72, curve))).ToString();
    //var str2 = EllipticCurvePointService.EllipticCurvePoint_A2P(EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(q_alice, e_bob, curve))).ToString();
    //var str3 = EllipticCurvePointService.EllipticCurvePoint_A2P(EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(q_bob, e_alice, curve))).ToString();
    //var frfs = Calculator.PointMultiplyByScalar(q_alice, e_bob, curve).ToString() ==
    //    Calculator.PointMultiplyByScalar(BasePoint, 72, curve).ToString();

    //var ter = e_alice + e_bob == e_bob + e_alice;

}