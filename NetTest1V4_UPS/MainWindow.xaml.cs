using NetTest1V4_UPS.IoC;
using NetTest1V4_UPS.IoCCore;
using NetTest1V4_UPS.ViewModels;
using System.Windows;

namespace NetTest1V4_UPS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IoCFactory.Instance.CurrentContainer = new IoCUnityContainer();
            var vm = IoCFactory.Instance.CurrentContainer.Resolve<VMMain>();
            DataContext = vm;

            //var appController = new ApplicationController();
            //var _viewModel = new VMMain(appController);
            //// The DataContext serves as the starting point of Binding Paths
            //DataContext = _viewModel;
        }
    }
}
