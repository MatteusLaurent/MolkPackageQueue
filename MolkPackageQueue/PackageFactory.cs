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

        public Package CreatePackage()
        {
            return new Package(GetRandomPriority());
        }
    }
}
