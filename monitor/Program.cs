using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace monitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the name of the process you want to monitor: ");
            string name = Console.ReadLine();
            Console.Write("Please enter the name of the lifespan in minutes: ");
            int lifespan = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the name of the frequency in minutes: ");
            int freq = Convert.ToInt32(Console.ReadLine());

            Thread checkThread = new Thread(() =>
            {
                Check check = new Check(name, lifespan);
                check.Monitor(freq);
            });
            checkThread.Start();
            
            while (Console.ReadKey().KeyChar!='q')
            {
                continue;
            }
            checkThread.Abort();
        }
    }
}
