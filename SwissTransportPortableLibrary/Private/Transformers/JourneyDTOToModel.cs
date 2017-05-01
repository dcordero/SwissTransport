using System;
using System.Collections.Generic;
using SwissTransportPortableLibrary.Models;
using SwissTransportPortableLibrary.NetworkDTOs;

namespace SwissTransportPortableLibrary.Transformers
{
    class JourneyDTOToModel
    {
        internal static List<Journey> Transform(List<JourneyDTO> journeysDTO)
        {
			List<Journey> journeys = new List<Journey>();
            foreach (JourneyDTO journeyDTO in journeysDTO)
			{
                journeys.Add(Transform(journeyDTO));
			}
			return journeys;
        }

        private static Journey Transform(JourneyDTO journeyDTO)
        {
            return new Journey(journeyDTO.Name, journeyDTO.To);
        }
    }
}
