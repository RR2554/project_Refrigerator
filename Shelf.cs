using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator_EX
{
    class Shelf
    {
        private static int nextID = 1;

        private int ID;
        private int floorNumber;
        private int shelfSpace;
        private List<Item> items;

       
        public int Id
        { 
            get{return ID; } 
            set {; } 
        }
        public int FloorNumber
        {
            get { return floorNumber; } 
            set {if (value > 0)
                    floorNumber = value;
                else
                    Console.WriteLine("floorNumber must be positive");
            }
        }
        public int ShelfSpace 
        {
            get { return shelfSpace; } 
            set {
                if (value > 0)
                    shelfSpace = value;
                else
                    Console.WriteLine("shelfSpace must be positive");
            }
        }
        public List<Item> Items 
        {
            get { return items; } 
            set {
                if (!(value is null))
                {
                    items = value;
                }
                else
                {
                    items = new List<Item>();
                }
                ; } 
        }

        public Shelf(int floorNumber,int shelfSpace)
        {
           
            this.ID = nextID++;
            this.floorNumber = floorNumber;
            this.shelfSpace = shelfSpace;
            this.items = new List<Item>();
            
        }
        public Shelf()
        {
            this.ID = nextID++;
        }


        public double spaceInShelf()
        {
            double wastedSpace = 0;
           
            foreach (Item item in items)
            {

                wastedSpace += item.SpaceNeed;

            }
            return  (ShelfSpace - wastedSpace);


            
        }

        public Boolean FindItemInShelf(int itemId)
        {
            foreach(Item item in items)
            {
                if(item.Id==itemId)
                    return true;
            }
            return false;
        }

        public Item RemoveItemFromShelf(int itemId)
        {
            Item removeItem=new Item();
            foreach(Item item in items)
            {
                if (item.Id == itemId)
                {
                    removeItem.Id = item.Id;
                    removeItem.ShelfId = item.ShelfId;
                    removeItem.SpaceNeed= item.SpaceNeed;
                    removeItem.Name= item.Name;
                    removeItem.ExpiryDate= item.ExpiryDate;
                    removeItem.Type= item.Type;
                    removeItem.Kashroot= item.Kashroot;

                    //removeItem = item;//לבדוקקקקק
                    items.Remove(item);
                    break;
                }
            }
            return removeItem;
        }

        public void addItemToShelf(Item item)
        {
            this.items.Add(item);
            item.ShelfId= this.ID;//עדכון המדף אליו הוא נכנס
            Console.WriteLine("The item has been placed on the shelf {0}", ID);
        }

        public void cleanTheShelf()
        {
            DateTime currentDate = DateTime.Now;
            for (int i = 0; i < Items.Count; i++)
            {

                if (Items[i].ExpiryDate.Date < currentDate.Date)
                {

                    Items.Remove(Items[i]);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder DetailsShelf = new StringBuilder();
            DetailsShelf.AppendLine($"ID: {ID}");
            DetailsShelf.AppendLine($"numberLevel: {floorNumber}");
            DetailsShelf.AppendLine($"placeInShelf: {shelfSpace}");
            DetailsShelf.AppendLine("Items:");
            foreach (Item itemm in items)
            {
                DetailsShelf.AppendLine(itemm.ToString());
            }
            return DetailsShelf.ToString(); ;
        }

    }
}
