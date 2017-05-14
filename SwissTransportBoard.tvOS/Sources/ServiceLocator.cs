using System;
using SwissTransportBoard.Presenter;
using SwissTransportBoard.View;
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

        internal UIViewController ProvideStationboardViewController() 
        {
            StationboardViewController viewController = new StationboardViewController();

            viewController.Presenter = new StationboardPresenter(viewController);
            viewController.DataSource = new StationboardViewControllerDataSource();

            return viewController;
        }
    }
}
