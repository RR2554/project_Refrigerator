using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator_EX
{
    class Item
    {
        private static int nextID = 1;

        private int ID;
        private int shelfId;
        private string name;
        private string type;
        private string kashroot;
        private DateTime expiryDate;
        private double spaceNeed;


        public int Id
        {
            get { return ID; }
            set {; }
        }


        public int ShelfId
        {
            get { return shelfId; } 
            set {shelfId=value; } 
        }


        public string Name
        {
            get { return name; }
            set {
                if (!(value.Equals("")))
                    name = value;
                else
                    Console.WriteLine("name must be contain string");
            } 
        }


        public string Type
        {
            get { return type; }
            set {if (value.Equals("food") || value.Equals("drink"))
                    type = value;
                else Console.WriteLine("type can be only food/drink");
            }
        }


        public string Kashroot
        {
            get { return kashroot; } 
            set {
                if (value.Equals("chalavi") || value.Equals("besari") || value.Equals("parve"))
                    kashroot = value;
                else Console.WriteLine("kashroot can be only chalavi/besari/parve");
            } 
        }


        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set {expiryDate=value; }
        }


        public double SpaceNeed
        {
            get { return spaceNeed; }
            set { spaceNeed = value; }
        }

        public Item(  string name, string type, string kashroot, DateTime expiryDate, double spaceNeed)
        {
            this.ID = nextID++;
            this.name = name;
            this.type = type;
            this.kashroot = kashroot;
            this.expiryDate = expiryDate;
            this.spaceNeed = spaceNeed;
        }

        public Item()
        {
            this.ID = nextID++;
        }

        public override string ToString()
        {
            return $"Item ID: {ID}, Shelf ID: {shelfId}, Name: {name}, Type: {type}, Kashroot: {kashroot}, Expiry Date: {expiryDate}, Space Need: {spaceNeed}";
        }
    }
}
