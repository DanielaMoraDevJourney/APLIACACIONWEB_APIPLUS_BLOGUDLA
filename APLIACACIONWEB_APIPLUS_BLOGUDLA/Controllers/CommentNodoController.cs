using APLIACACIONWEB_APIPLUS_BLOGUDLA.Models;
using APLIACACIONWEB_APIPLUS_BLOGUDLA.Services;
using Microsoft.AspNetCore.Mvc;

namespace APLIACACIONWEB_APIPLUS_BLOGUDLA.Controllers
{
    public class CommentNodoController : Controller
    {
        private readonly ApiService _apiService;

        public CommentNodoController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index(Guid blogNodoId)
        {
            var comments = await _apiService.GetAsync<IEnumerable<CommentNodo>>($"comments/nodo/byBlogNodo/{blogNodoId}");
            return View(comments);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var comment = await _apiService.GetAsync<CommentNodo>($"comments/nodo/{id}");
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        public IActionResult Create(Guid blogNodoId)
        {
            ViewBag.BlogNodoId = blogNodoId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CommentNodo comment)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync("comments/nodo", comment);
                return RedirectToAction(nameof(Index), new { blogNodoId = comment.BlogNodoId });
            }
            return View(comment);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var comment = await _apiService.GetAsync<CommentNodo>($"comments/nodo/{id}");
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CommentNodo comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _apiService.PutAsync($"comments/nodo/{id}", comment);
                return RedirectToAction(nameof(Index), new { blogNodoId = comment.BlogNodoId });
            }
            return View(comment);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var comment = await _apiService.GetAsync<CommentNodo>($"comments/nodo/{id}");
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var comment = await _apiService.GetAsync<CommentNodo>($"comments/nodo/{id}");
            if (comment != null)
            {
                await _apiService.DeleteAsync($"comments/nodo/{id}");
                return RedirectToAction(nameof(Index), new { blogNodoId = comment.BlogNodoId });
            }
            return NotFound();
        }
    }
}

