using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        Address address1 = new Address("123 Main St", "Dallas", "TX", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "WM-001", 29.99, 2));
        order1.AddProduct(new Product("USB Hub", "UH-202", 15.50, 1));
        order1.AddProduct(new Product("Keyboard", "KB-305", 45.00, 1));

        Address address2 = new Address("456 Elm Ave", "Toronto", "Ontario", "Canada");
        Customer customer2 = new Customer("Maria Lopez", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Laptop Stand", "LS-101", 35.00, 1));
        order2.AddProduct(new Product("Webcam", "WC-450", 59.99, 1));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():F2}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():F2}");
    }
}