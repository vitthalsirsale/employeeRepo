using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThreading
{
    internal class Program
    {
         static long result = 1;
         static object obj = new object();
        static void Main(string[] args)
        {
            //    //Thread t =  Thread.CurrentThread;
            //    //t.Name = "Test";

            //    //Console.WriteLine(t.Name);
            //    //Console.WriteLine(Thread.CurrentThread.Name);

            //    Thread t1 = new Thread(Method1) { Name = "t1"};

            //    Thread t2 = new Thread(Method2) { Name = "t2"};

            //    Thread t3 = new Thread(Method3) { Name = "t3"};

            //    t1.Start(); 
            //    t2.Start();
            //    t3.Start();
            //ParameterizedThreadStart obj = new ParameterizedThreadStart(Method1);
            //Thread t = new Thread(obj);
            //t.Start(30);
            int number = 10;

            Thread thread1 = new Thread(() => Factorial(1, number / 2));
            Thread thread2 = new Thread(() => Factorial(number/2 +1, number));
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"factorial of {number} is {result}");

        }

        static void Factorial(int start, int end) 
        
        
       {
            long partialResult1 =1;
            for (int i = start; i <= end; i++) { 
                partialResult1 *= i;
            }

             lock (obj)
            {
                result *= partialResult1;
            }
        }

        //static void Method1(object n)
        //{
        //    for (int i = 0; i <= Convert.ToInt32(n); i++)
        //    {
        //        Console.WriteLine($"Method1 : {i}");
        //        Thread.Sleep(1000);
        //    }
        //}
        //static void Method2()
        //{
        //    for (int i = 0; i <= 5; i++)
        //    {
        //        Console.WriteLine($"Method2 : {i}");
        //    }
        //}
        //static void Method3()
        //{
        //    for (int i = 0; i <= 5; i++)
        //    {
        //        Console.WriteLine($"Method3 : {i}");
        //    }


        //}
    }
}
