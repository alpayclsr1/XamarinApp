using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUser : ContentPage
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        async void Button_Clicked_1(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {


                Title = "Pick a Profile Photo"

            }) ;

            if (result != null)
            {
                using (var stream = await result.OpenReadAsync())
                {
                    var originalBitmap = SKBitmap.Decode(stream);
                    var resizedBitmap = originalBitmap.Resize(new SKImageInfo(400,400), SKFilterQuality.High);
                    var image = SKImage.FromBitmap(resizedBitmap);
                    var data = image.Encode(SKEncodedImageFormat.Jpeg, 80);
                    var memoryStream = new MemoryStream();
                    data.SaveTo(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    var skStream = new SKManagedStream(memoryStream);
                    var byteArray = memoryStream.ToArray();
                    ProfileImage.Source = ImageSource.FromStream(() => new MemoryStream(byteArray));
                }
            }

            }
        

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }

        private async void saveButton_Clicked(object sender, EventArgs e)
        {

            if (txtName.Text==null || txtEmail.Text==null)
            {
                await DisplayAlert("Warning", "Name or Email cannot be null!", "OK");
            }
            else
            {
                string name = txtName.Text;
                string surname = txtSurname.Text;
                string email = txtEmail.Text;
                string phone = txtPhone.Text;
                string password = txtPassword.Text;
                byte[] imageData;
                var stream = await ((StreamImageSource)ProfileImage.Source).Stream(CancellationToken.None);
                using (var memoryStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);
                    imageData = memoryStream.ToArray();
                }


                var user = new UserInfo
                {
                    Name = name,
                    Surname = surname,
                    Email = email,
                    Phone = phone,
                    Password = password,
                    Photo = imageData
                };

                var db = new UserDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "user.db3"));
                await db.SaveUserAsync(user);


                Navigation.PushAsync(new ShowUser());

            }
            
           
        }
    }
}