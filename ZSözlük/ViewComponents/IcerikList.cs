using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZSözlük.Entities;
using ZSözlük.Models.ViewModel;
using ZSözlük.Services;

namespace ZSözlük.ViewComponents
{
    public class IcerikList :ViewComponent
    {
        private readonly IIcerikService _icerikService;
        public IcerikList(IIcerikService icerikService)
        {
            _icerikService = icerikService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? KonuId,int pageNumber)
        {   
            if (KonuId.HasValue)
            {
                //var listwithid = _icerikRepository.GetirİcerikIdile((int)KonuId);
                var listwithid = await _icerikService.GetIcerikByKonuId((int)KonuId);
                return View(await PaginatedListModel<Icerik>.CreateAsync(listwithid, pageNumber, 5));
               ////return View(resultidile);
            }
            //var list =  _icerikRepository.GetirİcerikHepsi();//Await 
            var list = await _icerikService.GetAllIcerik();
            return View(await PaginatedListModel<Icerik>.CreateAsync(list, pageNumber, 5));
            //return View(result);
        }
    }

}
