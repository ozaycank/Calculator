using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CalculatorApp
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _calculation = string.Empty;
        private string _result= string.Empty;

        public string Calculation
        {
            get { return _calculation; }
            set
            {
                if (_calculation != value)
                {
                    _calculation = value ?? string.Empty;
                    OnPropertyChanged();
                }
            }
        }

        public string Result
        {
            get { return _result; }
            set
            {
                if (_result != value)
                {
                    _result = value ?? string.Empty;
                    OnPropertyChanged();
                }
            }
        }
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this; // Set the DataContext to this instance for data binding
        }

        // Event handler for the "Memory Clear" button
        private double _memoryValue = 0;

        private void MemoryClearButton_Click(object sender, RoutedEventArgs e)
        {
            _memoryValue = 0;
            // Optionally update a UI element to indicate that memory has been cleared
        }

        private void MemoryRecallButton_Click(object sender, RoutedEventArgs e)
        {
            // Display the value stored in memory in the result area
            Result = _memoryValue.ToString();
            Calculation = $"MR({_memoryValue})";
        }

        private void MemorySubtractionButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Result, out double resultValue))
            {
                _memoryValue -= resultValue;
                Calculation = $"M-({_memoryValue})";
            }
            else
            {
                // Handle invalid result value, e.g., non-numeric input
                Result = "Error";
                Calculation = "Invalid Input";
            }
        }

        // Event handler for the "Memory Addition" button
        private void MemoryAdditionButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Result, out double resultValue))
            {
                _memoryValue += resultValue;
                Calculation = $"M+({_memoryValue})";
            }
            else
            {
                // Handle invalid result value, e.g., non-numeric input
                Result = "Error";
                Calculation = "Invalid Input";
            }
        }


        // Event handler for the "Clear" button
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Result = "0";
            Calculation = string.Empty;
        }


        // Event handler for the "Change Sign" button
        private void ChangeSignButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Result, out double resultValue))
            {
                Result = (-resultValue).ToString();
                Calculation += $"(-{resultValue})";
            }
            else
            {
                // Handle invalid result value, e.g., non-numeric input
                Result = "Error";
                Calculation = "Invalid Input";
            }
        }


        // Event handler for the "Percent" button
        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Result, out double resultValue))
            {
                Result = (resultValue / 100).ToString();
                Calculation = $"{resultValue} %";
            }
        }

        // Event handler for the "Square Root" button
        private void SquareRootButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Result, out double resultValue) && resultValue >= 0)
            {
                Result = Math.Sqrt(resultValue).ToString();
                Calculation = $"√({resultValue})";
            }
            else
            {
                Result = "Error";
                Calculation = "Invalid Input";
            }
        }

        public void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                string buttonContent = button.Content.ToString();
                if (Result == "0" || Result == "Error")
                {
                    Result = buttonContent;
                }
                else
                {
                    Result += buttonContent;
                }
            }
        }

        public void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                string operation = button.Content.ToString();
                if (!string.IsNullOrEmpty(Result))
                {
                    if (!char.IsDigit(Result[^1]))
                    {
                        // Remove the last character if it's an operator
                        Calculation = Calculation.Substring(0, Calculation.Length - 1);
                    }
                    Calculation += $" {Result} {operation}";
                    Result = string.Empty;
                }
            }
        }


        // Event handler for the "Decimal" button
        private void DecimalButton_Click()
        {
            if (Result == "0" || Result == "Error")
            {
                Result = "0.";
            }
            else if (!Result.Contains("."))
            {
                Result += ".";
            }
        }

        // Event handler for the "Equals" button
        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Result))
            {
                Calculation += Result;
                try
                {
                    var result = new System.Data.DataTable().Compute(Calculation, "");
                    Result = result != null ? result.ToString() : string.Empty;
                    Calculation = string.Empty;
                }
                catch (Exception)
                {
                    Result = "Error";
                    Calculation = "Invalid Expression";
                }
            }
        }

        private const int MaxResultLength = 15;

        // Event handler for the "ResultTextBox" text changed event
        private void ResultTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            {
            // Limit the length of the result text
            if (Result.Length > MaxResultLength)
            {
                Result = Result.Substring(0, MaxResultLength);
            }

            // Handle key press events
            switch (e.Key)
            {
                case Key.D0:
                case Key.NumPad0:
                    NumberButton_Click("0");
                    break;
                case Key.D1:
                case Key.NumPad1:
                    NumberButton_Click("1");
                    break;
                case Key.D2:
                case Key.NumPad2:
                    NumberButton_Click("2");
                    break;
                case Key.D3:
                case Key.NumPad3:
                    NumberButton_Click("3");
                    break;
                case Key.D4:
                case Key.NumPad4:
                    NumberButton_Click("4");
                    break;
                case Key.D5:
                case Key.NumPad5:
                    NumberButton_Click("5");
                    break;
                case Key.D6:
                case Key.NumPad6:
                    NumberButton_Click("6");
                    break;
                case Key.D7:
                case Key.NumPad7:
                    NumberButton_Click("7");
                    break;
                case Key.D8:
                case Key.NumPad8:
                    NumberButton_Click("8");
                    break;
                case Key.D9:
                case Key.NumPad9:
                    NumberButton_Click("9");
                    break;


                case Key.Add:
                    OperationButton_Click("+");
                    break;
                case Key.Subtract:
                    OperationButton_Click("-");
                    break;
                case Key.Multiply:
                    OperationButton_Click("×");
                    break;
                case Key.Divide:
                    OperationButton_Click("÷");
                    break;
                case Key.Decimal:
                    DecimalButton_Click();
                    break;
                case Key.Enter:
                    EqualsButton_Click();
                    break;
                default:
                    break;
            }
        }
        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
