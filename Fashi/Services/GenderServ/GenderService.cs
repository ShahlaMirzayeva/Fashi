using AutoMapper;
using Fashi.Dtos.Gender;
using Fashi.Models;
using Fashi.Repositories.GenderRepo;

namespace Fashi.Services.GenderServ
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;

        public GenderService(IGenderRepository genderRepository, IMapper mapper)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
        }

        public async Task AddGenderAsync(GenderCreateDto genderDto)
        {
            var gender=_mapper.Map<Gender>(genderDto);
            await _genderRepository.AddAsync(gender);
            await _genderRepository.SaveAsync();

        }

        public async Task DeleteGenderAsync(int id)
        {
            await _genderRepository.DeleteAsync(id);
            await _genderRepository.SaveAsync();

        }

     
        public async Task UpdateGenderAsync(GenderUpdateDto genderDto)
        {
            var gender = await _genderRepository.GetByIdAsync(genderDto.Id);
            if (gender == null) throw new Exception("Gender not null");
           _mapper.Map(genderDto,gender);
            await _genderRepository.UpdateAsync(gender);
            await _genderRepository.SaveAsync();
        }

       public async Task<IEnumerable<GenderDto>> GetAllGenderAsync()
        {

           var gender=await _genderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GenderDto>>(gender);
        }

       public async Task<Gender>GetByIdGenderAsync(int id)
        {
           var gender=await _genderRepository.GetByIdAsync(id);
            return _mapper.Map<Gender>(gender);
        }
    }
}
