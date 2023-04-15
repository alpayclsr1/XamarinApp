using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void buttonNav_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page2());

        }

        private void addUser_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddUser());
        }

        private void showUser_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShowUser());
        }
    }
}
