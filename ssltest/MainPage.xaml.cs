namespace ssltest;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        HttpClientHandler handler = new HttpClientHandler
        {

        };

        handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
        {
            // Is this callback called on IOS Single Project, work on seperate Xamarin.iOS project
            Console.WriteLine(cert);
            return true;
        };

        var _httpClient = new HttpClient(handler);
        _httpClient.BaseAddress = new Uri("https://localhost:7161");
        var x = await _httpClient.GetAsync("https://localhost:7161/WeatherForecast");
    }
}


