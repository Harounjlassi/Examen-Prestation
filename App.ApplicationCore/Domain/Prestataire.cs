using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public class Prestataire
    {
        [Range(0, 5,ErrorMessage ="la prsiont doit etre entre 0 et 5 ")]
        public int Appreciation { get; set; }
        public int PrestataireId { get; set; }
        [DataType(DataType.Text)]
        [MaxLength(20)]

        public string PrestataireNom { get; set; }
        public string PrestatairePhoto { get; set; }

        public string PrestataireTel { get; set; }
        [DataType(DataType.Currency)]
        public double TarifHoraire { get; set; }

        public virtual  IList<Prestation> prestations { get; set; }
        public int SpecialiteFK { get; set; }

        [ForeignKey("SpecialiteFK")]
        public virtual Specialite specialite { get; set; }


    }
}
