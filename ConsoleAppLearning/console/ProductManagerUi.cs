namespace ConsoleAppLearning.console;
using ConsoleAppLearning.services;
using ConsoleAppLearning.models;

public class ProductManagerUI
{
    private static readonly ProductManager _productManager = new ProductManager();

    public static void EntryPoint()
    {
        bool continueRunning = true;

        while (continueRunning)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewProduct();
                    break;
                case "2":
                    UpdateProductStock();
                    break;
                case "3":
                    ViewAllProducts();
                    break;
                case "4":
                    RemoveProduct();
                    break;
                case "5":
                    continueRunning = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("=== Product Management System ===");
        Console.WriteLine("1. Add new product");
        Console.WriteLine("2. Update stock");
        Console.WriteLine("3. View all products");
        Console.WriteLine("4. Remove product");
        Console.WriteLine("5. Exit");
        Console.Write("\nEnter your choice (1-5): ");
    }

    private static void AddNewProduct()
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();

        Console.Write("Enter price: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            Console.WriteLine("Invalid price format.");
            return;
        }

        Console.Write("Enter quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity))
        {
            Console.WriteLine("Invalid quantity format.");
            return;
        }

        var product = new Product(
            name,
             price,
           quantity
        );

        if (_productManager.AddProduct(product))
        {
            Console.WriteLine("Product added successfully!");
        }
        else
        {
            Console.WriteLine("Failed to add product.");
        }
    }

    private static void UpdateProductStock()
    {
        var products = _productManager.ViewProducts();
        if (!products.Any())
        {
            Console.WriteLine("No products available to update.");
            return;
        }

        Console.WriteLine("\nCurrent Products:");
        foreach (var product in products)
        {
            Console.WriteLine($"Name: {product.Name}, Current Stock: {product.Quantity}");
        }

        Console.Write("\nEnter product name to update: ");
        string name = Console.ReadLine();

        var productToUpdate = products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (productToUpdate == null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        Console.Write("Enter new quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int newQuantity))
        {
            Console.WriteLine("Invalid quantity format.");
            return;
        }

        var updatedProduct = new Product
        {
            Name = productToUpdate.Name,
            Price = productToUpdate.Price,
            Quantity = newQuantity
        };

        _productManager.UpdateStock(productToUpdate, updatedProduct);
        Console.WriteLine("Stock updated successfully!");
    }

    private static void ViewAllProducts()
    {
        var products = _productManager.ViewProducts();
        if (!products.Any())
        {
            Console.WriteLine("No products in inventory.");
            return;
        }

        Console.WriteLine("\nCurrent Inventory:");
        Console.WriteLine("------------------");
        foreach (var product in products)
        {
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Price: ${product.Price}");
            Console.WriteLine($"Stock: {product.Quantity}");
            Console.WriteLine("------------------");
        }
    }

    private static void RemoveProduct()
    {
        var products = _productManager.ViewProducts();
        if (!products.Any())
        {
            Console.WriteLine("No products available to remove.");
            return;
        }

        Console.WriteLine("\nCurrent Products:");
        foreach (var product in products)
        {
            Console.WriteLine($"Name: {product.Name}");
        }

        Console.Write("\nEnter product name to remove: ");
        string name = Console.ReadLine();

        var productToRemove = products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (productToRemove == null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        if (_productManager.RemoveProduct(productToRemove))
        {
            Console.WriteLine("Product removed successfully!");
        }
        else
        {
            Console.WriteLine("Failed to remove product.");
        }
    }
}

