using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace monitor
{
    class Check
    {
        private int _lifespan;
        private string _name;
        public Check(string name, int lifespan)
        {
            _name = name;
            _lifespan = lifespan;
        }
        public void CheckAndKill()
        {
            Process[] processes = Process.GetProcessesByName(_name);
            foreach(Process process in processes)
            {
                Console.WriteLine(process.Id + " " + process.MainWindowTitle + " " + process.StartTime.ToString());
                DateTime startTime = process.StartTime;
                TimeSpan delta = DateTime.Now.Subtract(startTime);
                if (delta.Minutes >= _lifespan)
                {
                    process.Kill();
                    Console.WriteLine("Process killed");
                }
            }
        }
        public void Monitor(int freq)
        {
            while(true)
            {
                CheckAndKill();
                Thread.Sleep(1000 * 60 * freq);
            }
        }
    }
}
