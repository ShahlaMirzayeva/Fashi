using Fashi.Data;
using Fashi.Models;

namespace Fashi.Repositories.BenefitRepo
{
    public class BenefitRepository :Repository<Benefit>, IBenefitRepository
    {
        public BenefitRepository(AppDbContext context) : base(context)
        {
        }
    
    }
}
