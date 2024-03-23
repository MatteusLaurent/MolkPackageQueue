using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class PackageFactory
    {
        public Priority GetRandomPriority() 
        {
            Random randomizer = new Random();
            return (Priority)randomizer.Next(0,3); 
        }
        
        public Package CreatePackage()
        {           
            return new Package(GetRandomPriority());
        }
    }
}
