using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using LinkShortener.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace LinkShortener.Controllers
{
    public class HomeController : Controller
    {
        private readonly LinkShortenerContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(LinkShortenerContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View("~/Views/Links/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OriginalUrl")] Links link)
        {
            _logger.LogInformation("Entrando al método Create");

            if (ModelState.IsValid)
            {
                _logger.LogInformation("El modelo es válido");
                link.ShortUrl = GenerateShortUrl();
                _context.Add(link);
                await _context.SaveChangesAsync();

                ViewBag.ShortLink = link.ShortUrl;

                return RedirectToAction(nameof(ShowAllLinks));
            }

            // Log detalles de los errores de validación
            foreach (var modelState in ModelState)
            {
                foreach (var error in modelState.Value.Errors)
                {
                    _logger.LogWarning($"Error en la propiedad {modelState.Key}: {error.ErrorMessage}");
                }
            }

            _logger.LogWarning("El modelo no es válido");
            return View(link);
        }

        public async Task<IActionResult> ShowAllLinks()
        {
            var links = await _context.Links.ToListAsync();
            return View(links);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var link = await _context.Links.FindAsync(id);
            if (link == null)
            {
                return NotFound();
            }
            return View(link);
        }

        [HttpGet("/short/{shortUrl}")]
        public async Task<IActionResult> RedirectToOriginal(string shortUrl)
        {
            var link = await _context.Links.FirstOrDefaultAsync(l => l.ShortUrl == shortUrl);
            if (link == null)
            {
                return NotFound();
            }
            return Redirect(link.OriginalUrl);
        }

        private string GenerateShortUrl()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 6)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
