using FootMark.Services.Interfaces.Users;
using FootMark.Web.Areas.Admin.Helper;
using FootMark.Web.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootMark.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
 
        public UsersController(IUserService userService)
        {
            _userService = userService;         
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetAllAsync());
        }

        // GET: UserController/Details/5
        [HttpGet]
        public async Task <IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: UserController/Create
        public ActionResult CreateUser()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser([Bind("FirstName,LastName,UserName")] UserDto user)
        {

            if (ModelState.IsValid)
            {
                await _userService.AddAsync(user);

                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(UserDto user)
        {
          
            if (ModelState.IsValid)
            {
                await _userService.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        [HttpGet, ActionName("Delete")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
     
    }

}
