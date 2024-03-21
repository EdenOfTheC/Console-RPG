using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class POI
    {
        public bool isResolved;

        public POI(bool isResolved)
        {
            this.isResolved = isResolved;
        }

        public abstract void Resolve(List<Player> players);
    }
}
