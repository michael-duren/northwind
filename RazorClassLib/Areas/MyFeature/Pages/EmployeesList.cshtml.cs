using DataContext;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorClassLib.Areas.MyFeature.Pages;

public class EmployeesListModel : PageModel
{
    private readonly NorthwindContext _context;

    public EmployeesListModel(NorthwindContext context)
    {
        _context = context;
    }

    public Employee[] Employees { get; set; } = null!;

    public void OnGet()
    {
        ViewData["Title"] = "Northwind B2B - Employees";

        Employees = _context.Employees.OrderBy(e => e.LastName)
            .ThenBy(e => e.FirstName).ToArray();
    }
}