using static System.Console;
namespace MolkPackageQueue
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            PackageFactory packageFactory = new PackageFactory();
            Queue<Package> queue = new Queue<Package>();
            PriorityQueue prioqueue = new PriorityQueue();
            //List<Package> incoming = new List<Package>();
            List<Package> packages = new List<Package>();
            List<Package> delivered = new List<Package>();

            //Skapa 1-10 paket och köa dem (enligt nedan)
            while (PackageFactory.NrOfCreatedPackages < 50)
            {
                CreateRandomAmountOfPackages(packageFactory, prioqueue);
                SendRandomAmountOfPackages(prioqueue);
            }

            while (PriorityQueue.NrOfPackagesSent < 50)
                SendRandomAmountOfPackages(prioqueue);

            prioqueue.PrintLogList(prioqueue.IncommingPackageList);
            WriteLine();
            prioqueue.PrintLogList(prioqueue.PrioritizedOutgoingPackage);

            //avköa 1-5 paket med dequeue

            //Fortsätt tills minst 50 skapade och sedan till köer tomma.


            // Don´t forget the logging lists
            // Print log for packages created in order of creation, with payload packageName and package priority
            // Print log for packages handled (dequeue and add to logg), same content as above.
            // No high prio should be in bottom of handled list, alla paket som skapas ska finnas i hanterad-listan.
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