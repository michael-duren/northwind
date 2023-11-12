using DataContext;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Web.Pages;

public class CustomerOrdersModel : PageModel
{
    private readonly NorthwindContext _context;

    public CustomerOrdersModel(NorthwindContext context)
    {
        _context = context;
    }

    public Customer? Customer { get; set; } = null!;

    public void OnGet()
    {
        string? id = HttpContext.Request.Query["id"];

        Customer = _context.Customers.Include(c => c.Orders)
            .SingleOrDefault(c => c.CustomerId == id);
    }
}