using elliptic_curves_labs_2024.Models.Curves;
using elliptic_curves_labs_2024.Models.Points;
using System.Drawing;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;

namespace elliptic_curves_labs_2024.Services
{
    public static class EncryptionDecryptionService
    {

        public static EllipticCurvePointP GetQ(BigInteger e, EllipticCurvePointP P, EllipticCurveP curve)
        {
            return Calculator.PointMultiplyByScalar(P, e, curve);
        }
        
        public static byte[] Enc(
            string message, 
            BigInteger e,
            EllipticCurvePointP q,
            EllipticCurvePointP P, 
            EllipticCurveP curve)
        {
            var s = EllipticCurvePointService.EllipticCurvePoint_A2P(EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(q, e, curve)));

            byte[] key = new byte[32];
            byte[] iv = new byte[16];

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(P.ToString());
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Determine the length of the key in bytes
                int keyLength = hashBytes.Length;

                key = hashBytes;

                inputBytes = Encoding.UTF8.GetBytes(s.ToString());
                hashBytes = sha256.ComputeHash(inputBytes);
                Array.Copy(hashBytes, iv, 16);
            }

            AESService aes = new AESService(key, iv);

            var c_m = aes.EncryptToByte(message);

            return c_m;
        }

        public static string Dec(
            byte[] encrypted_message,
            BigInteger e,
            EllipticCurvePointP q,
            EllipticCurvePointP P,
            EllipticCurveP curve)
        {
            var s = EllipticCurvePointService.EllipticCurvePoint_A2P(EllipticCurvePointService.EllipticCurvePoint_P2A(Calculator.PointMultiplyByScalar(q, e, curve)));

            byte[] key = new byte[32];
            byte[] iv = new byte[16];

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(P.ToString());
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Determine the length of the key in bytes
                int keyLength = hashBytes.Length;

                key = hashBytes;

                inputBytes = Encoding.UTF8.GetBytes(s.ToString());
                hashBytes = sha256.ComputeHash(inputBytes);
                Array.Copy(hashBytes, iv, 16);
            }

            AESService aes = new AESService(key, iv);

            var message = aes.Decrypt(encrypted_message);

            return message;
        }

    }
}
