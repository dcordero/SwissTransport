﻿using System;
using SwissTransportPortableLibrary.NetworkDTOs;
using SwissTransportPortableLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwissTransportPortableLibrary.Transformers
{
   public class LocationsDTOToLocation
    {
        public static List<Location> Transform(ListOfLocationsDTO listOfLocationsDTO)
        {
            List<Location> locations = new List<Location>();
            foreach (LocationDTO locationDTO in listOfLocationsDTO.Locations) {
                locations.Add(Transform(locationDTO));
            }
            return locations;
        }

        public static Location Transform(LocationDTO locationDTO)
        {
			return new Location(locationDTO.Id, locationDTO.Name);
		}
    }
}
