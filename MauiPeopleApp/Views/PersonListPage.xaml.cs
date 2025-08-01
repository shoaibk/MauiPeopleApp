using MauiPeopleApp.Models;
using MauiPeopleApp.ViewModels;
using MauiPeopleApp.Views;

namespace MauiPeopleApp.Views;

public partial class PersonListPage : ContentPage
{
    private PersonListViewModel ViewModel => BindingContext as PersonListViewModel;

    public PersonListPage()
    {
        InitializeComponent();
        BindingContext = new PersonListViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (ViewModel.People.Count == 0)
            ViewModel.LoadPeopleCommand.Execute(null);
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Person selectedPerson)
        {
            // Navigate to detail page with selected person
            Navigation.PushAsync(new PersonDetailPage(selectedPerson));

            // Deselect the item
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}