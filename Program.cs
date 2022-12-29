using Smirnov_Maxim_lr1;

namespace Smirnov_Maxim_lr1
{
    class Program
    {
        static void Main()
        {
            Game game = new Game();
            
            GameAccount Max = new GameAccount("Max");
            GameAccount Zoe = new GameAccount("Zoe");

            double rate = 20;
            
            //game.Play(Max, Zoe, -rate); // Rate < 0
            
            game.Play(Max, Zoe, rate);
            game.Play(Zoe, Max, rate);
            game.Play(Max, Zoe, rate);
            game.Play(Zoe, Max, rate);
            game.Play(Max, Zoe, rate);
            game.Play(Zoe, Max, rate);
            Max.GetStats();
            Zoe.GetStats();
            
            game.GetStats();
        }
    }
}
