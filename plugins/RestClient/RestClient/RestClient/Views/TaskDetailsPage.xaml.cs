using RestClient.ViewModels;
using Xamarin.Forms;

namespace RestClient.Views
{
    public partial class TaskDetailsPage : ContentPage
    {
        public TaskDetailsPage(TasksViewModel tasksViewModel)
        {
            InitializeComponent();

            MessagingCenter.Subscribe<TasksViewModel, string>(this, "message", OnMessageReceived);

            BindingContext = tasksViewModel;
        }

        /// <summary>
        /// Will be invoked each time a message is sent 
        /// using the MessagingCenter from within the TasksViewModel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        private void OnMessageReceived(TasksViewModel sender, string message)
        {

            DisplayAlert("Notification", message, "Ok");
        }
    }
}
