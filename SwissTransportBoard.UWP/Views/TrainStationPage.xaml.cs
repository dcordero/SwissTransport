using SwissTransportBoard.UWP.Controls.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SwissTransportBoard.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TrainStationPage : Page
    {
        SwissTransportPortableLibrary.SwissTransport _client;

        public TrainStationPage()
        {
            this.InitializeComponent();
            _client = new SwissTransportPortableLibrary.SwissTransport();

            this.Loaded += TrainStationPage_Loaded;
        }

        private async void TrainStationPage_Loaded(object sender, RoutedEventArgs e)
        {
            //stadelhofelId = "008503059"
            //stadelhofen = ""008503003"
            var locations = await _client.GetLocations("Stadelhofen");            
            if (locations != null && locations.Count > 0)
            {
                var location = locations.First();
                txtStationName.Text = location.Name;

                var board = await _client.GetStationBoard(null, location.Id);

                foreach (var item in board.Journeys.Take(15))
                {
                    JourneyTemplate template = new JourneyTemplate();
                    template.DataContext = item;

                    pnlJourneys.Children.Add(template);
                }
            }
        }
    }
}
