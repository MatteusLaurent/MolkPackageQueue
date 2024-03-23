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

        public int LengthOfqueueLow()
        {
            return this.queueLow.Count;
        }

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
            if (queueHigh.Count > 0)
            {
                Package packageDequeued = queueHigh.Dequeue();
                prioritizedOutgoingPackage.Add(packageDequeued);
            }
            else if (queueMedium.Count > 0)
            {
                Package packageDequeued = queueMedium.Dequeue();
                prioritizedOutgoingPackage.Add(packageDequeued);
            }
            else if (queueLow.Count > 0)
            {
                Package packageDequeued = queueLow.Dequeue();
                prioritizedOutgoingPackage.Add(packageDequeued);
            }
            else
            {
                //All queues are empty
            }
        }

        //Test print
        public void PrintList(Package package)
        {
            Console.WriteLine(package.Priority);
            Console.WriteLine(package.Payload.PackageName);
        }
        //Test print
        public void PrintList(int index)
        {
            Console.WriteLine(incommingPackageList[index].Priority);
            Console.WriteLine(incommingPackageList[index].Payload.PackageName);
        }

        //Test print
        public void PrintList()
        {
            Console.WriteLine($"queueHigh: {queueHigh.Count}");
            Console.WriteLine($"queueMedium: {queueMedium.Count}");
            Console.WriteLine($"queueLow: {queueLow.Count}");
        }

        public void PrintLogList()
        {
            Console.WriteLine("Mölk Package Service");
            Console.WriteLine($"-------------------------------------------------");
            Console.WriteLine($"Number of elements in incommingPackageList: {incommingPackageList.Count}");
            Console.WriteLine($"Number of elements in prioritizedOutgoingPackage: {prioritizedOutgoingPackage.Count}");
          
            PrintLogListHelper(incommingPackageList);
            PrintLogListHelper(prioritizedOutgoingPackage);
        }

        public void PrintLogListHelper(List<Package> ListOfPackageToPrint)
        {
            Console.WriteLine($"-------------------------------------------------");
            Console.WriteLine($"Elements in {nameof(ListOfPackageToPrint)}:");
            Console.WriteLine($"-------------------------------------------------");
            Console.WriteLine($"Queue number:   Name:           Priority");

            int i = 1;
            foreach (Package package in ListOfPackageToPrint)
            {
                Console.Write($"{i}\t\t{package.Payload.PackageName} \t");
                Console.WriteLine(package.Priority);
                i++;
            }
        }
    }
}
