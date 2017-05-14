using System;
using System.Collections.Generic;

namespace SwissTransportBoard.Sources.View.Model
{
    public class JourneyViewModel
    {
        public String Name { get; }
        public String DepartureTime { get; } 
        public String PassList { get; }
        public String Platform { get; }

        internal JourneyViewModel(String name, String departureTime, String passList, String platform)
        {
            Name = name;
            DepartureTime = departureTime;
            PassList = passList;
            Platform = platform;
        }
    }
}
