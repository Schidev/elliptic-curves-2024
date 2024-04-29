using elliptic_curves_labs_2024.Models.Curves;
using elliptic_curves_labs_2024.Models.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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
            var POINT_AT_INFINITY = new EllipticCurvePointP(0, 1, 0, curve.module);

            if (point.Equals(POINT_AT_INFINITY))
                return POINT_AT_INFINITY;

            if (point.Y == 0)
                return POINT_AT_INFINITY;

            var W = curve.a * point.Z * point.Z + 3 * point.X * point.X;
            var S = point.Y * point.Z;
            var B = point.X * point.Y * S;
            var H = W * W - 8 * B;

            var new_X = (2 * H * S) % curve.module;
            var new_Y = (W * (4 * B - H) - 8 * point.Y * point.Y * S * S) % curve.module;
            var new_Z = (8 * S * S * S) % curve.module;

            while (new_X < 0)
                new_X += curve.module;

            while (new_Y < 0)
                new_Y += curve.module;

            while (new_Z < 0)
                new_Z += curve.module;

            return new EllipticCurvePointP(
                new_X,
                new_Y,
                new_Z,
                curve.module);
        }

        #endregion
    }
}
