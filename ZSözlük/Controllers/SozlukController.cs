using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using ZSözlük.Entities;
using ZSözlük.Services;

namespace ZSözlük.Controllers
{
    public class SozlukController : Controller
    {
        //private readonly KonuRepository _konuRepository;
        //private readonly IcerikRepository _icerikRepository;       
        private readonly IIcerikService _icerikService;       
        private readonly IKonuService _konuService;       

        public SozlukController( IIcerikService icerikService, IKonuService konuService)//KonuRepository konuRepository,IcerikRepository icerikRepository,
        {
           // _konuRepository = konuRepository;
           // _icerikRepository = icerikRepository;
            _icerikService = icerikService;
            _konuService = konuService;
        }
        public IActionResult Index(int? Konuid,int pageNumber=1)
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
            return View("Index",icerik);
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
                yeniicerik.IcerikTarih =DateTime.Now;
                yeniicerik.UserID= User.FindFirstValue(ClaimTypes.NameIdentifier);
                yeniicerik.UserName = User.FindFirstValue(ClaimTypes.Name);
                //_icerikRepository.Ekle(model);
                await _icerikService.CreateIcerik(yeniicerik);
                return RedirectToAction("Index");
            }
            return View("Index",model);
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
                //_konuRepository.Ekle(yeniKonu);
                await _konuService.CreateKonu(model);
                return RedirectToAction("Index");
            }
            return PartialView("KonuEkle", model);           
        }
    }
}
