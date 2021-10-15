// PieceworkWorker.cs
//         Title: IncInc Payroll (Piecework)
// Last Modified: Shweta Patel
//    Written By: 26/09/2021
// Stuent ID: 100773663
// Adapted from PieceworkWorker by Kyle Chapman, September 2019
// 
// This is a class representing individual worker objects. Each stores
// their own name and number of messages and the class methods allow for
// calculation of the worker's pay and for updating of shared summary
// values. Name and messages are received as strings.
// This is being used as part of a piecework payroll application.

using System.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace PiecesWorkPayroll
{
    class PieceworkWorker
    {
        #region "Variable declarations"

        // Instance variables
         string employeeName;
         int employeeMessages;
         bool isValid = true;
        static decimal overallPayroll;

        //constant variable or shared  class variable 
         const int MinimumMessage = 1;
         const int SentMessages1 = 1250;
         const int SentMessages2 = 2500;
         const int SentMessages3 = 3750;
         const int SentMessages4 = 5000;

        //constant variable for Pay base on the message sent 

         const decimal PayPerMessages = 0.02M;
         const decimal PayperMessages1 = 0.024M;
         const decimal PayPerMessages2 = 0.028M;
         const decimal PayPerMessages3 = 0.034M;
         const decimal PayPerMessages4 = 0.04M;
        internal static  string NameParameter;
        internal static  string RateParameter;


        #endregion

        #region "Constructors"

        /// <summary>
        /// PieceworkWorker constructor: accepts a worker's name and number of
        /// messages, sets and calculates values as appropriate.
        /// </summary>
        /// <param name="nameValue">the worker's name</param>
        /// <param name="messageValue">a worker's number of messages sent</param>
        public PieceworkWorker(string nameValue, string messagesValue)
        {
            // Validate and set the worker's name
            this.Name = nameValue;
            // Validate Validate and set the worker's number of messages
            this.Messages = messagesValue;
            // Calculcate the worker's pay and update all summary values
            findPay();
        }

        public PieceworkWorker(string nameValue, string messagesValue, string text) : this(nameValue, messagesValue)
        {
        }

        /// <summary>
        /// PieceworkWorker constructor: empty constructor used strictly for inheritance and instantiation
        /// </summary>


        #endregion

        #region "Class methods"

        /// <summary>
        /// Currently called in the constructor, the findPay() method is
        /// used to calculate a worker's pay using threshold values to
        /// change how much a worker is paid per message. This also updates
        /// all summary values.
        /// </summary>
        private void findPay()
        {
            if(isValid)
            {
                if(employeeMessages >= MinimumMessage && employeeMessages < SentMessages1)
                {
                    Pay = employeeMessages * PayPerMessages;
                }
                else if (employeeMessages >= SentMessages1 && employeeMessages < SentMessages2)
                {
                    Pay = employeeMessages * PayperMessages1;
                }
                else if (employeeMessages >= SentMessages2 && employeeMessages < SentMessages3)
                {
                    Pay = employeeMessages * PayPerMessages2;
                }
                else if (employeeMessages >= SentMessages3 && employeeMessages < SentMessages4)
                {
                    Pay = employeeMessages * PayPerMessages3;
                }
                else
                {
                    Pay = employeeMessages * PayPerMessages4;
                }
            }
            //Update the values
            overallPayroll += Pay;
            TotalMessages += employeeMessages;
            TotalWorkers++;
        }

        #endregion

        #region "Property Procedures"

        /// <summary>
        /// Gets and sets a worker's name
        /// </summary>
        /// <returns>an employee's name</returns>
        public string Name
        {
            get
            {
                return employeeName;
            }
            set
            {
                //validation for the worker's name 
                
                if(string.IsNullOrEmpty(value))
                {
                    isValid = false;
                    MessageBox.Show("The Worker name should not be empty.");
                }
                employeeName = value;
            }
        }

        /// <summary>
        /// Gets and sets the number of messages sent by a worker
        /// </summary>
        /// <returns>an employee's number of messages</returns>
        public string Messages
        {
            get
            {
                return employeeMessages.ToString();
            }
            set
            {
                // validation for the number of messages based on the
                if(int.TryParse(value, out employeeMessages))
                {
                    if (employeeMessages <= 0)
                    {
                        isValid = false;
                       MessageBox.Show("The Worker Message must be more than one", "Entry error");
                    }
                }
                else
                {
                    isValid = false;
                    MessageBox.Show("Please enter the number of message sent by the worker");
                }

                //employeeMessages = Convert.ToInteger(value); // This line is dangerous and should probably never appear in your code. Can you explain why? Post about it on the Q&A board and I'll give you a stock.
            }
        }

        /// <summary>
        /// Gets the worker's pay
        /// </summary>
        /// <returns>a worker's pay</returns>
        public decimal Pay { get; private set; }

        /// <summary>
        /// Gets the overall total pay among all workers
        /// </summary>
        /// <returns>the overall total pay among all workers</returns>
        public static decimal TotalPay
        {
            get
            {
                return overallPayroll;
            }
        }

        /// <summary>
        /// Gets the overall number of workers
        /// </summary>
        /// <returns>the overall number of workers</returns>
        public static int TotalWorkers { get; private set; }

        /// <summary>
        /// Gets the overall number of messages sent
        /// </summary>
        /// <returns>the overall number of messages sent</returns>
        public static int TotalMessages { get; private set; }

        /// <summary>
        /// Calculates and returns an average pay among all workers
        /// </summary>
        /// <returns>the average pay among all workers</returns>
        public static decimal AveragePay
        {
            get
            {
                if(TotalWorkers == 0)
                {
                    return 0;
                }
                return AveragePay;
               
            }
            
        }

        #endregion

    }
}
