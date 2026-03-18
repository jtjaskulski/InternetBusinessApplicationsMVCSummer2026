using Company.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.PortalWWW.Controllers
{
    public class ShopController(ILogger<ShopController> _logger, CompanyContext _context) : Controller
    {
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                var firstType = await _context.Category.FirstOrDefaultAsync();
                if (firstType == null)
                {
                    return NotFound();
                }
                id = firstType.IdCategory;
            }
            return View(await _context.Product.Where(t => t.IdCategory == id).ToListAsync());
        }
    }
}