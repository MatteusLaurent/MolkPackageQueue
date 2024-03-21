using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class Package
    {
        /// <summary>
        /// Creates a package with the given priority, and a random name and ID
        /// </summary>
        /// <param name="priority"></param>
        public Package(Priority priority)
        {
            Priority = priority;
            Payload = new Payload();
        }
        /// <summary>
        /// Creates a Package with the given priority and name, and a random ID
        /// </summary>
        /// <param name="priority"></param>
        /// <param name="packageName"></param>
        public Package(Priority priority, string packageName)
        {
            Priority = priority;
            Payload = new Payload(packageName);
        }
        public Priority Priority { get; }
        public Payload Payload { get; }
    }

    /// <summary>
    /// <list type="number"> Low
    /// <item/>Medium
    /// <item/>High</list>
    /// </summary>
    public enum Priority 
    { 
        Low = 0, 
        Medium = 1, 
        High = 2 
    }

    /// <summary>
    /// Handles the package name and ID 
    /// </summary>
    public class Payload
    {
        public Guid PackageGuid { get; } = Guid.NewGuid();
        public string PackageName { get; }
        /// <summary>
        /// Constructor with random package name
        /// </summary>
        public Payload()
        {
            PackageName = RandomPackageName();
        }
        /// <summary>
        /// Constructor with given package name
        /// </summary>
        /// <param name="name">sender specified package name</param>
        public Payload(string name)
        {
            PackageName = name;
        }
        /// <summary>
        /// Creates a random package name
        /// </summary>
        /// <returns>String of 3-5 capitalized letters</returns>
        public static string RandomPackageName()
        {
            Random rand = new Random();
            StringBuilder builder = new(rand.Next(3,6));
            for (var i = 0; i < builder.Capacity; i++)
            {
                char letter = (char)rand.Next('A', 'Z'+1);
                builder.Append(letter);
            }
            return builder.ToString();
        }
  
        /// <returns>String with package name and package ID</returns>
        public override string ToString()
        {
            string contents = $"Package \"{PackageName}\"\tID: {PackageGuid}";
            return contents;
        }
    }
}
