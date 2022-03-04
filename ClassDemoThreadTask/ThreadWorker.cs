using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClassDemoThreadTask
{
    public class ThreadWorker
    {
        private static bool done = false;    // Static fields are shared between all threads


        public ThreadWorker()
        {
        }

        public void Start()
        {
            //StartThreadTest();

            StartTaskTest();


            //CriticalRegionTest critRegion = new CriticalRegionTest();
            //critRegion.Start();
        }


        /*
         *
         * THREADS
         *
         */

        private void StartThreadTest()
        {
            new Thread(Go).Start();
            Go();
        }

        private void Go()
        {
            if (!done) { done = true; Console.WriteLine("Done");  }
        }



        /*
         *
         * TASKS
         *
         */

        private void StartTaskTest()
        {
            Task.Run(() => DoWork("Number One", ConsoleColor.Red));
            Task.Run(() => DoWork("Number Two", ConsoleColor.Green));
        }

        private void DoWork(String name, ConsoleColor colour)
        {

            
            for (int i = 0; i < 20; i++)
            {
                Console.ForegroundColor = colour;
                Console.WriteLine($"Name {name} no={i}");
            }
        }
    }
}