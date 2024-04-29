using elliptic_curves_labs_2024.Models.Curves;
using System.Numerics;

namespace elliptic_curves_labs_2024.Services
{
    public static class EllipticCurveService
    {
        public static bool IsValid(IEllipticCurve elliptic_curve)
            => (4 * BigInteger.Pow(elliptic_curve.a, 3) + 27 * BigInteger.Pow(elliptic_curve.b, 2)) % elliptic_curve.module != 0;
    }
}
