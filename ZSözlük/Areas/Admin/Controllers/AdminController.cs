using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Index()
        {         
            return View(await _ıcerikRepository.GetirİcerikHepsi());
        }
    }
}
