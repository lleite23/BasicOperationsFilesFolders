using FileFolders.Entities;
using FileFolders.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace FileFolders
{
    class Program
    {
        static void Main(string[] args)
        {
            string Source = @"D:\In\File1.txt";
            string OutPut = @"D:\Out\File2.txt";

            try
            {
                List<Order> order = new List<Order>();

                using (StreamReader sr =  new StreamReader(new FileStream(Source, FileMode.Open)))
                {
                    string[] lines;

                    while (!sr.EndOfStream)
                    {
                        lines = sr.ReadLine().Split(',');
                        string productName = lines[0];
                        double productPrice = double.Parse(lines[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(lines[2]);

                        order.Add(new Order(productName, productPrice, quantity));
                    }
                }

                using (StreamWriter sw = new StreamWriter(OutPut))
                {
                    double totalPrice = 0.0;

                    for (int i = 0; i <order.Count; i++)
                    {
                        double price = 0.0;
                        price = order[i].SubTotal(order[i].ProductPrice, order[i].Quantity);
                        sw.WriteLine($"Name: {order[i].ProductName}, SubTotal: $ {price.ToString("F2", CultureInfo.InvariantCulture)}");
                        totalPrice += price;
                    }

                    sw.WriteLine("Total: $ " + totalPrice.ToString("F2", CultureInfo.InvariantCulture));
                }
            }
            catch (DomainExceptions e)
            {
                Console.WriteLine("An error ocurred: ");
                Console.WriteLine(e.Message);
            }
        }
    }
}
