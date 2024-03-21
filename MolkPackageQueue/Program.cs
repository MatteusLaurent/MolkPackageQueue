namespace MolkPackageQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue prioqueue = new PriorityQueue();

            PackageHandler(prioqueue);

            Console.WriteLine("Incoming Packages:");
            prioqueue.PrintLogList(prioqueue.incommingPackageList);
            Console.WriteLine("\nHandled Packages:");
            prioqueue.PrintLogList(prioqueue.outgoingPackageList);

        }

        private static void PackageHandler(PriorityQueue prioqueue)
        {
            int totalPackages = 0;
            Random random = new Random();
            PackageFactory packageFactory = new PackageFactory();
            while (totalPackages < 50)
            {
                int creationQueue = random.Next(1, 11);
                for (int i = 0; i < creationQueue; i++)
                {
                    Package newPackage = packageFactory.CreatePackage();
                    prioqueue.Enqueue(newPackage);
                    totalPackages++;
                }

                int packagesToDequeue = random.Next(1, 6);
                for (int i = 0; i < packagesToDequeue; i++)
                {
                    if (prioqueue.IsEmpty())
                    {
                        break;
                    }
                    prioqueue.Dequeue();
                }
            }
            while (!prioqueue.IsEmpty())
            {
                int packagesToDequeue = random.Next(1, 6);
                for (int i = 0; i < packagesToDequeue; i++)
                {
                    if (prioqueue.IsEmpty())
                    {
                        break;
                    }
                    prioqueue.Dequeue();
                }

            }
        }
    }
}