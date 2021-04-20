using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_Personale
{
    public abstract class Persona
    {
        public string CodiceFiscale { get; set; }
        public string Nome { get; set; }

        public string Cognome { get; set; }
        public Persona(string codicefiscale,string nome,string cognome)
        {
            CodiceFiscale = codicefiscale;
            Nome = nome;
            Cognome = cognome;
        }

        

        public override string ToString() => $"{Nome} {Cognome}";
        
    }
}
