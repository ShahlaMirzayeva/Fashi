using Fashi.Models;
using Fashi.Repositories.GenderRepo;

namespace Fashi.Services.GenderServ
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public async Task AddGenderAsync(Gender gender)
        {
           await _genderRepository.AddAsync(gender);
            await _genderRepository.SaveAsync();

        }

        public async Task DeleteGenderAsync(int id)
        {
            await _genderRepository.DeleteAsync(id);
            await _genderRepository.SaveAsync();

        }

     
        public async Task UpdateGenderAsync(Gender gender)
        {
            await _genderRepository.UpdateAsync(gender);
            await _genderRepository.SaveAsync();
        }

       public Task<IEnumerable<Gender>> GetAllGenderAsync()
        {
            return _genderRepository.GetAllAsync();
        }

       public Task<Gender>GetByIdGenderAsync(int id)
        {
            return _genderRepository.GetByIdAsync(id);
        }
    }
}
