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

        public List<Package> incommingPackageList = new List<Package>();
        public List<Package> outgoingPackageList = new List<Package>();

        public void Enqueue(Package package)
        {
            switch (package.Priority)
            {
                case Priority.Low:
                    queueLow.Enqueue(package);
                    {
                        incommingPackageList.Add(package);
                        break;
                    }
                case Priority.Medium:
                    queueMedium.Enqueue(package);
                    {
                        incommingPackageList.Add(package);
                        break;
                    }
                case Priority.High:
                    queueHigh.Enqueue(package);
                    {
                        incommingPackageList.Add(package);
                        break;
                    }
                default: break;

            }
        }
        public void Dequeue()
        {
            Package package = null;
            if (queueHigh.Count > 0)
            {
                package = queueHigh.Dequeue();
            }
            else if (queueMedium.Count > 0)
            { 
                package = queueMedium.Dequeue(); 
            }
            else if (queueLow.Count > 0)
            {
                package = queueLow.Dequeue();
            }
            if (package != null)
            {
                outgoingPackageList.Add(package);
            }
        }

        public void PrintLogList(List<Package> packageList) 
        {
            foreach (Package package in packageList)
            {
                Console.WriteLine($"Package ID: {package.Payload.PackageName}, Priority: {package.Priority}");
            }
        }

        public bool IsEmpty()
        {
            return queueHigh.Count == 0 && queueMedium.Count == 0 && queueLow.Count == 0;
        }
    }
}
