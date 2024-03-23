namespace MolkPackageQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue prioqueue = new PriorityQueue();
            PackageFactory packageFactory = new PackageFactory();
            //skapar och köar 10 paket
            for (int i = 0; i < 10;  i++)
            {
                prioqueue.Enqueue(packageFactory.CreatePackage());
            }
            prioqueue.printIncoming();
            //avköa 1-5 paket med dequeue
            for (int i = 0; i < 5; i++)
            {
                prioqueue.Dequeue();
            }
            prioqueue.printOutgoing();
            //Fortsätt tills minst 50 skapade och sedan till köer tomma.
            for (int i = 0; i < 50; i++)
            {
                prioqueue.Enqueue(packageFactory.CreatePackage());
            }
            while(prioqueue.queueIsEmpty() == false)
            {
                prioqueue.Dequeue();
            }
            prioqueue.printIncoming();
            prioqueue.printOutgoing();
        }
    }
}