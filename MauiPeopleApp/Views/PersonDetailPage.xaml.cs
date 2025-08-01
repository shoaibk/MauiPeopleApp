using MauiPeopleApp.Models;
using Microsoft.Maui.Controls;

namespace MauiPeopleApp.Views
{
    public partial class PersonDetailPage : ContentPage
    {
        public PersonDetailPage(Person person)
        {
            InitializeComponent();
            BindingContext = person;
        }
      
    }
}