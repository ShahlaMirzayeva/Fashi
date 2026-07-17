using AutoMapper;
using Fashi.Areas.Admin.ViewModels.GenderVm;
using Fashi.Dtos.Gender;
using Fashi.Models;
using Fashi.Services.GenderServ;
using Microsoft.AspNetCore.Mvc;

namespace Fashi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GenderController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IMapper _mapper;
        public GenderController(IGenderService genderService, IMapper mapper)
        {
            _genderService = genderService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {var genders= await _genderService.GetAllGenderAsync();
            if(genders is null) { return NotFound(); }

            return View(genders);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateGenderVm createGender)
        {if (createGender == null) { return NotFound(); }
            if (!ModelState.IsValid)
            {
                return View(createGender);
            }
          //GenderCreateDto gender=new GenderCreateDto
          //  {
          //      Name=createGender.Name
          //  };
          var gender=_mapper.Map<GenderCreateDto>(createGender);
            await _genderService.AddGenderAsync(gender);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {Gender gender= await _genderService.GetByIdGenderAsync(id);
            if(gender is null)return NotFound();    
            //UpdateGenderVm updateGenderVm = new UpdateGenderVm
            //{
            //    Id = gender.Id,
            //    Name= gender.Name
            //};
            var updateGenderVm = _mapper.Map<UpdateGenderVm>(gender);
            return View(updateGenderVm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateGenderVm updateGenderVm)
        {
            if (!ModelState.IsValid)
            {
                return View(updateGenderVm);
            }
            //GenderUpdateDto oldGender = new GenderUpdateDto
            //{
            //    Id = updateGenderVm.Id,
            //    Name = updateGenderVm.Name
            //};
            var oldGender = _mapper.Map<GenderUpdateDto>(updateGenderVm);
            if (oldGender is null) { return NotFound(); }


            await _genderService.UpdateGenderAsync(oldGender);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
        
            await _genderService.DeleteGenderAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
