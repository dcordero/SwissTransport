using System;
using SwissTransportPortableLibrary.Models;
using SwissTransportPortableLibrary.NetworkDTOs;

namespace SwissTransportPortableLibrary.Transformers
{
    public class StopDTOToModel
    {
        internal static Stop Transform(StopDTO stopDTO)
        {
            return new Stop(LocationsDTOToModel.Transform(stopDTO.Station), stopDTO.Departure, stopDTO.Delay);
        }
    }
}
