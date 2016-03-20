using Xamarin.Forms;

namespace XamarinForms.SQLite
{
    public class App : Application
    {
        public App()
        {

            // The root page of your application
            MainPage = new SQLiteSamplePage().GetSampleContentPage();
        }
    }
}
