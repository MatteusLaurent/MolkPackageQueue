namespace MolkPackageQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implement MPS");
            PriorityQueue prioqueue = new PriorityQueue();
            PackageFactory packageFactory = new PackageFactory();
            int number_of_packages = 0;

            while (number_of_packages < 50)
            {
                //Skapa 1-10 paket och köa dem (enligt nedan)
                int random_number_of_packages = new Random().Next(1, 10);
                number_of_packages += random_number_of_packages;
                for (int i = 0; i < random_number_of_packages; i++)
                {
                    Package newPackage = packageFactory.CreatePackage();
                    prioqueue.Enqueue(newPackage);
                    //prioqueue.PrintList(newPackage);
                }
                //prioqueue.PrintList();

                //avköa 1-5 paket med dequeue
                random_number_of_packages = new Random().Next(1, 5);
                for (int i = 0; i < random_number_of_packages; i++)
                {
                    prioqueue.Dequeue();
                    //prioqueue.PrintList(i);
                }
                //prioqueue.PrintList();
            }

            while (prioqueue.LengthOfqueueLow() > 0)
            {
                prioqueue.Dequeue();
                //prioqueue.PrintList();
            }

            //Fortsätt tills minst 50 skapade och sedan till köer tomma.
            // Create a function and dequeue packages according to the rules. 
            // Don´t forget the logging lists
            // Print log for packages created in order of creation, with payload packageName and package priority
            // Print log for packages handled (dequeue and add to logg), same content as above.
            // No high prio should be in bottom of handled list, alla paket som skapas ska finnas i hanterad-listan.
            prioqueue.PrintLogList();
            Console.ReadLine();
        }
    }
}