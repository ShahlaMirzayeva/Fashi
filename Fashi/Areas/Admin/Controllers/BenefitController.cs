using AutoMapper;
using Fashi.Areas.Admin.ViewModels.BenefitVm;
using Fashi.Dtos.Benefit;
using Fashi.Services.BenefitServ;
using Microsoft.AspNetCore.Mvc;

namespace Fashi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BenefitController : Controller
    {
        private readonly IBenefitService _benefitService;
        private readonly IMapper _mapper;

        public BenefitController(IBenefitService benefitService, IMapper mapper)
        {
            _benefitService = benefitService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var benefits = await _benefitService.GetAllBenefitsAsync();
            return View(benefits);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBenefitVm benefitVm)
        {
            if (!ModelState.IsValid)
            {
                return View(benefitVm);
            }
            var benefit = _mapper.Map<BenefitCreateDto>(benefitVm);
            await _benefitService.AddBenefitAsync(benefit);
            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _benefitService.DeleteBenefitAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var benefit = await _benefitService.GetBenefitByIdAsync(id);
            var benefitVm = _mapper.Map<UpdateBenefitVm>(benefit);
            return View(benefitVm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBenefitVm benefitVm)
        {
            if (!ModelState.IsValid)
            {
                return View(benefitVm);
            }
            var benefit = _mapper.Map<BenefitUpdateDto>(benefitVm);
            await _benefitService.UpdateBenefitAsync(benefit);
            return RedirectToAction("Index");
        }
    }
}
