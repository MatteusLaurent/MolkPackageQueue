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
        string packageName = RandomName();
        private static string RandomName()
        {
            Random random = new Random();
            string name = String.Empty;
            for (int i = 0; i < random.Next(3,21); i++)
            {
                name += (char)random.Next('a','z');
            }
            return name;
        }

        public override string? ToString()
        {
            return packageName;
        }
    }
}
