using static System.Console;
namespace MolkPackageQueue
{
    internal class Program
    {
        static readonly Random random = new();
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            PackageFactory packageFactory = new PackageFactory();
            PriorityQueue prioqueue = new PriorityQueue();

            while (PackageFactory.NrOfCreatedPackages < 50)
            {
                CreateRandomAmountOfPackages(packageFactory, prioqueue, 4);
                SendRandomAmountOfPackages(prioqueue);
            }

            while (PriorityQueue.NrOfPackagesSent < 50)
                SendRandomAmountOfPackages(prioqueue);

            WriteOutReport(prioqueue);
        }

        private static void WriteOutReport(PriorityQueue prioqueue)
        {
            WriteLine("\n    --- Incoming ---");
            prioqueue.PrintLogList(prioqueue.IncommingPackageList);

            WriteLine("\n    --- Outgoing ---");
            prioqueue.PrintLogList(prioqueue.PrioritizedOutgoingPackage);

            List<Package> in_sorted = prioqueue.IncommingPackageList;
            in_sorted.Sort();
            WriteLine("\n    --- Sorted Incoming ---");
            prioqueue.PrintLogList(in_sorted);

            List<Package> out_sorted = prioqueue.PrioritizedOutgoingPackage;
            out_sorted.Sort();
            WriteLine("\n    --- Sorted Outgoing ---");
            prioqueue.PrintLogList(out_sorted);
        }

        private static void SendRandomAmountOfPackages(PriorityQueue prioqueue, int max = 5)
        {
            for (int i = 0; i < random.Next(1, max + 1); i++)
            {
                prioqueue.Dequeue();
            }
        }

        private static void CreateRandomAmountOfPackages(PackageFactory packageFactory, PriorityQueue prioqueue, int max = 10)
        {
            for (int i = 0; i < random.Next(1, max + 1); i++)
            {
                Package p = packageFactory.CreatePackage();
                prioqueue.Enqueue(p);
            }
        }
    }
}