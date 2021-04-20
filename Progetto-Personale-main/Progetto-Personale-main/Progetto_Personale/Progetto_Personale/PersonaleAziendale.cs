using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_Personale
{
    public class PersonaleAziendale : Persona
    { 
        public string Tipologia { get; set; }
        public string Qualifica { get; set; }
        public string Area { get; set; }

        public PersonaleAziendale(string codicefiscale,string nome,string cognome,string tipologia) : base(codicefiscale,nome,cognome)
        {
            Tipologia = tipologia;
        }
        public override string ToString()
        {
            return base.ToString() + $"tipologia: {Tipologia},Mansione: {Qualifica},Area: {Area}";
        }
    }
}
