using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_Personale
{
    public class Costanti
    {

        public static readonly string DIRECTORY = Directory.GetCurrentDirectory(); // file presente nel bin/Debug
        public const string FILE = @"\personaleAziendale.csv";
        private Costanti() { }
    }
}
