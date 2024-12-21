using System.Security.Cryptography.X509Certificates;

namespace WorldOfZuul
{
    public class Shipwreck
    {
        public static bool CaptainsMinigameDone = false;
        public static bool NavigationMinigameDone = false;

        public static void PlayNetEntanglingGame()
        {
            if (CaptainsMinigameDone == true)
        {
        Console.WriteLine("You have already entangled the net. There's nothing more to do here.");
        return;
        }
            string[] knots = { "Top", "Middle", "Bottom" };
            const int maxWrongMoves = 1; // Maximum allowed wrong moves
            bool quit = false; // Track if the player quits

            // Loop for retrying after failure
            do
            {
                int currentKnot = 0; // Index for the current knot to entangle
                int wrongMoves = 0; // Track wrong moves

                Console.WriteLine("Hey, did you know about ghost nets?");
                Console.WriteLine("They're terrible for marine life—fish and turtles get stuck in them, and they damage coral reefs.");
                Console.WriteLine("Plus, they break down into microplastics, polluting the ocean even more.\n");
                Console.WriteLine("Some ways to prevent them are to use biodegradable nets, mark fishing gear so it’s easier to find if lost, properly\r\nrecycle old nets, and support projects that recover them from the ocean.");
                Console.WriteLine("Your goal right now is to entangle the knots on this net");
                Console.WriteLine("You can only make one wrong move. Type 'q' to exit at any time.\n");

                while (currentKnot < knots.Length && wrongMoves <= maxWrongMoves && !quit)
                {
                    Console.Write("Enter the name of the knot to entangle (Top/Middle/Bottom): ");
                    string input = Console.ReadLine()?.Trim();

                    if (input?.ToLower() == "q")
                    {
                        quit = true;
                        break;
                    }

                    if (string.Equals(input, knots[currentKnot], StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Correct! {knots[currentKnot]} knot entangled successfully.\n");
                        currentKnot++;
                    }
                    else
                    {
                        wrongMoves++;
                        if (wrongMoves > maxWrongMoves)
                        {
                            Console.WriteLine("Oh no, you made too many mistakes and you damaged the surrounding marine life.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong move! Be careful, you can only make one wrong move.\n");
                        }
                    }
                }

                if (!quit && wrongMoves <= maxWrongMoves && currentKnot == knots.Length)
                {
                    Console.WriteLine("You entangled the net successfully without damaging the surrounding marine life, and now you can reach the chest!");
                    Console.WriteLine("Now you can open the chest and claim what's in it!");
                    CaptainsMinigameDone = true;
                    break;
                }
                else if (!quit && wrongMoves > maxWrongMoves)
                {
                    Console.WriteLine("Don't worry, I'll send you back in time so you can try again!");
                    Console.WriteLine("Retrying...\n");
                }

            } while (!quit && Console.ReadKey().Key != ConsoleKey.Q); // The game will keep retrying until the player quits with 'Q'
        }
        
    
    static char[,] net = {
        { 'o', 'o', 'o', 'o', 'O', 'o', 'o', 'o', 'o', 'o', 'o' },
        { 'o', 'o', 'o', 'o', 'o', 'O', 'o', 'o', 'o', 'o', 'o' },
        { 'o', 'o', 'o', 'o', 'o', 'O', 'o', 'o', 'o', 'o', 'o' },
        { 'o', 'o', 'o', 'o', 'O', 'O', 'O', 'o', 'o', 'o', 'o' },
        { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'O', 'o', 'o' },
        { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'O', 'o', 'o' }
    };

    static int cursorRow = 0;
    static int cursorCol = 0;
    static int lastCutRow = 0;
    static int lastCutCol = 0;
    static int netRowStart = 2; // Starting row for the net game

    public static void ExploreShipwreck()
    {
        if (NavigationMinigameDone == true)
        {
        Console.WriteLine("You have already cut the net. There's nothing more to do here.");
        return;
        }
        Console.Clear();
        Console.WriteLine("You found the net blocking the way to the chest. Press [Enter] to start cutting it!");
        Console.ReadKey();

        StartNetCuttingGame();
    }

    static void StartNetCuttingGame()
    {

        InitializeFirstCutPosition();
        DisplayNet();

        ConsoleKey key;
        do
        {
            var prevRow = cursorRow;
            var prevCol = cursorCol;

            key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (cursorRow > 0) cursorRow--;
                    break;
                case ConsoleKey.DownArrow:
                    if (cursorRow < net.GetLength(0) - 1) cursorRow++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (cursorCol > 0) cursorCol--;
                    break;
                case ConsoleKey.RightArrow:
                    if (cursorCol < net.GetLength(1) - 1) cursorCol++;
                    break;
                case ConsoleKey.Enter:
                    AttemptCut();
                    break;
            }

            if (prevRow != cursorRow || prevCol != cursorCol)
            {
                UpdateCursorPosition(prevRow, prevCol);
            }

            if (IsNetCut())
            {
                Console.SetCursorPosition(0, net.GetLength(0) + netRowStart + 2);
                Console.WriteLine("\nCongratulations! You've cut the entire net!");
                NavigationMinigameDone = true;
                break;
            }
        }
        while (key != ConsoleKey.Escape);

        Console.SetCursorPosition(0, net.GetLength(0) + netRowStart + 3);
        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();
    }

