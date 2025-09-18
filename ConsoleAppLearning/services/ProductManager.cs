using ConsoleAppLearning.models;

namespace ConsoleAppLearning.services;

public class ProductManager : IProductManager
{
    private static List<Product> products = new List<Product>();

    public bool AddProduct(Product product)
    {
        if (product == null)
            return false;
        products.Add(product);
        return true;
    }

    public Product UpdateStock(Product productTobeUpdated, Product product)
    {
        products.Remove(productTobeUpdated);
        products.Add(product);
        return product;
    }

    public List<Product> ViewProducts()
    {
        return products;
    }

    public bool RemoveProduct(Product product)
    {
        products.Remove(product);
        return true;
    }
}