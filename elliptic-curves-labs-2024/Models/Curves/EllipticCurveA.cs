using System.Numerics;

namespace elliptic_curves_labs_2024.Models.Curves
{
    public class EllipticCurveA : IEllipticCurve
    {
        public BigInteger a { get; set; }
        public BigInteger b { get; set; }
        public BigInteger module { get; set; }

        public EllipticCurveA(BigInteger a, BigInteger b, BigInteger module)
        {
            this.a = a;
            this.b = b;
            this.module = module;
        }

        public override string ToString()
        {
            return String.Format("y^2 = x^3 + {0} * x + {1} in F_{2}", a, b, module);
        }
    }
}
