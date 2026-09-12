using AutoMapper;
using Fashi.Areas.Admin.ViewModels.HomeBannerVm;
using Fashi.Dtos.HomeBanner;
using Fashi.Services.HomeBannerServ;
using Microsoft.AspNetCore.Mvc;

namespace Fashi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeBannerController : Controller
    {private readonly IHomeBannerService _homeBannerService;
        private readonly IMapper _mapper;
        public HomeBannerController(IHomeBannerService homeBannerService, IMapper mapper)
        {
            _homeBannerService = homeBannerService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var homeBanners = await _homeBannerService.GetAllHomeBannerAsync();
            return View(homeBanners);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateHomeBannerVm homeBannerVm)
        {
            if (!ModelState.IsValid)
            {
                return View(homeBannerVm);
            }
            var homeBanner = _mapper.Map<HomeBannerCreateDto>(homeBannerVm);
            await _homeBannerService.AddHomeBannerAsync(homeBanner);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _homeBannerService.DeleteHomeBannerAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var homeBanner = await _homeBannerService.GetByIdHomeBannerAsync(id);
            var homeBannerVm = _mapper.Map<UpdateHomeBannerVm>(homeBanner);
            return View(homeBannerVm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateHomeBannerVm homeBannerVm)
        {
            if (!ModelState.IsValid)
            {
                return View(homeBannerVm);
            }
            var homeBanner = _mapper.Map<HomeBannerUpdateDto>(homeBannerVm);
            await _homeBannerService.UpdateHomeBannerAsync(homeBanner);
            return RedirectToAction("Index");
        }
    }
}
