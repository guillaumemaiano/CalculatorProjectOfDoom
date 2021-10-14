using CalculatorProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalculatorProject.ViewModel
{
    public class CalculatorViewModel: INotifyPropertyChanged
    {
        private double _result;
        private string _visibilityLevel = "Hidden";
        private CalculatorModel _model = new CalculatorModel();

        public CalculatorModel Model { get => _model; }

        private ICommand _clickCommand;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnDisplayPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand CalculateAreaCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CalculatorCommandHandler(() => DisplayArea(), () => CanExecute));
            }
        }
        public bool CanExecute
        {
            get
            {
                // check if executing is allowed, i.e., validate, check if a process is running, etc. 
                return true;
            }
        }

        public double Result { get => _result; 
                set {
                _result = value;
                OnDisplayPropertyChanged();
            }
        }
        public string VisibilityLevel { get => _visibilityLevel; set { _visibilityLevel = value;
                OnDisplayPropertyChanged();
            } }

        public double HeightBoxValue { set
            {
                _model.Height = value;
                OnDisplayPropertyChanged();
            }
        }
        public double WidthBoxValue { set { _model.Width = value;
                OnDisplayPropertyChanged();
            } }

        private void CalculateArea()
        {
            Result = _model.area();
            // update call?
        }

        public void DisplayArea()
        {
            CalculateArea();
            VisibilityLevel = "Visible";
        }
    }

    public class CalculatorCommandHandler : ICommand
    {
        private Action _action;
        private Func<bool> _canExecute;

        /// <summary>
        /// Creates instance of the command handler
        /// </summary>
        /// <param name="action">Action to be executed by the command</param>
        /// <param name="canExecute">A bolean property to containing current permissions to execute the command</param>
        public CalculatorCommandHandler(Action action, Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Wires CanExecuteChanged event 
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Forcess checking if execute is allowed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
