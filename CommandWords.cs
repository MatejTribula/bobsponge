using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfZuul
{
    public class CommandWords
    {
        // DONE add inventory, take, drop, open, talk as valid commands
        public List<string> ValidCommands { get; } = new List<string> { "north", "east", "south", "west", "look", "back", "quit", "inventory", "take", "drop", "open", "talk" };

        public bool IsValidCommand(string command)
        {
            return ValidCommands.Contains(command);
        }
    }

}
