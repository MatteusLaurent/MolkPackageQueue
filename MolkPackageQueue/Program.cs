namespace MolkPackageQueue
{
    internal class Program
    {
        static List<Package> incommingPackages = new();
        static List<Package> outgoingPackages = new();

        static PriorityQueue priorityQueue = new();

        static void Main(string[] args)
        {
            Random random = new();
            while (priorityQueue.Count <= 50)
            {
                for (int i = 0; i < random.Next(10); i++)
                {
                    priorityQueue.Enqueue(Incomming());
                }

                if (priorityQueue.Count > 0)
                {
                    for (int i = 0; i < random.Next(5); i++)
                    {
                        Package? package = priorityQueue.Next();
                        if (package != null)
                        {
                            Outcomming(package);
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty");
                            break;
                        }
                    }
                }

                if (priorityQueue.Count <= 0) break;
            }

            Console.WriteLine("-- Dequeue remaining --");
            int count = 1;
            while (priorityQueue.Count > 0)
            {
                Package? package = priorityQueue.Next();
                if (package != null)
                {
                    Console.WriteLine($"Dequeue: # {count++}, Priority: {package.Priority}, Payload: {package.Payload}");
                    Outcomming(package);
                }
            }

            Console.WriteLine("-- Incomming --");

            count = 1;
            foreach (Package p in incommingPackages)
            {
                Console.WriteLine($"# {count++}, Priority: {p.Priority}, Payload: {p.Payload}");
            }
            Console.WriteLine("-- Outgoing --");
            count = 1;
            foreach (Package p in outgoingPackages)
            {
                Console.WriteLine($"# {count++}, Priority: {p.Priority}, Payload: {p.Payload}");
            }
        }

        private static Package Incomming() 
        {
            Package package = PackageFactory.CreatePackage();
            incommingPackages.Add(package);
            return package; 
        }

        private static void Outcomming(Package package)
        {
            outgoingPackages.Add(package);
            //incommingPackages.Remove(package);
            priorityQueue.Dequeue(package);
        }
    }
}