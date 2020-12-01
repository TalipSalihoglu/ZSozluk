using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZSözlük.Entities;
using ZSözlük.Models.ViewModel;
using ZSözlük.Repository;

namespace ZSözlük.ViewComponents
{
    public class IcerikList :ViewComponent
    {
        private readonly IcerikRepository _icerikRepository;
        public IcerikList(IcerikRepository icerikRepository)
        {
            _icerikRepository = icerikRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? KonuId, int pageNumber)
        {       
            if (KonuId.HasValue)
            {
                var listwithid = _icerikRepository.GetirİcerikIdile((int)KonuId);
                return View(await PaginatedListModel<Icerik>.CreateAsync(listwithid, pageNumber, 5));
                //return View(resultidile);
            }
            
            var list =  _icerikRepository.GetirİcerikHepsi();//Await 
            return View(await PaginatedListModel<Icerik>.CreateAsync(list, pageNumber, 5));
            //return View(result);
        }
    }

}
