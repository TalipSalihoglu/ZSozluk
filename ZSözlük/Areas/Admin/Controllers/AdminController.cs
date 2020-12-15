using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZSözlük.Entities;
using ZSözlük.Models.ViewModel;
using ZSözlük.Services;

namespace ZSözlük.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IIcerikService _ıcerikService;
        public AdminController(IIcerikService ıcerikService )
        {
            _ıcerikService = ıcerikService;
        }
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            //var list = _ıcerikRepository.GetirİcerikHepsi();            ,
            var list =await _ıcerikService.GetAllIcerik();
            return View(await PaginatedListModel<Icerik>.CreateAsync(list, pageNumber,10));
        }
        public async Task<IActionResult> DeleteIcerik(int id)
        {
            //var icerik = _ıcerikRepository.icerikBulIdile(id);
            //_ıcerikRepository.Sil(icerik);
            var icerik =(Icerik) await _ıcerikService.GetIcerikById(id);
            await _ıcerikService.DeleteIcerik(icerik);
            return RedirectToAction("Index");
        }
    }
}
