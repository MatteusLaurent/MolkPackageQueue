using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class PriorityQueue
    {
        Queue<Package> queueHigh = new Queue<Package>();
        Queue<Package> queueMedium = new Queue<Package>();
        Queue<Package> queueLow = new Queue<Package>();

        List<Package> incommingPackageList = new List<Package>();
        List<Package> prioritizedOutgoingPackage = new List<Package>();

        public void Enqueue(Package package)
        {
            switch (package.Priority) 
            {
                case Priority.Low: queueLow.Enqueue(package);
                    { 
                        incommingPackageList.Add(package);
                        break; 
                    }
                case Priority.Medium: queueMedium.Enqueue(package);
                    {
                        incommingPackageList.Add(package);
                        break; 
                    }
                case Priority.High: queueHigh.Enqueue(package);
                    {
                        incommingPackageList.Add(package);
                        break; 
                    }
                default: break;

            }
        }
        public void Dequeue(Package package)
        {
            
        }

        public void PrintLogList(List<Package> packageList) { }
    }
}
