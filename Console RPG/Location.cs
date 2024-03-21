using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Console_RPG
{
    class Location
    {
        public static Location newBarkTown = new Location(" New Bark Town", " Your hometown, a lovely small village full of your family and friends!", new Event(() =>
        {
            Console.WriteLine("Welcome to the world of Pokemon young trainer! here you will battle, train, and most importantly have fun! My name is Professor Elm, but you can call me Professor Elm.");
            Console.WriteLine(" ");
            Console.WriteLine("Unfortunately, all my pokemon seem to have run away, maybe if you go run an errand for me, they'll come back. PLease deliver this to Mr. Pokemon's house on Route 30");
            Console.WriteLine(" ");
            Console.WriteLine("You received an Egg!");
            Console.WriteLine(" ");
            Console.WriteLine("As you walk outsisde you run into a fun-looking girl, she tells you her name is Lyra!");
            Console.WriteLine(" ");
        }));
        public static Location route27 = new Location(" Route 27", " Impassable unless you have a pokemon with surf");
        public static Location route29 = new Location(" Route 29", " The first route truly avaliable to you");
        public static Location cherrygrove1 = new Location(" CherryGrove City", " A small city that has a pizzeria to the right of the pokemon center :)", new Event(() =>
        {
            Console.WriteLine(" ");
            Console.WriteLine("As you enter the town, an old guy comes running up to you and yells \"PLEASE TAKE THESE!!! I STO- I GOT THEM FOR CHEAP PLEASE THEY'RE COMING AFTER MEEEEE!!!!\" ");
            Console.WriteLine(" ");
            Console.WriteLine("You received the Running Shoes!");
            Console.WriteLine(" ");
        }));
        public static Location route30 = new Location(" Route 30", " A sunny walking path, there appears to be a small house nearby", new Event(() =>
        {
            Console.WriteLine(" as you walk onto the Route, you see a small house nearby; it must be Mr. Pokemon's house!");
        }));
        public static Location cherrygrove2 = new Location(" CherryGrove city", " As you enter the town, you see your rival. Pizza gone :( ", new BattleSystem(new List<Enemy>() { Enemy.rival }));
        public static Location route29_2 = new Location(" Route 29", " sun :)");
        public static Location newBark2 = new Location(" New Bark Town", " Before you even enter the town, you can hear a great commotion coming from somewhere inside");
        public static Location route29_3 = new Location(" Route 29", " Still the same beautiful route as before, but this time you see Lyra way down the path, maybe you should go say hi?");
        public static Location cherrygrove3 = new Location(" CherryGrove city", " Still a thriving city with tons of happy looking people around!");
        public static Location route30_2 = new Location(" Route 30", " AHHHHHHH");
        public static Location route31 = new Location(" Route 31", " Trees, grass, and flowers, oh my! such a pretty route");
        public static Location violet = new Location(" Violet City", " A quaint little town; it's home to the pokemon school as well as a Pokemon Center and PokeMart");
        public static Location sproutTower = new Location(" Sprout Tower", " A large, beautifully intricate tower that commands a sense of awe");
        public static Location darkCave = new Location(" Dark Cave", " You can't see, ANYTHING");
        public static Location violet2 = new Location(" Violet City", " Still a small, pretty town; you realize that the gym is open for battle!", new BattleSystem(new List<Enemy>() { Enemy.falkner }));
        public static Location pokeMart = new Location(" PokeMart", " A place to shop for all your needs!", new Shop("Poke Mart", new List<Item>() { Item.potionI, Item.potionII, Item.potionIII }));
        

        public string name;
        public string description;
        public POI interaction;

        public Location north, east, south, west;

        public Location(string name, string description, POI interaction = null)
        {
            this.name = name;
            this.description = description;
            this.interaction = interaction;
        }

        public void SetNearbyLocations(Location north = null, Location east = null, Location south = null, Location west = null)
        {
            if (!(north is null))
            {
                north.south = this;
                this.north = north;
            }

            if (!(east is null))
            {
                east.west = this;
                this.east = east;
            }

            if (!(south is null))
            {
                south.north = this;
                this.south = south;
            }

            if (!(west is null))
            {
                west.east = this;
                this.west = west;
            }

        }
        public void Resolve(List<Player> players)
        {

            Console.WriteLine("You have arrived at" + this.name + ".");
            Console.WriteLine(" ");
            Console.WriteLine(this.description);
            Console.WriteLine(" ");
            interaction?.Resolve(players);
            bool shouldLoop = true;
            Location nextLocation = null;
            while (shouldLoop)
            {
                if (!(north is null))
                    Console.WriteLine("NORTH " + this.north.name);

                if (!(east is null))
                    Console.WriteLine("EAST" + this.east.name);

                if (!(south is null))
                    Console.WriteLine("SOUTH" + this.south.name);

                if (!(west is null))
                    Console.WriteLine("WEST" + this.west.name);

                string direction = Console.ReadLine().ToLower();
               

                if (direction == "north")
                    nextLocation = this.north;

                else if (direction == "east")
                    nextLocation = this.east;

                else if (direction == "south")
                    nextLocation = this.south;

                else if (direction == "west")
                    nextLocation = this.west;
                else

                    Console.WriteLine("You have made an invalid choice, please choose again");

                if(nextLocation != null)
                    shouldLoop = false;
            }

            nextLocation.Resolve(players);
        }

    }
}
