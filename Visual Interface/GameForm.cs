using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project;

namespace Visual_Interface
{
    class GameForm:IForm
    {
        Game game { get; }
        IStrategy[] strategies { get; }

        public GameForm(List<IPrinteable> printeables,List<Player> players)
        {
            game = new Game((IDistribution)printeables[0], (IEndGame)printeables[1], (IEndRound)printeables[2], 
                            (IScoreCalculator)printeables[3], (IFirstPlayer)printeables[4],
                            (IStep)printeables[5], (IActionModeratorToAdd)printeables[6], 
                            (IActionModeratorToSub)printeables[7],(ITokensGenerator)printeables[8], players);
            strategies = new IStrategy[] {new IntelligentStrategy(),
                                          new IntelligentBotagordaStrategy(),
                                          new IntelligentRandomStrategy(),
                                          new BotagordaStrategy(),
                                          new RandomStrategy()};
        }
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("What strategy do you want to play now?");
            for (int i = 0; i < strategies.Length; i++)
            {
                Console.WriteLine(i+1+" - "+strategies[i].Print());
            }

            Console.WriteLine();
            Console.WriteLine("Other Options:");
            Console.WriteLine(strategies.Length+1+" - Play Random To The End");
            Console.WriteLine(strategies.Length+2+" - Back");
            Console.WriteLine();
            Console.WriteLine(game.Table_);

            bool strategyIsSelected = false;
            IStrategy strategy = new RandomStrategy();
            string key = Console.ReadLine();
            for (int i = 0; i < strategies.Length; i++)
            {
                if((i+1).ToString()==key)
                {
                    strategyIsSelected = true;
                    strategy = strategies[i];
                    break;
                }
            }
            if (strategyIsSelected|| (strategies.Length + 1).ToString() == key)
            {
                if(game.Play(strategy))
                    Show();
            }
            else if((strategies.Length + 1).ToString() == key)
            {
                while (game.Play(strategy))
                {
                    Thread.Sleep(1000);
                }
            }
            else if((strategies.Length + 2).ToString() == key)
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("The key is incorrect");
                Console.WriteLine("Try Again");
                Thread.Sleep(2000);
                Show();
            }
        }
    }
}
