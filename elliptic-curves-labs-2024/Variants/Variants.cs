using elliptic_curves_labs_2024.Models.Curves;
using elliptic_curves_labs_2024.Services;
using System.Globalization;
using System.Numerics;

namespace elliptic_curves_labs_2024.Variants
{
    public static class Variants
    {
        public static EllipticCurveP P192_curve 
        {
            get
            {
                BigInteger module = BigInteger.Parse("6277101735386680763835789423207666416083908700390324961279");
                BigInteger a = Calculator.GetPositiveInField(new BigInteger(-3), module);
                BigInteger b = BigInteger.Parse("0" + "64210519E59C80E70FA7E9AB72243049FEB8DEECC146B9B1", NumberStyles.HexNumber);

                return new EllipticCurveP(a,b,module);
            }
        }

        public static EllipticCurveP P224_curve
        {
            get
            {
                BigInteger module = BigInteger.Parse("26959946667150639794667015087019630673557916260026308143510066298881");
                BigInteger a = Calculator.GetPositiveInField(new BigInteger(-3), module);
                BigInteger b = BigInteger.Parse("0" + "b4050a850c04b3abf54132565044b0b7d7bfd8ba270b39432355ffb4", NumberStyles.HexNumber);

                return new EllipticCurveP(a, b, module);
            }
        }

        public static EllipticCurveP P256_curve
        {
            get
            {
                BigInteger module = BigInteger.Parse("115792089210356248762697446949407573530086143415290314195533631308867097853951");
                BigInteger a = Calculator.GetPositiveInField(new BigInteger(-3), module);
                BigInteger b = BigInteger.Parse("0" + "5ac635d8aa3a93e7b3ebbd55769886bc651d06b0cc53b0f63bce3c3e27d2604b", NumberStyles.HexNumber);

                return new EllipticCurveP(a, b, module);
            }
        }

        public static EllipticCurveP P384_curve
        {
            get
            {
                BigInteger module = BigInteger.Parse("0" + "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffeffffffff0000000000000000ffffffff", NumberStyles.HexNumber);
                BigInteger a = BigInteger.Parse("0" + "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffeffffffff0000000000000000fffffffc", NumberStyles.HexNumber); 
                BigInteger b = BigInteger.Parse("0" + "b3312fa7e23ee7e4988e056be3f82d19181d9c6efe8141120314088f5013875ac656398d8a2ed19d2a85c8edd3ec2aef", NumberStyles.HexNumber);

                return new EllipticCurveP(a, b, module);
            }
        }

        public static EllipticCurveP P521_curve
        {
            get
            {
                BigInteger module = BigInteger.Parse("0" + "01ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff", NumberStyles.HexNumber);
                BigInteger a = BigInteger.Parse("0" + "01fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffc", NumberStyles.HexNumber);
                BigInteger b = BigInteger.Parse("0" + "0051953eb9618e1c9a1f929a21a0b68540eea2da725b99b315f3b8b489918ef109e156193951ec7e937b1652c0bd3bb1bf073573df883d2c34f1ef451fd46b503f00", NumberStyles.HexNumber);

                return new EllipticCurveP(a, b, module);
            }
        }
    }
}
