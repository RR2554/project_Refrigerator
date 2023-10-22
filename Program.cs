
using Refrigerator_EX;
using System;

class Program
{
    public static List<Refrigerator> SortRefrigeratorsByFreeSpace(List<Refrigerator> refrigerators)
    {
        List<Refrigerator> sortRefrigerators = refrigerators.OrderByDescending(refrigerator => refrigerator.spaceInRefrigerator()).ToList();
        return sortRefrigerators;
    }

    public static Shelf buildShelf()
    {
        Console.WriteLine("we going to build shelf");
        Shelf shelf = new Shelf();
        Console.WriteLine("enter the floorNumber:");
        shelf.FloorNumber= Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("enter the shelfSpace:");
        shelf.ShelfSpace = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("now you dont have items in the shelf if you want to put item so you can AddItem");
        shelf.Items = new List<Item>();

        return shelf;
    }

    public static Refrigerator buildRefrigerator()
    {
        Refrigerator refrigerator = new Refrigerator();
        Console.WriteLine("enter the model:");
        refrigerator.Model = Console.ReadLine();
        Console.WriteLine("enter the color:");
        refrigerator.Color = Console.ReadLine();
        Console.WriteLine("enter num of shelves:");
        refrigerator.NumberOfShelves= Convert.ToInt32(Console.ReadLine());
       
        refrigerator.Shelves = new List<Shelf>();

        for (int i = 0; i < refrigerator.NumberOfShelves; i++)
        {
            Shelf shelf=buildShelf();
            refrigerator.Shelves.Add(shelf);
        }

        return refrigerator;
    }

    public static Item createItem()
    {
        Item item = new Item();
        Console.WriteLine("enter name:");
        item.Name = Console.ReadLine();
        Console.WriteLine("enter type");
        item.Type = Console.ReadLine();
        Console.WriteLine("enter kashroot");
        item.Kashroot = Console.ReadLine();
        Console.WriteLine("enter expiryDate");
        item.ExpiryDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("enter spaceNeed");
        item.SpaceNeed= Convert.ToInt32(Console.ReadLine());

        return item;
    }

