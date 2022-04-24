using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threadings
{

namespace     [Serializable]
    public class Person//: IDeserializationCallback
    {
        private string myFirstName;
        private string myLastName;
        private DateTime dateOfBirth;

        //   [NonSerialized]
        private int myAge = 0;


        // Declare a Name property of type string:
        public DateTime DOB
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        // Declare a Name property of type string:
        public string FirstName
        {
            get { return myFirstName; }
            set { myFirstName = value; }
        }

        public string LastName
        {
            get { return myLastName; }
            set { myLastName = value; }
        }

        public int Age
        {
            get
            {

                return myAge;

            }
            set { myAge = value; }
        }

        public int GetAge(DateTime dateofbirth)
        {
            if (dateofbirth != null)
            {
                Age = DateTime.Now.Year - dateofbirth.Year;
                return Age;
            }
            else
                throw new ArgumentNullException();
        }

        //void IDeserializationCallback.OnDeserialization(Object sender)
        //{
        //    GetAge(DOB);
        //}


        public override string ToString()
        {
            return "Name = " + FirstName + " " + LastName;
        }
    }

    class Program
    {
        public static void RunSnippet()
        {
            ParameterizedThreadStart operation = new ParameterizedThreadStart(ShowCurrentThreadID);
            Thread[] th = new Thread[5];

            for (int i = 0; i < 5; i++)
            {
                Person p = new Person();

                p.FirstName = i.ToString();
                p.LastName = (i + 10).ToString();

                th[i] = new Thread(operation);    
                th[i].Start(p);
               // th[i].Abort();
            }

            foreach (Thread thr in th)
                thr.Join();

        }

        public static void ShowCurrentThreadID(Object obj)
        {

            Thread.BeginCriticalRegion();
            Person p = obj as Person;
            if (p == null) throw new InvalidProgramException("Arguement must be string");

            p.FirstName = "somename";
            p.LastName="somelastname";

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("In critical region");
                Thread.Sleep(1000);
            }
            Thread.EndCriticalRegion();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Current Thread Id={0} , FirstName={1}, LastName={2}", Thread.CurrentThread.ManagedThreadId, p.FirstName,p.LastName);
                Thread.Sleep(1000);
            }
           
        }

        #region Helper methods

        public static void Main()
        {
            try
            {
                RunSnippet();
            }
            catch (Exception e)
            {
                string error = string.Format("---\nThe following error occurred while executing the snippet:\n{0}\n---", e.ToString());
                Console.WriteLine(error);
            }
            finally
            {
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private static void WL(object text, params object[] args)
        {
            Console.WriteLine(text.ToString(), args);
        }

        private static void RL()
        {
            Console.ReadLine();
        }

        private static void Break()
        {
            System.Diagnostics.Debugger.Break();
        }

        #endregion
    } 
}
