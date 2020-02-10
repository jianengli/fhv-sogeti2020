using System;
using System.IO;
using Xamarin.Forms;
using HouseApp.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Threading.Tasks;


namespace HouseApp
{
    public partial class HouseEntryPage : ContentPage
    {
        public HouseEntryPage()
        {
            InitializeComponent();
        }

        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.Current.IsCameraAvailable)
            {
                await DisplayAlert("Ops", "Nenhuma câmera detectada.", "OK");

                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(
                new StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    Directory = "Demo"
                });

            if (file == null)
                return;

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;

            });
        }
    }
}