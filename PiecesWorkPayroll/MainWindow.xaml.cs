//file Name: MainWindow.xamls.cs

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

namespace PiecesWorkPayroll
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This button will calculate and display the total pay.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calculate_click(object sender, RoutedEventArgs e)
        {

            try
            {
                //create a new object
                PieceworkWorker worker = new PieceworkWorker (TextBoxWorkerName.Text, TextBoxMessageSent.Text, TextBoxTotalPay.Text);

                //Dispaly the worker's pay
                TextBoxTotalPay.Text = worker.Pay.ToString("c");
                TextBoxMessageSent.Text = worker.Pay.ToString("c");
                TextBoxWorkerName.Text = PieceworkWorker.TotalWorkers.ToString();
                //dispaly the summary value from the class
                

                //Disable the input relatred field

                TextBoxWorkerName.IsReadOnly = true;
                TextBoxMessageSent.IsReadOnly = true;
                TextBoxTotalPay.IsReadOnly = true;
                buttonCalculatePay.IsEnabled = false;
                buttonClear.Focus();
            }
            catch (ArgumentException error)
            {
                //MessageBox.Show(error.Message, "Entry Error");

                if(error.ParamName == PieceworkWorker.NameParameter)
                {
                    labelNameError.Content = error.Message;
                    TextBoxWorkerName.Background = Brushes.Pink;
                    TextBoxWorkerName.BorderBrush = Brushes.Red;
                    TextBoxWorkerName.SelectAll();
                    TextBoxWorkerName.Focus();
                }
                else if(error.ParamName == PieceworkWorker.RateParameter)
                {
                    labelMessageError.Content = error.Message;
                    TextBoxMessageSent.Background = Brushes.Pink;
                    TextBoxMessageSent.BorderBrush = Brushes.Red;
                    TextBoxMessageSent.SelectAll();
                    TextBoxMessageSent.Focus();
                }
            }
            //catch (ArgumentOutOfRangeException error)
            //{
              //  MessageBox.Show(error.Message);

            //}
            catch (Exception error)
            {
                MessageBox.Show("Please enter only numeric number");
            }

            //Disable input controls.
            TextBoxWorkerName.IsReadOnly = true;
            TextBoxMessageSent.IsReadOnly = true;
            buttonCalculatePay.IsEnabled = false;
            buttonClear.Focus();
        }
        /// <summary>
        /// This is clear butto, it will empty/clear the all field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_click(object sender, RoutedEventArgs e)
        {
            SetDefaults();
        }
        /// <summary>
        /// Reset the form to its default state with all input and output fields cleared. 
        /// </summary>
        private void SetDefaults()
        {

            //Clear all input fields.
            TextBoxWorkerName.Clear();
            TextBoxMessageSent.Clear();
            TextBoxTotalPay.Clear();

            //Re-enable input controls
            TextBoxWorkerName.IsReadOnly = false;
            TextBoxMessageSent.IsReadOnly = false;
            TextBoxTotalPay.IsReadOnly = false;
            buttonCalculatePay.IsEnabled = true;

            //set focus.
            TextBoxWorkerName.Focus();
        }

        /// <summary>
        /// It will exit the application. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
        /// <summary>
        /// Displays the summary from, Which then populates.
        /// </summary>
     
        private void SummaryClick(object sender, RoutedEventArgs e)
        {
            SummaryWindow myJoyfulSummaryWindow = new SummaryWindow();
            myJoyfulSummaryWindow.ShowDialog();

        }
        /// <summary>
        /// Highlight a textbox with red to indicate an error state and put the focus on it.
        /// </summary>
        /// <param name="textBoxInError">A textbox in an error state</param>
        private void HighlightError(TextBox textBoxInError)
        {
            textBoxInError.Background = Brushes.Pink;
            textBoxInError.BorderBrush = Brushes.Red;
            textBoxInError.SelectAll();
            textBoxInError.Focus();
        }
    }
}
