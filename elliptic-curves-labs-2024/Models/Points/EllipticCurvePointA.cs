using System.Numerics;

namespace elliptic_curves_labs_2024.Models.Points
{
    public class EllipticCurvePointA
    {
        public BigInteger x { get; set; }
        public BigInteger y { get; set; }
        public BigInteger module { get; set; }

        public EllipticCurvePointA(BigInteger x, BigInteger y, BigInteger module)
        {
            this.x = x;
            this.y = y;
            this.module = module;
        }

        public override string ToString()
        {
            return String.Format($"Point has the following coordinates: \n\t\t(x, y) = ({this.x}, {this.y}) in F_{module}.");
        }

        public static bool operator !=(EllipticCurvePointA point_1, EllipticCurvePointA point_2)
        {
            if ((object)point_1 == null || (object)point_2 == null)
                throw new ArgumentNullException();

            return point_1.module != point_2.module ||
                    point_1.x != point_2.x ||
                    point_1.y != point_2.y;
        }

        public static bool operator ==(EllipticCurvePointA point_1, EllipticCurvePointA point_2)
        {
            if ((object)point_1 == null || (object)point_2 == null)
                throw new ArgumentNullException();

            return point_1.module == point_2.module &&
                    point_1.x == point_2.x &&
                    point_1.y == point_2.y;
        }
    }
}
