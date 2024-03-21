using System;
using System.Collections.Generic;
using System.Net;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Location.newBarkTown.SetNearbyLocations(west: Location.route29, east: Location.route27);
            Location.route27.SetNearbyLocations(west: Location.newBarkTown);
            Location.route29.SetNearbyLocations(west: Location.cherrygrove1, east: Location.newBarkTown);
            Location.cherrygrove1.SetNearbyLocations(east: Location.route29, north: Location.route30, west: Location.pokeMart);
            Location.route30.SetNearbyLocations(south: Location.cherrygrove1);
            Location.cherrygrove2.SetNearbyLocations(east: Location.route29_2, north: Location.route30);
            Location.route29_2.SetNearbyLocations(west: Location.cherrygrove2, east: Location.newBark2);
            Location.newBark2.SetNearbyLocations(west: Location.route29_3, east: Location.route27);
            Location.route29_3.SetNearbyLocations(west: Location.cherrygrove3, east: Location.newBark2);
            Location.cherrygrove3.SetNearbyLocations(east: Location.route29_3, north: Location.route30_2);
            Location.route30_2.SetNearbyLocations(north: Location.route31, south: Location.cherrygrove3);
            Location.route31.SetNearbyLocations(south: Location.route30_2, west: Location.violet);
            Location.violet.SetNearbyLocations(north: Location.sproutTower, east: Location.route31);
            Location.sproutTower.SetNearbyLocations(south: Location.violet2);



            Location.newBarkTown.Resolve(new List<Player>() { Player.player });
        }
    }
}
