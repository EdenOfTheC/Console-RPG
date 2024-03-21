using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Equipment : Item
    {
        public float durability;
        public float weight;
        public bool isEquipped;

        protected Equipment(string name, string description, int shopPrice, int sellPrice, float durability, float weight) : base(name, description,  shopPrice, sellPrice)
        {
            this.durability = durability;
            this.weight = weight;
            this.isEquipped = false;
        }
    }

    class Armor : Equipment
    {
        public int defense;

        public Armor(string name, string description, int shopPrice, int sellPrice, float durability, float weight, int defense) : base(name, description, shopPrice, sellPrice, durability, weight)
        {
            this.defense = defense;
        }

        public override void Use(Entity user, Entity target)
        {
            this.isEquipped = !this.isEquipped;
            if (this.isEquipped)
            {
                target.stats.defense += this.defense;
            }
            else
            { 
                target.stats.defense -= this.defense;
            }
        }
    }
    class Weapon : Equipment
    {
        public int strength;
        public Weapon(string name, string description, int shopPrice, int sellPrice, float durability, float weight, int strength) : base(name, description, shopPrice, sellPrice, durability, weight)
        {
            this.strength = strength;
        }

        public override void Use(Entity user, Entity target)
        {
            this.isEquipped = !this.isEquipped;
            if (this.isEquipped)
            {
                target.stats.strength += this.strength;
            }
            else
            {
                target.stats.strength -= this.strength;
            }
        }
    }
}
