using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SwissTransportPortableLibrary.Models;
using SwissTransportPortableLibrary.NetworkDTOs;
using SwissTransportPortableLibrary.Transformers;

namespace SwissTransportPortableLibrary
{
    public class SwissTransport
    {
        private ApiClient ApiClient { get; set; }

        public SwissTransport()
        {
            ApiClient = new ApiClient();
        }

        public async Task<List<Location>> GetLocations(string locationName)
        {
            var listOfLocationsDTO = await ApiClient.HttpGet<ListOfLocationsDTO>(String.Format("locations?query={0}", locationName));
            return LocationsDTOToModel.Transform(listOfLocationsDTO);
        }

        public async Task<Stationboard> GetStationBoard(string stationId)
        {
            var stationboardDTO = await ApiClient.HttpGet<StationboardDTO>(String.Format("stationboard?station={0}", stationId));
            return StationboardDTOToModel.Transform(stationboardDTO);
        }

    }
}
