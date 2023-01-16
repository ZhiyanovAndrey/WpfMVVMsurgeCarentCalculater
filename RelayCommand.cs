using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMVVMsurgeCarentCalculater
{
    internal class RelayCommand:ICommand
    {
        private readonly Action<Object> execute;
        private readonly Func<object, bool> canexecute;

        public event EventHandler CanExecuteChanged //срабатывает каждый раз при смене состояния CanExecute делегирует CommandManager 
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<Object> Execute, Func<object, bool> CanExecute) //конструктор для использования класса для любой команды принимает два делегата
        {
            execute = Execute ?? throw new ArgumentNullException(nameof(Execute)); //присвоим переданный Execute только если он не null,
                                                                                   //а если null то смысла выполнять команду нет выбросим исключение
            canexecute = CanExecute;
        }
        public bool CanExecute(object parameter) => canexecute?.Invoke(parameter) ?? true; //проверяет доступность команды
        public void Execute(object parameter) => execute(parameter); //сработает при вызове команды
    }
}
