using Refrigerator_EX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator_EX
{
    class Refrigerator
    {
        private static int nextID = 1;

        private int refrigeratorID;
        private string model;
        private string color;
        private int numberOfShelves;
        private List<Shelf> shelves;

        public Refrigerator( string model, string color, int numberOfShelves)
        {
            this.refrigeratorID = nextID++;
            this.model = model;
            this.color = color;
            this.numberOfShelves = numberOfShelves;
            this.shelves = new List<Shelf>();
        }

        public Refrigerator()
        {
            this.refrigeratorID = nextID++;
        }

        public int RefrigeratorID
        {
            get { return refrigeratorID; }
            set {; } 
        }
        public string Model 
        {
            get { return model; }
            set {
                if (!(value.Equals("")))
                    model = value;
                else
                    Console.WriteLine("model must be contain string");
            }
        }
        public string Color
        {
            get { return color; }
            set
            {
                if (!(value.Equals("")))
                    color = value;
                else
                    Console.WriteLine("color must be contain string");
            }
        }
        public int NumberOfShelves 
        {
            get { return numberOfShelves; }
            set { if (value > 0 && value < 15)
                    numberOfShelves = value;
                else
                    Console.WriteLine("The number of shelves must be positive less than 15");
                    }
        }
        public List<Shelf> Shelves
        {
            get { return shelves; }
            set
            {
                if (!(value is null))
                {
                    shelves = value;
                }
                else
                {
                    shelves = new List<Shelf>();
                }; }
        }

//-----------------------------------------------------------------------------------------------------------
        public double spaceInRefrigerator()//פונקציה שבודקת כמה מקום נשאר במקרר
        {
            
            double refrigeratorSpace = 0;
            foreach (Shelf shelf in shelves)
            {

               refrigeratorSpace += shelf.spaceInShelf();
                
            }
            return refrigeratorSpace;

        }

//--------------------------------------------------------------------------------------------------------------
        public List<Shelf> SortShelvesByFreeSpace()
        {
            List<Shelf> sortShelves= shelves.OrderByDescending(shelf => shelf.spaceInShelf()).ToList();
            return sortShelves;
        }

        public List<Item> SortItemsByExpiryDate()
        {
            List<Item> sortItems= new List<Item>();
            foreach(Shelf shelf in shelves)
            {
                if(shelf.Items!=null)
                sortItems = sortItems.Concat(shelf.Items).ToList();
            }
            sortItems= sortItems.OrderBy(item=>item.ExpiryDate).ToList();
            return sortItems;
        }


//------------------------------------------------------------------------------------------------------------------------------------------------------
        public void addItemToRefrigerator(Item item)//פונקציה שמוסיפה פריט למקרר 
        {

            if (this.spaceInRefrigerator() < item.SpaceNeed)//אם אין בכל המקרר מקום להכניס את הפריט
                throw new Exception("There is not enough space in the fridge to put the item");
            else
            {
                foreach (Shelf shelf in shelves)// 
                {
                    if (shelf.spaceInShelf() > item.SpaceNeed)
                    {//אם יש מקום במדף להכניס
                        shelf.addItemToShelf(item);
                        break;
                    }

                }
                if(item.ShelfId==0)//אם הגעתי לשלב הזה ועדיין הקוד של המדף הוא 0 זה אומר שבכללי יש מקום במקרר אבל המקום מפוזר בין המדפים בצורה כזאת שאין מקום בכל מדף וצריך לארגן לזה מקום
                {
                    throw new Exception("There is space in the fridge but you have to rearrange the items on the shelves so that there is space to put the item");
                }

                }
        
        }

//-------------------------------------------------------------------------------------------------------------------------------------------------------
       public Item RemoveItemFromRefrigerator(int itemId)
        {
            Item removeItem= null;
            foreach(Shelf shelf in shelves)
            {
                if (shelf.FindItemInShelf(itemId))//אם מצאת את הפריט במדף הזה
                {
                   removeItem= shelf.RemoveItemFromShelf(itemId);
                    break;
                }
            }
            if (removeItem == null)
            {
                Console.WriteLine("the item not found");//כאן אני צריכה לזרוק שגיאה
            }
            return removeItem;
        }

 //-------------------------------------------------------------------------------------------------------------------------------------------

        public void cleanTheRefrigerator()
        {
            Console.WriteLine("we clean the refrigerator");
           
            foreach (Shelf shelf in shelves)
            {

                shelf.cleanTheShelf();
               
           
            }
        }

//-------------------------------------------------------------------------------------------------------------------------------------------------
        public List<Item> FoodOptions(string kosher, string type)
        {
            List<Item> OptionalItems = new List<Item>();
            DateTime currentDate = DateTime.Now;
            foreach (Shelf shelf in shelves)
            {
                foreach (Item item in shelf.Items)
                {
                    if (item.Type.Equals(type) && item.Kashroot.Equals(kosher))
                        if (currentDate < item.ExpiryDate)
                            OptionalItems.Add(item);
                }
            }
            return OptionalItems;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------

        public Boolean IsSpacebBiggerThan20()
        {
            if (this.spaceInRefrigerator() >= 20)
                return true;
            return false;
        }

   //------------------------------------------------------------------------------------------------------------------------------------------

        public List<Item> itemsToRemove(string kosher,int days)
        {
            
            DateTime currentDate = DateTime.Now;
            TimeSpan dayDifference;
            List<Item> itemsRemove = new List<Item>();
            foreach (Shelf shelf in shelves)
            {
                int itemLenght = shelf.Items.Count;
                for (int i = 0; i < shelf.Items.Count; i++)
                {
                    if (shelf.Items[i].Kashroot.Equals(kosher))
                    {
                        dayDifference = shelf.Items[i].ExpiryDate - currentDate;
                        if (dayDifference.TotalDays < days)
                        {
                            itemsRemove.Add(shelf.Items[i]);
                            shelf.Items.Remove(shelf.Items[i]);
                            i--;
                        }
                    }

                }
            } 
            return itemsRemove;
        }

//---------------------------------------------------------------------------------------------------------------------------------------------------------
        public void getReadyForShopping()
        {
        
            int flag;
            if (this.IsSpacebBiggerThan20())
            {
                Console.WriteLine("Your fridge is ready for shopping. Good luck!");
                return;
            }

            this.cleanTheRefrigerator();
            Console.WriteLine("After cleaning you have {0} space in the fridge", this.spaceInRefrigerator());
            if (this.spaceInRefrigerator() >= 20)
            {
                Console.WriteLine("Your fridge is ready for shopping. Good luck!");
                return;
            }
           
            flag = RemoveItemAndChecking("chalavi", 3);
            if (flag == 1)
                return;

            flag = RemoveItemAndChecking("besari", 7);
            if (flag == 1)
                return;

            flag = RemoveItemAndChecking("parve", 1);
            if (flag == 1)
                return;
           
           

            return;
        }

//----------------------------------------------------------------------------------------------------------------------------------------
          public int RemoveItemAndChecking(string kosher, int days)
           {

            List<Item> itemssToRemove;
           
            itemssToRemove = itemsToRemove(kosher, days);
            Console.WriteLine("We removed the following {0} products from the fridge:", kosher);
            foreach (Item item in itemssToRemove)
            {
                Console.WriteLine(item.Name);
            }
            if (this.IsSpacebBiggerThan20())
            {

                Console.WriteLine("Your fridge is ready for shopping. Good luck!");
                return 1;
            }
            return 0;
           }

//----------------------------------------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($" ID: {refrigeratorID}");
            result.AppendLine($"Model: {model}");
            result.AppendLine($"Color: {color}");
            result.AppendLine($"Number of Shelves: {numberOfShelves}");

          
            result.AppendLine("Shelves:");

            foreach (var shelf in shelves)
            {
                result.AppendLine(shelf.ToString());
            }

            return result.ToString();

        }
    }


}
