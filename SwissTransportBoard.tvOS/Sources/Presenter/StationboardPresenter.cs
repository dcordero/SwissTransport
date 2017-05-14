﻿using System;
using SwissTransportBoard.View;
using SwissTransport;
using SwissTransport.Models;
using System.Collections.Generic;
using SwissTransportBoard.Sources.View.Model;
using System.Text;
using System.Linq;

namespace SwissTransportBoard.Presenter
{
    class StationboardPresenter : IStationboardPresenter
    {
        WeakReference<IStationboardUI> View { get; set; } 

        internal StationboardPresenter(IStationboardUI view)
        {
            this.View = new WeakReference<IStationboardUI>(view);
        }

        #region IStationboardPresenter

        public void ViewDidLoad()
        {
            FetchLocationsAsync();
        }

        #endregion

        #region Private

        private async void FetchLocationsAsync()
        {
            SwissTransportClient swissTransportClient = new SwissTransportClient();
            List<Location> listOfLocations = await swissTransportClient.GetLocations("Oerlikon");

            List<Transportation> transportations = new List<Transportation>();
            transportations.Add(Transportation.ArzExt);
            transportations.Add(Transportation.EcIc);
            transportations.Add(Transportation.IceTgvRj);
            transportations.Add(Transportation.Ir);
            transportations.Add(Transportation.ReD);
            transportations.Add(Transportation.SSNR);

            Stationboard stationboard = await swissTransportClient.GetStationBoard(
                "Oerlikon",
                null,
                transportations,
                DateTime.Now,
                10);

            UpdateUI(stationboard);
        }

        private void UpdateUI(Stationboard stationboard)
        {
            var journeyViewModels = new List<JourneyViewModel>();

            foreach (var journey in stationboard.Journeys.Take(7)) 
            {
                journeyViewModels.Add(BuildViewModel(journey));
            }

            IStationboardUI MyView;
            if (View.TryGetTarget(out MyView))
            {
                MyView.Configure("Oerlikon", journeyViewModels);
            }
        }

        private JourneyViewModel BuildViewModel(Journey journey)
         {
            string passList = journey.To;
            if (journey.PassList != null & journey.PassList.Count > 1)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in journey.PassList.Skip(1).Take(3))
                {
                    sb.Append(item.Station.Name);
                    sb.Append("   ");
                }
                passList = sb.ToString();
            }

            return new JourneyViewModel(journey.Name, 
                                        journey.Stop.Departure?.ToString("HH:mm"), 
                                        passList, 
                                        journey.Stop.Platform);
         }

        #endregion
    }
}
