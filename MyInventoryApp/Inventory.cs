using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventoryApp
{
    public class Inventory
    {
        private string name;
        private double price;
        private double weight;
        private string description;
        private int quantity;

        public Inventory(string name, double price, double weight, string description, int quantity)
        {
            this.price = price;
            this.weight = weight;
            this.description = description;
            this.quantity = quantity;
            this.name = name;
        }

        public string getName()
        {
            return this.name;
        }

        public double getPrice()
        {
            return this.price;
        }

        public double getWeight()
        {
            return this.weight;
        }

        public string getDescription()
        {
            return this.description;
        }

        public int getQuantity()
        {
            return this.quantity;
        }
    }
}