    static void InitializeFirstCutPosition()
    {
        for (int i = 0; i < net.GetLength(0); i++)
        {
            for (int j = 0; j < net.GetLength(1); j++)
            {
                if (net[i, j] == 'O')
                {
                    lastCutRow = i;
                    lastCutCol = j;
                    return;
                }
            }
        }
    }

    static void AttemptCut()
    {
        if (cursorRow == lastCutRow && cursorCol == lastCutCol && net[cursorRow, cursorCol] == 'O')
        {
            net[cursorRow, cursorCol] = 'o';
            Console.SetCursorPosition(cursorCol, cursorRow + netRowStart);
            Console.Write('o');
            FindNextCutPosition();
        }
        else if (net[cursorRow, cursorCol] == 'O')
        {
            Console.SetCursorPosition(0, net.GetLength(0) + netRowStart + 1);
            Console.WriteLine("You must cut the net in the correct order (top-to-bottom, left-to-right).");
        }
        else
        {
            Console.SetCursorPosition(0, net.GetLength(0) + netRowStart + 1);
            Console.WriteLine("There's nothing to cut here.");
        }
    }

    static void FindNextCutPosition()
    {
        for (int i = lastCutRow; i < net.GetLength(0); i++)
        {
            for (int j = (i == lastCutRow ? lastCutCol + 1 : 0); j < net.GetLength(1); j++)
            {
                if (net[i, j] == 'O')
                {
                    lastCutRow = i;
                    lastCutCol = j;
                    return;
                }
            }
        }

        lastCutRow = -1;
        lastCutCol = -1;
    }

    static void DisplayNet()
    {
        for (int i = 0; i < net.GetLength(0); i++)
        {
            Console.SetCursorPosition(0, i + netRowStart);
            for (int j = 0; j < net.GetLength(1); j++)
            {
                Console.Write(net[i, j]);
            }
            Console.WriteLine();
        }
        HighlightCursor();
    }

    static void UpdateCursorPosition(int prevRow, int prevCol)
    {
        Console.SetCursorPosition(prevCol, prevRow + netRowStart);
        Console.Write(net[prevRow, prevCol]);

        HighlightCursor();
    }

    static void HighlightCursor()
    {
        Console.SetCursorPosition(cursorCol, cursorRow + netRowStart);
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.Write(net[cursorRow, cursorCol]);
        Console.ResetColor();
    }

    static bool IsNetCut()
    {
        foreach (char c in net)
        {
            if (c == 'O') return false;
        }
        return true;
    }
}
  
    }

