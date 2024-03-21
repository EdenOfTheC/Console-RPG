using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Item
    {
        public static HealthPotionItem potionI = new HealthPotionItem("Potion", "Heals 20 points of damage, it has no effect on a fainted pokemon.", 300, 999, 20);
        public static HealthPotionItem potionII = new HealthPotionItem("Super Potion", "Heals 60 points of damage, it has no effect on a fainted pokemon.", 700, 999, 60);
        public static HealthPotionItem potionIII = new HealthPotionItem("Hyper Potion", "Heals 120 points of damage, it has no effect on a fainted pokemon.", 1200, 999, 120);
        public string name;
        public string description;
        public int shopPrice;
        public int maxAmount;

        public Item(string name, string description, int shopPrice, int maxAmount)
        {
            this.name = name;
            this.description = description;
            this.shopPrice = shopPrice;
            this.maxAmount = maxAmount;


        }

        public abstract void Use(Entity user, Entity target);
    }

    class HealthPotionItem : Item
    {
        public int healAmount;


        public HealthPotionItem(string name, string description, int shopPrice, int maxAmount, int healAmount) : base(name, description, shopPrice, maxAmount)
        {
            this.healAmount = healAmount;
        }

        public override void Use(Entity user, Entity target)
        {
            user.currentHP += this.healAmount;
        }
    }

    class PpPotionItem : Item
    {
        public int ppUp;


        public PpPotionItem(string name, string description, int shopPrice, int maxAmount, int PpAmount) : base(name, description, shopPrice, maxAmount)
        {
            this.ppUp = PpAmount;
        }

        public override void Use(Entity user, Entity target)
        {
            user.currentHP += this.ppUp;
        }
    }
}
