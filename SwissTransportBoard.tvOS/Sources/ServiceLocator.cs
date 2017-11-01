using System;
using SwissTransportBoard.Modules.Board.Presenter;
using SwissTransportBoard.Modules.Board.View;
using SwissTransportBoard.Modules.Selector.Presenter;
using SwissTransportBoard.Modules.Selector.View;
using SwissTransport.Models;
using UIKit;

namespace SwissTransportBoard
{
    class ServiceLocator
    {
        static readonly ServiceLocator instance = new ServiceLocator();

        ServiceLocator() { }

        internal static ServiceLocator Instance
        {
            get
            {
                return instance;
            }
        }

        internal UIViewController ProvideStationboardViewControllerFor(Location location) 
        {
            StationboardViewController viewController = new StationboardViewController();
            viewController.Presenter = new StationboardPresenter(viewController, location);
            viewController.DataSource = new StationboardViewControllerDataSource();

            return viewController;
        }

        internal UIViewController ProvideStationSelectorViewController(Wireframe wireframe)
        {
            StationSelectorViewController viewController = new StationSelectorViewController();
            StationSelectorPresenter presenter = new StationSelectorPresenter(viewController, wireframe);
            viewController.Presenter = presenter;
            viewController.DataSource = new StationSelectorViewControllerDataSource();
            viewController.Delegate = new StationSelectorViewControllerDelegate(presenter);

            UISearchController searchViewController = new UISearchController(viewController);
            UISearchContainerViewController searchContainerViewController = new UISearchContainerViewController(searchViewController);
            searchViewController.SearchResultsUpdater = viewController;
            searchViewController.View.BackgroundColor = UIColor.Clear.FromHex(0x0D2B88);

            return searchContainerViewController;
        }
    }
}
