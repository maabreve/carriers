using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PowerEvent.Data.Contract;
using PowerEvent.Model;

namespace PowerEvent.Data
{
    public class TeamRepository : EfRepository<Team>, ITeamRepository
    {
        public TeamRepository(DbContext context) : base(context) { }

        public async Task<List<Team>> GetByOfficeAsync(int OfficeId)
        {
            return await DbContext.Set<Team>().Where(s => s.OfficeId == OfficeId).ToListAsync();
        }

    }
}
