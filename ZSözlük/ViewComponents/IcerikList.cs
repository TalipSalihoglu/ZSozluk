using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IViewComponentResult> InvokeAsync(int? KonuId)
        {       
            if (KonuId.HasValue)
            {
                var resultidile = await _icerikRepository.GetirİcerikIdile((int)KonuId);
                return View(resultidile);
            }
            var result = await _icerikRepository.GetirİcerikHepsi();
            return View(result);
        }
    }

}
