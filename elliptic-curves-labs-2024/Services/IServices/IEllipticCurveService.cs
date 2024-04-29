using elliptic_curves_labs_2024.Models.Curves;

namespace elliptic_curves_labs_2024.Services.IServices
{
    public interface IEllipticCurveService
    {
        public bool IsValid(IEllipticCurve elliptic_curve);
    }
}
