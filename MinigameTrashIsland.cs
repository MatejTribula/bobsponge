namespace WorldOfZuul;

public class MinigameTrashIsland : Minigame
{
    private bool continuePlaying = true;
    private bool isStopped = false;

    private int x = 3;
    private int y = 0;
    private int score = 0;

    private int winningScore = 20;
    private int turns = 20;

    // General icons
    private string playerIcon = "🕺";
    private string backgroundIcon = "🟦";
    private string obstacleIcon = "🗿";

    // Plus points
    private string specialBarellIcon = "🛢️ "; // +10
    private string plasticBagIcon = "🛍️ "; // +5
    private string fishingHookIcon = "🪝 "; // +4
    private string plasticCupIcon = "🥤"; // +3
    private string tireIcon = "🛞 "; // +2
    private string phoneIcon = "📱"; // +1

    // Minus points
    private string coralIcon = "🪸 "; // -5
    private string seaWeedIcon = "🌱"; // -4
    private string boneIcon = "🦴"; // -3
    private string shellIcon = "🐚"; // -2
    private string woodIcon = "🪵 "; // -1

    private Dictionary<string, int> itemScores;


    private string[,] map;

    public MinigameTrashIsland()
    {
        itemScores = new Dictionary<string, int>
            {
                { specialBarellIcon, 10 },
                { plasticBagIcon, 5 },
                { fishingHookIcon, 4 },
                { plasticCupIcon, 3 },
                { tireIcon, 2 },
                { phoneIcon, 1 },
                { coralIcon, -5 },
                { seaWeedIcon, -4 },
                { boneIcon, -3 },
                { shellIcon, -2 },
                { woodIcon, -1 }
            };

        map = new string[,] {
                { backgroundIcon, backgroundIcon, backgroundIcon, backgroundIcon, backgroundIcon, backgroundIcon, backgroundIcon, backgroundIcon },
                { backgroundIcon, shellIcon, backgroundIcon, backgroundIcon, specialBarellIcon, backgroundIcon, backgroundIcon, backgroundIcon },
                { backgroundIcon, backgroundIcon, backgroundIcon, backgroundIcon, seaWeedIcon, backgroundIcon, backgroundIcon, backgroundIcon },
                { playerIcon, backgroundIcon, coralIcon, backgroundIcon, backgroundIcon, plasticCupIcon, backgroundIcon, boneIcon },
                { backgroundIcon, backgroundIcon, backgroundIcon, phoneIcon, backgroundIcon, backgroundIcon, backgroundIcon, backgroundIcon },
                { backgroundIcon, backgroundIcon, backgroundIcon, backgroundIcon, backgroundIcon, backgroundIcon, backgroundIcon, backgroundIcon },
                { woodIcon, backgroundIcon, backgroundIcon, plasticBagIcon, backgroundIcon, backgroundIcon, tireIcon, backgroundIcon },
                { backgroundIcon, backgroundIcon, backgroundIcon, backgroundIcon, fishingHookIcon, backgroundIcon, backgroundIcon, backgroundIcon },
            };
    }


    public override void Play()
    {
        continuePlaying = true;
        turns = 20;
        score = 0;

        while (continuePlaying)
        {

            Console.Clear();

            Console.WriteLine("You have decided to stop the growth of the trash island by collecting incoming junk!");
            Console.WriteLine();


            Console.WriteLine("Icon guide:");
            Console.WriteLine($"{playerIcon} - Player, {backgroundIcon} - Empty space, {obstacleIcon} - Obstacle, Other icons - Collectible Items");
            Console.WriteLine();

            Console.WriteLine("Objective:");
            Console.WriteLine($"Collect harmful items to earn points. To win you will need to have score of at least: {winningScore}!");

            Console.WriteLine();


            // print the whole map in the console -> loop first through columns of one row and move to another one
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine($"TURNS: {turns}  SCORE: {score}");
            Console.WriteLine();

            Console.WriteLine("Input");
            Console.WriteLine("Use ARROW keys to move. Any other input will stop the game.");

            ConsoleKey key = Console.ReadKey(true).Key;
            int newX = x, newY = y;

            // min -> is actually max number of rows/columns
            // max -> is the last index thus 0
            if (key == ConsoleKey.UpArrow) newX = Math.Max(0, x - 1);
            else if (key == ConsoleKey.DownArrow) newX = Math.Min(7, x + 1);
            else if (key == ConsoleKey.LeftArrow) newY = Math.Max(0, y - 1);
            else if (key == ConsoleKey.RightArrow) newY = Math.Min(7, y + 1);
            else Stop();

            // IF INPUT IS DIFFERENT STOP EXECUTION OF MINIGAME ->


            // interaction logic will be here:
            if (itemScores.ContainsKey(map[newX, newY]))
            {
                score += itemScores[map[newX, newY]];
                Console.WriteLine($"This is your current score: {score}");
            }


            // replaces icons on the map
            map[x, y] = "🟦";
            x = newX;
            y = newY;
            map[x, y] = "🕺";


            turns--;

            if (turns == 0)
            {
                continuePlaying = false;
            }
        }

        Console.Clear();
        if (isStopped)
        {
            Console.WriteLine("You have stopped completing the minigmae");
            return;
        }
        if (score >= winningScore)
        {
            IsComplete = true;
            Console.WriteLine("Congratulations! you have successfully completed the minigame!");
            return;
        }
        else Console.WriteLine("You have failed to complete the goal.");

    }

    private void Stop()
    {
        continuePlaying = false;
        isStopped = true;
    }
}