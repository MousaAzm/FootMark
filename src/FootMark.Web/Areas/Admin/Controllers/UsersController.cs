using FootMark.Application.Interfaces;
using FootMark.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FootMark.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: UserController/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetAllAsync());
        }

        // GET: UserController/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var userViewModel = await _userService.GetByIdAsync(id.Value);

            if (userViewModel == null) return NotFound();

            return View(userViewModel);
        }

        // GET: UserController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel user)
        {

            if (!ModelState.IsValid) return View(user);

            if (ResponseHasErrors(await _userService.AddAsync(user)))
                return View(user);

            ViewBag.Sucesso = "User Registered!";

            return View(user);
        }

        // GET: UserController/Edit/3
        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var user = await _userService.GetByIdAsync(id.Value);

            if (user == null) return NotFound();

            return View(user);
        }

        // POST: UserController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserViewModel user)
        {

            if (!ModelState.IsValid) return NotFound();

            if (ResponseHasErrors(await _userService.UpdateAsync(user)))
                return RedirectToAction(nameof(Index));

            ViewBag.Sucesso = "User Updated!";

            return RedirectToAction(nameof(Index));
        }

        // GET: UserController/Delete/3
        [HttpGet, ActionName("Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var user = await _userService.GetByIdAsync(id.Value);

            if (user == null) return NotFound();

            return View(user);
        }

        // Post: UserController/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (ResponseHasErrors(await _userService.RemoveAsync(id)))
                return View(await _userService.GetByIdAsync(id));

            ViewBag.Sucesso = "User Removed!";

            return RedirectToAction(nameof(Index));
        }

    }

}
