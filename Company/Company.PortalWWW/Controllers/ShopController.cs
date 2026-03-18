using System.Diagnostics;
using Company.Data.Data;
using Company.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.PortalWWW.Controllers
{
    public class ShopController : Controller
    {
        private ILogger<ShopController> _logger;
        private CompanyContext _context;

        public ShopController(ILogger<ShopController> logger, CompanyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index() => View();

        public IActionResult Contact() => View();

        public IActionResult About() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}