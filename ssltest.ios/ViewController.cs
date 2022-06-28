using Foundation;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using UIKit;

namespace ssltest.ios
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public async override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            HttpClientHandler handler = new HttpClientHandler
            {

            };

            handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
            {
                // Is this callback called on IOS Single Project, work on seperate Xamarin.iOS project
                Console.WriteLine(cert);
                return true;
            };

            // Wait for API to load up
            await Task.Delay(5000);

            var _httpClient = new HttpClient(handler);
            _httpClient.BaseAddress = new Uri("https://localhost:7161");
            var x = await _httpClient.GetAsync("https://localhost:7161/WeatherForecast");
            Console.WriteLine(await x.Content.ReadAsStringAsync());
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
