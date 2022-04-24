using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Security.Policy;

namespace AppDomains
{
    class Program
    {
        static void Main(string[] args)
        {
            Zone Safezone = new Zone(SecurityZone.Internet);
            Object[] hostevidence = { Safezone };
            Evidence e = new Evidence(hostevidence, null);
            AppDomain Ad = AppDomain.CreateDomain("Domain1",e);
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine(Ad.FriendlyName);
            Ad.ExecuteAssembly(@"E:\Shatlin\Work\trials\ReadFile\ReadFile\bin\Debug\ReadFile.exe");
            AppDomain.Unload(Ad);
            Console.ReadLine();

        }
    }
}
