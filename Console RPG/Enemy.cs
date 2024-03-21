using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_RPG
{
    class Enemy : Entity
    {
        public static Enemy rival = new Enemy("Chris P. Bacon", 70, 0, new Stats( 17, 23, 15, 4, 11), 2000, 3576);
        public static Enemy falkner = new Enemy("Gym Leader Falkner", 120, 0, new Stats(25, 22, 14, 7, 11), 7000, 11537);
        
        public int EXP;
        public int moneyDropped;

        public Enemy(string name, int hp, int mana, Stats stats, int EXP, int moneyDropped) : base(name, hp, mana, stats, moneyDropped)
        {
            this.EXP = EXP;
            this.moneyDropped = moneyDropped;
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random(150);
            return targets[random.Next(targets.Count)];
        }

        public override void Attack(Entity target)
        {
            target.currentHP -= this.stats.strength - target.stats.defense;
            Console.WriteLine(" ");
            Console.WriteLine($"You lost {target.currentHP -= this.stats.strength} health!");
            Console.WriteLine(" ");
            Console.WriteLine(this.name + " attacked " + target.name + "!");
            Console.WriteLine(" ");
        }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Entity target = ChooseTarget(players.Cast<Entity>().ToList());
            Attack(target);
        }
    }
}
