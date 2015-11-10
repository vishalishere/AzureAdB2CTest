using System;
using AzureAdApp.PageBase;
using Windows.UI.Xaml;
using AzureAdApp.Handlers;
using System.Net.Http;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AzureAdApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : PrismPage
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LogWindow.Text = "";
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.GetStringAsync("http://localhost:28967/api/values");
                AddText(result);
            }
            catch(Exception ex)
            {
                AddText(ex.Message);
            }

            var token = await AuthenticationHandler.GetAuthorizationHeaderAsync();
            AddText("token:" + token.Token);
            GetValues(token.Token);
        }

        private async void SignupButton_Click(object sender, RoutedEventArgs e)
        {
            LogWindow.Text = "";

            var token = await AuthenticationHandler.CreateAccountAsync();
            AddText("token:" + token.Token);
            GetValues(token.Token);
        }


        private async void GetValues(string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            // Call to ApiAppOne
            try
            {
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
