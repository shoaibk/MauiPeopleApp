using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

namespace MauiPeopleApp.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var request = new AuthenticationRequestConfiguration("Fingerprint Login", "Scan your fingerprint");

        var result = await CrossFingerprint.Current.AuthenticateAsync(request);

        if (result.Authenticated)
        {
            // Navigate to list page after successful login
            await Navigation.PushAsync(new PersonListPage());
        }
        else
        {
            await DisplayAlert("Error", "Authentication failed", "OK");
        }
    }
}