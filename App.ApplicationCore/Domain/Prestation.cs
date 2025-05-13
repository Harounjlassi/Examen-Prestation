using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public class Prestation
    {
        public DateTime HeureDebut  { get; set; }
        public int NbHeures { get; set; }

        public int PrestataireFK { get; set; }
        public int ClientFK { get; set; }

        public virtual Client client { get; set; }
        public virtual  Prestataire prestataire { get; set; }


    }
}
