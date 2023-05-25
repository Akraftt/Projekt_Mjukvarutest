using Projekt.Control;
using Projekt.Interfaces;

namespace Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //9783161484100
            InterfaceISBN validator = new ISBNValidator();
            InterfaceISBN isbn = new ISBN(validator);

            Console.Write("Enter an ISBN To Validate: ");
            string inputISBN = Console.ReadLine();

            bool isValid = isbn.IsValidISBN(inputISBN);
            Console.WriteLine("The ISBN Is: " + (isValid ? "Valid." : "Invalid."));
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}