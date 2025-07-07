using NewsApp.Pages;

namespace NewsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Enable stack-based navigation
            MainPage = new NavigationPage(new NewsHomePage());
        }
    }
}
