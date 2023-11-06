namespace MolkPackageQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implement MPS");
            PriorityQueue prioqueue = new PriorityQueue();
            PackageFactory packageFactory = new PackageFactory();
            prioqueue.Enqueue(packageFactory.CreatePackage());
            // Create a function and dequeue packages according to the rules. 
            // Don´t forget the logging lists
            // Print log for packages created in order of creation, with payload packageName and package priority
            // Print log for packages handled (dequeue and add to logg), same content as above.
            // No high prio should be in bottom of handled list, alla paket som skapas ska finnas i hanterad-listan.
        }
    }
}