    static void Main()
    {

        Console.WriteLine("we going to build refrigerator");
        Refrigerator refrigerator = buildRefrigerator();
        Console.WriteLine("The refrigerator was successfully built. You can insert items");
        refrigerator.addItemToRefrigerator(createItem());

       //==========================================================================
       //הוספתי כאן מעצמי הרבה פריטים למקרר כדי שאני יוכל להתעסק עם הפונקציות ולראות שהכל תקין 
       //אבל את הרעיון של הכנסת פריט לפי קלט מהמשתמש ביצעתי פעם אחת
       //================================================================================
        DateTime date1 = new DateTime(2023, 10, 21);
        Item item1 = new Item("apple","food","parve", date1,3);
        refrigerator.addItemToRefrigerator(item1);
        DateTime date2 = new DateTime(2023, 10, 29);
        Item item2 = new Item(  "milk", "drink", "chalavi", date2, 5);
        refrigerator.addItemToRefrigerator(item2);
        DateTime date3 = new DateTime(2023, 10, 21);
        Item item3 = new Item( "gvina", "food", "chalavi", date3, 2);
        refrigerator.addItemToRefrigerator(item3);
        DateTime date4 = new DateTime(2023, 10, 28);
        Item item4 = new Item(  "chaze", "food", "besari", date4, 6);
        refrigerator.addItemToRefrigerator(item4);
        DateTime date5 = new DateTime(2023, 10, 22);
        Item item5 = new Item( "maadan", "food", "chalavi", date5, 3);
        refrigerator.addItemToRefrigerator(item5);
        DateTime date6 = new DateTime(2023, 10, 26);
        Item item6 = new Item( "tachun", "food", "besari", date6, 11);
        refrigerator.addItemToRefrigerator(item6);
        DateTime date7 = new DateTime(2023, 11, 12);
        Item item7 = new Item("cake", "food", "parve", date7, 8);
        refrigerator.addItemToRefrigerator(item7);
        DateTime date8 = new DateTime(2023, 11,11);
        Item item8 = new Item("water", "drink", "parve", date8, 3);
        refrigerator.addItemToRefrigerator(item8);
        DateTime date9 = new DateTime(2023, 10, 24);
        Item item9 = new Item("shokolate", "food", "chalavi", date9, 2);
        refrigerator.addItemToRefrigerator(item9);
        DateTime date10 = new DateTime(2023, 10, 20);
        Item item10 = new Item("cucamber", "food", "parve", date10,4);
        refrigerator.addItemToRefrigerator(item10);
        DateTime date11 = new DateTime(2023, 10, 29);
        Item item11 = new Item("potato", "food", "parve", date11, 3);
        refrigerator.addItemToRefrigerator(item11);



        List<Refrigerator> refrigerators = new List<Refrigerator>();

       

           int flag = 1;
        while (flag == 1) {
            Console.WriteLine("Press 1: the program will print all the items on the refrigerator and all its contents.");
            Console.WriteLine("Click 2: the program will print how much space is left in the fridge");
            Console.WriteLine("Press 3: The program will allow the user to put an item in the fridge.");
            Console.WriteLine("Press 4: The program will allow the user to remove an item from the refrigerator.");
            Console.WriteLine("Press 5: the program will clean the refrigerator and print all the checked items to the user.");
            Console.WriteLine("Click 6: The program will ask the user \"What do I want to eat?\" and bring the function to bring a product.");
            Console.WriteLine("Click 7: the program will print all the products sorted by their expiration date.");
            Console.WriteLine("Press 8: the program will print all the shelves arranged according to the free space left on them.");
            Console.WriteLine("Press 9: the program will print all the refrigerators arranged according to the free space left in them.");
            Console.WriteLine("Click 10: The program will prepare the refrigerator for shopping");
            Console.WriteLine("Press 100: system shutdown.");
            Console.WriteLine("enter your choice");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine(refrigerator.ToString());
                    break;
                case 2:
                    Console.WriteLine("Free space in the fridge:{0}", refrigerator.spaceInRefrigerator());
                    break;
                case 3:
                    Console.WriteLine("enter the item details:");
                    Item newItem = createItem();
                    refrigerator.addItemToRefrigerator(newItem);
                    break;
                case 4:
                    Console.WriteLine("Enter the ID of the item you want to remove:");
                    int itemId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("The details of the item you took out of the fridge: {0}", refrigerator.RemoveItemFromRefrigerator(itemId).ToString());
                    break;
                case 5:
                    refrigerator.cleanTheRefrigerator();
                    break;
                case 6:
                    string kashroot, type;
                    Console.WriteLine("Enter the kosher of the food you want to receive: ");
                    while (true)
                    {
                        kashroot = Console.ReadLine();
                        if (!(kashroot.Equals("chalavi") || kashroot.Equals("besari") || kashroot.Equals("parve")))
                            Console.WriteLine("kashroot can be only chalavi/besari/parve,enter again!");
                        else
                            break;
                    }
                    Console.WriteLine("Enter the type of the food you want to receive: ");
                    while (true)
                    {
                        type = Console.ReadLine();
                        if (!(type.Equals("food") || type.Equals("drink")))
                            Console.WriteLine("type can be only drink/food,enter again!");
                        else
                            break;
                    }
                    List<Item> listOfFood = refrigerator.FoodOptions(kashroot, type);
                    foreach (Item item in listOfFood)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case 7:
                    List<Item> sortItems = refrigerator.SortItemsByExpiryDate();
                    foreach (Item item in sortItems)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case 8:
                    List<Shelf> sortShelf = refrigerator.SortShelvesByFreeSpace();
                    foreach (Shelf shelf in sortShelf)
                    {
                        Console.WriteLine(shelf.ToString());
                    }
                    break;
                case 9:
                    List<Refrigerator> sortRefrigerator = SortRefrigeratorsByFreeSpace(refrigerators);
                    break;
                case 10:
                    refrigerator.getReadyForShopping();
                    break;
                case 100:
                    flag = 0;
                    break;
    
        }
        }
    }
}
