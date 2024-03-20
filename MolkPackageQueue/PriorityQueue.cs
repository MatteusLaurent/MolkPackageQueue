using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class PriorityQueue
    {
        Queue<Package> queueHigh = new();
        Queue<Package> queueMedium = new();
        Queue<Package> queueLow = new();

        public int Count => queueHigh.Count + queueMedium.Count + queueLow.Count;

        public void Enqueue(Package package)
        {
            if (package.Priority == Priority.High)
            {
                queueHigh.Enqueue(package);
            }
            else if (package.Priority == Priority.Medium)
            {
                queueMedium.Enqueue(package);
            }
            else
            {
                queueLow.Enqueue(package);
            }
        }

        public void Dequeue(Package package)
        {
            if (package.Priority == Priority.High)
            {
                queueHigh = new(queueHigh.Where(x => !x.Equals(package)));
            }
            else if (package.Priority == Priority.Medium)
            {
                queueMedium = new(queueMedium.Where(x => !x.Equals(package)));
            }
            else
            {
                queueLow = new(queueLow.Where(x => !x.Equals(package)));
            }
        }

        public Package? Next()
        {
            if (queueHigh.Count > 0) return queueHigh.Dequeue();
            if (queueMedium.Count > 0) return queueMedium.Dequeue();
            if (queueLow.Count > 0) return queueLow.Dequeue();
            else return null;
        }
    }
}
