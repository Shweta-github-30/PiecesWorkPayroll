// SummaryWindow.cs
//         Title: Summary Window (Piecework)
// Last Modified: Shweta Patel
//    Written By: 11/10/2021
// Stuent ID: 100773663
// Adapted from PieceworkWorker by Kyle Chapman, September 2019
// 



using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PiecesWorkPayroll
{
    /// <summary>
    /// Interaction logic for SummaryWindow.xaml
    /// </summary>
    public partial class SummaryWindow : Window
    {
        public SummaryWindow()
        {
            InitializeComponent();
            PopulateSummary();
        }
        /// <summary>
        /// Close the summary from (returing to the form that called it)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Fill in the textboxes on thr form with values from worker class. 
        /// </summary>

        private void PopulateSummary()
        {
            TextBoxTotalWorker.Text = PieceworkWorker.TotalWorkers.ToString();
            TextboxMessage.Text = PieceworkWorker.TotalMessages.ToString();
            textBoxWorkersPay.Text = PieceworkWorker.TotalPay.ToString();
            TextBoxAveragePay.Text = PieceworkWorker.TotalPay.ToString("c");
        }

    }
}
