using System;
using UIKit;

namespace SwissTransportBoard
{
    public class Wireframe
    {
        internal void PresentInitialViewController()
        {
            UIViewController viewController = ServiceLocator.Instance.ProvideStationSelectorViewController();
            SetRootViewController(viewController);
        }

        internal void PresentStationboardViewController()
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
