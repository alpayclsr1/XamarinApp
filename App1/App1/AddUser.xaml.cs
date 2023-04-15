using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            });
            if (result != null)
            {
                ProfileImage.Source = ImageSource.FromFile(result.FullPath);
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;


            var user = new UserInfo
            {
                Name = name,
                Surname = surname,
                Email = email,
                Phone = phone
            };

            var db = new UserDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "user.db3"));
            await db.SaveUserAsync(user);
        }
    }
}