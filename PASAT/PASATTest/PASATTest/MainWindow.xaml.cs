using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Timers;
using System.Windows.Threading;

using PASATTest.Model;
using PASATTest.Controller;

namespace PASATTest
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Shared within this class between methods

        // Needed by test completed checker
        private MainWindow thisMainWindow = null;
        private Timer isDoneTimer = null;
        public delegate void TimerDoneDelegate();

        // Info or DEBUG helpers
        private int primaryThreadID = 0;        
        
        // Needed to setup and run PASAT
        private PasatTest pTest = null;
        private PASATTestThread pThread = null;

        public MainWindow()
        {
            InitializeComponent();

            // Set the reference to be this window so test call back can use later
            thisMainWindow = this;

            // Create an instance of the test interface model class
            pTest = new PasatTest();

            // Create an instance of the class that will run the test
            pThread = new PASATTestThread();
            pThread.PASATTestThreadInit( pTest) ;

            primaryThreadID = System.Threading.Thread.CurrentThread.ManagedThreadId;
            
            // Set defaults

            radioButtonFormA.IsChecked = true;
            radioButtonFormB.IsChecked = false;

            radioButtonPractice.IsChecked = true;
            radioButtonActualTest.IsChecked = false;

            radioButton3seconds.IsChecked = true;
            radioButton2seconds.IsChecked = false;
        }

        // Run Test button
        private void buttonRunTest_Click(object sender, RoutedEventArgs e)
        {
            // Hide the Run Test button
            buttonRunTest.Visibility = System.Windows.Visibility.Hidden;

            // set the test Form
            pTest.SetFormAFlag( true == radioButtonFormA.IsChecked );

            // get values from other controls
            // Delay 3 or 2 Seconds
            int delayBetweenPairs = PasatTest.MIN_DELAY_BETWEEN_PAIRS;

            if ( true == radioButton3seconds.IsChecked )
                delayBetweenPairs = PasatTest.MAX_DELAY_BETWEEN_PAIRS;

            pTest.SetDelayBetweenPairs( delayBetweenPairs );

            // If Practice, get number of tests from the Practice textbox
            pTest.SetPracticeTestFlag( true == radioButtonPractice.IsChecked );
            int numTests = 1;
            if ( true == radioButtonPractice.IsChecked )
            {
                try
                {
                    //Console.WriteLine("Text in textbox1: " + PASATTestThread.mainWindow.textBox1.Text);
                    numTests = Int32.Parse( textBoxNumOfPracticeTests.Text );
                }
                catch
                {
                    numTests = PasatTest.MIN_NUM_PRACTICE_TESTS;
                }

                // TODO: use a spin control or parsing during user changes in Edit box to have these limits
                if ( numTests < PasatTest.MIN_NUM_PRACTICE_TESTS )
                {
                    numTests = PasatTest.MIN_NUM_PRACTICE_TESTS;
                    
                    // Change UI to show number of tests actually used
                    textBoxNumOfPracticeTests.Text = numTests.ToString();
                }

                if ( PasatTest.MAX_NUM_PRACTICE_TESTS < numTests )
                {
                    numTests = PasatTest.MAX_NUM_PRACTICE_TESTS;
                
                    // Change UI to show number of tests actually used
                    textBoxNumOfPracticeTests.Text = numTests.ToString();
                }
            }
            else
                numTests = PasatTest.DEFAULT_NUM_TESTS;
            pTest.SetNumTests( numTests );

            pThread.PASATTestThreadInit( pTest );

            // Show estimated test time needed
            int minutes, seconds;
            string estTime = pTest.GetTestTimeEstimate( out minutes, out seconds );
            textBlockEstTime.Text = estTime;

            //myMessageBox( "Before running test..." );

            // Set up to check for test completion every 1 Second
            pTest.SetTestDoneFlag( false );
            if (null == isDoneTimer)
            {
                isDoneTimer = new Timer(1000); // Set up the timer for 1 Second
                isDoneTimer.Elapsed += new ElapsedEventHandler(CheckForDone);
            }
            isDoneTimer.Enabled = true;     // Enable the timer

            pThread.RunTest();  // run the test

            //MessageBox.Show("After return from call to RunTest ...");
            //button1.Visibility = Visibility.Visible;
            //button1.UpdateLayout();
            //this.UpdateLayout();
        }

        public void testCompleted()
        {
            buttonRunTest.Visibility = Visibility.Visible;
            buttonRunTest.UpdateLayout();
            this.UpdateLayout();
        }

        // Called by a timer on a thread (NOT from the UI primary thread) every so often to see if the test completed
        private void CheckForDone( object sender, ElapsedEventArgs e )
        {
            if ( true == pTest.GetTestDoneFlag() )
            {
                // stop the timer from calling here now
                isDoneTimer.Enabled = false;

                // Because this is NOT the UI thread, dispatch to a helper with access to UI controls/windows
                // Place delegate on the Dispatcher of the UI primary thread without waiting.
                thisMainWindow.Dispatcher.BeginInvoke( DispatcherPriority.Normal,
                    new TimerDoneDelegate(testCompleted));
            }
            return;
        }

        public void refreshWindow()
        {
            buttonRunTest.Visibility = Visibility.Visible;
            this.UpdateLayout();
        }

        private void mainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            pTest.SetTestDoneFlag( true );
        }

    }
}
