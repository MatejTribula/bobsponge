namespace WorldOfZuul;

public class NPC
{
    public string Name;
    private string greeting;
    public List<string> Questions { get; } = new();
    private List<string> answers = new();

    public NPC(string name, string greeting)
    {
        this.Name = name;
        this.greeting = greeting;
    }

    public void Talk(int input)
    {
        var index = input - 1;

        Console.WriteLine($"{Name}: {answers[index]}");
    }

    public void AddQA(string question, string answer)
    {
        Questions.Add(question);
        answers.Add(answer);
    }

    public void ShowQuestions()
    {
        for (int i = 0; i < Questions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Questions[i]}");
        }
    }

    public void PrintGreeting()
    {
        Console.WriteLine($"{Name}: {greeting}");
    }

}