using elliptic_curves_labs_2024.Models.Curves;
using elliptic_curves_labs_2024.Models.Points;
using System.Numerics;

namespace elliptic_curves_labs_2024.Services
{
    public static class Calculator
    {
        #region Euclidean Algorithm

        public static BigInteger GetExtendedEuclideanAlgorithmValues(BigInteger number_a, BigInteger number_b, out BigInteger s, out BigInteger t)
        {
            if (number_a < number_b)
                return GetExtendedEuclideanAlgorithmValues(number_b, number_a, out s, out t);

            if (number_a % number_b == BigInteger.Zero)
            {
                s = BigInteger.Zero;
                t = BigInteger.One;
                return number_b;
            }

            var q0 = number_a / number_b;
            var s0 = BigInteger.One;
            var t0 = -q0;
            var r0 = number_a - number_b * q0;

            //Console.WriteLine("{0} = {1} * {2} + {3}", number_a, number_b, q0, r0);

            if (number_b % r0 == 0)
            {
                s = s0;
                t = t0;

                return r0;
            }

            var q1 = number_b / r0;
            var s1 = -q1;
            var t1 = 1 + q0 * q1;
            var r1 = number_b - r0 * q1;

            //Console.WriteLine("{0} = {1} * {2} + {3}", number_b, r0, q1, r1);

            while (r0 % r1 != 0)
            {

                var q = r0 / r1;

                BigInteger s2 = s0 - s1 * q;
                BigInteger t2 = t0 - t1 * q;
                BigInteger r2 = r0 - r1 * q;

                s0 = s1;
                t0 = t1;
                r0 = r1;

                s1 = s2;
                t1 = t2;
                r1 = r2;

                //Console.WriteLine("{0} = {1} * {2} + {3}", r0, r1, q, r2);
            }

            s = s1;
            t = t1;

            return r1;
        }

        #endregion

        #region Find Inverse element in Field

        public static BigInteger GetInverseElementInFieldByExtendedEuclideanAlgorithm(BigInteger number_a, BigInteger module)
        {
            var _ = GetExtendedEuclideanAlgorithmValues(number_a, module, out BigInteger u, out BigInteger v);

            //Console.WriteLine("Coefficients: {0} * u + {1} * v = 1", u, v);

            while (v < 0)
            {
                v += module;
            }

            return v;
        }

        #endregion

        #region Some operations in field

        public static BigInteger GetPositiveInField(BigInteger number, BigInteger module)
        {
            while (number < 0)
                number += module;
            return number % module;
        }

        #endregion

        #region Operations with points

        public static EllipticCurvePointP PointDouble(EllipticCurvePointP point, EllipticCurveP curve)
        {
            var point_at_infinity = EllipticCurvePointService.POINT_AT_INFINITY_P(point.module);
            
            if (point == point_at_infinity)
                return point_at_infinity;

            if (point.Y == 0)
                return point_at_infinity;

            var W = GetPositiveInField(curve.a * point.Z * point.Z + 3 * point.X * point.X, point.module);
            var S = GetPositiveInField(point.Y * point.Z, point.module);
            var B = GetPositiveInField(point.X * point.Y * S, point.module);
            var H = GetPositiveInField(W * W - 8 * B, point.module);

            var new_X = GetPositiveInField(2 * H * S, point.module);
            var new_Y = GetPositiveInField(W * (4 * B - H) - 8 * point.Y * point.Y * BigInteger.ModPow(S, 2, point.module), point.module);
            var new_Z = GetPositiveInField(8 * BigInteger.ModPow(S, 3, point.module), point.module);

            return new EllipticCurvePointP(new_X, new_Y, new_Z, curve.module);
        }

        public static EllipticCurvePointP AddPoints(EllipticCurvePointP addend_a, EllipticCurvePointP addend_b, EllipticCurveP curve)
        {
            var point_at_infinity = EllipticCurvePointService.POINT_AT_INFINITY_P(curve.module);

            if (addend_a.module != curve.module || addend_b.module != curve.module)
                throw new ArgumentException();

            if (addend_a == point_at_infinity && addend_b == point_at_infinity)
                return point_at_infinity;

            if (addend_a == point_at_infinity)
                return addend_b;

            if (addend_b == point_at_infinity)
                return addend_a;

            var U1 = GetPositiveInField(addend_b.Y * addend_a.Z, curve.module);
            var U2 = GetPositiveInField(addend_a.Y * addend_b.Z, curve.module);
            var V1 = GetPositiveInField(addend_b.X * addend_a.Z, curve.module);
            var V2 = GetPositiveInField(addend_a.X * addend_b.Z, curve.module);

            if (V1 == V2)
            {
                if (U1 != U2)
                    return point_at_infinity;
                else
                    return PointDouble(addend_a, curve);
            }

            var U = GetPositiveInField(U1 - U2, curve.module);
            var V = GetPositiveInField(V1 - V2, curve.module);
            var W = GetPositiveInField(addend_a.Z * addend_b.Z, curve.module);
            var A = GetPositiveInField(U * U * W - V * V * V - 2 * V * V * V2, curve.module);

            var new_X = GetPositiveInField(V * A, curve.module);
            var new_Y = GetPositiveInField(U * (V * V * V2 - A) - V * V * V * U2, curve.module);
            var new_Z = GetPositiveInField(V * V * V * W, curve.module);

            return new EllipticCurvePointP(new_X, new_Y, new_Z, curve.module);
        }

        public static EllipticCurvePointP PointMultiplyByScalar(EllipticCurvePointP point, BigInteger scalar, EllipticCurveP curve)
        {
            var result = EllipticCurvePointService.POINT_AT_INFINITY_P(curve.module);
            var temp = new EllipticCurvePointP(point.X, point.Y, point.Z, point.module);

            while (scalar != 0)
            {
                if ((scalar & 1) == 1)
                {
                    result = AddPoints(result, temp, curve);
                    //result = result.Z != BigInteger.One
                    //    ? EllipticCurvePointService.EllipticCurvePoint_NormalZ(result)
                    //    : result;

                }
                temp = PointDouble(temp, curve);
                //temp = temp.Z != BigInteger.One
                //        ? EllipticCurvePointService.EllipticCurvePoint_NormalZ(temp)
                //        : temp;
                scalar = scalar >> 1;
            }

            return result;
        }

        #endregion
    }
}
