using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZSözlük.Services;

namespace ZSözlük.ViewComponents
{
    public class KonuList : ViewComponent
    {
        private readonly IKonuService _konuService;
        public KonuList(IKonuService konuService)
        {
            _konuService = konuService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var result = await _konuRepository.GetirHepsiKonu();
            var result = await _konuService.GetAllKonu();
            return View(result);
        }
    }
}
