using Fashi.Dtos.Gender;
using Fashi.Models;

namespace Fashi.Services.GenderServ
{
    public interface IGenderService
    {
        Task<IEnumerable<GenderDto>> GetAllGenderAsync();
        Task<Gender> GetByIdGenderAsync(int id);
        Task AddGenderAsync(GenderCreateDto gender);
        Task DeleteGenderAsync(int id);
      
        Task UpdateGenderAsync(GenderUpdateDto gender);

    }
}
