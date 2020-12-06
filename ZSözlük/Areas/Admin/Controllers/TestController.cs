using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZSözlük.Entities;
using ZSözlük.IRepositories;
using ZSözlük.Models.ViewModel;
using ZSözlük.Services;

namespace ZSözlük.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIcerikService _ıcerikService;
        public TestController(IUnitOfWork unitOfWork, IIcerikService ıcerikService)
        {
            _unitOfWork = unitOfWork;
            _ıcerikService = ıcerikService;
        }
        public async Task<IActionResult> Index(int pageNumber=1)
        {
            var list =await _unitOfWork.Icerikler.GetAllAsync();
            return View(await PaginatedListModel<Icerik>.CreateAsync(list, pageNumber, 10));
        }
        public async Task<IActionResult> Delete(int id)
        {
            //var entity=await _unitOfWork.Icerikler.GetByIdAsync(id);
            //_unitOfWork.Icerikler.Remove(entity);
            //await _unitOfWork.CommitAsync();

            var entity = await _ıcerikService.GetIcerikById(id);
            await _ıcerikService.DeleteIcerik(entity);

            return RedirectToAction("Index");
        }
    }
}
