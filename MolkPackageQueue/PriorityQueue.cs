using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class PriorityQueue
    {
        private Queue<Package> queueHigh = new Queue<Package>();
        private Queue<Package> queueMedium = new Queue<Package>();
        private Queue<Package> queueLow = new Queue<Package>();

        private List<Package> incomingPackageList = new List<Package>();
        private List<Package> prioritizedOutgoingPackage = new List<Package>();

        public void Enqueue(Package package)
        {
            switch (package.Priority)
            {
                case Priority.Low:
                    queueLow.Enqueue(package);
                    incomingPackageList.Add(package);
                    break;
                case Priority.Medium:
                    queueMedium.Enqueue(package);
                    incomingPackageList.Add(package);
                    break;
                case Priority.High:
                    queueHigh.Enqueue(package);
                    incomingPackageList.Add(package);
                    break;
                default:
                    break;
            }
        }

        public Package Dequeue()
        {
            Package dequeuedPackage = null;

            if (queueHigh.Count > 0)
            {
                dequeuedPackage = queueHigh.Dequeue();
                prioritizedOutgoingPackage.Add(dequeuedPackage);
            }
            else if (queueMedium.Count > 0)
            {
                dequeuedPackage = queueMedium.Dequeue();
                prioritizedOutgoingPackage.Add(dequeuedPackage);
            }
            else if (queueLow.Count > 0)
            {
                dequeuedPackage = queueLow.Dequeue();
                prioritizedOutgoingPackage.Add(dequeuedPackage);
            }

            return dequeuedPackage;
        }

        public bool IsEmpty()
        {
            return queueHigh.Count == 0 && queueMedium.Count == 0 && queueLow.Count == 0;
        }

        public void PrintLogList(List<Package> packageList)
        {
            foreach (var package in packageList)
            {
                Console.WriteLine($"Priority: {package.Priority}, Payload: {package.Payload.PackageName}");
            }
        }
        public List<Package> GetIncomingPackageList()
        {
            return incomingPackageList;
        }

        public List<Package> GetPrioritizedOutgoingPackage()
        {
            return prioritizedOutgoingPackage;
        }
    }
}
