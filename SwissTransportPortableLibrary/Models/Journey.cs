﻿using System;
using System.Collections.Generic;

namespace SwissTransportPortableLibrary.Models
{
    public class Journey
    {
        public String Name { get; set; }
        public String To { get; set; }
        public Stop Stop { get; set; }
        public List<Stop> PassList { get; set; }

        internal Journey(String name, String to, Stop stop, List<Stop> passList)
        {
            Name = name;
            To = to;
            Stop = stop;
            PassList = passList;
        }
    }
}
