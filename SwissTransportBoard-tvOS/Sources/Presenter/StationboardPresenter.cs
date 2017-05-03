﻿using System;
using SwissTransportBoard.View;
using SwissTransportPortableLibrary;
using SwissTransportPortableLibrary.Models;
using System.Collections.Generic;
using SwissTransportBoard.Sources.View.Model;

namespace SwissTransportBoard.Presenter
{
    public class StationboardPresenter : IStationboardPresenter
    {
        public WeakReference<IStationboardUI> View { get; set; }

        public StationboardPresenter(IStationboardUI view)
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
            SwissTransport swissTransport = new SwissTransport();
            List<Location> listOfLocations = await swissTransport.GetLocations("Oerlikon");
            Stationboard stationboard = await swissTransport.GetStationBoard("Oerlikon", listOfLocations[0].Id, Transportation.Bus);

            UpdateUI(stationboard);
        }

        private void UpdateUI(Stationboard stationboard)
        {
            var journeyViewModels = new List<JourneyViewModel>();
            foreach (var journey in stationboard.Journeys) {
				string stopTime = journey.Stop.Departure?.ToString();
                
                journeyViewModels.Add(new JourneyViewModel(journey.Name, stopTime, new List<string>(), ""));
            }

            IStationboardUI MyView;
            if (View.TryGetTarget(out MyView))
            {
                MyView.Configure(journeyViewModels);
            }
        }

        #endregion
    }
}
