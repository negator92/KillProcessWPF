using System.Windows;

namespace KillProcess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            (DataContext as ApplicationViewModel).TextBoxProcess = textBox;
            textBox.Focus();
        }
    }
}