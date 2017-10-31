using System;
using UIKit;
using SwissTransport.Models;

namespace SwissTransportBoard
{
    public class Wireframe
    {
        internal void PresentInitialViewController()
        {
            UIViewController viewController = ServiceLocator.Instance.ProvideStationSelectorViewController(this);
            SetRootViewController(viewController);
        }

        internal void PresentStationboardViewController(UIViewController fromViewController, Location location)
        {
            UIViewController viewController = ServiceLocator.Instance.ProvideStationboardViewControllerFor(location);
            fromViewController.PresentViewController(viewController, true, null);
            SetRootViewController(viewController);
        }

        private void SetRootViewController(UIViewController viewController)
        {
            AppDelegate appDelegate = (AppDelegate) UIApplication.SharedApplication.Delegate;
            appDelegate.Window.RootViewController = viewController;
        }
    }
}
