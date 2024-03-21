using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class PriorityQueue
    {
        Queue<Package> queueHigh = new Queue<Package>();
        Queue<Package> queueMedium = new Queue<Package>();
        Queue<Package> queueLow = new Queue<Package>();

        public List<Package> incomingPackagesLog { get; } = new List<Package>();
        public List<Package> outgoingPackagesLog { get; } = new List<Package>();

        /// <summary>
        /// Places the Package in the correct Priority queue and logs it as incoming
        /// </summary>
        /// <returns>Awaitable Task</returns>
        /// <param name="package"></param>
        /// <remarks>Any package not sent with a priority gets the lowest priority</remarks>
        public async Task Enqueue(Package package)
        {
            switch(package.Priority)
            {
                case Priority.High:
                    queueHigh.Enqueue(package);
                    break;
                case Priority.Medium: 
                    queueMedium.Enqueue(package);
                    break;
                default:                        
                    queueLow.Enqueue(package);
                    break;
            }
            incomingPackagesLog.Add(package);
        }
        /// <summary>
        /// Removes one package from a queue by order of priority, and logs it as outgoing.
        /// </summary>
        /// <returns>Awaitable Task</returns>
        /// <remarks>If the sent (outgoing) packages are as many as have been recieved (incoming), no packages are dequeued</remarks>
        public async Task<TaskStatus> Dequeue()
        {
            if (incomingPackagesLog.Count == outgoingPackagesLog.Count) 
                return TaskStatus.Canceled;
            if (queueHigh.Count > 0)
            {
                outgoingPackagesLog.Add(queueHigh.Dequeue());
                return TaskStatus.RanToCompletion;
            }
            else if (queueMedium.Count > 0)
            {
                outgoingPackagesLog.Add(queueMedium.Dequeue());
                return TaskStatus.RanToCompletion;
            }
            else if (queueLow.Count > 0)
            {
                outgoingPackagesLog.Add(queueLow.Dequeue());
                return TaskStatus.RanToCompletion;
            }
            return TaskStatus.Canceled;
        }

        /// <summary>
        /// Checks that all queues in this PriorityQueue are empty
        /// </summary>
        /// <returns>true if all queues are empty; false if there are packages left in any queue</returns>
        public bool AreQueuesEmpty()
        {
            if (queueHigh.Count > 0 || queueMedium.Count > 0 || queueLow.Count > 0)
                return false; 
            return true;
        }
    }
}
