using AutoMapper;
using Fashi.Areas.Admin.ViewModels.ColorVm;
using Fashi.Dtos.Color;
using Fashi.Models;
using Fashi.Services.ColorServ;
using Microsoft.AspNetCore.Mvc;

namespace Fashi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;
        public ColorController(IColorService colorService,IMapper mapper)
        {
            _colorService = colorService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {var colors =await  _colorService.GetAllColorAsync();
            return View(colors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateColorVm createColorVm)
        {
            if (!ModelState.IsValid)
            {
                return View(createColorVm);
            }
            //ColorCreateDto color = new ColorCreateDto
            //{
            //    ColorName= createColorVm.ColorName,
            //};
            var color= _mapper.Map<ColorCreateDto>(createColorVm);
            await _colorService.AddColorAsync(color);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
           await _colorService.DeleteColorAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var color = await _colorService.GetColorByIdAsync(id);
            if (color == null) return NotFound();
            //UpdateColorVm updateColorVm = new UpdateColorVm
            //{
            //    Id = color.Id,
            //    ColorName = color.ColorName
            //};
            var updateColorVm = _mapper.Map<UpdateColorVm>(color);
            return View(updateColorVm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateColorVm updateColorVm)
        {
            if (!ModelState.IsValid)
            {
                return View(updateColorVm);
            }
      //ColorUpdateDto color = new ColorUpdateDto
      //      {
      //          Id = updateColorVm.Id,
      //          ColorName = updateColorVm.ColorName
      //      };
      var color = _mapper.Map<ColorUpdateDto>(updateColorVm);   
            await _colorService.UpdateColorAsync(color);
            return RedirectToAction(nameof(Index));
        }
    }
}
