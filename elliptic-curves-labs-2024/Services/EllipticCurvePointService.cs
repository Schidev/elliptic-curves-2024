using elliptic_curves_labs_2024.Models.Points;
using elliptic_curves_labs_2024.Services.IServices;
using System.Numerics;

namespace elliptic_curves_labs_2024.Services
{
    public class EllipticCurvePointService : IEllipticCurvePointService
    {
        public EllipticCurvePointA POINT_AT_INFINITY_A(BigInteger module)
            => new EllipticCurvePointA(BigInteger.Zero, BigInteger.Zero, module);
        public EllipticCurvePointP POINT_AT_INFINITY_P(BigInteger module)
            => new EllipticCurvePointP(BigInteger.Zero, BigInteger.One, BigInteger.Zero, module);

        public EllipticCurvePointP EllipticCurvePoint_A2P(EllipticCurvePointA point_a)
            => new EllipticCurvePointP(point_a.x, point_a.y, BigInteger.One, point_a.module);

        public EllipticCurvePointA EllipticCurvePoint_P2A(EllipticCurvePointP point_p)
        {
            if (point_p == POINT_AT_INFINITY_P(point_p.module))
                return POINT_AT_INFINITY_A(point_p.module);
            
            if (point_p.Z == BigInteger.Zero)
                return POINT_AT_INFINITY_A(point_p.module);

            var new_x = Calculator.GetPositiveInField(point_p.X * Calculator.GetInverseElementInFieldByExtendedEuclideanAlgorithm(point_p.Z, point_p.module), point_p.module);
            var new_y = Calculator.GetPositiveInField(point_p.Y * Calculator.GetInverseElementInFieldByExtendedEuclideanAlgorithm(point_p.Z, point_p.module), point_p.module);

            return new EllipticCurvePointA(new_x, new_y, point_p.module);
        }
    }
}
