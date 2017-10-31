using System;
using SwissTransportBoard.Modules.Selector.View;
using SwissTransportBoard.Modules.Selector.View.Model;
using SwissTransport;
using SwissTransport.Models;
using System.Collections.Generic;

namespace SwissTransportBoard.Modules.Selector.Presenter
{

    class StationSelectorPresenter : IStationSelectorPresenter
    {
        WeakReference<IStationSelectorUI> View { get; set; }

        internal StationSelectorPresenter(IStationSelectorUI view)
        {
            this.View = new WeakReference<IStationSelectorUI>(view);
        }

        #region IStationboardPresenter

        public void ViewDidLoad()
        {
            SearchStations("Oerl");
        }

        #endregion

        #region Private

        private async void SearchStations(String query)
        {
            SwissTransportClient swissTransportClient = new SwissTransportClient();
            List<Location> listOfLocations = await swissTransportClient.GetLocations(query);

            UpdateUIWithStations(listOfLocations);
        }

        private void UpdateUIWithStations(List<Location> listOfLocations)
        {
            var stationViewModels = new List<StationViewModel>();

            foreach (var location in listOfLocations) 
            {
                stationViewModels.Add(BuildViewModel(location));
            }

            IStationSelectorUI MyView;
            if (View.TryGetTarget(out MyView))
            {
                MyView.Configure(stationViewModels);
            }
        }

        private StationViewModel BuildViewModel(Location location)
        {
            return new StationViewModel(location.Name);
        }
        
        #endregion
    }

}
