using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project;

namespace Visual_Interface
{
    interface IForm
    {
        void Show();
    }
    class MainForm : IForm
    {
        IDistribution[] distributions;
        
        public MainForm()
        {
            distributions = new IDistribution[] { new ClassicDistributionTen(),new DoublesToTrashDistribution()};
        }
        public void Show()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ||||     ||||||    ||||  ||||    |||    ||||  ||    ||||||");
            Console.WriteLine(" ||  ||   ||  ||    || |||| ||    |||    || || ||    ||  ||");
            Console.WriteLine(" ||||     ||||||    ||  ||  ||    |||    ||  ||||    ||||||");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("1 - Classic Game");
            Console.WriteLine("2 - Custom Game");

            string key = Console.ReadLine();

            List<Player> players = new List<Player>();
            players.Add(new Player("Player1", new List<Player>()));
            players.Add(new Player("Player2", new List<Player>()));
            players.Add(new Player("Player3", new List<Player>()));
            players.Add(new Player("Player4", new List<Player>()));

            List<IPrinteable> printeables = new List<IPrinteable>();

            if (key == "1")
            {
                //(IDistribution)printeables[0], (IEndGame)printeables[1], (IEndRound)printeables[2], 
                //            (IScoreCalculator)printeables[3], (IFirstPlayer)printeables[4],
                //            (IStep)printeables[5], (IActionModeratorToAdd)printeables[6], 
                //            (IActionModeratorToSub)printeables[7], players);

                printeables.Add(new ClassicDistributionTen());
                printeables.Add(new ClassicEndGame());
                printeables.Add(new ClassicEndRound());
                printeables.Add(new ScoreCalculatorA());
                printeables.Add(new FirstPlayerA());
                printeables.Add(new ClassicStep());
                printeables.Add(new ClassicActionToAdd());
                printeables.Add(new ClassicActionToSub());
                printeables.Add(new Generator_9_Variant());

                GameForm gameForm = new GameForm(printeables, players);
                gameForm.Show();
            }

            else if (key == "2")
            {
                DistributionForm distributionForm = new DistributionForm(printeables, distributions);
                distributionForm.Show();
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
