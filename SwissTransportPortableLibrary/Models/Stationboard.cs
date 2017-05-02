﻿using System;
using System.Collections.Generic;

namespace SwissTransportPortableLibrary.Models
{
    public class Stationboard
    {
        public Location Station { get; private set; }
        public List<Journey> Journeys { get; private set; }

        internal Stationboard(Location station, List<Journey> journeys)
        {
            Station = station;
            Journeys = journeys;
		}
    }
}
