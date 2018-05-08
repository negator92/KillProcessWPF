using System.Windows;

namespace KillProcess
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ApplicationViewModel ApplicationViewModel { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            ApplicationViewModel = new ApplicationViewModel();
        }
    }
}