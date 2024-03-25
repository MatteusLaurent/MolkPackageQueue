using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MolkPackageQueue
{
    public class PriorityQueue
    {
        public static int NrOfPackagesSent = 0;
        Queue<Package> queueHigh = new Queue<Package>();
        Queue<Package> queueMedium = new Queue<Package>();
        Queue<Package> queueLow = new Queue<Package>();

        List<Package> incommingPackageList = new List<Package>();
        List<Package> prioritizedOutgoingPackage = new List<Package>();

        public List<Package> IncommingPackageList { get => incommingPackageList; set => incommingPackageList = value; }
        public List<Package> PrioritizedOutgoingPackage { get => prioritizedOutgoingPackage; set => prioritizedOutgoingPackage = value; }

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

        // Create a function and dequeue packages according to the rules. 
        public void Dequeue()
        {
            if (queueHigh.Count > 0)
                prioritizedOutgoingPackage.Add(queueHigh.Dequeue());
            else if (queueMedium.Count > 0)
                prioritizedOutgoingPackage.Add(queueMedium.Dequeue());
            else if (queueLow.Count > 0)
                prioritizedOutgoingPackage.Add(queueLow.Dequeue());
            else
            {
                WriteLine("All the packages has ben sent.");
                return;
            }
            NrOfPackagesSent++;
        }

        // ? Förstår inte varför den här vill ta emot en parameter. Prioriteringen kan ju skötas internt här i klassen. ?
        public void Dequeue(Package package)
        {
        }

        public void PrintLogList(List<Package> packageList)
        {
            packageList.ForEach(p => { WriteLine($"{p.Payload,-25}{p.Priority,10}"); });
        }
    }
}
