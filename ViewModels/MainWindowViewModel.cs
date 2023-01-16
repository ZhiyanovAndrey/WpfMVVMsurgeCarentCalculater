using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVMsurgeCarentCalculater.Models;

namespace WpfMVVMsurgeCarentCalculater.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string PropertyName = null) //что бы заставить событие сработать и не вызывать в каждом свойстве Invoke пропишем отдельным методом
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }


        //значение напряжения 110 кВ ЭЧЭ-50
        private double tb_U110_50;
        public double TB_U110_50
        {
            get { return tb_U110_50; }
            set
            {
                tb_U110_50 = value;
                OnPropertyChanged(); //Можем оставить скобки пустыми название Num само подставится, произойдет уведомление подписчиков о смене названия
            }

        }

        //значение напряжения 110 кВ ЭЧЭ-51
        private double tb_U110_51;
        public double TB_U110_51
        {
            get { return tb_U110_51; }
            set
            {
                tb_U110_51 = value;
                OnPropertyChanged();
            }

        }

        //вывод значения напряжения 27,5 кВ Т1 ЭЧЭ-50
        private string tb_UT1_50;
        public string TB_UT1_50
        {
            get { return tb_UT1_50; }
            set
            {
                tb_UT1_50 = value;
                OnPropertyChanged();
            }

        }

        //значение РПН Т1 ЭЧЭ-50
        private int rpnT1_50_sld;
        public int RPNT1_50_sld
        {
            get { return rpnT1_50_sld; }
            set
            {
                rpnT1_50_sld = value;
                OnPropertyChanged();
            }

        }

        public ICommand AddCommand { get; } //доступно только для чтения
        private void OnAddCommandExecute(object p)
        {
            TB_UT1_50 = (RPNT1_50_sld + TB_U110_50).ToString();

        }
        private bool CanAddCommandExecuted(object p)
        {
    return true;
        }
        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecuted); //действия которые мы определим в методах
                                                                                       //через конструктор передадутся в команду
                                                                                       //получится полноценная команда с 2-мя методами и событием

        }

    }
}
