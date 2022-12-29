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

    private List<GameAccountStats> stats = new List<GameAccountStats>();
    private string UserName;
    private double CurrentRating = 1000;
    private int GamesCount = 0;

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

    public void WinGame(string opponentName, double rate)
    { 
        CurrentRating += rate;
        GamesCount += 1;
        stats.Add(new GameAccountStats(opponentName, rate, true));
    }

    public void LoseGame(string opponentName, double rate)
    {
        CurrentRating -= rate;
        GamesCount += 1;
        stats.Add(new GameAccountStats(opponentName, rate, false));
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