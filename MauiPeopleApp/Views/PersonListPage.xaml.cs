using System.Runtime.InteropServices.JavaScript;
using MauiPeopleApp.Models;
using MauiPeopleApp.ViewModels;

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


    private async void OnSelectionChanged(object? sender, SelectionChangedEventArgs ev)
    {
        try
        {
            if (ev.CurrentSelection.Count > 0 && ev.CurrentSelection[0] is Person selectedPerson)
            {
                await Navigation.PushAsync(new PersonDetailPage(selectedPerson));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
}