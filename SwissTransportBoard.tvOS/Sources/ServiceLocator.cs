using System;
using SwissTransportBoard.Modules.Board.Presenter;
using SwissTransportBoard.Modules.Board.View;
using SwissTransportBoard.Modules.Selector.Presenter;
using SwissTransportBoard.Modules.Selector.View;
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

        internal UIViewController ProvideStationSelectorViewController()
        {
            StationSelectorViewController viewController = new StationSelectorViewController();
            viewController.Presenter = new StationSelectorPresenter(viewController);
            viewController.DataSource = new StationSelectorViewControllerDataSource();

            return viewController;
        }

        internal UIViewController ProvideStationboardViewController() 
        {
            StationboardViewController viewController = new StationboardViewController();
            viewController.Presenter = new StationboardPresenter(viewController);
            viewController.DataSource = new StationboardViewControllerDataSource();

            return viewController;
        }
    }
}
