using System;

namespace MolkPackageQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implement MPS");
            PriorityQueue prioqueue = new PriorityQueue();
            PackageFactory packageFactory = new PackageFactory();

			Random randomNumber = new Random();
            int queuedPackets = 0;
			int dequeuedPackets = 0;

			//Skapa 1-10 paket och köa dem (enligt nedan)
			while (dequeuedPackets < 50) 
            {
                if (queuedPackets < 50)
                {
					for (int i = 0; i < randomNumber.Next(1, 11); i++)
					{
						prioqueue.Enqueue(packageFactory.CreatePackage());
						queuedPackets++;
                        if (queuedPackets == 50) break;
					}
				}
                if (dequeuedPackets < 50)
                {
					for (int i = 0; i < randomNumber.Next(1, 6); i++)
					{
						prioqueue.Dequeue();
						dequeuedPackets++;
						if (queuedPackets == 50) break;
					}
				}
                

			}

			Console.WriteLine("incomming list: ");
			prioqueue.PrintincommingList();

			Console.WriteLine("outgoing prio: ");
			prioqueue.PrintprioOutgoingList();

			Console.WriteLine("Sorted on prio then name inc: ");
			prioqueue.PrintSortedinc();

			Console.WriteLine("Sorted on prio then name out: ");
			prioqueue.PrintSortedout();

		}
    }
}