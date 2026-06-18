using Fashi.Data;
using Fashi.Models;

namespace Fashi.Repositories.GenderRepo
{
    public class GenderRepository:Repository<Gender>, IGenderRepository
    {
        public GenderRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
