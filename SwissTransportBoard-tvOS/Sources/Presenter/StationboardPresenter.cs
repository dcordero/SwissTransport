using System;
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
            System.Collections.Generic.List<Location> listOfLocations = await swissTransport.GetLocations("Oerlikon");
            Stationboard stationboard = await swissTransport.GetStationBoard("Oerlikon", listOfLocations[0].Id);

            /*
            SwissTransport swissTransport = new SwissTransport();
            var listOfLocations = await swissTransport.GetLocations();
            */

            var i = 0;
        }

        #endregion
    }
}
