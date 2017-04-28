using System;
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
            UIViewController viewController = new StationboardViewController();
            return viewController;
        }
    }
}
