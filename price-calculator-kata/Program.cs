internal class Program
{
    private static void Main(string[] args)
    {
        string? Name;
        double UPC;
        decimal price;
        decimal tax;
        decimal discount;

        Console.WriteLine("Enter Name of Product");
        Name = Console.ReadLine();

        Console.WriteLine("Enter UPC");
        UPC = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter Price");
        price = Decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter Tax amount  in %");
        tax = Decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter Discount amount  in %");
        discount= Decimal.Parse(Console.ReadLine());

        var taxAmount = TaxAmount(price,tax);
        
        var priceAfterTax = price + taxAmount;
        var discountAmount = DiscountAmount(price,discount);
        var totalPrice = priceAfterTax - discountAmount;
        PrintTaxMessage(Name,UPC, price, totalPrice,tax,discount,taxAmount,discountAmount);


    }
    private static decimal TaxAmount(decimal beforeTaxPrice, decimal tax)
    {
        return  (Decimal.Multiply(beforeTaxPrice, (tax/100)));
    }
   

    private static void PrintTaxMessage(string Name,double upc, decimal price, decimal totalPrice,decimal tax,decimal discount,decimal taxAmount,decimal discountAmount)
    {
        Console.WriteLine($"Sample Product:  {Name}, UPC : {upc} reported as ${price} \n");
        Console.WriteLine($"Tax: {tax}%,Discount: {discount}");
        Console.WriteLine($"Tax amount = ${taxAmount.ToString("#.##")}; Discount amount = ${discountAmount.ToString("#.##")}");
        Console.WriteLine($"Price before = ${price.ToString("#.##")}, price after = ${totalPrice.ToString("#.##")}");
    }
    private static decimal DiscountAmount(decimal priceAfterTax, decimal discountAmount)
    {
        return  (Decimal.Multiply(priceAfterTax, (discountAmount/100)));
    }
}