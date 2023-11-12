using DataContext;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages;

public class CustomersModel : PageModel
{
    private readonly NorthwindContext _context;

    public CustomersModel(NorthwindContext context)
    {
        _context = context;
    }

    public ILookup<string?, Customer>? CustomersByCountry { get; set; } = null!;

    public void OnGet()
    {
        ViewData["Title"] = "Northwind B2B - Customers";

        CustomersByCountry = _context.Customers.ToLookup(c => c.Country);
    }
}