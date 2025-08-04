namespace ConsoleAppLearning.models;

public class Product
{
    private string name {set; get; }
    private decimal price { set; get; }
    private int stock {set; get; }
    
    public Product(string name, decimal price, int stock)
    {
        this.name = name;
        this.price = price;
        this.stock = stock;
    }
    
}