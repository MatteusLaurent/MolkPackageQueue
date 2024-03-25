using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class PackageFactory
    {
        public static int NrOfCreatedPackages;

        /// <summary>
        /// Randomizes an int between 0,2
        /// </summary>
        /// <returns>Priority enum value low, medium or high</returns>
        public Priority GetRandomPriority() 
        {
            Random randomizer = new Random();
            return (Priority)randomizer.Next(0,3); 
        }
        /// <summary>
        /// Creates an Package of random priority
        /// </summary>
        /// <returns>Package Object</returns>
        public Package CreatePackage()
        {
            NrOfCreatedPackages++;
            return new Package(GetRandomPriority());
        }
    }
}
