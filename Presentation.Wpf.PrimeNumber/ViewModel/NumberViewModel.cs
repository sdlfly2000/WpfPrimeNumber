using Presentation.Wpf.PrimeNumber.Model;
using Presentation.Wpf.PrimeNumber.ValidationRules;
using System.ComponentModel;

namespace Presentation.Wpf.PrimeNumber.ViewModel
{
    public class NumberViewModel : INotifyPropertyChanged
    {
        private const string ErrorMsg = "Please enter a integer!";

        private Number _number;
        private string _errorMessage = string.Empty;
        private string _messagePrimeNumber = string.Empty;
        private string _debugMessage = string.Empty;
        
        private INumberValidationRule _numberValidationRule;

        public event PropertyChangedEventHandler PropertyChanged;

        public NumberViewModel()
        {
            _number = new Number();
        }

        public string ErrorMessage {
            get { return _errorMessage; }
            set {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        public string MessagePrimeNumber { 
            get { return _messagePrimeNumber; } 
            set {
                _messagePrimeNumber = value; 
                OnPropertyChanged("MessagePrimeNumber"); 
            } 
        }

        public string DebugMessage
        {
            get { return _debugMessage; }
            set { _debugMessage = value; OnPropertyChanged("DebugMessage"); }
        }

        public object Value
        {
            get { return _number.Value.ToString(); }
            set {

                if (_numberValidationRule.validate(value))
                {
                    var vaildValue = int.Parse(value.ToString());
                    if (_number.Value != vaildValue)
                    {
                        _number.Value = vaildValue;
                    }
                    _errorMessage = string.Empty;
                }
                else
                {
                    _number.Value = 0;
                    _errorMessage = ErrorMsg;
                }
                OnPropertyChanged("Value");
                OnPropertyChanged("ErrorMessage");
            }               
            
        }

        public void SetNumberValidationRule(INumberValidationRule rule)
        {
            _numberValidationRule = rule;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
