namespace MolkPackageQueue
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Implement MPS");
            PriorityQueue MPSQueue = new();

            // Loop until 50 packages has been recieved (incoming)
            await TakeFiftyPackages(MPSQueue);

            // Keep sending packages until all queues are emptied
            while (MPSQueue.outgoingPackagesLog.Count < MPSQueue.incomingPackagesLog.Count)
            {
                MPSQueue.Dequeue();
            }

            // Print log for packages recieved in order of creation
            Console.WriteLine("------- Incoming packages -------");
            await PrintLog(MPSQueue.incomingPackagesLog);

            // Print log for packages sent in order of dequeuing
            Console.WriteLine("------- Outgoing packages -------");
            await PrintLog(MPSQueue.outgoingPackagesLog);

            // Check that all queues are empty
            if (MPSQueue.AreQueuesEmpty())
            {
                Console.WriteLine("++++++++++ All queues are cleared +++++++++++");
            }
            else
            {
                Console.WriteLine("!!!!!!!!!! Packages left in queue !!!!!!!!!!!");
            }
        }
        /// <summary>
        /// Handles packages by receiving 1-10 and sending 1-5 repeatedly, until 50 packages has been recieved (logged as incoming)
        /// </summary>
        /// <param name="queue"></param>
        /// <returns>Awaitable Task</returns>
        static async Task TakeFiftyPackages(PriorityQueue queue)
        {
            while (queue.incomingPackagesLog.Count < 50)
            {
                Random rand = new();
                int recieving = rand.Next(1, 11);
                int sending = rand.Next(1, 6);
                for (int i = 0; i < recieving; i++)
                {
                    if (queue.incomingPackagesLog.Count >= 50) 
                        return;
                    queue.Enqueue(PackageFactory.CreatePackage());
                }
                for (int ix = 0; ix < sending; ix++)
                {
                    queue.Dequeue();
                }
            }
        }
        /// <summary>
        /// Prints the given log List in order of addition
        /// </summary>
        /// <param name="packages"></param>
        /// <returns>Awaitable Task</returns>
        static async Task PrintLog(List<Package> packages)
        {
            foreach (Package p in packages)
            {
                Console.WriteLine($"Prio: {p.Priority} \t{p.Payload}");
            }
        }
    }
}