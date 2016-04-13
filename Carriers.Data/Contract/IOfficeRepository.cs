using PowerEvent.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PowerEvent.Data.Contract
{
    public interface IOfficeRepository : IRepository<Office>
    {
        Task<List<Office>> Get(int TeamMemberId);
    }
}
