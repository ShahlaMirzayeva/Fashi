using Fashi.Data;
using Fashi.Models;
using System.Linq.Expressions;

namespace Fashi.Repositories.DealOfWeekRepo
{
    public class DealOfWeekRepository : Repository<DealOfWeek>, IDealOfWeekRepository
    {
        public DealOfWeekRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
