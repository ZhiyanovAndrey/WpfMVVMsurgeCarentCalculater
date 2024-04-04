using System.Windows;
using WpfMVVMsurgeCarentCalculater.ViewModels;

namespace WpfMVVMsurgeCarentCalculater
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

            //устанавливаем значения по умолчанию

            MainWindowViewModel vm = new MainWindowViewModel();
            vm.RPNT1_50_sld = 14;
            vm.RPNT24_51_sld = 13;
            vm.RPNT15_51_sld = 13;
            vm.RPNT24_52_sld = 14;
            vm.R50_51 = 20.769;
            vm.R51_52 = 25.1335;


            DataContext = vm; // получить значения в любом элементе в пределах MainWindow


        }
    }
}
