internal class Program
{
    private static void Main(string[] args)
    {
        string? Name;
        double UPC;
        decimal price;

        Console.WriteLine("Enter Name of Product");
        Name = Console.ReadLine();

        Console.WriteLine("Enter UPC");
        UPC = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter Price");
        price = Decimal.Parse(Console.ReadLine());

        var priceAfterTax = CalculateTax(price);
        PrintTaxMessage(Name, price, priceAfterTax);


    }
    private static decimal CalculateTax(decimal beforeTaxPrice)
    {
        return beforeTaxPrice + (Decimal.Multiply(beforeTaxPrice, (decimal)0.20));
    }

    private static void PrintTaxMessage(string Name, decimal price, decimal priceAfterTax)
    {
        Console.WriteLine($"Product {Name} reported as ${price} before tax and ${priceAfterTax.ToString("#.##")} after 20% tax.");
    }
}