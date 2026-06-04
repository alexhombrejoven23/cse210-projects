class Program
{
    static void Main(string[] args)
    {
        Address addr1 = new Address("123 Main St", "Dallas", "TX", "USA");
        Customer cust1 = new Customer("John Smith", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Wireless Mouse", "WM-001", 29.99, 2));
        order1.AddProduct(new Product("USB Hub", "UH-202", 15.50, 1));
        order1.AddProduct(new Product("Keyboard", "KB-305", 45.00, 1));

        Address addr2 = new Address("456 Elm Ave", "Toronto", "Ontario", "Canada");
        Customer cust2 = new Customer("Maria Lopez", addr2);
        Order order2 = new Order(cust2);
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