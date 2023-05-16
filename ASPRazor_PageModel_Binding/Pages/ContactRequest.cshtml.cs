using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

public class ContactRequest : PageModel
{
    [BindProperty]
    public UserContact userContact { set; get; }

    private readonly ILogger<ContactRequest> _logger;
    public ContactRequest(ILogger<ContactRequest> logger)
    {
        _logger = logger;
        _logger.LogInformation("ContactRequest is created");
    }
    public double Tong(double a, double b)
    {
        return a + b;
    }
}