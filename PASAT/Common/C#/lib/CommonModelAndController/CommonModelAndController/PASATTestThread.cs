// Code for running PASAT test
// structured to run as a separate thread from the foreground UI thread
//
// This has platform specific C# code to build Windows PC, Windows Phone, Mono C# applications
//

// This is used to set the compilation/execution platform for the PASAT cross platform project
//
// ONLY 1 of the below platform defines should be uncommented

//#define  WIN_PC_PLATFORM      // defined as compiler command line arg

//#define  WINDOWS_PHONE        // defined as compiler command line arg

//#define  MONO_PC_PLATFORM     // defined as compiler command line arg

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;         // Sleep and also background thread

using PASATTest.Model;
//
// Add platform specific support for .WAV file play and declare namespace
//
#if WIN_PC_PLATFORM || MONO_PC_PLATFORM
    // allow sound loading and output (.WAV file)
    using System.Media;
#endif

#if WIN_PC_PLATFORM || WINDOWS_PHONE
    using System.Windows;    // MessageBox
using System.Windows.Forms;
#endif

#if WIN_PC_PLATFORM
namespace PASATTest.Controller
#endif

#if WINDOWS_PHONE
// Allow PASAT test work to be done in another thread
    using System.ComponentModel;

    using System.Windows.Resources;         // allows loading .WAV from app Resources

    // allow sound output (.WAV file) from a Silverlight app by using part of XNA framework
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;

namespace PASATTest_WP7
#endif

#if MONO_PC_PLATFORM
namespace PASAT_Mono
#endif

