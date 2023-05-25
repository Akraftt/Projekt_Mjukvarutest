using Projekt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projekt.Interfaces;

namespace Projekt.Control
{
    public class ISBN : InterfaceISBN, IWebsite
    {
        private readonly InterfaceISBN _validator;

        public ISBN(InterfaceISBN validator)
        {
            _validator = validator;
        }

        // ---------------------------------------------------------------------------

        public bool IsValidISBN(string isbn)
        {
            return _validator.IsValidISBN(isbn);
        }



        public string GetBookAuthor(string isbn)
        {
            return "Test Author";
        }


        public string GetBookTitle(string isbn)
        {
            return "Test Title";
        }


    }
}


