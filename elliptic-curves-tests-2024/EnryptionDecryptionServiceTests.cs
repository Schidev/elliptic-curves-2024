using elliptic_curves_labs_2024.Models.Points;
using elliptic_curves_labs_2024.Services;
using elliptic_curves_labs_2024.Variants;
using System.Globalization;
using System.Numerics;

namespace elliptic_curves_tests_2024
{
    public class EnryptionDecryptionServiceTests
    {
        [Fact]
        public void EnryptionDecryptionServiceTests_Enc_And_Dec_Test_01_P192()
        {
            // Arrange
            // Alice's message
            var alice_message = "I have sth to tell you, Bob. Are you on line?";
            
            // Define curve and base point
            var curve = Variants.P192_curve;

            BigInteger BasePoint_X = BigInteger.Parse("0" + "188da80eb03090f67cbf20eb43a18800f4ff0afd82ff1012", NumberStyles.HexNumber);
            BigInteger BasePoint_Y = BigInteger.Parse("0" + "7192b95ffc8da78631011ed6b24cdd573f977a11e794811", NumberStyles.HexNumber);

            var BasePoint = EllipticCurvePointService.EllipticCurvePoint_A2P(new EllipticCurvePointA(BasePoint_X, BasePoint_Y, curve.module));
            BigInteger expected_order = BigInteger.Parse("6277101735386680763835789423176059013767194773182842284081");

            // Act
            var e_alice = (Calculator.getRandom(expected_order.ToByteArray().Length - 1)) % expected_order;
            var e_bob = (Calculator.getRandom(expected_order.ToByteArray().Length - 1)) % expected_order;

            var q_alice = EllipticCurvePointService.EllipticCurvePoint_A2P(EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(BasePoint, e_alice, curve)));
            var q_bob = EllipticCurvePointService.EllipticCurvePoint_A2P(EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(BasePoint, e_bob, curve)));

            var encrypted_message = EncryptionDecryptionService.Enc(alice_message, e_alice, q_bob, BasePoint, curve);
            var decrypted_message = EncryptionDecryptionService.Dec(encrypted_message, e_bob, q_alice, BasePoint, curve);

            // Assert
            Assert.True(alice_message == decrypted_message);
        }

    }
}
