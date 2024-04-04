using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        double UT1_50, UT24_51, UT15_51, UT24_52;

        //1 значение напряжения 110 кВ ЭЧЭ-50
        private double tb_U110_50;
        public double TB_U110_50
        {
            get { return tb_U110_50; }
            set
            {
                tb_U110_50 = value;
                UT1_50 = Calculate.GetU27_5(tb_U110_50, Calculate.ConvertRPN(rpnT1_50_sld));
                TB_UT1_50 = UT1_50.ToString("F2");
                OnPropertyChanged(); //Можем оставить скобки пустыми название TB_UT1_50 само подставится, произойдет уведомление подписчиков о смене названия
            }

        }

        //2 значение напряжения 110 кВ ЭЧЭ-51
        private double tb_U110_51;
        public double TB_U110_51
        {
            get { return tb_U110_51; }
            set
            {
                tb_U110_51 = value;
                UT24_51 = Calculate.GetU27_5(tb_U110_51, Calculate.ConvertRPN(rpnT24_51_sld)); //расчет НН Т24 ЭЧЭ-51
                TB_UT24_51 = UT24_51.ToString("F2");

                UT15_51 = Calculate.GetU27_5(tb_U110_51, Calculate.ConvertRPN(rpnT15_51_sld)); //расчет НН Т15 ЭЧЭ-51
                TB_UT15_51 = UT15_51.ToString("F2");

                OnPropertyChanged();
            }

        }

        //3 значение напряжения 110 кВ ЭЧЭ-52
        private double tb_U110_52;
        public double TB_U110_52
        {
            get { return tb_U110_52; }
            set
            {
                tb_U110_52 = value;
                UT24_52 = Calculate.GetU27_5(tb_U110_52, Calculate.ConvertRPN(rpnT24_52_sld)); //расчет НН Т24 ЭЧЭ-52
                TB_UT24_52 = UT24_52.ToString("F2");
                OnPropertyChanged();
            }

        }

        //1 вывод значения напряжения 27,5 кВ Т1 ЭЧЭ-50
        private string tb_UT1_50;
        public string TB_UT1_50
        {
            get { return tb_UT1_50; }
            set
            {
                tb_UT1_50 = value;
                TB_I5051 = Calculate.GetSurgeCurent(UT1_50, UT24_51, r50_51).ToString("F2");
                OnPropertyChanged();
            }
        }

        //2 вывод значения напряжения 27,5 кВ Т2,4 ЭЧЭ-51
        private string tb_UT24_51;
        public string TB_UT24_51
        {
            get { return tb_UT24_51; }
            set
            {
                tb_UT24_51 = value;
                TB_I5051 = Calculate.GetSurgeCurent(UT1_50, UT24_51, r50_51).ToString("F2");
                OnPropertyChanged();
            }
        }

        //3 вывод значения напряжения 27,5 кВ Т1,5 ЭЧЭ-51
        private string tb_UT15_51;
        public string TB_UT15_51
        {
            get { return tb_UT15_51; }
            set
            {
                tb_UT15_51 = value;
                TB_I5152 = Calculate.GetSurgeCurent(UT15_51, UT24_52, R51_52).ToString("F2");
                OnPropertyChanged();
            }
        }

        //4 вывод значения напряжения 27,5 кВ Т2,4 ЭЧЭ-52
        private string tb_UT24_52;
        public string TB_UT24_52
        {
            get { return tb_UT24_52; }
            set
            {
                tb_UT24_52 = value;
                TB_I5152 = Calculate.GetSurgeCurent(UT15_51, UT24_52, R51_52).ToString("F2");
                OnPropertyChanged();
            }
        }

        //1 значение РПН Т1 ЭЧЭ-50
        private int rpnT1_50_sld;
        public int RPNT1_50_sld
        {
            get { return rpnT1_50_sld; }
            set
            {
                rpnT1_50_sld = value;
                UT1_50 = Calculate.GetU27_5(tb_U110_50, Calculate.ConvertRPN(rpnT1_50_sld)); //расчет НН Т1 ЭЧЭ-50
                TB_UT1_50 = UT1_50.ToString("F2");
                OnPropertyChanged();
            }
        }

        //2 значение РПН Т2,4 ЭЧЭ-51
        private int rpnT24_51_sld;
        public int RPNT24_51_sld
        {
            get { return rpnT24_51_sld; }
            set
            {
                rpnT24_51_sld = value;
                UT24_51 = Calculate.GetU27_5(tb_U110_51, Calculate.ConvertRPN(rpnT24_51_sld)); //расчет НН Т24 ЭЧЭ-51
                TB_UT24_51 = UT24_51.ToString("F2");
                OnPropertyChanged();
            }
        }

        //3 значение РПН Т1,5 ЭЧЭ-51
        private int rpnT15_51_sld;
        public int RPNT15_51_sld
        {
            get { return rpnT15_51_sld; }
            set
            {
                rpnT15_51_sld = value;
                UT15_51 = Calculate.GetU27_5(tb_U110_51, Calculate.ConvertRPN(rpnT15_51_sld)); //расчет НН Т15 ЭЧЭ-51
                TB_UT15_51 = UT15_51.ToString("F2");
                OnPropertyChanged();
            }
        }

        //4 значение РПН Т2,4 ЭЧЭ-52
        private int rpnT24_52_sld;
        public int RPNT24_52_sld
        {
            get { return rpnT24_52_sld; }
            set
            {
                rpnT24_52_sld = value;
                UT24_52 = Calculate.GetU27_5(tb_U110_52, Calculate.ConvertRPN(rpnT24_52_sld)); //расчет НН Т24 ЭЧЭ-52
                TB_UT24_52 = UT24_52.ToString("F2");
                OnPropertyChanged();
            }
        }


        //вывод значения уравнительного тока ЭЧЭ-50 - ЭЧЭ-51
        private string tb_I5051;
        public string TB_I5051
        {
            get { return tb_I5051; }
            set
            {
                tb_I5051 = value;
                OnPropertyChanged();
            }
        }

        //вывод значения уравнительного тока ЭЧЭ-51 - ЭЧЭ-52
        private string tb_I5152;
        public string TB_I5152
        {
            get { return tb_I5152; }
            set
            {
                tb_I5152 = value;
                OnPropertyChanged();
            }
        }

         //сопротивления участков контактной сети для расчета уравнительных токов

        private double r50_51;
        public double R50_51
        {
            get { return r50_51; }
            set
            {
                r50_51 = value;
                TB_I5051 = Calculate.GetSurgeCurent(UT1_50, UT24_51, r50_51).ToString("F2");
                OnPropertyChanged();
            }
        }

        private double r51_52;
        public double R51_52
        {
            get { return r51_52; }
            set
            {
                r51_52 = value;
                TB_I5152 = Calculate.GetSurgeCurent(UT15_51, UT24_52, R51_52).ToString("F2");
                OnPropertyChanged();
            }
        }

    }
}
