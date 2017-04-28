using System;
using SwissTransportBoard.Presenter;
using SwissTransportBoard.View;
using UIKit;

namespace SwissTransportBoard
{
    public class ServiceLocator
    {
        private static readonly ServiceLocator instance = new ServiceLocator();

        private ServiceLocator() { }

        public static ServiceLocator Instance
        {
            get
            {
                return instance;
            }
        }

        public UIViewController ProvideStationboardViewController() 
        {
            StationboardViewController viewController = new StationboardViewController();

            viewController.Presenter = new StationboardPresenter(viewController);
            viewController.DataSource = new StationboardViewControllerDataSource();

            return viewController;
        }
    }
}
