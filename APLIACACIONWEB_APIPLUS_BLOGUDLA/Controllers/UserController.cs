using APLIACACIONWEB_APIPLUS_BLOGUDLA.Models;
using APLIACACIONWEB_APIPLUS_BLOGUDLA.Services;
using Microsoft.AspNetCore.Mvc;

namespace APLIACACIONWEB_APIPLUS_BLOGUDLA.Controllers
{
    public class UserController : Controller
    {
        private readonly ApiService _apiService;

        public UserController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _apiService.GetAsync<IEnumerable<User>>("users");
            return View(users);
        }

        public async Task<IActionResult> Details(string username)
        {
            var user = await _apiService.GetAsync<User>($"users/{username}");
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync("users", user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(string username)
        {
            var user = await _apiService.GetAsync<User>($"users/{username}");
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string username, User user)
        {
            if (username != user.Username)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync($"users/{username}", user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(string username)
        {
            var user = await _apiService.GetAsync<User>($"users/{username}");
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string username)
        {
            await _apiService.DeleteAsync($"users/{username}");
            return RedirectToAction(nameof(Index));
        }
    }
}
