using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    //Classes are useful for storing complex objects.
    abstract class Entity
    {
        public static Entity eden = new Player("Eden", 50, 25, new Stats(10, 8, 7, 4, 7), 1);
        public static Entity otherguy = new Player("OtherGuy", 40, 15, new Stats(8, 7, 5, 2, 8), 1);
        public static Entity enemy = new Enemy("BigBadGuy", 30, 10, new Stats(5, 3, 2, 1, 5), 15, 500);
        public static Entity enemy2 = new Enemy("OtherBigBadGuy", 28, 20, new Stats(10, 2, 2, 7, 5), 15, 500);
        public string name;

        public int currentHP, maxHP;
        public int currentMana, maxMana;
        public int currentMoney, maxMoney;

        public Stats stats;

        public Entity(string name, int hp, int mana, Stats stats, int money)
        {
            this.name = name;
            this.currentHP = hp;
            this.maxHP = hp;
            this.currentMana = mana;
            this.maxMana = mana;
            this.stats = stats;
            this.currentMoney = money;
            this.maxMoney = money;
        }

        public abstract void DoTurn(List<Player> players, List<Enemy> enemies);
        public abstract Entity ChooseTarget(List<Entity> targets);
        public abstract void Attack(Entity target);

        public void UseItem(Item item, Entity target)
        {
            item.Use(this, target);
        }
    }
}
