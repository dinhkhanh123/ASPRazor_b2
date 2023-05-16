using System.Collections.Generic;
using System.Linq;

public class ProductService
{
    private List<Product> products = new List<Product>();

    public ProductService()
    {
        LoadProducts();
    }
    public Product Find(int id)
    {
        var qr = from p in products
                 where p.Id == id
                 select p;
        return qr.FirstOrDefault();
    }

    public List<Product> AllProduct() => products;

    public void LoadProducts()
    {
        products.Clear();

        products.Add(new Product()
        {
            Id = 1,
            Name = "Product 1",
            Description = "Product 1 Description",
            Price = 900
        });
        products.Add(new Product()
        {
            Id = 2,
            Name = "Product 2",
            Description = "Product 2 Description",
            Price = 800
        });
        products.Add(new Product()
        {
            Id = 3,
            Name = "Product 3",
            Description = "Product 3 Description",
            Price = 700
        });
    }
}