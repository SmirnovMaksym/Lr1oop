namespace Smirnov_Maxim_lr1;

public class GetGame
{
    public BaseGame Game()
    {
        return new Game();
    }
    
    public BaseGame NoRating()
    {
        return new NoRating();
    }
    
    public BaseGame NoStats()
    {
        return new NoStats();
    }
    
    public BaseGame ReverseOpponent()
    {
        return new ReverseOpponent();
    }
}