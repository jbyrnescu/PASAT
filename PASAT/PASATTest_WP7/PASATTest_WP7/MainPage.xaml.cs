using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

// Allow PASAT test work to be done in another thread
//using System.ComponentModel;

using System.Threading;     // allow sleep calls

// using System.Windows.Threading;

// Allow set up for a timer to use to help with audio play
using Microsoft.Xna.Framework;

using PASATTest.Controller;
using PASATTest.Model;

namespace PASATTest_WP7
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Shared within this class between methods
        // Needed by test completed checker
        private MainPage thisMainWindow = null;
        public delegate void TimerDoneDelegate();

        // Needed to setup and run PASAT
        private PasatTest pTest = null;
        private PASATTestThread pThread = null;
        
        // Support for a background worker thread
//        private BackgroundWorker bw = null;

        // Timer to simulate the XNA game loop (SoundEffect class is from the XNA Framework)
        private GameTimer gameTimer = null;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Create PASAT classes to use later
            pTest = new PasatTest();
            pThread = new PASATTestThread();

/* KEEP this as comment for now...
 * currently using common approach to create/start a thread: see RunTest
 * 
            // Set up to have a worker thread
            // Set up the PASAT test code on a background thread
            bw = new BackgroundWorker();

            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = false;

            bw.DoWork += new DoWorkEventHandler(pThread.bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
*/
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
      
            startButton.Name = "Test Running...";
            Thread.Sleep(10);
            

            // startButton.Visibility = System.Windows.Visibility.Collapsed;  // was .Hidden; for Win PC
            startButton.IsEnabled = false;

            // These are fixed for now
            // TODO  add way to change test parameters
            //
            pTest.SetNumTests( PasatTest.MIN_NUM_PRACTICE_TESTS );

            pTest.SetDelayBetweenPairs( PasatTest.MIN_DELAY_BETWEEN_PAIRS );

            // set the test Form
            pTest.SetFormAFlag( true );

            pTest.SetPracticeTestFlag( true );

            pThread.PASATTestThreadInit( pTest );

            pTest.SetTestDoneFlag( false );

            // Create Timer to simulate the XNA game loop (SoundEffect class is from the XNA Framework)
            if ( null == gameTimer )
            {
                gameTimer = new GameTimer();
                gameTimer.UpdateInterval = TimeSpan.FromMilliseconds(33);

                // Call FrameworkDispatcher.Update to update the XNA Framework internals.
                gameTimer.Update += delegate { try { CheckForDone(); } catch { } };
            }

            // Start the GameTimer running.
            gameTimer.Start();

            // Prime the pump or we'll get an exception.
            FrameworkDispatcher.Update();

            pThread.RunTest();  // run the test

/* KEEP this as comment for now...
* currently using common approach to create/start a thread: see RunTest
* 
            // IF the worker thread is idle start it async, need to call bw.CancelAsync() later to stop test early
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
*/

        }

        public void testCompleted()     // NOT currently used
        {
            startButton.IsEnabled = true;
            startButton.UpdateLayout();
            thisMainWindow.UpdateLayout();
        }

        // Called by a timer on UI (primary) thread every so often to see if the test completed
        private void CheckForDone()
        {
            try 
            { 
                FrameworkDispatcher.Update();
            }
            catch 
            { 
            }
            
            if ( true == pTest.GetTestDoneFlag() )
            {
                // stop the timer from calling here now
                gameTimer.Stop();
            }

            if ( true == pTest.GetTestDoneFlag() )
            {
                // Change UI to show test is finished
                startButton.IsEnabled = true;
                startButton.UpdateLayout();
                thisMainWindow.UpdateLayout();
            }
            return;
        }

/* KEEP this as comment for now...
* currently using common approach to create/start a thread: see RunTest
* 
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string msg = null;
            if ((e.Cancelled == true))
            {
                msg = "Test Canceled";
            }

            else if (!(e.Error == null))
            {
                msg = "Error: " + e.Error.Message;
            }

            else
            {
                msg = "Test Finished";
            }
            startButton.IsEnabled = true;
            startButton.Name = msg;
        }
*/

    }
}