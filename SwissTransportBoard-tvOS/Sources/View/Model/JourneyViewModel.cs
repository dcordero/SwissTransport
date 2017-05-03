using System;
using System.Collections.Generic;

namespace SwissTransportBoard.Sources.View.Model
{
    public class JourneyViewModel
    {
        public String Name { get; }
        public String Time { get; } 
        public List<String> To { get; }
        public String Platform { get; }

        internal JourneyViewModel(String name, String time, List<String> to, String platform)
        {
            Name = name;
            Time = time;
            To = to;
            Platform = platform;
        }
    }
}
