using System;

namespace SwissTransportPortableLibrary.Models
{
    public class Journey
    {
        internal String Name { get; set; }
        internal String To { get; set; }
        internal Stop Stop { get; set; }

        internal Journey(String name, String to, Stop stop)
        {
            Name = name;
            To = to;
            Stop = stop;
        }
    }
}