// NOTE:
// Most of this code usually runs in the context of a thread that is NOT the UI (primary) thread
//
// namespace is set above
{

    public class PASATTestThread
    {

        private PasatTest pTest = null;     // reference to already created instance of model class

        // instance of thread class for a background thread
        private Thread backThread = null;

        // Constructor
        public PASATTestThread()
        {
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

			if ( null == backThread )
			{
				// Create a background thread to run the test
				backThread = new Thread( new ThreadStart(prvRunTest) );
			}

			// Run the test on the background thread
			backThread.Start();

            Thread.Sleep(100);	// sleep the calling thread for a bit
        }

//
// Private data and member functions
//
        /// <summary>
        /// Loads a WAV file into a memory buffer
        /// </summary>
        /// <param name="SoundFilePath">Relative path to the wav file.</param>
#if WIN_PC_PLATFORM || MONO_PC_PLATFORM
        /// <param name="Sound">The SoundPlayer to load the audio into.</param>
        private void prvLoadSound(String SoundFilePath, out SoundPlayer Sound)
#endif

#if WINDOWS_PHONE
        /// <param name="Sound">The SoundEffect to load the audio into.</param>
        private void prvLoadSound(String SoundFilePath, out SoundEffect Sound)
#endif
        {
            // For error checking, assume we'll fail to load the file.
            Sound = null;
            if (SoundFilePath.Length > 0)
            {
                try
                {
                #if WIN_PC_PLATFORM || MONO_PC_PLATFORM
                    // Create the SoundPlayer using the file path/name
                    Sound = new SoundPlayer(SoundFilePath);
                    Sound.Load();       // load the file into memory for playing later
                #endif
                #if WINDOWS_PHONE
                    // Holds information about a file stream.
                    StreamResourceInfo SoundFileInfo = App.GetResourceStream(new Uri(SoundFilePath, UriKind.Relative));

                    // Create the SoundEffect from the Stream
                    Sound = SoundEffect.FromStream(SoundFileInfo.Stream);
                #endif
                }
                catch (NullReferenceException)
                {
                    // Display an error message
                #if WIN_PC_PLATFORM || WINDOWS_PHONE
                    MessageBox.Show("Couldn't load sound " + SoundFilePath);
                #endif
                }
            }
        }

        // The sounds of spoken digits to play as memory buffers
        private bool isSoundsInit = false;

#if WIN_PC_PLATFORM || MONO_PC_PLATFORM
        private SoundPlayer sound1, sound2, sound3, sound4, sound5, sound6, sound7, sound8, sound9;
#endif
#if WINDOWS_PHONE
        private SoundEffect sound1, sound2, sound3, sound4, sound5, sound6, sound7, sound8, sound9;
#endif

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

        public void PlayDigitSound(int digit)
        {
            int error = 0;
            string msg = "Can't play as sound" + digit + " is null.";

            switch ( digit )    // allowed digits are: 1 to 9
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
                    msg = "Digit " + digit + " is out of range.";
                    error = 10;     // digit out of allowed range
                    break;
            }
        #if WINDOWS_PHONE
            if ( error != 0 )
                MessageBox.Show(msg);
        #endif
        }

//
// Background worker thread entry point.  This is NOT the UI (primary) thread context.
//
//#if WINDOWS_PHONE
        //public void bw_DoWork(object sender, DoWorkEventArgs e)
//#endif
        private void prvRunTest()
        {
            int error = 0;
            int retValue = 0;   // 0 for no errors else error code

        //    BackgroundWorker worker = sender as BackgroundWorker;

            //SpeechSynthesizer s = new SpeechSynthesizer();

            //Random myRandomGenerator = new Random();

            int rate = pTest.GetDelayBetweenPairs();
            
            int numTests = pTest.GetNumTests();

            int[] dataTable = null;
            int testLength = 0;
            dataTable = pTest.GetTestTable( out testLength );

            //Int32 randomInt;
            //Int32[,] memory = new Int32[pTest.numTests, testLength[0] ];
            Int32 digit = 0;
            Int32 newDigit = 0;
            Int32 expectedSum = 0;

            for (int i = 0; i < numTests; i++)
            {
            //    if ((true == worker.CancellationPending ))
            //    {
            //        e.Cancel = true;
            //        break;
            //    }

                String speakString = "Starting test number " + i + " at " + rate + " milliseconds in 5 seconds";
                // s.Speak(speakString);
                // MessageBox.Show(speakString);    // uncomment for DEBUG
                // Thread.Sleep(5000);

                for (int j = 0; j < testLength; j++)
                {

                    //randomInt = myRandomGenerator.Next(11);
                    //memory[i, j] = randomInt;

                    // Check if this the digit or the sum from the array
                    if ( (j % 2) != 0 )
                    {
                        // Odd index means this is the sum
                        expectedSum = dataTable[j];
                        newDigit = expectedSum - digit;
                        if (newDigit <= 0)  // check for table data error(s)
                        {
                            // s.Speak("Error in built in table data, sum minus previous digit is negative");


                            // Thread.Sleep(3000);
                            speakString = "Error in data, sum of " + expectedSum + " minus the previous digit " + digit + " is negative " + newDigit;
                            // s.Speak(speakString);
#if WIN_PC_PLATFORM || WINDOWS_PHONE
                            MessageBox.Show(speakString);
#endif
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

                    // s.Speak(digit.ToString());
                    PlayDigitSound( digit );		// about 2 Seconds

					// Check for user cancelling test
					if ( true == pTest.GetTestDoneFlag() )
					{
						numTests = 0;	// don't do any more tests
						break;
					}

                    Thread.Sleep( rate );		// 2 or 3 Seconds

					// Check for user cancelling test
					if ( true == pTest.GetTestDoneFlag() )
					{
						numTests = 0;	// don't do any more tests
						break;
					}
                }

                if (error != 0)
                    break;

                // calling code now sets the rate
                // rate += pTest.rateIncrement;

          //      if ((worker.CancellationPending == true))
          //      {
          //          e.Cancel = true;
          //          break;
          //      }
            }

            if (error != 0)
                retValue = error;

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
*/
            pTest.SetTestDoneFlag( true );	// done

            backThread = null;				// release reference to background thread
        }
    }
}
