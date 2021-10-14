using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject.Model
{
    public class CalculatorModel: INotifyPropertyChanged
    {
        private double _height;

        private double _width;

        public double Width { set
            {
                _width = value;
                OnCoolPropertyChanged();
            }
        }
        public double Height { set
            {
                _height = value;
                OnCoolPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public double area()
        {
            return _height * _width;
        }

        protected virtual void OnCoolPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
