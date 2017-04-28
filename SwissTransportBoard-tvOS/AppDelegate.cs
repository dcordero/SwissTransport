using Foundation;
using UIKit;

namespace SwissTransportBoard
{
	public class Application
	{
		static void Main(string[] args)
		{
			UIApplication.Main(args, null, "AppDelegate");
		}
	}

	[Register("AppDelegate")]
	public sealed class AppDelegate : UIApplicationDelegate
	{
		public override UIWindow Window { get; set; }
		private Wireframe wireframe { get; set; }

		public AppDelegate()
		{
			Window = new UIWindow(UIScreen.MainScreen.Bounds);
			wireframe = new Wireframe();
		}

		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			wireframe.PresentInitialViewController();
			Window.MakeKeyAndVisible();

			return true;
		}
	}
}

