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
        // Get handler from platform code (this is key otherwise the handler will not instantiate correctly)
        HttpClientHelper httpClientHelper = new HttpClientHelper();
        HttpClientHandler handler = httpClientHelper.GetInsecureHandler();
        var _httpClient = new HttpClient(handler);

        _httpClient.BaseAddress = new Uri("https://localhost:7161");
        var x = await _httpClient.GetAsync("https://localhost:7161/WeatherForecast");
    }
}

