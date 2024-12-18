using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfZuul
{
    public class CommandWords
    {

        public List<string> ValidCommands { get; } = new List<string> { "north", "east", "south", "west", "look", "back", "quit", "inventory", "take", "drop", "open", "loot", "close", "talk", "bye", "start", "progress", "goal" };

        public bool IsValidCommand(string command)
        {
            if (isIntInput(command))
            {
                return true;
            }
            return ValidCommands.Contains(command);
        }

        // method that checks if input is a number
        private bool isIntInput(string command)
        {
            return int.TryParse(command, out _);
        }

    }

}
