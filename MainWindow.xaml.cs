using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
