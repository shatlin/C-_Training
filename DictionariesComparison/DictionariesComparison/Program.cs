using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
namespace DictionariesComparison
{
    public class Program
    {
        public static void RunSnippet()
        {
            Hashtable ht = new Hashtable();
            ListDictionary ld = new ListDictionary();
            HybridDictionary hd = new HybridDictionary();
            long beforeloop = 0;
            long afterloop = 0;
            int i = 0;
            beforeloop=DateTime.Now.Ticks;
            for( i=0;i<50000;i++)
                ht.Add(i,i.ToString());
            afterloop = DateTime.Now.Ticks;
            Console.WriteLine("Hashtable took " + (afterloop - beforeloop) +" nano seconds");


            beforeloop = DateTime.Now.Ticks;
            for ( i = 0; i < 50000; i++)
                ld.Add(i, i.ToString());
            afterloop = DateTime.Now.Ticks;
            Console.WriteLine("List Dictionary took " + (afterloop - beforeloop) + " nano seconds");


            beforeloop = DateTime.Now.Ticks;
            for ( i = 0; i < 50000; i++)
                hd.Add(i, i.ToString());
            afterloop = DateTime.Now.Ticks;
            Console.WriteLine("Hybrid Dictionary took " + (afterloop - beforeloop) + " nano seconds");

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
