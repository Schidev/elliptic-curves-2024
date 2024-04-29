﻿using elliptic_curves_labs_2024.Models.Points;
using System.Numerics;

namespace elliptic_curves_labs_2024.Services
{
    public static class EllipticCurvePointService
    {
        public static EllipticCurvePointA POINT_AT_INFINITY_A(BigInteger module)
            => new EllipticCurvePointA(BigInteger.Zero, BigInteger.Zero, module);
        public static EllipticCurvePointP POINT_AT_INFINITY_P(BigInteger module)
            => new EllipticCurvePointP(BigInteger.Zero, BigInteger.One, BigInteger.Zero, module);

        public static EllipticCurvePointP EllipticCurvePoint_A2P(EllipticCurvePointA point_a)
            => point_a == POINT_AT_INFINITY_A(point_a.module)
               ? new EllipticCurvePointP(point_a.x, BigInteger.One, BigInteger.Zero, point_a.module)
               : new EllipticCurvePointP(point_a.x, point_a.y, BigInteger.One, point_a.module);

        public static EllipticCurvePointA EllipticCurvePoint_P2A(EllipticCurvePointP point_p)
        {
            if (point_p == POINT_AT_INFINITY_P(point_p.module))
                return POINT_AT_INFINITY_A(point_p.module);
            
            if (point_p.Z == BigInteger.Zero)
                return POINT_AT_INFINITY_A(point_p.module);

            var new_x = Calculator.GetPositiveInField(point_p.X * Calculator.GetInverseElementInFieldByExtendedEuclideanAlgorithm(point_p.Z, point_p.module), point_p.module);
            var new_y = Calculator.GetPositiveInField(point_p.Y * Calculator.GetInverseElementInFieldByExtendedEuclideanAlgorithm(point_p.Z, point_p.module), point_p.module);

            return new EllipticCurvePointA(new_x, new_y, point_p.module);
        }

        public static EllipticCurvePointP EllipticCurvePoint_NormalZ(EllipticCurvePointP point_p)
        {
            if (point_p == POINT_AT_INFINITY_P(point_p.module))
                return POINT_AT_INFINITY_P(point_p.module);

            if (point_p.Z == BigInteger.Zero)
                return POINT_AT_INFINITY_P(point_p.module);
            //
            var new_X = Calculator.GetPositiveInField(point_p.X * Calculator.GetInverseElementInFieldByExtendedEuclideanAlgorithm(point_p.Z, point_p.module), point_p.module);
            var new_Y = Calculator.GetPositiveInField(point_p.Y * Calculator.GetInverseElementInFieldByExtendedEuclideanAlgorithm(point_p.Z, point_p.module), point_p.module);
            var new_Z = BigInteger.One;

            return new EllipticCurvePointP(new_X, new_Y, new_Z, point_p.module);
        }
    }
}
