using System.Collections.Concurrent;
using System.Dynamic;
using System.Numerics;
using System.Transactions;
using WorldOfZuul;



public class NuclearAccident : Minigame
{
    public override void Play()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        MazeClass maze = new MazeClass();
        maze.Maze = new bool[,] {
        {false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false},
    {false, true,  true,  false, true,  true,  true,  true,  false, true,  true,  true,  false, true,  true,  false},
    {false, false, true,  false, true,  false, false, true,  false, true,  false, true,  false, false, true,  false},
    {false, true,  true,  false, true,  false, true,  true,  false, true,  false, true,  true,  false, true,  false},
    {false, true,  false, false, true,  false, false, false, false, true,  false, false, true,  false, true,  false},
    {false, true,  true,  true,  true,  true,  true,  true,  false, true,  true,  false, true,  true,  true,  false},
    {false, false, false, false, false, false, false, true,  false, false, true,  false, false, false, true,  false},
    {false, true,  true,  true,  true,  true,  false, true,  true,  false, true,  true,  true,  false, true,  false},
    {false, true,  false, true, false, true,  false, false, true,  false, false, false, true,  false, true,  false},
    {false, true,  false, true,  false, true,  true,  false, true,  true,  true,  false, true,  false, true,  false},
    {false, true,  false, true,  false, false, true,  false, false, false, true,  false, true,  true,  true,  false},
    {false, true,  false, true,  true,  false, true,  true,  true,  false, true,  false, false, false, true, false},
    {false, true,  false, false, true,  false, false, false, true,  false, true,  true,  true,  false, true,  false},
    {false, true,  true,  false, true,  true,  true,  false, true,  false, false, false, true,  true,  true,  false},
    {false, false, true,  false, false, false, true,  false, true,  true,  true,  false, false, false, true, false},
    {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false}

};
        Mechanics obj = new Mechanics(maze);
        int[] finalPosition = new int[] { 0, 1 };
        obj.currentPosition = new int[] { 14, 14 };
        Console.WriteLine("Hello Player. There was a nuclear leak in the plant that is heading towards the ocean, which could result in the disaster. In order to prevent it, you have to navigate towards the control panel in the main block to shut down the gate.");
        Console.WriteLine("Your position in the plant is determined by X");
        while (ArraysEqual(finalPosition, obj.currentPosition) == false)
        {
            Console.WriteLine("Enter a W/A/S/D symbol to move");
            obj.DisplayMaze();
            String? result = Console.ReadLine();
            if (result == "W" || result == "w")
            {
                obj.Up();
            }
            else if (result == "S" || result == "s")
            {
                obj.Down();
            }
            else if (result == "A" || result == "a")
            {
                obj.Left();
            }
            else if (result == "D" || result == "d")
            {
                obj.Right();
            }
            else
            {
                Console.WriteLine("Plese enter correct key");
            }
        }
        Console.WriteLine("You now found the Main control room");
        Console.WriteLine("Press the red button to close the gate type \"press\"");
        string? inp = Console.ReadLine();
        if (string.Equals(inp, "Press", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Congratualations! You successfully completed the level");
            IsComplete = true;
        }
        else
        {
            Console.WriteLine("Please enter \"press\"");
        }
    }

    static bool ArraysEqual(int[] a, int[] b)
    {
        if (a[0] == b[0] && a[1] == b[1])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class Mechanics
{
    MazeClass maze2;
    public Mechanics(MazeClass maze)
    {
        maze2 = maze;
    }

    public int[] currentPosition { get; set; } = null!;

    public int[] Up()
    {
        int row = currentPosition[0];
        int column = currentPosition[1];
        int[] TargetPosition = new int[] { row - 1, column };
        if (maze2.Maze[row - 1, column] == true)
        {
            currentPosition = TargetPosition;
            Console.WriteLine("You moved up");
            return currentPosition;

        }
        else
        {
            Console.WriteLine("You hit the wall");
            return currentPosition;
        }
    }

    public void Down()
    {
        int row = currentPosition[0];
        int column = currentPosition[1];
        int[] TargetPosition = new int[] { row + 1, column };
        if (maze2.Maze[row + 1, column] == true)
        {
            currentPosition = TargetPosition;
            Console.WriteLine("You moved down");
        }
        else
        {
            Console.WriteLine("You hit the wall");
        }
    }

    public int[] Left()
    {
        int row = currentPosition[0];
        int column = currentPosition[1];
        int[] TargetPosition = new int[] { row, column - 1 };
        if (maze2.Maze[row, column - 1] == true)
        {
            currentPosition = TargetPosition;
            Console.WriteLine("You moved left");
            return currentPosition;

        }
        else
        {
            Console.WriteLine("You hit the wall");
            return currentPosition;
        }
    }

    public int[] Right()
    {
        int row = currentPosition[0];
        int column = currentPosition[1];
        int[] TargetPosition = new int[] { row, column + 1 };
        if (maze2.Maze[row, column + 1] == true)
        {
            currentPosition = TargetPosition;
            Console.WriteLine("You moved right");
            return currentPosition;

        }
        else
        {
            Console.WriteLine("You hit the wall");
            return currentPosition;
        }
    }

    public void DisplayMaze()
    {
        for (int row = 0; row < maze2.Maze.GetLength(0); row++)
        {
            for (int col = 0; col < maze2.Maze.GetLength(1); col++)
            {
                if (currentPosition[0] == row && currentPosition[1] == col)
                {
                    Console.Write("X ");
                }
                else
                {
                    string result = maze2.Maze[row, col] ? "◻ " : "◼ ";
                    Console.Write(result);
                }

            }
            Console.WriteLine();
        }
    }
}

public class MazeClass
{
    private bool[,] maze = new bool[5, 5];
    public bool[,] Maze
    {
        get { return maze; }
        set { maze = value; }
    }
}

