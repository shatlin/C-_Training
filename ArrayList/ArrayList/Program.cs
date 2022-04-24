using System;
using System.Linq;
using System.Text;
using System.Collections;
namespace ArrayLister
{
    public class CaseLessComparer : IEqualityComparer
    {
        CaseInsensitiveComparer _comparer = new CaseInsensitiveComparer();

        public int GetHashCode(Object obj)
        {
            return obj.ToString().ToLowerInvariant().GetHashCode();
        }

        public new bool Equals(object x, object y)
        {
            if (_comparer.Compare(x, y) == 0) return true;
            else return false;
        }
    }

    public class Program
    {
        public static void RunSnippet()
        {
            ArrayList ar = new ArrayList();
            ar.Add(10);
            ar.Add("ten");
            ar.Add(new CaseLessComparer());
            

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
