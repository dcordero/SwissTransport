using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using SwissTransportPortableLibrary.Models;
using SwissTransportPortableLibrary.NetworkDTOs;
using SwissTransportPortableLibrary.Transformers;

namespace SwissTransportPortableLibrary
{
    public class SwissTransport
    {
        private const string ApiBaseAddress = "http://transport.opendata.ch/v1/";

        protected HttpClient ApiClient { get; private set; }

        public SwissTransport()
        {
            ApiClient = CreateClient();
        }

        #region Public

        public async Task<List<Location>> GetLocations(string locationName)
        {
            var listOfLocationsDTO = await HttpGet<ListOfLocationsDTO>(String.Format("locations?query={0}", locationName));
            return LocationsDTOToLocation.Transform(listOfLocationsDTO);
        }

        public async Task<Stationboard> GetStationBoard(string stationId)
        {
            var stationboardDTO = await HttpGet<StationboardDTO>(String.Format("stationboard?station={0}", stationId));
            return StationboardDTOToModel.Transform(stationboardDTO);
        }

        #endregion


        #region Private

        private HttpClient CreateClient()
        {
            HttpClient apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(ApiBaseAddress);

            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return apiClient;
        }


        public async Task<T> HttpGet<T>(String path) where T : class
        {
            HttpResponseMessage response = await ApiClient.GetAsync(path);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        #endregion
    }
}
