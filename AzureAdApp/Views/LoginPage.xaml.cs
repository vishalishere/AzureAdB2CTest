using System;
using AzureAdApp.PageBase;
using Windows.UI.Xaml;
using AzureAdApp.Handlers;
using System.Net.Http;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AzureAdApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : PrismPage
    {
        private string _token = String.Empty;
        public LoginPage()
        {
            this.InitializeComponent();
            GetDataButton.IsEnabled = false;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            LogWindow.Text = "";
            try
            {
                AddText("Trying to get some data from ApiAppOne before login");
                HttpClient client = new HttpClient();
                var result = await client.GetStringAsync("http://localhost:28967/api/values");
                AddText(result);
            }
            catch (Exception ex)
            {
                AddText(ex.Message);
            }
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {


            var token = await AuthenticationHandler.GetAuthorizationHeaderAsync();
            // AddText("login token:" + token.Token);
            _token = token.Token;
            GetDataButton.IsEnabled = true;
        }

        private async void SignupButton_Click(object sender, RoutedEventArgs e)
        {
            var token = await AuthenticationHandler.CreateAccountAsync();
            // AddText("sign up token:" + token.Token);
            _token = token.Token;
            GetDataButton.IsEnabled = true;
        }

        private async void GetDataButton_Click(object sender, RoutedEventArgs e)
        {
            GetValues(_token);
        }

        private async void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            LogWindow.Text = "";
        }

        private async void GetValues(string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            // Call to ApiAppOne
            try
            {
                AddText("Get some data from ApiAppOne after login");
                var apiAppOne = await client.GetStringAsync("http://localhost:28967/api/values");
                AddText("Response from ApiAppOne: " + apiAppOne);
            }
            catch(Exception ex)
            {
                AddText("Exception from ApiAppOne: " + ex.Message);

            }

            // call to ApiAppTwo
            try
            {
                AddText("Get some data from ApiAppTwo after login");
                var apiAppTwo = await client.GetStringAsync("http://localhost:28997/api/values");
                AddText("Response from ApiAppTwo: " + apiAppTwo);
            }
            catch (Exception ex)
            {
                AddText("Exception from ApiAppTwo: " + ex.Message);
            }
        }


        private void AddText(string text)
        {
            LogWindow.Text = LogWindow.Text + Environment.NewLine + text;
        }
    }
}
