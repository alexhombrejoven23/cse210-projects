using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Online Ordering System");
            Console.WriteLine("======================\n");

            Address address1 = new Address("123 Main St", "New York", "NY", "USA");
            Address address2 = new Address("456 Oak Ave", "Toronto", "Ontario", "Canada");
            Address address3 = new Address("789 Pine Rd", "Los Angeles", "CA", "USA");

            Customer customer1 = new Customer("John Smith", address1);
            Customer customer2 = new Customer("Maria Garcia", address2);
            Customer customer3 = new Customer("David Johnson", address3);

            Product product1 = new Product("Laptop", "P001", 899.99, 1);
            Product product2 = new Product("Mouse", "P002", 25.50, 2);
            Product product3 = new Product("Keyboard", "P003", 49.99, 1);
            Product product4 = new Product("Monitor", "P004", 199.99, 1);
            Product product5 = new Product("USB Cable", "P005", 9.99, 3);
            Product product6 = new Product("Headphones", "P006", 79.99, 1);

            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);
            order1.AddProduct(product5);

            Order order2 = new Order(customer2);
            order2.AddProduct(product3);
            order2.AddProduct(product4);
            order2.AddProduct(product6);

            Order order3 = new Order(customer3);
            order3.AddProduct(product1);
            order3.AddProduct(product6);
            order3.AddProduct(product2);
            order3.AddProduct(product5);

            DisplayOrderDetails(order1);
            DisplayOrderDetails(order2);
            DisplayOrderDetails(order3);
        }

        static void DisplayOrderDetails(Order order)
        {
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine($"Total Cost: ${order.CalculateTotalCost():F2}");
            Console.WriteLine("===========================================\n");
        }
    }
}