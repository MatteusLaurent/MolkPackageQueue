using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class PackageFactory
    {
        /// <summary>
        /// Randomizes an int between 0,2
        /// </summary>
        /// <returns>Priority enum value low, medium or high</returns>
        public Priority GetRandomPriority()
        {
            Random randomizer = new Random();
            return (Priority)randomizer.Next(0, 3);
        }
        /// <summary>
        /// Creates a new package with a random priority
        /// </summary>
        /// <returns>A <see cref="Package"/> with a random priority given by <see cref="GetRandomPriority"/></returns>
        public Package CreatePackage()
        {
            return new Package(GetRandomPriority());
        }
    }
}
