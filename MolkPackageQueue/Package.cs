namespace MolkPackageQueue
{
    public class Package : IComparable<Package>
    {
        static int ID = 0;
        /// <summary>
        /// Construct a package with a certain priority
        /// </summary>
        /// <param name="priority"></param>
        public Package(Priority priority)
        {
            Id = ID++;
            Priority = priority;
            Payload = new Payload();
        }
        /// <summary>
        /// Constructor for creating a dummy package wich show then no package been sent due to lack of packages
        /// </summary>
        public Package()
        {
            Id = -ID;
            Priority = Priority.No;
            Payload = new Payload(false);
        }
        public int Id { get; }
        public Priority Priority { get; }
        public Payload Payload { get; }

        /// <summary>
        /// Implementation of compare to ordering the packages by priorroty and length of payload.
        /// Needed by Sort
        /// Just for fun :) i added a third sorting criteria by Id as i noted the two list werent identical due to same length strings returns 0
        /// </summary>
        /// <param name="other">The package we compare with</param>
        /// <returns>-1 to 1</returns>
        /// <exception cref="ArgumentException">Throws an exception if we for some reason try to compare a package with null</exception>
        public int CompareTo(Package? other)
        {
            if (other != null)
            {
                if (Priority > other.Priority)
                    return -1;
                else if (Priority < other.Priority)
                    return 1;
                else
                    if (Payload.GetLoad() > other.Payload.GetLoad())
                    return 1;
                else if (Payload.GetLoad() < other.Payload.GetLoad())
                    return -1;
                else
                    if (Id > other.Id)
                    return 1;
                else if (Id < other.Id)
                    return -1;
                return 0;
            }
            throw new ArgumentException("Something and nothing is not comparable. Check your code before u wreck your code. :)");
        }
    }

    public enum Priority
    {
        No = -1,
        Low = 0,
        Medium = 1,
        High = 2
    }

    /// <summary>
    /// The payload for our package.
    /// Pretty much, just a string
    /// </summary>
    public class Payload
    {
        readonly string packageName = RandomName();
        public Payload() { }
        public Payload(bool none) { packageName = "none"; }
        private static string RandomName()
        {
            Random random = new Random();
            string name = String.Empty;
            for (int i = 0; i < random.Next(3, 21); i++)
            {
                name += (char)random.Next('a', 'z');
            }
            return name;
        }
        public int GetLoad() => packageName.Length;

        public override string? ToString() => packageName;
    }
}
