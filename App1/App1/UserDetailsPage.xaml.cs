using System;
using System.Collections.Generic;
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
            
            
        }
    }
}