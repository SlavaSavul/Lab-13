using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;

using System.Reflection;
using System.IO;
using System.Threading;
using System.Diagnostics;






namespace OOPLab10
{

    class Program
    {
        static void Main(string[] args)
        {

            foreach (Process process in Process.GetProcesses())
            {
                Console.WriteLine("ID: {0}  Name: {1}  Priority: {2}", process.Id, process.ProcessName, process.BasePriority);
            }
            Console.WriteLine("--------------------------------------------------------");
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine("Name: {0} ", domain.FriendlyName);
            foreach(Assembly asm in domain.GetAssemblies())
            {
                Console.WriteLine("--"+asm.GetName().Name);
            }
            Console.WriteLine("--------------------------------------------------------");

            //AppDomain secondDomain = AppDomain.CreateDomain("New");
            // secondDomain.Load(@"C:\Users\User\Desktop\Lab OOP\Lab15\OOPLab10\bin\Debug\Ass.exe");
            Console.WriteLine("--------------------------------------------------------");

            //  Numbers number= new Numbers();
            //  Thread newThreead = new Thread( new ThreadStart(number.WriteNumbers));
            // newThreead.Start();
            //Thread.Sleep(7000);
            // newThreead.Name = "New Threead";
            // Console.WriteLine("Name  " + newThreead.Name);
            // Console.WriteLine("IsAlive  " + newThreead.IsAlive);
            // Console.WriteLine("IsBackground   " + newThreead.IsBackground);
            //  Console.WriteLine("ThreadState    " + newThreead.ThreadState);
         //   Console.WriteLine("--------------------------------------------------------");
            EvenOddNumbers evenodd = new EvenOddNumbers();
          //  Thread New1 = new Thread(new ThreadStart(evenodd.WriteOddNumbers));
          //  Thread New2 = new Thread(new ThreadStart(evenodd.WriteEvenNumbers));
          //  New2.Start();
          //  New2.Priority = ThreadPriority.AboveNormal;
         //   New1.Start();
            Console.WriteLine("--------------------------------------------------------");





            Console.ReadKey();
        }

        class EvenOddNumbers
        {
            static object locker = new object();
            int n=20;
            FileStream SW = File.Open("Numbers2.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
         

            public void WriteEvenNumbers()
            {

                for (int i = 1; i < n; i++)
                {
                    if (i % 2 != 0) continue;
                    byte[] input = Encoding.Default.GetBytes(i.ToString());
                    SW.Write(input,0, input.Length);
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                }
                Console.WriteLine("End WriteEvenNumbers");

                if(SW!=null )SW.Close();
            }
            public void WriteOddNumbers()
            {

                for (int i = 1; i < n; i++)
                {
                    if (i % 2 == 0) continue;
                    byte[] input = Encoding.Default.GetBytes(i.ToString());
                    SW.Write(input, 0, input.Length); Console.WriteLine(i);
                    Thread.Sleep(800);
                }
                Console.WriteLine("End WriteOddNumbers");

                if (SW != null) SW.Close();
            }

        }
        class Numbers
        {
            int n;
            StreamWriter SW = new StreamWriter("Numbers.txt");
           public void WriteNumbers()
            {
                Console.WriteLine("Enter number");
                n = Int32.Parse(Console.ReadLine());

                for(int i=1;i<n;i++)
                {
                    SW.WriteLine(i);
                    Console.WriteLine(i);
                    Thread.Sleep(2000);
                }
                Console.WriteLine("End");

                SW.Close();
            }

        }


       

        ///////////////////////+
    }
}
