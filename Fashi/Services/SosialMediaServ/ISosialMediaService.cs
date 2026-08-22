using Fashi.Models;

namespace Fashi.Services.SosialMediaServ
{
    public interface ISosialMediaService
    {Task<IEnumerable<SosialMedia>> GetAllSosialMediaAsync();
        Task<SosialMedia> GetSosialMediaByIdAsync(int id);
        Task AddSosialMediaAsync(SosialMedia sosialMedia);
        Task DeleteSosialMediaAsync(int id);
        Task UpdateSosialMediaAsync(SosialMedia sosialMedia);
    }
}
