using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public class Client
    {
        public string Adresse { get; set; }
        public int ClientId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }

        public virtual IList<Prestation> prestations { get; set; }

    }
}
