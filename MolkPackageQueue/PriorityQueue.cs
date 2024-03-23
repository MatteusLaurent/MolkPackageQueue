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
        public void Dequeue()
        {
            Package temp;
            if(queueHigh.Count > 0)
            {
                temp = queueHigh.Dequeue();
                prioritizedOutgoingPackage.Add(temp);
                    
            }
            else if(queueMedium.Count > 0)
            {
                temp = queueMedium.Dequeue();
                prioritizedOutgoingPackage.Add(temp);
            }
            else if(queueLow.Count > 0)
            {
                temp = queueLow.Dequeue();
                prioritizedOutgoingPackage.Add(temp);
            }
            else
            {
                Console.WriteLine("queue is empty");
            }
        }

        public void printIncoming()
        {
            Console.WriteLine("--------- Incoming ----------\n");
            foreach(var package in incommingPackageList)
            {
                Console.WriteLine(package.Payload.PackageName + $"\nPackagePriority: {package.Priority}");
                Console.WriteLine();
            }
        }

        public void printOutgoing()
        {
            Console.WriteLine("--------- Outgoing ----------\n");
            foreach (var package in prioritizedOutgoingPackage)
            {
                Console.WriteLine(package.Payload.PackageName + $"\nPackagePriority: {package.Priority}");
                Console.WriteLine();
            }
        }

        public bool queueIsEmpty()
        {
            if (queueLow.Count == 0 && queueMedium.Count == 0 && queueHigh.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
