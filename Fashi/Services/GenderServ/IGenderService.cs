using Fashi.Models;

namespace Fashi.Services.GenderServ
{
    public interface IGenderService
    {
        Task<IEnumerable<Gender>> GetAllGenderAsync();
        Task<Gender> GetByIdGenderAsync(int id);
        Task AddGenderAsync(Gender gender);
        Task DeleteGenderAsync(int id);
      
        Task UpdateGenderAsync(Gender gender);

    }
}
