using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DictionaryCollections
{
    
    public class MyClass
    {
        public static void RunSnippet()
        {
            bitarraycode();
        }

        public static void hashtabletest()
        {
            Hashtable ht = new Hashtable();
            string numstring = "123456789";
            ht["1"] = "one";
            ht["2"] = "two";
            ht["3"] = "three";
            ht["4"] = "four";
            ht["5"] = "five";

            ht["7"] = "seven";
            ht["8"] = "eight";
            ht["9"] = "nine";

            for (int i = 0; i <= numstring.Length; i++)
            {
                //if(ht.ContainsKey(i.ToString()))
                {
                    Console.WriteLine(ht[i.ToString()]);
                }
            }
        }

        public static void bitarraycode()
        {
            BitArray bArr = new BitArray(3);
            BitArray bBrr = new BitArray(3);
            bArr[0] = true;
            bArr[1] = false;
            bArr[2] = true;


            bBrr[0] = false;
            bBrr[1] = true;
            bBrr[2] = true;

            BitArray bCrr = new BitArray(3);
            bCrr = bArr.Xor(bBrr);

            foreach (bool b in bCrr)
            {
                Console.WriteLine(b.ToString());
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
