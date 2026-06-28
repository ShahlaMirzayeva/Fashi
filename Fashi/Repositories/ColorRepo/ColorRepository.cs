using Fashi.Data;
using Fashi.Models;

namespace Fashi.Repositories.ColorRepo
{
    public class ColorRepository:Repository<Color>, IColorRepository
    {
        public ColorRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
