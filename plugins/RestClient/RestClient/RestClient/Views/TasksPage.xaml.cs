using RestClient.Models;
using RestClient.ViewModels;
using Xamarin.Forms;

namespace RestClient.Views
{
    public partial class TasksPage : ContentPage
    {
        public TasksPage()
        {
            InitializeComponent();
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {

            TasksViewModel tasksViewModel = BindingContext as TasksViewModel;
            tasksViewModel.SelectedTask = e.Item as TaskModel;

            await Navigation.PushAsync(new TaskDetailsPage(tasksViewModel));
        }
    }
}
