using System;
using System.Security.Cryptography;
using System.Text;

namespace CreditCardZheil
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" +-+-+-+ Enter Your Credit Card Number: +-+-+-+");
            string CreditCard = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(" +-+-+-+ Press Enter To Compress +-+-+-+ ");
            Console.ReadLine();

            var compression = new Compression();
            compression.CompressedCC();
            Console.ReadLine();

            var encrypt = new Encryption();
            encrypt.Encrypt();
            Console.ReadLine();

            var store = new Storing();
            store.Store();
            Console.ReadLine();

        }
    }

    public interface ICardNumber
    {
        void Encrypt();
    }

    public class Encryption:ICardNumber
    {
        public void Encrypt() 
        {

            string CreditCard = Console.ReadLine();
            string source = CreditCard;
            using (SHA384 SHA512Hash = SHA384.Create())
            {
                byte[] sourseBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashbytes = SHA512Hash.ComputeHash(sourseBytes);

                string hash = BitConverter.ToString(hashbytes).Replace("-", string.Empty);

                CreditCard = hash;
            }
            Console.Clear();
            Console.WriteLine(" +-+-+-+ Your Encryption code is +-+-+-+ ");
            Console.WriteLine(CreditCard);
            Console.WriteLine("Press enter to save into Cloud");
        } 
    }
  
    public class Compression:Encryption
    {
        public void CompressedCC()
        {
            Console.Clear();
            Console.WriteLine(" +-+-+-+ The data is successfully compressed.. +-+-+-+ ");
            Console.WriteLine("Press enter to Encrypt");
        }

    }
    
    public class Storing : Encryption
    {
        public void Store()
        {
            Console.Clear();
            Console.WriteLine("+-+-+-+ Succesfully Stored into Cloud. +-+-+-+ ");
            Console.WriteLine("Press Any Key To Exit");
        }
    }
}
