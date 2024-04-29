using elliptic_curves_labs_2024.Models.Curves;
using elliptic_curves_labs_2024.Services.IServices;
using System.Numerics;

namespace elliptic_curves_labs_2024.Services
{
    public class EllipticCurveService : IEllipticCurveService
    {
        public bool IsValid(IEllipticCurve elliptic_curve)
            => (4 * BigInteger.Pow(elliptic_curve.a, 3) + 27 * BigInteger.Pow(elliptic_curve.b, 2)) % elliptic_curve.module != 0;
    }
}
