namespace WorldOfZuul
{
    public class GuideTurtle : Minigame
    {
        public override void Play()
        {
            Console.WriteLine("Turtles mistake plastic bags for jellyfish, which they try to eat. This can be deadly for them.");
            Console.WriteLine("Guide the turtle to safety at position (4, 4).");
            int turtleX = 2;
            int turtleY = 2;

            while (turtleX != 4 || turtleY != 4)
            {
                Console.WriteLine($"Current position: ({turtleX},{turtleY}). Move (up/down/left/right):");
                string move = Console.ReadLine().ToLower();

                if (move == "up" && turtleY < 4) turtleY++;
                else if (move == "down" && turtleY > 0) turtleY--;
                else if (move == "left" && turtleX > 0) turtleX--;
                else if (move == "right" && turtleX < 4) turtleX++;
                else Console.WriteLine("Invalid move. Try again.");
            }

            Console.WriteLine("Turtle guided to safety! Well done! You've made the lagoon a safer place.");
            IsComplete = true;
        }
    }
}
