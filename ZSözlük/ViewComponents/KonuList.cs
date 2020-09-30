using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZSözlük.Repository;
using ZSözlük.Entities;

namespace ZSözlük.ViewComponents
{
    public class KonuList : ViewComponent
    {
        private readonly KonuRepository _konuRepository;
        public KonuList(KonuRepository konuRepository)
        {
            _konuRepository = konuRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _konuRepository.GetirHepsiKonu();
            return View(result);
        }
    }
}
