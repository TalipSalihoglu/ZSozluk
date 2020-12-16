using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using ZSözlük.Entities;
using ZSözlük.Models;
using ZSözlük.Services;

namespace ZSözlük.Controllers
{
    public class SozlukController : Controller
    {
        private readonly IIcerikService _icerikService;
        private readonly IKonuService _konuService;
        private readonly UserManager<ApplicationUser> _userManager;

        public SozlukController(IIcerikService icerikService, IKonuService konuService, UserManager<ApplicationUser> userManager)
        {
            _icerikService = icerikService;
            _konuService = konuService;
            _userManager = userManager;
        }
        public IActionResult Index(int? Konuid, int pageNumber = 1)
        {
            if (Konuid.HasValue)
            {
                ViewBag.konuid = (int)Konuid;
            }
            else
            {
                ViewBag.konuid = Konuid;
            }
            ViewBag.pageNumber = pageNumber;
            return View();

        }
        [Authorize]
        [HttpGet]
        public IActionResult IcerikEkle()
        {
            var icerik = new Icerik();
            return View("Index", icerik);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> IcerikEkle(Icerik model)
        {
            ViewBag.konuid = model.KonuID;
            if (ModelState.IsValid)
            {
                Icerik yeniicerik = new Icerik();
                yeniicerik.IcerikFull = model.IcerikFull;
                yeniicerik.KonuID = model.KonuID;
                yeniicerik.IcerikTarih = DateTime.Now;
                yeniicerik.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                yeniicerik.UserName = User.FindFirstValue(ClaimTypes.Name);
                await _icerikService.CreateIcerik(yeniicerik);
                return RedirectToAction("Index");
            }
            return View("Index", model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult KonuEkle()
        {
            var konu = new Konu();
            return PartialView("KonuEkle", konu);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> KonuEkle(Konu model)
        {
            if (ModelState.IsValid)
            {
                Konu yeniKonu = new Konu();
                yeniKonu.KonuBaslık = model.KonuBaslık;
                await _konuService.CreateKonu(model);
                return RedirectToAction("Index");
            }
            return PartialView("KonuEkle", model);
        }

        [Authorize]
        public async Task<IActionResult> UserDetail(string Userid, int pageNumber = 1)
        {
            var User = await _userManager.FindByIdAsync(Userid);
            ViewBag.pageNumber = pageNumber;
            var list = await _icerikService.GetIcerikByUserId(Userid);
            ViewBag.count = list.Count;
            return View(User);
        }
           
        public async Task<IActionResult> MyProfile(int pageNumber = 1)
        {
            ViewBag.pageNumber = pageNumber;
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            return View(applicationUser);
        }
    }
}
