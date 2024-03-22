namespace MolkPackageQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue prioqueue = new PriorityQueue();
            PackageFactory packageFactory = new PackageFactory();

            int totalPackagesCreated = 0;

            while (totalPackagesCreated < 50)
            {
                int numToCreate = Math.Min(new Random().Next(1, 11), 50 - totalPackagesCreated);
                for (int i = 0; i < numToCreate; i++)
                {
                    prioqueue.Enqueue(packageFactory.CreatePackage());
                    totalPackagesCreated++;
                }
            }

            while (!prioqueue.IsEmpty())
            {
                int numToDequeue = new Random().Next(1, 6);
                for (int i = 0; i < numToDequeue; i++)
                {
                    Package dequeuedPackage = prioqueue.Dequeue();
                    if (dequeuedPackage != null)
                    {
                        Console.WriteLine($"Dequeued package: Priority - {dequeuedPackage.Priority}, Payload - {dequeuedPackage.Payload.PackageName}");
                    }
                }
            }

            Console.WriteLine("\nLog for packages created:");
            prioqueue.PrintLogList(prioqueue.GetIncomingPackageList());

            Console.WriteLine("\nLog for packages handled:");
            prioqueue.PrintLogList(prioqueue.GetPrioritizedOutgoingPackage());
        }
    }
}