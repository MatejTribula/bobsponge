namespace WorldOfZuul;

public class KnotUntanglingMinigame : Minigame
{
    private bool quit = false;
    private int currentKnot = 0;
    private int wrongMoves = 0;
    private const int maxWrongMoves = 1;
    private static readonly string[] knots = { "Top", "Middle", "Bottom" };

    public KnotUntanglingMinigame()
    {
        IsComplete = false;
    }

    public override void Play()
    {
        if (IsComplete)
        {
            Console.WriteLine("You have already completed this minigame!");
            return;
        }

        Console.WriteLine("Welcome to the Knot Untangling Minigame!");
        Console.WriteLine("Marine life often gets trapped in ghost nets, and untangling them is vital for conservation.");
        Console.WriteLine("Your task is to untangle the knots in the correct order: Top, Middle, Bottom.");
        Console.WriteLine("You can only make one mistake. Type 'q' at any time to quit.\n");

        while (currentKnot < knots.Length && wrongMoves <= maxWrongMoves && !quit)
        {
            Console.Write("Enter the name of the knot to untangle (Top/Middle/Bottom): ");
            string input = Console.ReadLine()?.Trim();

            if (input?.ToLower() == "q")
            {
                quit = true;
                break;
            }

            if (string.Equals(input, knots[currentKnot], StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Correct! {knots[currentKnot]} knot untangled successfully.\n");
                currentKnot++;
            }
            else
            {
                wrongMoves++;
                Console.WriteLine(wrongMoves > maxWrongMoves
                    ? "Too many mistakes! You've damaged the surrounding marine life."
                    : "Wrong move! You can only make one more mistake.\n");
            }
        }

        if (!quit && currentKnot == knots.Length)
        {
            Console.WriteLine("Congratulations! You've successfully untangled all the knots!");
            IsComplete = true;
        }
        else if (!quit)
        {
            Console.WriteLine("Better luck next time! Try again.");
        }
    }

    public override void Stop()
    {
        quit = true;
        Console.WriteLine("You have exited the Knot Untangling Minigame.");
    }
}
public class NetCuttingMinigame : Minigame
{
    private bool quit = false;
    private char[,] net = {
        { 'o', 'o', 'o', 'o', 'O', 'o', 'o', 'o', 'o', 'o', 'o' },
        { 'o', 'o', 'o', 'o', 'o', 'O', 'o', 'o', 'o', 'o', 'o' },
        { 'o', 'o', 'o', 'o', 'o', 'O', 'o', 'o', 'o', 'o', 'o' },
        { 'o', 'o', 'o', 'o', 'O', 'O', 'O', 'o', 'o', 'o', 'o' },
        { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'O', 'o', 'o' },
        { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'O', 'o', 'o' }
    };

    private int cursorRow = 0;
    private int cursorCol = 0;
    private int lastCutRow = 0;
    private int lastCutCol = 0;
    private const int netRowStart = 2;

    public NetCuttingMinigame()
    {
        IsComplete = false;
    }

    public override void Play()
    {
        if (IsComplete)
        {
            Console.WriteLine("You have already completed this minigame!");
            return;
        }

        Console.Clear();
        Console.WriteLine("You found the net blocking the way to the chest. Press [Enter] to start cutting it!");
        Console.WriteLine("Press [Arrow Keys] to move and [Enter] to cut. Press [Esc] to quit.\n");
        Console.ReadKey();

        InitializeFirstCutPosition();
        DisplayNet();

        while (!IsNetCut() && !quit)
        {
            var prevRow = cursorRow;
            var prevCol = cursorCol;

            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow when cursorRow > 0:
                    cursorRow--;
                    break;
                case ConsoleKey.DownArrow when cursorRow < net.GetLength(0) - 1:
                    cursorRow++;
                    break;
                case ConsoleKey.LeftArrow when cursorCol > 0:
                    cursorCol--;
                    break;
                case ConsoleKey.RightArrow when cursorCol < net.GetLength(1) - 1:
                    cursorCol++;
                    break;
                case ConsoleKey.Enter:
                    AttemptCut();
                    break;
                case ConsoleKey.Escape:
                    quit = true;
                    break;
            }

            if (prevRow != cursorRow || prevCol != cursorCol)
                UpdateCursorPosition(prevRow, prevCol);
        }

        if (IsNetCut())
        {
            Console.SetCursorPosition(0, net.GetLength(0) + netRowStart + 1);
            Console.WriteLine("Congratulations! You've successfully cut the net!");
            IsComplete = true;
        }
        else
        {
            Console.SetCursorPosition(0, net.GetLength(0) + netRowStart + 1);
            Console.WriteLine("You have exited the minigame without completing it.");
        }
    }

    public override void Stop()
    {
        quit = true;
        Console.WriteLine("You have exited the Net Cutting Minigame.");
    }

    private void InitializeFirstCutPosition()
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

    private void AttemptCut()
    {
        if (cursorRow == lastCutRow && cursorCol == lastCutCol && net[cursorRow, cursorCol] == 'O')
        {
            net[cursorRow, cursorCol] = 'o';
            Console.SetCursorPosition(cursorCol, cursorRow + netRowStart);
            Console.Write('o');
            FindNextCutPosition();
        }
        else
        {
            Console.SetCursorPosition(0, net.GetLength(0) + netRowStart + 1);
            Console.WriteLine("Cut the net in the correct order (top-to-bottom, left-to-right).");
        }
    }

    private void FindNextCutPosition()
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
    }

    private void DisplayNet()
    {
        for (int i = 0; i < net.GetLength(0); i++)
        {
            Console.SetCursorPosition(0, i + netRowStart);
            for (int j = 0; j < net.GetLength(1); j++)
            {
                Console.Write(net[i, j]);
            }
        }
        HighlightCursor();
    }

    private void UpdateCursorPosition(int prevRow, int prevCol)
    {
        Console.SetCursorPosition(prevCol, prevRow + netRowStart);
        Console.Write(net[prevRow, prevCol]);

        HighlightCursor();
    }

    private void HighlightCursor()
    {
        Console.SetCursorPosition(cursorCol, cursorRow + netRowStart);
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.Write(net[cursorRow, cursorCol]);
        Console.ResetColor();
    }

    private bool IsNetCut()
    {
        foreach (char c in net)
        {
            if (c == 'O') return false;
        }
        return true;
    }
}
