namespace WorldOfZuul;

public class TrashIsland : Minigame
{
    private bool continuePlaying = true;
    private bool isStopped = false;

    private int x = 3;
    private int y = 0;
    private int score = 0;

    private int winningScore = 20;
    private int turns = 20;

    private static class Icons
    {
        public const string Player = "🕺";
        public const string Background = "🟦";
        public const string Obstacle = "🗿";

        // Plus points
        public const string SpecialBarrel = "🛢️ ";
        public const string PlasticBag = "🛍️ ";
        public const string FishingHook = "🪝 ";
        public const string PlasticCup = "🥤";
        public const string Tire = "🛞 ";
        public const string Phone = "📱";

        // Minus points
        public const string Coral = "🪸 ";
        public const string SeaWeed = "🌱";
        public const string Bone = "🦴";
        public const string Shell = "🐚";
        public const string Wood = "🪵 ";
    }
    private Dictionary<string, int> itemScores;


    private string[,] map;

    public TrashIsland()
    {
        itemScores = new Dictionary<string, int>
            {
                { Icons.SpecialBarrel, 10 },
                { Icons.PlasticBag, 5 },
                { Icons.FishingHook, 4 },
                { Icons.PlasticCup, 3 },
                { Icons.Tire, 2 },
                { Icons.Phone, 1 },
                { Icons.Coral, -5 },
                { Icons.SeaWeed, -4 },
                { Icons.Bone, -3 },
                { Icons.Shell, -2 },
                { Icons.Wood, -1 }
            };

        // Initialize the map with icons
        map = new string[,] {
                { Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.Background },
                { Icons.Background, Icons.Shell, Icons.Background, Icons.Background, Icons.SpecialBarrel, Icons.Background, Icons.Background, Icons.Background },
                { Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.SeaWeed, Icons.Background, Icons.Background, Icons.Background },
                { Icons.Player, Icons.Background, Icons.Coral, Icons.Background, Icons.Background, Icons.PlasticCup, Icons.Background, Icons.Bone },
                { Icons.Background, Icons.Background, Icons.Background, Icons.Phone, Icons.Background, Icons.Background, Icons.Background, Icons.Background },
                { Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.Background },
                { Icons.Wood, Icons.Background, Icons.Background, Icons.PlasticBag, Icons.Background, Icons.Background, Icons.Tire, Icons.Background },
                { Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.FishingHook, Icons.Background, Icons.Background, Icons.Background }
            };
    }


    public override void Play()
    {
        continuePlaying = true;

        GenerateMap();

        turns = 20;
        score = 0;

        while (continuePlaying)
        {

            Console.Clear();

            Console.WriteLine("You have decided to stop the growth of the trash island by collecting incoming junk!");
            Console.WriteLine();


            Console.WriteLine("Icon guide:");
            Console.WriteLine($"{Icons.Player} - Player, {Icons.Background} - Empty space, {Icons.Obstacle} - Obstacle, Other icons - Collectible Items");
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

    public override void Stop()
    {
        continuePlaying = false;
        isStopped = true;
    }

    private void GenerateMap()
    {
        map = new string[,]
        {
        { Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.Background },
        { Icons.Background, Icons.Shell, Icons.Background, Icons.Background, Icons.SpecialBarrel, Icons.Background, Icons.Background, Icons.Background },
        { Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.SeaWeed, Icons.Background, Icons.Background, Icons.Background },
        { Icons.Player, Icons.Background, Icons.Coral, Icons.Background, Icons.Background, Icons.PlasticCup, Icons.Background, Icons.Bone },
        { Icons.Background, Icons.Background, Icons.Background, Icons.Phone, Icons.Background, Icons.Background, Icons.Background, Icons.Background },
        { Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.Background },
        { Icons.Wood, Icons.Background, Icons.Background, Icons.PlasticBag, Icons.Background, Icons.Background, Icons.Tire, Icons.Background },
        { Icons.Background, Icons.Background, Icons.Background, Icons.Background, Icons.FishingHook, Icons.Background, Icons.Background, Icons.Background }
        };

        // Reset player position
        x = 3;
        y = 0;
    }

}