using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;

namespace App.ApplicationCore.Services
{
    public class PrestationService : Service<Prestation>, IPrestationService
    {
        public PrestationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<IGrouping<Intitule, Prestation>> GetPrestationListClient(int c)
        {
            return GetMany(p=>p.client.ClientId==c)
                .GroupBy(p=>p.prestataire.specialite.Intitule).ToList();
        }
    }
}
