using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    class PackageFactory
    {
        static Random randomizer = new Random();
        public static Package CreatePackage()
        {
            var values = Enum.GetValues<Priority>();
            return new Package(values[randomizer.Next(values.Length)]);
        }
    }
}
