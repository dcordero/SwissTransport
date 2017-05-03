using System;
using System.Threading.Tasks;
using System.Linq;
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
            var parameters = new Dictionary<string, object> 
            { 
                ["query"] = locationName 
            };

            var listOfLocationsDTO = await ApiClient.HttpGet<ListOfLocationsDTO>("locations", parameters);
            return LocationsDTOToModel.Transform(listOfLocationsDTO);
        }

        public async Task<Stationboard> GetStationBoard(string stationName, 
                                                        string stationId = null, 
                                                        List<Transportation> transportations = null,
                                                        DateTime? dateTime = null,
                                                        int? limit = null)
        {
            var parameters = new Dictionary<string, object>
            {
                ["station"] = stationName,
                ["id"] = stationId,
                ["transportations"] = transportations.Select(x => x.GetString()).ToList(),
                ["datetime"] = dateTime?.ToString("yyyy-MM-dd HH:mm"),
                ["limit"] = limit?.ToString()
            };

            var stationboardDTO = await ApiClient.HttpGet<StationboardDTO>("stationboard", parameters);
            return StationboardDTOToModel.Transform(stationboardDTO);
        }

    }
}
