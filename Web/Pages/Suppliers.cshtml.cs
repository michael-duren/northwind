using DataContext;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages;

public class SuppliersModel : PageModel
{
    private readonly NorthwindContext _context;
    
    public IEnumerable<Supplier>? Suppliers { get; set; }
    [BindProperty]
    public Supplier? Supplier { get; set; }

    public SuppliersModel(NorthwindContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Northwind B2B - Suppliers";

        Suppliers =  _context.Suppliers.OrderBy(c => c.Country).ThenBy(c => c.CompanyName);
    }

    public IActionResult OnPost()
    {
        if (Supplier is not null && ModelState.IsValid)
        {
            _context.Suppliers.Add(Supplier);
            _context.SaveChanges();
            return RedirectToPage("/Suppliers");
        }
        else
        {
            return Page();
        }
    }
}