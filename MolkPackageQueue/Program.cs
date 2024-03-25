using System.Diagnostics;

namespace MolkPackageQueue
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            PriorityQueue priorityQueue = new PriorityQueue();
            bool packageHandlingIsDone = false;
            Console.WriteLine("Implement MPS");
            while (!packageHandlingIsDone)
            {
                if (priorityQueue.ListOfIncomingPackages.Count < 50) GenerateIncomingPackages(priorityQueue);
                HandleOutgoingPackages(priorityQueue);
                //DebugOutput(priorityQueue);
                packageHandlingIsDone = priorityQueue.NumberOfPackagesInQueue == 0 && priorityQueue.ListOfIncomingPackages.Count >= 50;
            }
            Console.WriteLine($"\n{priorityQueue.ListOfIncomingPackages.Count} incoming packages:");
            priorityQueue.PrintLogList(priorityQueue.ListOfIncomingPackages);
            Console.WriteLine($"\n{priorityQueue.ListOfOutgoingPackages.Count} outgoing packages:");
            priorityQueue.PrintLogList(priorityQueue.ListOfOutgoingPackages);
        }

        /// <summary>
        /// Generates a random number of incoming <see cref="Package"/>s and enqueues them to the <paramref name="priorityQueue"/>
        /// </summary>
        /// <param name="priorityQueue">The <see cref="PriorityQueue"/> to enqueue the packages to</param>
        private static void GenerateIncomingPackages(PriorityQueue priorityQueue)
        {
            for (int i = 0; i < random.Next(1, 11); i++)
            {
                priorityQueue.Enqueue(PackageFactory.CreatePackage());
            }
        }

        /// <summary>
        /// Dequeues a random number of packages from the <paramref name="priorityQueue"/>
        /// </summary>
        /// <param name="priorityQueue">The <see cref="PriorityQueue"/> to dequeue the packages from</param>
        private static void HandleOutgoingPackages(PriorityQueue priorityQueue)
        {
            for (int i = 0; i < random.Next(1, 6); i++)
            {
                if (priorityQueue.NumberOfPackagesInQueue > 0) priorityQueue.Dequeue();
            }
        }

        /// <summary>
        /// Outputs debug information about the <paramref name="priorityQueue"/>
        /// </summary>
        private static void DebugOutput(PriorityQueue priorityQueue)
        {
            Debug.WriteLine($"Number of packages in queue: {priorityQueue.NumberOfPackagesInQueue}");
            Debug.WriteLine($"Number of outgoing packages: {priorityQueue.ListOfOutgoingPackages.Count}");
            Debug.WriteLine($"Number of incoming packages: {priorityQueue.ListOfIncomingPackages.Count}");
            Debug.WriteLine(priorityQueue.NumberOfPackagesInQueue == 0);
            Debug.WriteLine(priorityQueue.ListOfIncomingPackages.Count > 50);
        }
    }
}