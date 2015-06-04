using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssymmetricEncryptDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Key generation part
            //    public key is given to the client, could be even emailed, and will be used only for encryption
            //    private key (private & public together) should be stored on our/server side for decryption
            const int keySize = 512;
            string publicAndPrivateKey;
            string publicKey;

            AsymmetricEncryption.GenerateKeys(keySize, out publicKey, out publicAndPrivateKey);

            Console.WriteLine("PublicKey: {0}", publicKey);
            Console.WriteLine();

            Console.WriteLine("PublicAndPrivateKey: {0}", publicAndPrivateKey);
            Console.WriteLine();


            // 2. Encryption - Client part 
            //    we will give them public key to encrypt:
            string text = "text for encryption 0987654321!@#$%";

            string encrypted = AsymmetricEncryption.EncryptText(text, keySize, publicKey);

            // 3. Decryption - Our/Server part
            // to decrypt we will use both:
            string decrypted = AsymmetricEncryption.DecryptText(encrypted, keySize, publicAndPrivateKey);
            Console.WriteLine("Encrypted: {0}", encrypted);
            Console.WriteLine("Decrypted: {0}", decrypted);

            Console.ReadKey();
        }
    }
}
