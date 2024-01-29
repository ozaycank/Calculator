using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

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
        private void MemoryClearButton_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for the "Memory Clear" button click event
        }

        // Event handler for the "Memory Recall" button
        private void MemoryRecallButton_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for the "Memory Recall" button click event
        }

        // Event handler for the "Memory Subtraction" button
        private void MemorySubtractionButton_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for the "Memory Subtraction" button click event
        }

        // Event handler for the "Memory Addition" button
        private void MemoryAdditionButton_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for the "Memory Addition" button click event
        }

        // Event handler for the "Clear" button
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for the "Clear" button click event
        }

        // Event handler for the "Change Sign" button
        private void ChangeSignButton_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for the "Change Sign" button click event
        }

        // Event handler for the "Percent" button
        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for the "Percent" button click event
        }

        // Event handler for the "Square Root" button
        private void SquareRootButton_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for the "Square Root" button click event
        }

        // Event handler for number buttons
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for number button click events
        }

        // Event handler for operation buttons
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for operation button click events
        }

        // Event handler for the "Decimal" button
        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for the "Decimal" button click event
        }

        // Event handler for the "Equals" button
        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic for the "Equals" button click event
        }

        // Event handler for the "ResultTextBox" text changed event
        private void ResultTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Add your logic for the "ResultTextBox" text changed event
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
