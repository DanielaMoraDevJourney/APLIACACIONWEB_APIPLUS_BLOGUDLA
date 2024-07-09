using APLIACACIONWEB_APIPLUS_BLOGUDLA.Models;
using APLIACACIONWEB_APIPLUS_BLOGUDLA.Services;
using Microsoft.AspNetCore.Mvc;

namespace APLIACACIONWEB_APIPLUS_BLOGUDLA.Controllers
{
    public class BlogFicaController : Controller
    {
            private readonly ApiService _apiService;

    public BlogFicaController(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Index()
    {
        var blogs = await _apiService.GetAsync<IEnumerable<BlogFica>>("fica/blogs");
        return View(blogs);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var blog = await _apiService.GetAsync<BlogFica>($"fica/blogs/{id}");
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
    public async Task<IActionResult> Create(BlogFica blog)
    {
        if (ModelState.IsValid)
        {
            await _apiService.PostAsync("fica/blogs", blog);
            return RedirectToAction(nameof(Index));
        }
        return View(blog);
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var blog = await _apiService.GetAsync<BlogFica>($"fica/blogs/{id}");
        if (blog == null)
        {
            return NotFound();
        }
        return View(blog);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, BlogFica blog)
    {
        if (id != blog.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            await _apiService.PutAsync($"fica/blogs/{id}", blog);
            return RedirectToAction(nameof(Index));
        }
        return View(blog);
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var blog = await _apiService.GetAsync<BlogFica>($"fica/blogs/{id}");
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
        await _apiService.DeleteAsync($"fica/blogs/{id}");
        return RedirectToAction(nameof(Index));
    }

    }
}
