using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Shop : POI
    {
        public string shopName;
        public List<Item> items;

        public Shop(string shopName, List<Item> items) : base(false)
        {
            this.shopName = shopName;
            this.items = items;
        }

        public override void Resolve(List<Player> players)
        {
            Console.WriteLine("Welcome to the PokeMart!");

            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("BUY | SELL | LEAVE");
                string userInput = Console.ReadLine();
                if (userInput == "BUY")
                {
                    Item item = ChooseItem(this.items);
                    Player.CoinCount -= item.shopPrice;
                    Player.Inventory.Add(item);

                    Console.WriteLine($"you bought a {item.name}!");
                }
                else if (userInput == "SELL")
                {
                    Item item = ChooseItem(Player.Inventory);
                    Player.CoinCount += item.shopPrice;
                    Player.Inventory.Remove(item);

                    Console.WriteLine($"you sold a {item.name}!");
                }
                else if (userInput == "LEAVE")
                {
                    break;
                }

                Console.WriteLine(" ");

            }
            
        }

        public Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine("Current items avaliable, which would you like");

            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {choices[i].name} ({choices[i].shopPrice})");
            }

            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }
    }
}
