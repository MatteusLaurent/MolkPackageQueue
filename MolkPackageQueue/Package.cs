using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class Package
    {
        public Package(Priority priority)
        {
            Priority = priority;
            Payload = new Payload();
        }
        public Priority Priority { get; }
        public Payload Payload { get; }
    }

    public enum Priority 
    { 
        Low = 0, 
        Medium = 1, 
        High = 2 
    }

    public class Payload 
    {
        static List<string> sender = new List<string> { "Tele 2", "Lyreco", "CDON", "INET", "MediaMarkt", "Clas ohlsson", "IKEA", "Webhallen", "Netonet", "kjell o company" };
        static Random random = new Random();

        public Payload()
        {
            int randomIndex = random.Next(0, sender.Count);
            PackageName = $"Sender: {sender[randomIndex]}\nPackageID: {Guid.NewGuid()}";
        }

        public string PackageName { get; }
    }
}
