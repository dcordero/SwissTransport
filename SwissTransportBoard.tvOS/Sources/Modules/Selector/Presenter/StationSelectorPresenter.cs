using System;
using SwissTransportBoard.Modules.Selector.View;
using SwissTransportBoard.Modules.Selector.View.Model;
using SwissTransport;
using SwissTransport.Models;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace SwissTransportBoard.Modules.Selector.Presenter
{

    class StationSelectorPresenter : IStationSelectorPresenter
    {
        WeakReference<IStationSelectorUI> View { get; set; }

        private Wireframe Wireframe;
        private List<Location> Locations;

        internal StationSelectorPresenter(IStationSelectorUI view, Wireframe wireframe)
        {
            this.View = new WeakReference<IStationSelectorUI>(view);
            this.Wireframe = wireframe;
        }

        #region IStationboardPresenter

        public void ViewDidLoad()
        {
            SearchStations("Oerl");
        }

        public void StationSelectedAt(NSIndexPath indexPath)
        {
            if (indexPath.Row < Locations.Count)
            {
                var item = Locations[indexPath.Row];

                IStationSelectorUI MyView;
                if (View.TryGetTarget(out MyView))
                {
                    Wireframe.PresentStationboardViewController(MyView.ViewController(), item);
                }
            }            
        }

        #endregion

        #region Private

        private async void SearchStations(String query)
        {
            SwissTransportClient swissTransportClient = new SwissTransportClient();
            List<Location> listOfLocations = await swissTransportClient.GetLocations(query);
            this.Locations = listOfLocations;
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
