using AutoMapper;
using Fashi.Areas.Admin.ViewModels.SosialMediaVm;
using Fashi.Dtos.SosialMedia;
using Fashi.Models;
using Fashi.Services.SosialMediaServ;
using Microsoft.AspNetCore.Mvc;

namespace Fashi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SosialMediaController : Controller
    {private readonly ISosialMediaService _sosialMediaService;
        private readonly IMapper _mapper;
        public SosialMediaController(ISosialMediaService sosialMediaService, IMapper mapper)
        {
            _sosialMediaService = sosialMediaService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {var sosialMedia = await _sosialMediaService.GetAllSosialMediaAsync();
            return View(sosialMedia);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSosialMediaVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var sosialMedia = _mapper.Map<SosialMediaCreateDto>(model);
            await _sosialMediaService.AddSosialMediaAsync(sosialMedia);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult>Delete(int id)
        {
            await _sosialMediaService.DeleteSosialMediaAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var sosialMedia = await _sosialMediaService.GetSosialMediaByIdAsync(id);
            var model = _mapper.Map<UpdateSosialMediaVm>(sosialMedia);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateSosialMediaVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var sosialMedia = _mapper.Map<SosialMediaUpdateDto>(model);
            await _sosialMediaService.UpdateSosialMediaAsync(sosialMedia);
            return RedirectToAction("Index");
        }
    }
}
