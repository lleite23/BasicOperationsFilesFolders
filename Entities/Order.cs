using System.Globalization;

namespace FileFolders.Entities
{
    class Order
    {
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int Quantity { get; set; }

        public Order() { }

        public Order(string productName, double productPrice, int quantity)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            Quantity = quantity;
        }

        public double SubTotal(double price, int quantity)
        {
            return price * quantity;
        }
    }
}
