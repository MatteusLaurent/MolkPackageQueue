using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    class PackageFactory
    {
        /// <summary>
        /// Creates a package with a random priority
        /// </summary>
        /// <returns> 
        /// <see cref="Package.Package(Priority)"/>
        /// </returns>
        public static Package CreatePackage()
        {
            Random randomizer = new Random();
            Priority prio = (Priority)randomizer.Next(0, 3);
            return new Package(prio);
        }
    }
}
