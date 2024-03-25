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

        public List<Package> ListOfIncomingPackages = new List<Package>();
        public List<Package> ListOfOutgoingPackages = new List<Package>();
        /// <summary>
        /// The total number of packages in the low, medium and high priority queues
        /// </summary>
        public int NumberOfPackagesInQueue
        {
            get => queueLow.Count + queueMedium.Count + queueHigh.Count;
            private set { }
        }

        /// <summary>
        /// Enqueues a package to the correct queue based on the priority of the package
        /// </summary>
        /// <param name="package">The package to be enqueued</param>
        public void Enqueue(Package package)
        {
            switch (package.Priority)
            {
                case Priority.Low: queueLow.Enqueue(package); break;
                case Priority.Medium: queueMedium.Enqueue(package); break;
                case Priority.High: queueHigh.Enqueue(package); break;
                default: break;
            }
            ListOfIncomingPackages.Add(package);
        }

        /// <summary>
        /// Dequeues a <see cref="Package"/> from the highest priority queue available
        /// </summary>
        public Package Dequeue()
        {
            // Checks the queues in order of priority; high --> medium --> low
            Package? package = queueHigh.Count > 0 ? queueHigh.Dequeue() : queueMedium.Count > 0 ? queueMedium.Dequeue() : queueLow.Count > 0 ? queueLow.Dequeue() : null;
            if (package != null)
            {
                ListOfOutgoingPackages.Add(package);
            }
            return package;
        }

        /// <summary>
        /// Prints the log of <see cref="Package"/>s in <paramref name="packageList"/>
        /// </summary>
        /// <param name="packageList">The list of packages to be printed</param>
        public void PrintLogList(List<Package> packageList)
        {
            foreach (Package package in packageList)
            {
                Console.WriteLine($"Package: {package.Payload} with {package.Priority} priority");
            }
        }
    }
}
