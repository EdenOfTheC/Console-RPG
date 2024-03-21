using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Console_RPG
{
    class BattleSystem : POI
    {
        
        public List<Enemy> enemies;

        public BattleSystem(List<Enemy> enemies) : base(false)
        {
            
            this.enemies = enemies;
        }

        public override void Resolve(List<Player> players)
        {
            if (this.isResolved)
                return;

            while (true)
            {
                foreach (var player in players)
                {
                    if (player.currentHP > 0)
                    Console.WriteLine("It's " + player.name + "'s turn.");
                    player.DoTurn(players, enemies);
                }

                foreach (var enemy in enemies)
                {
                    if (enemy.currentHP > 0)
                    {
                        Console.WriteLine("It's " + enemy.name + "'s turn.");
                        enemy.DoTurn(players, enemies);
                    }
                    
                }

                if (players.TrueForAll(player => player.currentHP <= 0))
                {
                    int lossMoney = 0;
                    foreach (var item in enemies) 
                    {
                        players[0].currentMoney -= item.moneyDropped;
                        lossMoney += item.moneyDropped;
                    }
                    Console.WriteLine("You whited out, you scurry along to the pokemon center and drop " + lossMoney + " dollars" );
                 
                    break;
                }

                if (enemies.TrueForAll(enemy => enemy.currentHP <= 0))
                {
                    int totalMoney = 0;

                    foreach (var item in enemies)
                    {
                        players[0].currentMoney += item.moneyDropped;
                        totalMoney += item.moneyDropped;
                    }
                    Console.WriteLine("You defeated your opponent! they gave you " + totalMoney + " dollars!");
                    this.isResolved = true;
                    break;
                }

                
            }
        }
    }
}
