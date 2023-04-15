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
    public partial class ShowUser : ContentPage
    {
        List<UserInfo> users;
        
        public ShowUser()
        {
            
            InitializeComponent();
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var db = new UserDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "user.db3"));
            users = await db.GetUsersAsync();
            usersListView.ItemsSource = users;
        }
        private async void OnUserSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selectedUser = (UserInfo)e.SelectedItem;
                await Navigation.PushAsync(new UserDetailsPage(selectedUser));
            }
        }
        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var userToDelete = ((ImageButton)sender).CommandParameter as UserInfo;
            var answer = await DisplayAlert("Delete user", $"Are you sure you want to delete {userToDelete.Name}?", "Yes", "No");
            if (answer)
            {
                var db = new UserDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "user.db3"));
                await db.DeleteUserAsync(userToDelete);
                users.Remove(userToDelete);
                usersListView.ItemsSource = db.GetUsersAsync().Result;
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddUser());
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShowUser());
            
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = searchBar.Text;

            var db = new UserDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "user.db3"));

            if (string.IsNullOrEmpty(searchText))
            {
              
                usersListView.ItemsSource = db.GetUsersAsync().Result;
            }
            else
            {


                try
                {
                    var filteredUsers = db.GetUsersAsync().Result.Where(u => u.Name.ToLower().Contains(searchText.ToLower())).ToList();
                    if (usersListView != null && filteredUsers != null)
                    {
                        usersListView.ItemsSource = filteredUsers;
                    }
                }
                catch (Exception ex)
                {

                }
                
               




            }
        }
    }
}