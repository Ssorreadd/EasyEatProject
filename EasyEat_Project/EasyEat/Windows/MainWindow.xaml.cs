using EasyEat.HelperClasses;
using EasyEat.Pages;
using System.Windows;

namespace EasyEat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ListManager.SetDefaultInfo();

            FrameManager.MainFrame = MainWindowFrame;
            FrameManager.MainFrame.Navigate(new StartPage());
        }
    }
}
