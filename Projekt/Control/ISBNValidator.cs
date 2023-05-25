using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Projekt.Interfaces;
namespace Projekt.Control
{
    public class ISBNValidator : InterfaceISBN
    {
        public bool IsValidISBN(string isbn)
        {
            if (isbn == null || isbn.Length != 13)
            {
                return false;
            }
            int sum = 0;
            for (int i = 0; i < isbn.Length; i++)
            {
                int digit = int.Parse(isbn[i].ToString());
                sum += (i % 2 == 0) ? digit : 3 * digit;
            }
            int checkDigit = int.Parse(isbn[isbn.Length - 1].ToString());
            return (10 - sum % 10) % 10 == checkDigit;
        }
    }
}
