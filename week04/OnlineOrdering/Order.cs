using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public double CalculateTotalCost()
        {
            double total = 0;
            
            foreach (Product product in _products)
            {
                total += product.GetTotalCost();
            }

            // Add shipping cost
            total += _customer.IsInUSA() ? 5 : 35;
            
            return total;
        }

        public string GetPackingLabel()
        {
            string packingLabel = "PACKING LABEL\n";
            packingLabel += "=====================\n";
            
            foreach (Product product in _products)
            {
                packingLabel += $"Product: {product.Name}\n";
                packingLabel += $"ID: {product.ProductId}\n";
                packingLabel += "-----------------\n";
            }
            
            return packingLabel;
        }

        public string GetShippingLabel()
        {
            string shippingLabel = "SHIPPING LABEL\n";
            shippingLabel += "=====================\n";
            shippingLabel += $"Customer: {_customer.Name}\n";
            shippingLabel += $"{_customer.Address.GetFullAddress()}\n";
            
            return shippingLabel;
        }
    }
}