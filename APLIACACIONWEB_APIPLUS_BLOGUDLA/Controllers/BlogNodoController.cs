using APLIACACIONWEB_APIPLUS_BLOGUDLA.Models;
using APLIACACIONWEB_APIPLUS_BLOGUDLA.Services;
using Microsoft.AspNetCore.Mvc;

namespace APLIACACIONWEB_APIPLUS_BLOGUDLA.Controllers
{
    public class BlogNodoController : Controller
    {
        private readonly ApiService _apiService;

        public BlogNodoController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _apiService.GetAsync<IEnumerable<BlogNodo>>("nodo/blogs");
            return View(blogs);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var blog = await _apiService.GetAsync<BlogNodo>($"nodo/blogs/{id}");
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogNodo blog)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync("nodo/blogs", blog);
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var blog = await _apiService.GetAsync<BlogNodo>($"nodo/blogs/{id}");
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, BlogNodo blog)
        {
            if (id != blog.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync($"nodo/blogs/{id}", blog);
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var blog = await _apiService.GetAsync<BlogNodo>($"nodo/blogs/{id}");
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _apiService.DeleteAsync($"nodo/blogs/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
