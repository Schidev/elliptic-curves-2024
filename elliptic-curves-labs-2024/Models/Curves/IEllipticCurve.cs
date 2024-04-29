using System.Numerics;

namespace elliptic_curves_labs_2024.Models.Curves
{
    public interface IEllipticCurve
    {
        public BigInteger a { get; set; }
        public BigInteger b { get; set; }
        public BigInteger module { get; set; }
    }
}
