using System.Security.Cryptography;
using System.Text;

namespace elliptic_curves_labs_2024.Services
{
    class AESService
    {
        private readonly Aes aes = Aes.Create();
        private readonly UnicodeEncoding unicodeEncoding = new UnicodeEncoding();

        private const int CHUNK_SIZE = 128;

        private void InitializeAes()
        {
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
        }

        public AESService()
        {
            InitializeAes();

            aes.KeySize = CHUNK_SIZE;
            aes.BlockSize = CHUNK_SIZE;

            aes.GenerateKey();
            aes.GenerateIV();
        }

        public AESService(string base64key, string base64iv)
        {
            InitializeAes();

            aes.Key = Convert.FromBase64String(base64key);
            aes.IV = Convert.FromBase64String(base64iv);
        }

        public AESService(byte[] key, byte[] iv)
        {
            InitializeAes();

            aes.Key = key;
            aes.IV = iv;
        }

        public string Decrypt(byte[] cipher)
        {
            ICryptoTransform transform = aes.CreateDecryptor();
            byte[] decryptedValue = transform.TransformFinalBlock(cipher, 0, cipher.Length);
            return unicodeEncoding.GetString(decryptedValue);
        }

        public string DecryptFromBase64String(string base64cipher)
        {
            return Decrypt(Convert.FromBase64String(base64cipher));
        }

        public byte[] EncryptToByte(string plain)
        {
            ICryptoTransform encryptor = aes.CreateEncryptor();
            byte[] cipher = unicodeEncoding.GetBytes(plain);
            byte[] encryptedValue = encryptor.TransformFinalBlock(cipher, 0, cipher.Length);
            return encryptedValue;
        }

        public string EncryptToBase64String(string plain)
        {
            return Convert.ToBase64String(EncryptToByte(plain));
        }

        public string GetBase64Key()
        {
            return Convert.ToBase64String(aes.Key);
        }

        public string GetBase64IV()
        {
            return Convert.ToBase64String(aes.IV);
        }

        public override string ToString()
        {
            return "key:" + GetBase64Key() + Environment.NewLine + "iv:" + GetBase64IV();
        }
    }
}
