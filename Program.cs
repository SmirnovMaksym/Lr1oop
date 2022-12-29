using Smirnov_Maxim_lr1;

namespace Smirnov_Maxim_lr1
{
    class Program
    {
        static void Main()
        {
            GetGame games = new GetGame();
            var game = games.Game();
            
            GameAccount Max = new OnlyWin("Max");
            GameAccount Zoe = new OnlyLose("Zoe");

            double rate = 20;
            
            //game.Play(Max, Zoe, -rate); // Rate < 0
            
            game.Play(Max, Zoe, rate);
            game.Play(Zoe, Max, rate);
            game.Play(Max, Zoe, rate);
            game.Play(Zoe, Max, rate);
            game.Play(Zoe, Max, rate);
            game.Play(Max, Zoe, rate);
            game.Play(Zoe, Max, rate);
            Max.GetStats();
            Zoe.GetStats();
            
            game.GetStats();
        }
    }
}