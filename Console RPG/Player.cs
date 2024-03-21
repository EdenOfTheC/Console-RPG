using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_RPG
{
    class Player : Entity
    {
        public static List<Item> Inventory = new List<Item>() { Item.potionI, Item.potionI, Item.potionI, Item.potionII };
        public static int CoinCount = 0;

        public static Player player = new Player("YOU", 100, 22, new Stats(22, 20, 17, 9, 11), 1);

        public int level;

        public Player(string name, int hp, int mana, Stats stats, int level) : base(name, hp, mana, stats, 0)
        {
            this.level = level;
        }

        public override Entity ChooseTarget(List<Entity> choices)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Type in the number correlated to the entity you want to target");
            Console.WriteLine(" ");

            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {choices[i].name}");
            }

            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }
        public Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Current items avaliable, which would you like");
            Console.WriteLine(" ");

            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {choices[i].name}");
            }

            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }

        public override void Attack(Entity target)
        {
            Console.WriteLine(" ");
            Console.WriteLine(this.name + " attacked " + target.name + "!");
            Console.WriteLine(" ");
            target.currentHP -= this.stats.strength - target.stats.defense;
            Console.WriteLine($"The enemy lost {target.currentHP -= this.stats.strength} health!");
            Console.WriteLine(" ");
        }
        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine(" ");
            Console.WriteLine("ATTACK | BAG ");
            Console.WriteLine(" ");
            string choice = Console.ReadLine();

            if (choice == "ATTACK")
            {
                Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                Attack(target);
            }
            else if (choice == "BAG")
            {
                Item item = ChooseItem(Inventory);
                Entity target = ChooseTarget(players.Cast<Entity>().ToList());

                item.Use(this, target);
                Inventory.Remove(item);
            }
        }
        
    }
}
