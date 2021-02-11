using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZSözlük.IRepositories;
using ZSözlük.IServices;
using ZSözlük.Models;

namespace ZSözlük.Controllers
{
    public class LikeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILikeService _likeService;
        public LikeController(UserManager<ApplicationUser> userManager, ILikeService likeService)
        {
            _userManager = userManager;
            _likeService= likeService;
        }

        [Authorize]
        public async Task<IActionResult> Like(int id, int? Konuid, string PageUserid, int pageNumber = 1)
        {
            string user_id = _userManager.GetUserId(User);
            await _likeService.Like(id, user_id);
            if(PageUserid != null)
            {
                return RedirectToAction("UserDetail", "Sozluk", new { Userid=PageUserid, pageNumber });
            }
            return RedirectToAction("Index", "Sozluk", new { Konuid, pageNumber });
        }

        [Authorize]
        public async Task<IActionResult> CancelLike(int id, int? Konuid, string PageUserid, int pageNumber = 1)
        {
            string UserId = _userManager.GetUserId(User);
            await _likeService.CancelLike(id, UserId);
            if (PageUserid != null)
            {
                return RedirectToAction("UserDetail", "Sozluk", new { Userid = PageUserid, pageNumber });
            }
            return RedirectToAction("Index", "Sozluk", new { Konuid, pageNumber });
        }
    }
}
