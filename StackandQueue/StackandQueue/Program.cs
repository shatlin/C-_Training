using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace StackandQueue
{
    class person
    {
        private string FirstName;
        private string LastName;

        public person(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public static bool operator == (person firstperson, person secondperson)
        {
            if (((object)firstperson == null) || ((object)secondperson == null)) return false;
            return secondperson.FirstName == firstperson.FirstName && secondperson.LastName == firstperson.LastName;
        }

        public static bool operator !=(person firstperson, person secondperson)
        {
            if (((object)firstperson == null) || ((object)secondperson == null)) return false;
            return secondperson.FirstName != firstperson.FirstName|| secondperson.LastName != firstperson.LastName;
        }

        public override bool Equals(object obj)
        {
            person secondperson = obj as person;
            if (secondperson == null) return false;

            return secondperson.FirstName == FirstName && secondperson.LastName == LastName;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            person shatlin = new person("shatlin", "denistan");
            person diana = new person("diana", "shatlin");
            person duplicateshatlin = new person("shatlin", "denistan");


            #region equals
                if (shatlin.Equals(diana) )
                    Console.WriteLine("equal") ;
                else 
                    Console.WriteLine("not equal");

                if (shatlin.Equals(duplicateshatlin))
                    Console.WriteLine("equal");
                else 
                    Console.WriteLine("not equal"); 
            #endregion


                #region ==
                if (shatlin==diana)
                    Console.WriteLine("equal");
                else
                    Console.WriteLine("not equal");

                if (shatlin==duplicateshatlin)
                    Console.WriteLine("equal");
                else
                    Console.WriteLine("not equal");
                #endregion


            //stackandqueue();
            //hashtable();
            Console.ReadLine();
        }

        public static void stackandqueue()
        {
            Stack<int> newstack = new Stack<int>();
            for (int i = 0; i <= 20; i++)
            {
                newstack.Push(i);
            }

            while (newstack.Count > 0)
            {

                if (newstack.Peek() != 5)
                {
                    Console.WriteLine(newstack.Pop());
                }
                else
                {
                    Console.WriteLine("15 items popped");
                    Console.ReadLine();
                    break;

                }



            }
        }

        public static void hashtable()
        {
            Hashtable ht = new Hashtable();
            for (int i = 0; i < 20; i++)
            {
                ht.Add(i,i.ToString());
            }

            foreach (DictionaryEntry de in ht)
            {
                Console.WriteLine(de.Key.ToString() + "_____" + de.Value);
            }

            foreach (object obj in ht.Keys)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine("There are totally " + ht.Count+ " elements in the hash table");

            Console.ReadLine();
        }

    }
}
