// Code for running PASAT test
// structured to run as a separate thread from the foreground UI thread
//
// This has platform specific C# code to build Windows PC, Mono C# applications
//

// This is used to set the compilation/execution platform for the PASAT cross platform project
//
// ONLY 1 of the below platform defines should be uncommented

// #define WIN_PC_PLATFORM

// #define  WIN_PHONE_PLATFORM

//#define  MONO_PC_PLATFORM


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;     // support for thread calls

#if WIN_PC_PLATFORM
    // Text to Speech is used for prompts but NOT the test digits
    using System.Speech.Synthesis;

	using System.Windows;	// MessageBox
#endif


// allow sound loading and output (.WAV file)
using System.Media;

// Support to create a background thread
// using System.Threading.Tasks;



// NOTE:
// Most of this code usually runs in the context of a thread that is NOT the UI thread

#if WIN_PC_PLATFORM
namespace PASATTest
#endif

#if MONO_PC_PLATFORM
namespace PASAT_Mono
#endif
{

    class PASATTestThread
    {

        private PasatTest pTest = null;        // reference to already created instance of model class

		// instance of thread class for a background thread
		private Thread backThread = null;

        // Constructor
        public PASATTestThread() {
			pTest = null;
			backThread = null;
			isSoundsInit = false;
        }

		// Initializer to call after Constructor with a reference to test interface class
		public void PASATTestThreadInit( PasatTest pasatTest )
		{
			this.pTest = pasatTest;

			prvLoadSounds();	// load sound files into memory buffers
		}
//
//  Called to finish setting up what is needed to run a test and the start the test running
//
//  NOTE: This is called in the context of the UI (primary) thread
//
        public void RunTest()
        {
			prvLoadSounds();	// load sound files into memory buffers

        #if WIN_PC_PLATFORM
            // get an instance of the task scheduler for background threads 
            var backgroundScheduler = TaskScheduler.Default;

            // get an instance of the UI (foreground thread) task scheduler
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            // Create a background thread and run using the private prvRunTest method 
            // and using the previously set call back to the UI thread code when done
            Task.Factory.StartNew(delegate { this.prvRunTest(); }, backgroundScheduler).
                ContinueWith(delegate { pTest.GetTestDoneCallBack(); }, uiScheduler);
        #endif

		#if MONO_PC_PLATFORM
			if ( null == backThread )
			{
				// Create a background thread to run the test
				backThread = new Thread( new ThreadStart(prvRunTest) );
			}

			// Run the test on the background thread
			backThread.Start();

			Thread.Sleep(100);	// sleep the calling thread for a bit
		#endif
        }

//
// Private data and member functions
//
        /// <summary>
        /// Loads a WAV file into a memory buffer
        /// </summary>
        /// <param name="SoundFilePath">Relative path to the wav file.</param>
        /// <param name="Sound">The SoundPlayer to load the audio into.</param>
        private void prvLoadSound(String SoundFilePath, out SoundPlayer Sound)
        {
            // For error checking, assume we'll fail to load the file.
			Sound = null;
			if ( SoundFilePath.Length > 0 )
			{
	            try
	            {
	                // Create the SoundPlayer using the file path/name
					Sound = new SoundPlayer(SoundFilePath);
	                Sound.Load();       // load the file into memory for playing later
	            }
	            catch (NullReferenceException)
	            {
	                // Display an error message
	            //    MessageBox.Show("Couldn't load sound " + SoundFilePath);
	            }
			}
        }

        // The sounds of spoken digits to play as memory buffers
		private bool isSoundsInit = false;
        private SoundPlayer sound1 = null;
		private SoundPlayer sound2 = null;
		private SoundPlayer sound3 = null;
		private SoundPlayer sound4 = null;
		private SoundPlayer sound5 = null;
		private SoundPlayer sound6 = null;
		private SoundPlayer sound7 = null;
		private SoundPlayer sound8 = null;
		private SoundPlayer sound9 = null;

        private void prvLoadSounds()
        {
			if ( false == isSoundsInit )
			{
	            // .WAV files are part of app Resources as LINKED resources NOT EMBEDDED (in MS Windows sense)
	            //
	            // this approach REQUIRES that a separate Resources directory 
	            // with below files exists to play these
	            prvLoadSound("./Resources/1.wav", out sound1);
	            prvLoadSound("./Resources/2.wav", out sound2);
	            prvLoadSound("./Resources/3.wav", out sound3);
	            prvLoadSound("./Resources/4.wav", out sound4);
	            prvLoadSound("./Resources/5.wav", out sound5);
	            prvLoadSound("./Resources/6.wav", out sound6);
	            prvLoadSound("./Resources/7.wav", out sound7);
	            prvLoadSound("./Resources/8.wav", out sound8);
	            prvLoadSound("./Resources/9.wav", out sound9);
				isSoundsInit = true;
			}
        }

        public int PlayDigitSound(int digit)
        {
            int error = 0;
            string msg = "Can't play as sound" + digit + " is null.";

            switch (digit)    // allowed digits are: 1 to 9
            {
                case 1:
                    try
                    {
                        sound1.Play();
                    }
                    catch (NullReferenceException)
                    {
                        error = digit;
                    }
                    break;
                case 2:
                    try
                    {
                        sound2.Play();
                    }
                    catch (NullReferenceException)
                    {
                        error = digit;
                    }
                    break;
                case 3:
                    try
                    {
                        sound3.Play();
                    }
                    catch (NullReferenceException)
                    {
                        error = digit;
                    }
                    break;
                case 4:
                    try
                    {
                        sound4.Play();
                    }
                    catch (NullReferenceException)
                    {
                        error = digit;
                    }
                    break;
                case 5:
                    try
                    {
                        sound5.Play();
                    }
                    catch (NullReferenceException)
                    {
                        error = digit;
                    }
                    break;
                case 6:
                    try
                    {
                        sound6.Play();
                    }
                    catch (NullReferenceException)
                    {
                        error = digit;
                    }
                    break;
                case 7:
                    try
                    {
                        sound7.Play();
                    }
                    catch (NullReferenceException)
                    {
                        error = digit;
                    }
                    break;
                case 8:
                    try
                    {
                        sound8.Play();
                    }
                    catch (NullReferenceException)
                    {
                        error = digit;
                    }
                    break;
                case 9:
                    try
                    {
                        sound9.Play();
                    }
                    catch (NullReferenceException)
                    {
                        error = digit;
                    }
                    break;
                default:
                    error = 10;     // digit out of allowed range
					msg = "Digit " + digit + " is out of range.";
                    break;
            }

        //    if (error != 0)
        //        MessageBox.Show(msg);

			return error;
        }

//
// Background worker thread entry point.  This is NOT the UI (primary) thread context.
//
        private void prvRunTest()
        {
            //SpeechSynthesizer s = new SpeechSynthesizer();

            //Random myRandomGenerator = new Random();

            int startingRate = pTest.GetDelayBetweenPairs();
            int rate = startingRate;

            int[] dataTable = null;
            int testLength = 0;
            dataTable = pTest.GetTestTable(out testLength);
            
            int numTests = pTest.GetNumTests();

            if ( null == sound1 )
                prvLoadSounds();

            //Int32 randomInt;
            //Int32[,] memory = new Int32[pTest.numTests, testLength[0] ];
            Int32 digit = 0;
            Int32 newDigit = 0;
            Int32 expectedSum = 0;

            int error = 0;
            for (int i = 0; i < numTests; i++)
            {
                String speakString = "Starting test number " + i + " at " + rate + " milliseconds in 5 seconds";
                //s.Speak(speakString);
                // MessageBox.Show(speakString);    // uncomment for DEBUG
                //Thread.Sleep(5000);

                for (int j = 0; j < testLength; j++)
                {

                    //randomInt = myRandomGenerator.Next(11);   // NOTE: This would sometimes generate 0 and 10 which are invalid according to PDF
                    //memory[i, j] = randomInt;

                    // Check if this is the digit or the sum from the array
                    if ( (j % 2) != 0 )
                    {
                        // This is the sum
                        expectedSum = dataTable[j];
                        newDigit = expectedSum - digit;
                        if (newDigit <= 0)
                        {
                            // s.Speak("Error in built in table data, sum minus previous digit is negative");
                            //Thread.Sleep(3000);
                            speakString = "Error in data, sum of " + expectedSum + " minus the previous digit " + digit + " is negative " + newDigit;
                            //s.Speak(speakString);
                            error = 1;
                            Thread.Sleep(3000);
                            break;
                        }
                        digit = newDigit;
                    }
                    else
                        digit = dataTable[j];

                    //        s.Speak(i.ToString());
                    // s.Speak(randomInt.ToString());
                    
                    //s.Speak(digit.ToString());
                    PlayDigitSound(digit);

                    Thread.Sleep(rate);
                }

                if (error != 0)
                    break;

                // rate no longer changes here
                // rate += pTest.rateIncrement;

            }

            //s.Speak("Hello. My name is John Byrne.  I was born a poor white child.");

// Print out the answers
        //
        // This was important when using RANDOM numbers but not important when using fixed internal table values
        // because the spreadsheets have the same table values
        //
        // COMMENTED OUT
        //
/*          
            Console.WriteLine("The answers are: ");
            for (int i = 0; i < pTest.numTests; i++)
            {
                Console.WriteLine("Test number: {0}", i);
                StringBuilder testNumbersString = new StringBuilder();
                testNumbersString.Append("Test Number: " + i.ToString() + "\n");
                for (int j = 0; j < pTest.testLength; j++)
                {
                    //testNumbersString.Append(memory[i,j].ToString() + " ");
                    //System.Console.Write(memory[i, j] + " ");
                }
                MessageBox.Show(testNumbersString.ToString());
                Console.WriteLine();

                for (int j = 1; j < pTest.testLength; j++)
                {
                    //Console.Write((memory[i, j - 1] + memory[i, j]) + " ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            // call the windowing system to reset the button
            // Can't do this because it's a different thread calling us
            // completedFunction();
*/            


			pTest.SetTestDoneFlag( true );	// done

			backThread = null;				// release reference to background thread
        }
    }
}
