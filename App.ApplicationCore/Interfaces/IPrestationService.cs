using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.ApplicationCore.Domain;

namespace App.ApplicationCore.Interfaces
{
    public interface IPrestationService:IService<Prestation>
    {
        IEnumerable<IGrouping<Intitule, Prestation>> GetPrestationListClient(int c );
    }
}
