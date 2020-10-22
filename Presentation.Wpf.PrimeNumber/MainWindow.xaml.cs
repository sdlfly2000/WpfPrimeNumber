using Presentation.Wpf.PrimeNumber.Actions;
using Presentation.Wpf.PrimeNumber.ValidationRules;
using Presentation.Wpf.PrimeNumber.ViewModel;
using System;
using System.Windows;

namespace Presentation.Wpf.PrimeNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string FindItMsg = "Yes, it is a Prime Number!! Congrats!!";
        private const string NotFindItMsg = "No, it is NOT a Prime Number!! Try again!!";

        private readonly IPrimeNumberAction _primeNumberAction;

        public MainWindow(
            INumberValidationRule numberValidationRule,
            IPrimeNumberAction primeNumberAction)
        {
            InitializeComponent();

            var model = new NumberViewModel();
            model.SetNumberValidationRule(numberValidationRule);
            DataContext = model;

            _primeNumberAction = primeNumberAction;

        }

        #region Private Methods

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            var numberViewModel = DataContext as NumberViewModel;

            numberViewModel.DebugMessage = "Running...";

            RunIsPrimeNum(numberViewModel);
            var isPrimeNumber = RunIsPrimeNumImproved(numberViewModel);

            numberViewModel.MessagePrimeNumber = isPrimeNumber
                ? FindItMsg
                : NotFindItMsg;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            var numberViewModel = DataContext as NumberViewModel;
            numberViewModel.Value = 0;
            numberViewModel.ErrorMessage = string.Empty;
            numberViewModel.MessagePrimeNumber = string.Empty;
            numberViewModel.DebugMessage = string.Empty;
        }

        private bool RunIsPrimeNum(NumberViewModel model)
        {
            var startTime = DateTime.Now;
            var isPrimeNumber = _primeNumberAction.IsPrimeNumber(int.Parse(model.Value.ToString()));
            var endTime = DateTime.Now;

            model.DebugMessage = "Method 1 " + Environment.NewLine;
            model.DebugMessage += "Time Elapse: " + (endTime - startTime).TotalMilliseconds + "ms" + Environment.NewLine;
            model.DebugMessage += "---------------------------------";

            return isPrimeNumber;
        }

        private bool RunIsPrimeNumImproved(NumberViewModel model)
        {
            var startTime = DateTime.Now;
            var isPrimeNumber = _primeNumberAction.IsPrimeNumberImproved(int.Parse(model.Value.ToString()));
            var endTime = DateTime.Now;

            model.DebugMessage += "Method Improved" + Environment.NewLine;
            model.DebugMessage += "Time Elapse: " + (endTime - startTime).TotalMilliseconds + "ms" + Environment.NewLine;

            return isPrimeNumber;
        }

        #endregion
    }
}
