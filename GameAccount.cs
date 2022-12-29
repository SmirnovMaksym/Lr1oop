namespace Smirnov_Maxim_lr1;

public class GameAccount
{
    public class GameAccountStats
    {
        private string opponentName;

        public string NameOpponent
        {
            get { return opponentName; }
        }

        public bool Win
        {
            get { return win; }
        }

        public double Rate
        {
            get { return rate; }
        }
        private double rate;
        private bool win;

        public GameAccountStats(string opponentName, double rate, bool win)
        {
            this.opponentName = opponentName;
            this.rate = rate;
            this.win = win;
        }
    }

    protected List<GameAccountStats> stats = new List<GameAccountStats>();
    protected string UserName;
    protected double CurrentRating = 1000;
    protected int GamesCount = 0;

    public GameAccount(string UserName)
    {
        this.UserName = UserName;
    }
    public GameAccount()
    {
        UserName = "UserName";
    }

    public double UseCurrentRating
    {
        get { return CurrentRating; }
        set { CurrentRating = value; }
    }
    public string UseUserName
    {
        get { return UserName; }
    }

    public virtual void WinGame(BaseGame game)
    { 
        if (game.stats.Count != 0)
        {
            CurrentRating += game.stats[^1].Rate;
            stats.Add(new GameAccountStats(game.stats[^1].Loser, game.stats[^1].Rate, true));
        }
        GamesCount += 1;
    }

    public virtual void LoseGame(BaseGame game)
    {
        if (game.stats.Count != 0)
        {
            CurrentRating -= game.stats[^1].Rate;
            stats.Add(new GameAccountStats(game.stats[^1].Winner, game.stats[^1].Rate, false));
        }
        GamesCount += 1;
    }

    public void GetStats()
    {
        Console.WriteLine("{0} rate {1}  {2} games played", UserName, CurrentRating, GamesCount);
        for (int i = 0; i < stats.Count; i++)
        {
            if (stats[i].Win)
            {
                Console.WriteLine("\tgame {0} win. Opponent: {1}. Rate {2}", i + 1, stats[i].NameOpponent, stats[i].Rate);
            }
            else
            {
                Console.WriteLine("\tgame {0} lose. Opponent: {1}. Rate {2}", i + 1, stats[i].NameOpponent, stats[i].Rate);
            }
        }
    }
}

public class OnlyWin : GameAccount
{
    public OnlyWin(string UserName)
    {
        this.UserName = UserName;
    }
    
    public override void LoseGame(BaseGame game)
    {
        GamesCount += 1;
        if (game.stats.Count != 0)
        {
            stats.Add(new GameAccountStats(game.stats[^1].Winner, 0, false));
        }
    }
}

public class OnlyLose : GameAccount
{
    public OnlyLose(string UserName)
    {
        this.UserName = UserName;
    }
    
    public override void WinGame(BaseGame game)
    {
        GamesCount += 1;
        if (game.stats.Count != 0)
        {
            stats.Add(new GameAccountStats(game.stats[^1].Loser, 0, true));
        }
    }
}

public class Intangible : GameAccount
{
    public Intangible(string UserName)
    {
        this.UserName = UserName;
    }
    
    public override void WinGame(BaseGame game)
    {
        GamesCount += 1;
        if (game.stats.Count != 0)
        {
            stats.Add(new GameAccountStats(game.stats[^1].Loser, 0, true));
        }
    }
    public override void LoseGame(BaseGame game)
    {
        GamesCount += 1;
        if (game.stats.Count != 0)
        {
            stats.Add(new GameAccountStats(game.stats[^1].Winner, 0, false));
        }
    }
}