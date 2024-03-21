using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolkPackageQueue
{
    public class Package
    {
        public Package(Priority priority)
        {
            Priority = priority;
            Payload = new Payload();
        }
        public Priority Priority { get; }
        public Payload Payload { get; }
    }

    public enum Priority 
    { 
        Low = 0, 
        Medium = 1, 
        High = 2 
    }

    public class Payload 
    {
        public string PackageName { get; private set; }

        public Payload()
        {
            PackageName = GetRandomName();
        }

        private string GetRandomName()
        {
            Random random = new Random();
            int nameLength = 8;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖabcdefghijklmnopqrstuvxyzåäö1234567890!#¤%&/=?@£$€§½";
            char[] name = new char[nameLength];
            for (int i = 0; i < nameLength; i++)
            {
                name[i] = chars[random.Next(chars.Length)];
            }
            return new string(name);
        }
    }
}
