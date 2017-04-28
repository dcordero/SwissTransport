using System;
using UIKit;

namespace SwissTransportBoard
{
    public class Wireframe
    {
        public void PresentInitialViewController()
        {
            UIViewController viewController = ServiceLocator.Instance.ProvideStationboardViewController();
            SetRootViewController(viewController);                                              
        }

        private void SetRootViewController(UIViewController viewController)
        {
            AppDelegate appDelegate = (AppDelegate) UIApplication.SharedApplication.Delegate;
            appDelegate.Window.RootViewController = viewController;
        }
    }
}
