using Fashi.Data;
using Fashi.Models;

namespace Fashi.Repositories.SosialMediaRepo
{
    public class SosialMediaRepository: Repository<SosialMedia>, ISosialMediaRepository
    {
        public SosialMediaRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
