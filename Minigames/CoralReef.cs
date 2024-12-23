using System.Collections;

namespace WorldOfZuul;

//add a delay between correct/incorrect and the next question
//add a typing animation

public class CoralReef : Minigame
{


    public CoralReef() { }

    public override void Play()
    {

        Console.WriteLine("KOKOT");
        var triviaQuestions = new List<(string question, string answer)>{
            ("Where are most coral reefs located globally? \n a: On the equator \n b: In deep oceans \n c: Southeast Asia \n d: Between 30° north and south of the equator ", "d"),
            ("Which temperature is ideal for coral growth? \n a: 20°C \n b: Over 30°C \n c: 25°C \n d: 35°C ", "c"),
            ("Where is the world's largest coral reef found? \n a: Indonesia \n b: Cayman Islands \n c: Australia \n d: Philippines", "c"),
            ("Why are coral reefs valuable? \n a: They provide stock for the fishing industry \n b: They provide shelter to land from tropical storms \n c: They are home to a quarter of all global marine life \n d: All of the above", "d"),
            ("Which of the following is not sustainable? \n a: Dynamite fishing \n b: Education \n c: Marine Protected Areas \n d: No Wake Zones", "a"),
            ("Which is most likely to happen if water temperatures rise? \n a: Coral growth increases \n b: Coral bleaching occurs \n c: Corals change colour \n d: Corals can't photosynthesize", "b"),
            ("Which is the main cause of ocean acidification, which harms coral reefs? \n a: Overfishing \n b: Oil spills \n c: Too much CO2 in the atmosphere \n d: Plastic pollution", "c"),
            ("How many of the worlds coral reefs are at risk of extinction due to global warming? \n a: Over 20% \n b: Over 30% \n c: Over 40% \n d: None", "c")
        };

        string UserAnswer;
        int CoralPoints = 0;
        float TestResult;

        foreach (var level in triviaQuestions)
        {
            TypeSlow(level.question, 10);
            Console.Write("> ");

            UserAnswer = Console.ReadLine();

            if (UserAnswer == level.answer)
            {
                CoralPoints++;
                TypeSlow("Correct! Good job.", 15);
                Console.WriteLine();
            }
            else
            {
                TypeSlow("Oops, wrong answer.", 15);
                Console.WriteLine();
            }
        }

        if (CoralPoints == triviaQuestions.Count)
        {
            TypeSlow("All correct! You win!!", 15);
            IsComplete = true;
            Console.WriteLine();
        }
        else
        {
            TestResult = (float)CoralPoints / (float)triviaQuestions.Count * 100;
            TypeSlow($"You did not answer everything correctly ({TestResult}%) try again.", 15);
            Console.WriteLine();
        }
    }


    public static void TypeSlow(string ToType, int TypeDelay)
    {
        foreach (var character in ToType)
        {
            Console.Write(character);
            Thread.Sleep(TypeDelay);
        }
        Console.WriteLine();
    }
}