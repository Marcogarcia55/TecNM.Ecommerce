using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tecnm.Eccomerce.WebSite.Pages.ProductCategory;


public class ListModel : PageModel
{
    public string Name { get; set; }

    public ListModel()
    {
        Name = "SIIII";
    }
    public void OnGet()
    {
        
    }
}