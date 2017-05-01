using System;
using System.Collections.Generic;
using SwissTransportBoard.View;
using SwissTransportPortableLibrary;
using SwissTransportPortableLibrary.Models;

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

            IStationboardUI MyView;
            if (View.TryGetTarget(out MyView))
            {
                MyView.Configure();
            }
        }

        #endregion

        #region Private

        private async void FetchLocationsAsync()
        {
            SwissTransport swissTransport = new SwissTransport();
            List<Location> listOfLocations = await swissTransport.GetLocations("Oerlikon");
            Stationboard stationboard = await swissTransport.GetStationBoard(listOfLocations[0].Id);
        }

        #endregion
    }
}
