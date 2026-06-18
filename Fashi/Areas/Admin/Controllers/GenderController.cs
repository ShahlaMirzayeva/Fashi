using Fashi.Areas.Admin.ViewModels.GenderVm;
using Fashi.Models;
using Fashi.Services.GenderServ;
using Microsoft.AspNetCore.Mvc;

namespace Fashi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GenderController : Controller
    {
        private readonly IGenderService _genderService;
        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }
        public async Task<IActionResult> Index()
        {var genders= await _genderService.GetAllGenderAsync();
         
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
            Gender gender = new Gender
            {
                Name= createGender.Name
            };
            await _genderService.AddAsync(gender);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {Gender gender= await _genderService.GetByIdGenderAsync(id);
            return View(gender);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateGenderVm updateGenderVm)
        {
            if (!ModelState.IsValid)
            {
                return View(updateGenderVm);
            }

        Gender oldGender=await _genderService.GetByIdGenderAsync(updateGenderVm.Id);
            if (oldGender == null) { return NotFound(); }
            oldGender.Name = updateGenderVm.Name;
            await _genderService.UpdateAsync(oldGender);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var gender = await _genderService.GetByIdGenderAsync(id);
            if(gender is null) { return NotFound(); }
            await _genderService.DeleteAsync(gender);
            return RedirectToAction(nameof(Index));
        }
    }
}
