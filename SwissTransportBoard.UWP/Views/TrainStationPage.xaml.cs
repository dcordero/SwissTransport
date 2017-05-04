using SwissTransportBoard.UWP.Controls.Templates;
using SwissTransportPortableLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
        DispatcherTimer dt = new DispatcherTimer();
        public TrainStationPage()
        {
            this.InitializeComponent();
            _client = new SwissTransportPortableLibrary.SwissTransport();

            this.Loaded += TrainStationPage_Loaded;
            dt.Interval = TimeSpan.FromSeconds(60);
            dt.Tick += Dt_Tick;
        }

        private void Dt_Tick(object sender, object e)
        {
            Render();
        }

        private string _locationId;

        private async Task Render()
        {
            List<Transportation> transportations = new List<Transportation>();
            transportations.Add(Transportation.ArzExt);
            transportations.Add(Transportation.EcIc);
            transportations.Add(Transportation.IceTgvRj);
            transportations.Add(Transportation.Ir);
            transportations.Add(Transportation.ReD);
            transportations.Add(Transportation.SSNR);
            var board = await _client.GetStationBoard(null, _locationId, transportations, DateTime.Now.AddMinutes(5), 12);

            pnlJourneys.Children.Clear();
            txtTime.Text = DateTime.Now.ToString("HH:mm");

            foreach (var item in board.Journeys)
            {
                JourneyTemplate template = new JourneyTemplate();
                template.DataContext = item;

                pnlJourneys.Children.Add(template);
            }
        }

        private async void TrainStationPage_Loaded(object sender, RoutedEventArgs e)
        {
            var locations = await _client.GetLocations("Zürich Altstetten");            
            if (locations != null && locations.Count > 0)
            {
                var location = locations.First();
                txtStationName.Text = location.Name;
                _locationId = location.Id;
                await Render();
                dt.Start();
            }
        }
    }
}
