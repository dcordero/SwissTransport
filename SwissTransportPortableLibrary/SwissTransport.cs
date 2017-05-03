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
            var parameters = new Dictionary<string, string> 
            { 
                ["query"] = locationName 
            };

            var listOfLocationsDTO = await ApiClient.HttpGet<ListOfLocationsDTO>("locations", parameters);
            return LocationsDTOToModel.Transform(listOfLocationsDTO);
        }

        public async Task<Stationboard> GetStationBoard(string stationName, 
                                                        string stationId = null, 
                                                        Transportation? transportation = null,
                                                        DateTime? dateTime = null)
        {
            var parameters = new Dictionary<string, string> 
            { 
                ["station"] = stationName,
                ["id"] = stationId,
                ["transportations"] = transportation?.GetString(),
                ["datetime"] = dateTime?.ToString("yyyy-MM-dd HH:mm")
            };

            var stationboardDTO = await ApiClient.HttpGet<StationboardDTO>("stationboard", parameters);
            return StationboardDTOToModel.Transform(stationboardDTO);
        }

    }
}
