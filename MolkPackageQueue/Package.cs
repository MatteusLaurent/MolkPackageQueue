using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MolkPackageQueue
{
    public class Package : IComparable<Package>
    {
        public Package(Priority priority)
        {
            Priority = priority;
            Payload = new Payload();
        }
        public Priority Priority { get; }
        public Payload Payload { get; }

		public int CompareTo(Package? other)
		{
            if (this.Priority > other.Priority) return -1;
            else if (this.Priority < other.Priority) return 1;
            else
            {
				 //If priorities are equal, compare package names
				return this.Payload.packageName.CompareTo(other.Payload.packageName);
			}
        }
		

		public override string ToString()
		{
			// Customize the string representation of the object
			return $"PackageName: {Payload.packageName}, Prio: {Priority}";
		}
	}

    public enum Priority 
    { 
        Low = 0, 
        Medium = 1, 
        High = 2 
    }

    public class Payload 
    {
		private static readonly Random random = new Random();
        private static int packagenumber = 1;
		//private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

		//string packageName = GenerateRandomString(10);
		public string packageName = $"Package_{packagenumber++}";
	}
}
