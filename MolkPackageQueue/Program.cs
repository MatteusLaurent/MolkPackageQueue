namespace MolkPackageQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implement MPS");
            PriorityQueue prioqueue = new PriorityQueue();
            PackageFactory packageFactory = new PackageFactory();
            //Skapa 1-10 paket och köa dem (enligt nedan)
            prioqueue.Enqueue(packageFactory.CreatePackage());
            //avköa 1-5 paket med dequeue
            //Fortsätt tills minst 50 skapade och sedan till köer tomma.
            // Create a function and dequeue packages according to the rules. 
            // Don´t forget the logging lists
            // Print log for packages created in order of creation, with payload packageName and package priority
            // Print log for packages handled (dequeue and add to logg), same content as above.
            // No high prio should be in bottom of handled list, alla paket som skapas ska finnas i hanterad-listan.
        }
    }
}