using static System.Console;

namespace MolkPackageQueue
{
    public class PriorityQueue
    {
        private static int nrOfPackagesSent = 0;
        readonly Queue<Package> queueHigh = new Queue<Package>();
        readonly Queue<Package> queueMedium = new Queue<Package>();
        readonly Queue<Package> queueLow = new Queue<Package>();

        List<Package> incommingPackageList = new List<Package>();
        List<Package> prioritizedOutgoingPackage = new List<Package>();

        public List<Package> IncommingPackageList { get => incommingPackageList; set => incommingPackageList = value; }
        public List<Package> PrioritizedOutgoingPackage { get => prioritizedOutgoingPackage; set => prioritizedOutgoingPackage = value; }
        public static int NrOfPackagesSent { get => nrOfPackagesSent; set => nrOfPackagesSent = value; }

        /// <summary>
        /// Enques an package to the queue of coresponding priority
        /// and to the list of incoming packages
        /// </summary>
        /// <param name="package">The package to enqueue</param>
        public void Enqueue(Package package)
        {
            switch (package.Priority) 
            {
                case Priority.Low: queueLow.Enqueue(package);
                    { 
                        incommingPackageList.Add(package);
                        break; 
                    }
                case Priority.Medium: queueMedium.Enqueue(package);
                    {
                        incommingPackageList.Add(package);
                        break; 
                    }
                case Priority.High: queueHigh.Enqueue(package);
                    {
                        incommingPackageList.Add(package);
                        break; 
                    }
                default: break;
            }
        }

        // Create a function and dequeue packages according to the rules. 
        /// <summary>
        /// Dequeue packages from the top priority queue wich holds packages
        /// If all queues ar empty it adds an epty phony package to the list of outgoing so we can se that nothing was sent
        /// If succesfully sent package increse NrOfPackagesSent
        /// </summary>
        public void Dequeue()
        {
            if (queueHigh.Count > 0)
                prioritizedOutgoingPackage.Add(queueHigh.Dequeue());
            else if (queueMedium.Count > 0)
                prioritizedOutgoingPackage.Add(queueMedium.Dequeue());
            else if (queueLow.Count > 0)
                prioritizedOutgoingPackage.Add(queueLow.Dequeue());
            else
            {
                prioritizedOutgoingPackage.Add(new Package());
                return;
            }
            NrOfPackagesSent++;
        }

        // ? Förstår inte varför den här vill ta emot en parameter. Prioriteringen kan ju skötas internt här i klassen. ?
        public void Dequeue(Package package)
        {
        }

        /// <summary>
        /// Print a complete log list.
        /// Used both internally and from main
        /// So for now it should be kept public
        /// </summary>
        /// <param name="packageList"></param>
        public void PrintLogList(List<Package> packageList)
        {
            packageList.ForEach(p => { WritePackage(p); });
        }

        /// <summary>
        /// Used by PrintLogList for propper formating and a special message when package is a dummy
        /// </summary>
        /// <param name="p"></param>
        private static void WritePackage(Package p)
        {
            if (p.Id >= 0)
            {
                WriteLine($"{p.Id,5}{"",5} {p.Payload,-25}{p.Priority,-10}");
            }
            else
            {
                WriteLine("   Package cue empty, nothing to send");
            }
        }
    }
}
