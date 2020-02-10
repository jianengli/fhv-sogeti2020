using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using HouseApp.Models;

namespace HouseApp
{
    public partial class NotesPage : ContentPage
    {

        public NotesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HouseEntryPage
            {
                BindingContext = new House()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new HouseEntryPage
                {
                    BindingContext = e.SelectedItem as House
                });
            }
        }
    }
}