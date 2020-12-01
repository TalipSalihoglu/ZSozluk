using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZSözlük.Entities;
using ZSözlük.Models.ViewModel;
using ZSözlük.Repository;

namespace ZSözlük.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IcerikRepository _ıcerikRepository;
        public AdminController(IcerikRepository icerikRepository)
        {
            _ıcerikRepository = icerikRepository;
        }
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            var list = _ıcerikRepository.GetirİcerikHepsi();            
            return View(await PaginatedListModel<Icerik>.CreateAsync(list, pageNumber,10));
        }
    }
}
