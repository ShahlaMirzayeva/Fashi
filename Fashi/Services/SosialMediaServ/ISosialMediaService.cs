using Fashi.Dtos.SosialMedia;
using Fashi.Models;

namespace Fashi.Services.SosialMediaServ
{
    public interface ISosialMediaService
    {Task<IEnumerable<SosialMediaDto>> GetAllSosialMediaAsync();
        Task<SosialMediaDto> GetSosialMediaByIdAsync(int id);
        Task AddSosialMediaAsync(SosialMediaCreateDto sosialMediaDto);
        Task DeleteSosialMediaAsync(int id);
        Task UpdateSosialMediaAsync(SosialMediaUpdateDto sosialMediaDto);
    }
}
