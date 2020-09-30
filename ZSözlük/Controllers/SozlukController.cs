using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZSözlük.Repository;

namespace ZSözlük.Controllers
{
    public class SozlukController : Controller
    {
        private readonly KonuRepository _konuRepository;
        public SozlukController(KonuRepository konuRepository)
        {
            _konuRepository = konuRepository;
        }
        public IActionResult Index(int? Konuid)
        {
            if (Konuid.HasValue)
            {
                ViewBag.konuid = (int)Konuid;
            }
            else
            {
                ViewBag.konuid = Konuid;
            }
            
            return View();

        }
    }
}
