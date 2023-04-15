using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailsPage : ContentPage
    {
        public UserDetailsPage(UserInfo user)
        {
            InitializeComponent();
            name.Text = user.Name;
            surname.Text = user.Surname;
            email.Text = user.Email;
            phone.Text = user.Phone;
            password.Text = user.Password;

            try
            {
                if (user != null && user.Photo != null )
                {
                    profile.Source = ImageSource.FromStream(() => new MemoryStream(user.Photo));
                }
                else
                {
                    profile.Source = "default_profile_image.png";
                }

            }
            catch (Exception ex)
            {

            }

            
            
                         
            
            
        }
    }
}