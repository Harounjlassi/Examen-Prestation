using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;

namespace App.ApplicationCore.Services
{
    public class PrestataireService : Service<Prestataire>, IPrestataireService
    {
        public PrestataireService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<Prestataire> GetFirstThreePrestataire()
        {
            return GetMany(p => p.specialite.Intitule == Intitule.Bricolage)
                .OrderByDescending(p => p.Appreciation).Take(3).ToList();
        }

        public double GetMoyTarif(int c)
        {
            return GetMany(p => p.specialite.Code == c).Select(p=>p.TarifHoraire).Average();
        }
        public double Gain()
        {
            double tarifMoinsCher = GetAll().OrderBy(p => p.TarifHoraire).First().TarifHoraire;
            var query = GetAll().OrderBy(p => p.TarifHoraire).First().prestations;
            double nbre = 0;
            foreach (var item in query)
            {
                if (item.HeureDebut.Year == DateTime.Now.Year)
                {
                    nbre = nbre + item.NbHeures;
                }

            }
            return nbre * tarifMoinsCher;
        }
    }
}
