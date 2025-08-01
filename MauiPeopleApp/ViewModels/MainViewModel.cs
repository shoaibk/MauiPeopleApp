using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

namespace MauiPeopleApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task LoginWithFingerprint()
        {
#if IOS
            await App.Current.MainPage.DisplayAlert("Platform", "You're on iOS", "OK");
#endif
            // var isAvailable = await CrossFingerprint.Current.IsAvailableAsync();
            var isAvailable = false;
            try
            {
                isAvailable = await CrossFingerprint.Current.IsAvailableAsync(allowAlternativeAuthentication:true);
                await App.Current.MainPage.DisplayAlert("Info", $"Biometric available: {isAvailable}", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.ToString(), "OK");
            }
            
            if (!isAvailable)
            {
                await Shell.Current.DisplayAlert("Error", "Biometric authentication not available.", "OK");
                return;
            }

            var result = await CrossFingerprint.Current.AuthenticateAsync(new AuthenticationRequestConfiguration("Authentication", "Authenticate to continue")
            {
                CancelTitle = "Cancel",
                FallbackTitle = "Use PIN"
            });

            if (result.Authenticated)
            {
                await Shell.Current.GoToAsync("//PersonListPage");
            }
            else
            {
                await Shell.Current.DisplayAlert("Failed", "Authentication failed.", "OK");
            }
        }
    }
}