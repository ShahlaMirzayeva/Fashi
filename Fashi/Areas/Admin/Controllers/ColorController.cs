using Fashi.Areas.Admin.ViewModels.ColorVm;
using Fashi.Models;
using Fashi.Services.ColorServ;
using Microsoft.AspNetCore.Mvc;

namespace Fashi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;
        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
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
            Color color = new Color
            {
                ColorName= createColorVm.ColorName,
            };
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
            UpdateColorVm updateColorVm = new UpdateColorVm
            {
                Id = color.Id,
                ColorName = color.ColorName
            };
            return View(updateColorVm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateColorVm updateColorVm)
        {
            if (!ModelState.IsValid)
            {
                return View(updateColorVm);
            }
            var color = await _colorService.GetColorByIdAsync(updateColorVm.Id);
            if (color == null) return NotFound();
            color.ColorName = updateColorVm.ColorName;
            await _colorService.UpdateColorAsync(color);
            return RedirectToAction(nameof(Index));
        }
    }
}
