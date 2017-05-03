using System;

namespace SwissTransportPortableLibrary.Models
{
    public class Journey
    {
        public String Name { get; set; }
        public String To { get; set; }
        public Stop Stop { get; set; }

        internal Journey(String name, String to, Stop stop)
        {
            Name = name;
            To = to;
            Stop = stop;
        }
    }
}
