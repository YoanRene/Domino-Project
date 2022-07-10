using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project;

namespace Visual_Interface
{
    class DistributionForm:IForm
    {
        List<IPrinteable> PrinteablesToPlay { get; } = new List<IPrinteable>();
        IPrinteable[] Printeables { get; }
        public DistributionForm(List<IPrinteable> printablesToPlay, IPrinteable[] printeables)
        {
            Printeables = printeables;
        }
        public void Show()
        {
            Console.Clear();
            for (int i = 0; i < Printeables.Length; i++)
            {
                Console.WriteLine(i + 1 + " - " + Printeables[i].Print());
            }
            Console.WriteLine(Printeables.Length + 1 + " - Back");

            string key = Console.ReadLine();
            bool isOkKey = false;

            

            for (int i = 0; i < Printeables.Length; i++)
            {
                if (key == (i + 1).ToString())
                {
                    isOkKey = true;
                    PrinteablesToPlay.Add(Printeables[i]);
                    break;
                }
            }
            if (key == (Printeables.Length + 1).ToString())
            {
                IForm mainForm = new MainForm();
                mainForm.Show();
            }
            else if (!isOkKey)
            {
                Console.Clear();
                Console.WriteLine("The key is incorrect");
                Console.WriteLine("Try Again");
                Thread.Sleep(2000);
                Show();
            }
            else
            {

            }
        }

    }

}
