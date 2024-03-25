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
        /* Static counter to keep track of the order of the packages.
        Alternatively, GUIDs or random integers could have been used for more randomness. */

        private static int packageCounter = 1;
        private string packageName;
        public Payload() 
        { 
            packageName = $"package_{packageCounter++}";
        }
        public override string ToString()
        {
            return packageName;
        }
    }
}
