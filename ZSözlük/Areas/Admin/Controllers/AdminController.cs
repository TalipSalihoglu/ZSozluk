using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZSözlük.Entities;
using ZSözlük.Models;
using ZSözlük.Models.ViewModel;
using ZSözlük.Services;

namespace ZSözlük.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IIcerikService _ıcerikService;
        private readonly IKonuService _konuService;
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminController(IIcerikService ıcerikService, IKonuService konuService, UserManager<ApplicationUser> userManager)
        {
            _ıcerikService = ıcerikService;
            _userManager = userManager;
            _konuService = konuService;
        }
        public IActionResult Index()
        {       
            return View();
        }
        public async Task<IActionResult> DeleteIcerik(int id)
        {
            var icerik = await _ıcerikService.GetIcerikById(id);
            await _ıcerikService.DeleteIcerik(icerik);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> IcerikList(int pageNumber = 1)
        {
            ViewBag.icerikList = true;
            var list = await _ıcerikService.GetAllIcerik();
            return View(await PaginatedListModel<Icerik>.CreateAsync(list, pageNumber, 10));
        }
        public IActionResult UserList()
        {
            var list = _userManager.Users.ToList();
            return View(list);
        }
        public async Task<IActionResult> KonuList() 
        {
           var list =await _konuService.GetAllKonu();
            return View(list);
        }
        public async Task<IActionResult> KonuListbyid(int id,int pageNumber=1)
        {
            ViewBag.icerikList = false;
            var list = await _ıcerikService.GetIcerikByKonuId(id);
            return View("IcerikList",await PaginatedListModel<Icerik>.CreateAsync(list, pageNumber, 10));
        }
    }
}
