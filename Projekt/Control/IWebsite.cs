using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Interfaces
{
    public interface IWebsite
    {
        string GetBookAuthor(string isbn);
        string GetBookTitle(string isbn);
    }
}
