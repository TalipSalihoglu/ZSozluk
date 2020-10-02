using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZSözlük.Entities;
using ZSözlük.Repository;

namespace ZSözlük.Controllers
{
    public class SozlukController : Controller
    {
        private readonly KonuRepository _konuRepository;
        private readonly IcerikRepository _icerikRepository;
        public SozlukController(KonuRepository konuRepository,IcerikRepository icerikRepository)
        {
            _konuRepository = konuRepository;
            _icerikRepository = icerikRepository;
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
        public IActionResult IcerikEkle(Icerik model)
        {
            if (ModelState.IsValid)
            {
                Icerik yeniicerik = new Icerik();
                yeniicerik.IcerikFull = model.IcerikFull;
                yeniicerik.KonuID = model.KonuID;
                _icerikRepository.Ekle(model);
                return RedirectToAction("Index");
            }
            return View("Index",model);
        }
        public IActionResult KonuEkle(Konu model)
        {
            if (ModelState.IsValid)
            {
                Konu yeniKonu = new Konu();
                yeniKonu.KonuBaslık = model.KonuBaslık;
                _konuRepository.Ekle(yeniKonu);
                return RedirectToAction("Index");
            }
            return View("Index", model);
        }
    }
}
