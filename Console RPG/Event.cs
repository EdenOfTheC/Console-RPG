using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    internal class Event : POI
    {
        public Action interaction;

        public Event (Action interaction) : base(false)
        {
            this.interaction = interaction;
        }

        public override void Resolve(List<Player> players)
        {
            if (this.isResolved)
                return;
            interaction.Invoke();
            this.isResolved = true;
        }
    }
}
