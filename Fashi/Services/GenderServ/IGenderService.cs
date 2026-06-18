using Fashi.Models;

namespace Fashi.Services.GenderServ
{
    public interface IGenderService
    {
        Task<IEnumerable<Gender>> GetAllGenderAsync();
        Task<Gender> GetByIdGenderAsync(int id);
        Task AddAsync(Gender gender);
        Task DeleteAsync(int id);
      
        Task UpdateAsync(Gender gender);

    }
}
