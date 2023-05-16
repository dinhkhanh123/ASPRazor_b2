using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ASPRazor_PageModel_Binding
{
    public class ProductPageModel : PageModel
    {
        private readonly ILogger<ProductPageModel> _logger;

        public readonly ProductService productService;
        public ProductPageModel(ILogger<ProductPageModel> logger, ProductService _productService)
        {
            _logger = logger;
            productService = _productService;

        }

        public Product product { set; get; }


        //OnGet,OnPost
        public void OnGet(int? id)
        {
            if (id != null)
            {


                product = productService.Find(id.Value);
            }
            else
            {
                ViewData["Title"] = $"danh sach san pham";
            }

        }
        ///product/{id:int?}?handler=lastproduct
        public IActionResult OnGetLastProduct()
        {
            ViewData["Title"] = $"danh sach san pham cuoi";
            product = productService.AllProduct().LastOrDefault();
            if (product != null)
            {

                return Page();
            }
            else
            {
                return this.Content("Khong tim thay san pham");
            }
        }
        public IActionResult OnGetRemoveAll()
        {
            productService.AllProduct().Clear();
            return RedirectToPage("ProductPage");
        }
        public IActionResult OnGetLoad()
        {
            productService.LoadProducts();
            return RedirectToPage("ProductPage");
        }

        public IActionResult OnPostDelete(int? id)
        {
            if (id != null)
            {
                product = productService.Find(id.Value);
                if (product != null)
                {
                    productService.AllProduct().Remove(product);
                }
            }

            return RedirectToPage("ProductPage", new { id = string.Empty });
        }
    }
}
