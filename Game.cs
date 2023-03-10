using System.ComponentModel.DataAnnotations;

namespace Smirnov_Maxim_lr1;

public abstract class BaseGame
{
    protected int GamesCount = 0;

    public class GameStats
    {
        private string winner;

        public string Winner
        {
            get { return winner; }
        }
        private string loser;
        
        public string Loser
        {
            get { return loser; }
        }
        private double rate;

        public double Rate
        {
            get { return rate; }
        }
        public GameStats(string winner, string loser, double rate)
        {
            this.winner = winner;
            this.loser = loser;
            this.rate = rate;
        }
    }

    public List<GameStats> stats = new List<GameStats>();
    public abstract void Play(GameAccount winner, GameAccount loser, double rate);

    public void GetStats()
    {
        Console.WriteLine("|\tWinner\t|\tLoser\t|\tRate\t|");
        for (int i = 0; i < stats.Count; i++)
        {
            Console.WriteLine("|\t{0}\t|\t{1}\t|\t{2}\t|", stats[i].Winner, stats[i].Loser, stats[i].Rate);
        }
        
    }
}
public class Game : BaseGame
{
    public override void Play(GameAccount winner, GameAccount loser, double rate)
    {
        if (rate < 0)
        {
            throw new Exception("Rate < 0");
        }

        if (loser.UseCurrentRating - rate > 0)
        {
            stats.Add(new GameStats(winner.UseUserName, loser.UseUserName, rate));
            winner.WinGame(this);
            loser.LoseGame(this);
            
            GamesCount += 1;
        }
        else
        {
            throw new Exception("Loser rate - Rate <= 0");
        }
    }
}

public class ReverseOpponent : BaseGame
{
    public override void Play(GameAccount winner, GameAccount loser, double rate)
    {
        if (rate < 0)
        {
            throw new Exception("Rate < 0");
        }

        if (loser.UseCurrentRating - rate > 0)
        {
            stats.Add(new GameStats(loser.UseUserName, winner.UseUserName, rate));
            loser.WinGame(this);
            winner.LoseGame(this);
            
            GamesCount += 1;
        }
        else
        {
            throw new Exception("Loser rate - Rate <= 0");
        }
    }
}

public class NoRating : BaseGame
{
    public override void Play(GameAccount winner, GameAccount loser, double rate)
    {
        if (rate < 0)
        {
            throw new Exception("Rate < 0");
        }

        if (loser.UseCurrentRating - rate > 0)
        {
            stats.Add(new GameStats(winner.UseUserName, loser.UseUserName, 0));
            loser.WinGame(this);
            winner.LoseGame(this);
            
            GamesCount += 1;
        }
        else
        {
            throw new Exception("Loser rate - Rate <= 0");
        }
    }
}

public class NoStats : BaseGame
{
    public override void Play(GameAccount winner, GameAccount loser, double rate)
    {
        if (rate < 0)
        {
            throw new Exception("Rate < 0");
        }

        if (loser.UseCurrentRating - rate > 0)
        {
            loser.WinGame(this);
            winner.LoseGame(this);
            GamesCount += 1;
        }
        else
        {
            throw new Exception("Loser rate - Rate <= 0");
        }
    }
}
