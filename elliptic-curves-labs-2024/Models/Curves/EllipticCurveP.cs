using System.Numerics;

namespace elliptic_curves_labs_2024.Models.Curves
{
    public class EllipticCurveP : IEllipticCurve
    {
        public BigInteger a { get; set; }
        public BigInteger b { get; set; }
        public BigInteger module { get; set; }

        public EllipticCurveP(BigInteger a, BigInteger b, BigInteger module)
        {
            this.a = a;
            this.b = b;
            this.module = module;
        }

        public override string ToString()
        {
            return String.Format("Y^2 * Z = X^3 + {0} * X * Z^2 + {1} * Z^3 in F_{2}", a, b, module);
        }
    }
}
