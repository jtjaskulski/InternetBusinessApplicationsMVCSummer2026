using Company.Data.Data;
using Company.Data.Data.Shop;
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
        public async Task<IActionResult> Discounts() 
            => View(await _context.Product.Where(t => t.IsDiscount).ToListAsync());

        public async Task<IActionResult> Details(int? id) 
        {
            Product? item = null;
            if (_context?.Product?.Any() == true)
            {
                id ??= (await _context.Product.FirstOrDefaultAsync())?.IdProduct;
                item = await _context
                    .Product
                    .Include(p => p.Category)
                    .FirstOrDefaultAsync(p => p.IdProduct == id);
            }
            return View(item);
        }
    }
}