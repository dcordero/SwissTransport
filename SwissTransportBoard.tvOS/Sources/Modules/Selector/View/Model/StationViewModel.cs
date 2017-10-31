using System;
using System.Collections.Generic;

namespace SwissTransportBoard.Modules.Selector.View.Model
{
    public class StationViewModel
    {
        public String Name { get; }

        internal StationViewModel(String name)
        {
            Name = name;
        }
    }
}
