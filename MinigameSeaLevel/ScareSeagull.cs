namespace WorldOfZuul
{
    public class ScareSeagulls : Minigame
    {
        public override void Play()
        {
            Console.WriteLine("Seagulls often carry trash to other areas, spreading pollution further. Keeping them away from trash can help reduce waste.");
            Console.WriteLine("Choose the correct answer to scare the seagull away:");
            Console.WriteLine("What is the seagull spreading? [1] Plastic [2] Trash [3] Litter [4] Debris");

            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine("Fantastic job scaring the seagulls away! The area is now cleaner.");
                IsComplete = true;
            }
            else
            {
                Console.WriteLine("Incorrect. Try again.");
            }
        }
    }
}
