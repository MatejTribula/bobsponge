namespace WorldOfZuul
{
    public class PickTrash : Minigame
    {
        private int trashCollected = 0;

        public override void Play()
        {
            Console.WriteLine("Did you know that every year, millions of tons of plastic enter the oceans, harming marine animals and ecosystems?");
            while (trashCollected < 10)
            {
                Console.WriteLine($"Press 'enter' to pick trash. Total trash cleaned: {trashCollected}.");
                Console.ReadLine();
                trashCollected++;
            }
            Console.WriteLine("All trash collected! Small actions make a big difference.");
            IsComplete = true;
        }
    }
}
