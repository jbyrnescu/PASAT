using System;
using Gtk;
using GLib;

using System.Threading;
using System.Runtime.InteropServices;

using PASAT_Mono;


public partial class MainWindow: Gtk.Window
{
    // Shared within this class between methods

	// Needed by test completed checker
	private MainWindow thisMainWindow = null;

	// Needed to setup and run PASAT
    private PasatTest pTest = null;
    private PASATTestThread pThread = null;

	// Info or DEBUG helpers
	private int primaryThreadID = 0;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		// Set the reference to be this window so test call back can use later
		thisMainWindow = this;

		// Create an instance of the test interface model class
		pTest = new PasatTest();

		// Create an instance of the class that will run the test
		pThread = new PASATTestThread();

		primaryThreadID = System.Threading.Thread.CurrentThread.ManagedThreadId;
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		pTest.SetTestDoneFlag( true );
		Application.Quit ();
		a.RetVal = true;
	}

	protected void RunTestOnClicked (object sender, System.EventArgs e)
	{
		//throw new System.NotImplementedException ();
		int numTests = 1;

		// Hide the Run Test button
		this.buttonRunTest.Visible = false;

		// Set test values from the controls

	    // If Practice, get number of tests from the Practice spinbutton
        if ( true == this.radiobuttonPractice.Active )
        {
            try
            {
				numTests = this.spinbuttonNumPractice.ValueAsInt;
            }
            catch
            {
                numTests = PasatTest.MIN_NUM_PRACTICE_TESTS;
            }

            if (numTests < PasatTest.MIN_NUM_PRACTICE_TESTS)
                numTests = PasatTest.MIN_NUM_PRACTICE_TESTS;

            if (PasatTest.MAX_NUM_PRACTICE_TESTS < numTests)
                numTests = PasatTest.MAX_NUM_PRACTICE_TESTS;
        }
        else
            numTests = PasatTest.DEFAULT_NUM_TESTS;
        pTest.SetNumTests(numTests);

        // get values from other controls
        // Delay 3 or 2 Seconds
        int delayBetweenPairs = PasatTest.MIN_DELAY_BETWEEN_PAIRS;

        if ( true == this.radiobutton3seconds.Active )
            delayBetweenPairs = PasatTest.MAX_DELAY_BETWEEN_PAIRS;

        pTest.SetDelayBetweenPairs(delayBetweenPairs);

        // set the test Form
        pTest.SetFormAFlag( true == radiobuttonFormA.Active );

        pTest.SetPracticeTestFlag( true == radiobuttonPractice.Active );

		pThread.PASATTestThreadInit( pTest );

        // Show estimated test time needed
        int minutes, seconds;
        string estTime = pTest.GetTestTimeEstimate( out minutes, out seconds );
        labelTimeEstimate.Text = estTime;

		// Set up to check for test completion every 1 Second
		pTest.SetTestDoneFlag( false );
		GLib.Timeout.Add( 1000, new GLib.TimeoutHandler( CheckForDone ));

		//myMessageBox( "Before running test..." );

		pThread.RunTest();  // run the test

	}

	public void myMessageBox( string message )
	{
		bool showMsg = true;
		string msg = null;

		// Get current thread ID
		int threadID = System.Threading.Thread.CurrentThread.ManagedThreadId;

		// Get domain ID
		int domainID = System.Threading.Thread.GetDomainID();

		// App domain name
		string domainName = AppDomain.CurrentDomain.FriendlyName;

		if ( threadID == primaryThreadID )
			msg = "Primary ";
		else
		{
			msg = "Background ";
			showMsg = false;	// problem with running from threads other than the Primary
		}

		msg += "thread, ";
		msg += "ID: " + threadID + "\n";
		msg += "domain Name: " + domainName + "\n";
		msg += "domain ID: " + domainID + "\n";
		msg += message;

		if ( true == showMsg )
		{
			MessageDialog myMsgDialog = new MessageDialog( thisMainWindow,
															DialogFlags.DestroyWithParent,
															MessageType.Info,
															ButtonsType.Ok, msg );

			// Not saving user response as it was a simple OK button
			myMsgDialog.Modal = false;
			myMsgDialog.Run();		// wait for user to hit OK button or Close window
			myMsgDialog.Destroy();
		}
	}

	// Called by a timer every so often to see if the test completed
	public bool CheckForDone()
	{
		if ( true == pTest.GetTestDoneFlag() )
		{
			//thisMainWindow.buttonRunTest.Name = "Run Test";
			thisMainWindow.buttonRunTest.Visible = true;
			//thisMainWindow.ShowAll();
			return false;	// false return will stop the timer calling here
		}
		return true;
	}
}
