using Company.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.PortalWWW.Controllers.Components;

public class CategoriesComponent(CompanyContext context, ILogger<CategoriesComponent> logger) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        try
        {
            logger.LogInformation("Start CategoriesComponent");
            return View("CategoriesComponent", await context.Category.AsNoTracking().ToListAsync());
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error in CategoriesComponent");
            throw;
        }
    }
}