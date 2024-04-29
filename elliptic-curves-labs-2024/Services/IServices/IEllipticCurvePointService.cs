using elliptic_curves_labs_2024.Models.Points;

namespace elliptic_curves_labs_2024.Services.IServices
{
    public interface IEllipticCurvePointService
    {
        public EllipticCurvePointP EllipticCurvePoint_A2P(EllipticCurvePointA point_a);
        public EllipticCurvePointA EllipticCurvePoint_P2A(EllipticCurvePointP point_p);
    }
}
