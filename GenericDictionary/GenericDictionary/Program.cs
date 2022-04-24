using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericDictionary
{
    public class Program
    {
        public static void RunSnippet()
        {
            Dictionary<int,string> GD=new Dictionary<int,string>();
            GD[1] = "India";
            GD[2] = "Bahrain";
            GD[3] = "South Africa";
            GD[4]="UK";
            Console.WriteLine(GD[4]);
            foreach (KeyValuePair<int, string> item in GD)
            {
                Console.WriteLine(item.Value);
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
