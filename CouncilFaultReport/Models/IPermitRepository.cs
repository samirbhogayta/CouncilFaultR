using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilFaultReport.Models
{
    interface IPermitRepository
    {
        Task Add(Permit permit);
        Task Update(Permit permit);
        Task Delete(string id);
        Task<Permit> GetPermit(string id);
        Task<IEnumerable<Permit>> GetPermits();
    }
}
