using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskConsoleApplication
{
    public class CustException:Exception
    {

        public CustException(string message) : base(message) { }        
        public string CustExceptionMsg { get { return "Custom:" + Message; }  }
    }
    class Program
    {
        static void Main(string[] args)
        {

            //int i = 10;
            //int j = 20;
            //int k = i + j;

            //k++;

            //Console.WriteLine(k);

            Task t2 = f2();

            try
            {
                Console.WriteLine( "Task ID:" + t2.Id);
                t2.Wait();
            }
            catch (CustException exag)
            {
               // foreach (Exception ex in exag.Flatten().InnerExceptions)
                    Console.WriteLine(exag.CustExceptionMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            Console.WriteLine("Inside Main After wait");
            Console.ReadKey();

        }
       static  Task f2()
        {
            Task t3 = null;
            //Task t1 = F1();
            //await t1;
            //Console.WriteLine("Inside F2 after await");
            //Task t1 = F1();
            //t1.ContinueWith(PrintError, TaskContinuationOptions.OnlyOnFaulted);
            try
            {
                Task t1 = F1();
                 t3 = t1.ContinueWith((t) =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Inside F2 after await" + Task.CurrentId);
                });

                return t3;
                // await t1;
                //Thread.Sleep(1000);
                //Console.WriteLine("Inside F2 after await" + Task.CurrentId);
            }
            catch (CustException exag)
            {
               // foreach (Exception ex in exag.Flatten().InnerExceptions)
                    Console.WriteLine(exag.CustExceptionMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return t3;
        }

   

        static  Task F1()
        {

            Task task = Task.Run(() =>
            {
                Task del = Task.Delay(5000);
                del.Wait();
                //throw new CustException( "Exception from child task" );
                //Console.WriteLine("Inside DelayF1 after await");

            }
            );

            return task;
            

           
            //Console.WriteLine("Inside DelayF1");
        }

        static void PrintError(Task task)
        {
            Exception ex = task.Exception;
            Console.WriteLine(ex.Message);
        }
    }
}
