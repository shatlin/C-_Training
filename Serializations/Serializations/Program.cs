using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Serializations
{

    [Serializable]
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

    public class MyClass
    {
        public static void RunSnippet()
        {
            XMLserialise();
            XMLdeserialise();
        }

        public static void serialise()
        {
            DateTime dt=new DateTime(1977,6,8);
            Person ps = new Person();
            ps.FirstName = "shatlin";
            ps.LastName = "denistan";
            ps.DOB = dt;
            ps.GetAge(ps.DOB);

            FileStream fs = new FileStream("D:\\ripped\\Streaming.data", FileMode.OpenOrCreate);
            BinaryFormatter bformater = new BinaryFormatter();
            bformater.Serialize(fs, ps);
            fs.Close();
        }
        
        public static void deserialise()
        {
            FileStream fs = new FileStream("D:\\ripped\\Streaming.data", FileMode.OpenOrCreate);
            BinaryFormatter bformater = new BinaryFormatter();
            Person ps=(Person) bformater.Deserialize(fs);
            Console.WriteLine(ps.Age);
            fs.Close();
        }

        public static void XMLserialise()
        {
            DateTime dt = new DateTime(1977, 6, 8);
            Person ps = new Person();
            ps.FirstName = "shatlin";
            ps.LastName = "denistan";
            ps.DOB = dt;
            ps.GetAge(ps.DOB);

            FileStream fs = new FileStream("D:\\ripped\\Streaming.xml", FileMode.OpenOrCreate);
            XmlSerializer bformater = new XmlSerializer(typeof(Person));
            bformater.Serialize(fs, ps);
            fs.Close();
        }

        public static void XMLdeserialise()
        {
            FileStream fs = new FileStream("D:\\ripped\\Streaming.xml", FileMode.Open);
            XmlSerializer bformater = new XmlSerializer(typeof(Person));
            Person ps = (Person)bformater.Deserialize(fs);
            Console.WriteLine(ps.Age);
            fs.Close();
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
