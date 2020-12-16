using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ZSözlük.Entities;
using ZSözlük.Models.ViewModel;
using ZSözlük.Services;

namespace ZSözlük.ViewComponents
{
    public class IcerikListByUser : ViewComponent
    {
        private readonly IIcerikService _icerikService;
        public IcerikListByUser(IIcerikService icerikService)
        {
            _icerikService = icerikService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string Userid, int pageNumber,bool MyPage=false)
        {
            ViewBag.MyPage = MyPage;
            ViewBag.userid = Userid;
            var list = await _icerikService.GetIcerikByUserId(Userid);
            return View(await PaginatedListModel<Icerik>.CreateAsync(list, pageNumber, 5));
        }
     }
}
