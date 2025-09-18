using ConsoleAppLearning.models;

namespace ConsoleAppLearning.services;

/*
   Some key features include:
       - Add new products with name, price, and stock quantity.
       - Update stock when products are sold or restocked.
       - View all products and their stock levels.
       - Remove products from inventory.
 */

public interface IProductManager
{
    bool AddProduct(Product product);
    Product UpdateStock(Product productToBeUpdated, Product product);
    List<Product> ViewProducts();
    bool RemoveProduct(Product product);
}