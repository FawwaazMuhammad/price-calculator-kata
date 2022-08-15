internal class Program
{
    private static void Main(string[] args)
    {
        string Name;
        double UPC;
        decimal price;

        Console.WriteLine("Enter Name of Product");
        Name = Console.ReadLine();

        Console.WriteLine("Enter UPC");
        UPC = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter Price");
        price = Decimal.Parse(Console.ReadLine());
        
        var priceAfterTax = price+(Decimal.Multiply(price,(decimal)0.20));
        Console.WriteLine($"Product {Name} reported as ${price} before tax and ${priceAfterTax.ToString("#.##")} after 20% tax.");
    }
}