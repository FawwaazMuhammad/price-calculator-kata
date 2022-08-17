internal class Program
{
    private static void Main(string[] args)
    {
        string? Name;
        int UPC;
        decimal price;
        decimal tax;
        decimal discount;

        Console.WriteLine("Enter Name of Product");
        Name = Console.ReadLine();

        Console.WriteLine("Enter UPC");
        UPC = Int16.Parse(Console.ReadLine());

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

        var  upcDiscount = UPCDiscount(UPC);
        if(upcDiscount != Decimal.Zero){
            var upcDiscountAmount = price*upcDiscount;
            var totalPriceAfterUpcDiscount = totalPrice - upcDiscountAmount;
            PrintTaxMessageWithUpcDiscount(Name,UPC, price, totalPriceAfterUpcDiscount,tax,discount,taxAmount,discountAmount,upcDiscountAmount,upcDiscount);
        }
        else{
        PrintTaxMessageWithDiscount(Name,UPC, price, totalPrice,tax,discount,taxAmount,discountAmount);
       // PrintTaxMessageWithoutDiscount(Name,UPC, price, totalPrice,tax,taxAmount,priceAfterTax);
        }


    }
    private static decimal TaxAmount(decimal beforeTaxPrice, decimal tax) =>
          (Decimal.Multiply(beforeTaxPrice, (tax/100)));
   
    private static decimal UPCDiscount(int upc) => upc switch
        {
            12324 => (decimal)0.07,
            777 => (decimal)0.20,
            _ => Decimal.Zero
        };
    

    private static void PrintTaxMessageWithDiscount(string Name,double upc, decimal price, decimal totalPrice,decimal tax,decimal discount,decimal taxAmount,decimal discountAmount)
    {
        Console.WriteLine("case 1 \n");
        Console.WriteLine("With Discount");
        Console.WriteLine($"Sample Product:  {Name}, UPC : {upc} reported as ${price} \n");
        Console.WriteLine($"Tax: {tax}%,Discount: {discount}");
        Console.WriteLine($"Tax amount = ${taxAmount.ToString("#.##")}; Discount amount = ${discountAmount.ToString("#.##")}");
        Console.WriteLine($"Price before = ${price.ToString("#.##")}, price after = ${totalPrice.ToString("#.##")}");
    }
    private static void PrintTaxMessageWithoutDiscount(string Name,double upc, decimal price, decimal totalPrice,decimal tax,decimal taxAmount,decimal priceAfterTax)
    {
        Console.WriteLine("case 2 \n");
        Console.WriteLine("Without Discount");
        Console.WriteLine($"Sample Product:  {Name}, UPC : {upc} reported as ${price} \n");
        Console.WriteLine($"Tax: {tax}%,No Discount");
        Console.WriteLine($"Tax amount = ${taxAmount.ToString("#.##")}; No Discount");
        Console.WriteLine($"Price before = ${price.ToString("#.##")}, price after = ${priceAfterTax.ToString("#.##")}");
    }

    private static void PrintTaxMessageWithUpcDiscount(string Name,double upc, decimal price, decimal totalPrice,decimal tax,decimal discount,decimal taxAmount,decimal discountAmount,decimal upcDiscountAmount,decimal upcDiscount)
    {
        Console.WriteLine("case 1 \n");
        Console.WriteLine("With Universal Discount and UPC discount");
        Console.WriteLine($"Sample Product:  {Name}, UPC : {upc} reported as ${price} \n");
        Console.WriteLine($"Tax: {tax}%,Discount: {discount}%, UPC Discount: {upcDiscount}%");
        Console.WriteLine($"Tax amount = ${taxAmount.ToString("#.##")}; Discount amount = ${discountAmount.ToString("#.##")}; UPC amount = ${upcDiscountAmount.ToString("#.##")}");
        Console.WriteLine($"Price before = ${price.ToString("#.##")}, price after = ${totalPrice.ToString("#.##")}");
    }
    
    private static decimal DiscountAmount(decimal priceAfterTax, decimal discountAmount)
    {
        return  (Decimal.Multiply(priceAfterTax, (discountAmount/100)));
    }
}