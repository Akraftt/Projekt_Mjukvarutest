using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Interfaces
{
    public interface IDatabase
    {
        string ReturnAuthor(string isbn);
        string ReturnTitle(string isbn);
    }
}
