namespace WorldOfZuul;


public class Minigame
{
    public bool IsComplete = false;

    public Minigame() { }

    // if method is marked as virtual children of this class may override it 
    public virtual void Play() { }
    public virtual void Stop() { }
}