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
            if (queueHigh.Count > 0) prioritizedOutgoingPackage.Add(queueHigh.Dequeue());
            else if (queueMedium.Count > 0) prioritizedOutgoingPackage.Add(queueMedium.Dequeue());
            else if (queueLow.Count > 0) prioritizedOutgoingPackage.Add(queueLow.Dequeue());
		}

        public void PrintincommingList() => PrintLogList(incommingPackageList);
		public void PrintprioOutgoingList() => PrintLogList(prioritizedOutgoingPackage);
		public void PrintSortedinc() => PrintSortedLogList(incommingPackageList);
		public void PrintSortedout() => PrintSortedLogList(prioritizedOutgoingPackage);

		public void PrintLogList(List<Package> packageList) 
        {
            Console.WriteLine("");
            foreach (var package in packageList)
            {
                Console.WriteLine($"{package}");
            }
        }

		
		public void PrintSortedLogList(List<Package> packageList) 
        {
			packageList.Sort();

			Console.WriteLine("");
			foreach (var package in packageList)
			{
				Console.WriteLine($"{package}");
			}
		}

    }
}
