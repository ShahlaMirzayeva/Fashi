using Fashi.Data;
using Fashi.Models;

namespace Fashi.Repositories.SaleRepo
{
    public class SaleRepository:Repository<Sale>, ISaleRepository
    {
        public SaleRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
