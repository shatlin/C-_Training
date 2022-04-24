using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = File.Open("e:\\kfp_agk.log", FileMode.Open);
            StreamReader sr=new StreamReader(fs);
            Console.WriteLine(sr.ReadToEnd());
            Console.ReadLine();
        }
    }
}
