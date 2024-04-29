using elliptic_curves_labs_2024.Models.Curves;
using elliptic_curves_labs_2024.Services;
using elliptic_curves_labs_2024.Services.IServices;
using System.Numerics;
namespace elliptic_curves_tests_2024
{
    public class EllipticCurvesServiceTests
    {
        [Fact]
        public void EllipticCurveIsValid_ReturnsFalse()
        {
            // Arrange
            BigInteger a = new BigInteger(6);
            BigInteger b = new BigInteger(1);
            BigInteger module = new BigInteger(11);
            var a_elliptic_curve = new EllipticCurveA(a, b, module);

            IEllipticCurveService service = new EllipticCurveService();

            // Act
            var isValid = service.IsValid(a_elliptic_curve);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void EllipticCurveIsValid_ReturnsTrue()
        {
            // Arrange
            BigInteger a = new BigInteger(1);
            BigInteger b = new BigInteger(10);
            BigInteger module = new BigInteger(11);
            var a_elliptic_curve = new EllipticCurveA(a, b, module);

            IEllipticCurveService service = new EllipticCurveService();

            // Act
            var isValid = service.IsValid(a_elliptic_curve);

            // Assert
            Assert.True(isValid);
        }
    }
}
