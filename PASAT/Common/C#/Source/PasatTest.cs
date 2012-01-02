// Model file of MVC pattern for Windows PC, Windows Phone 7, and Mono platforms
//
// This holds all the public method functions to set up test values used by various platform UIs
//
// This is the interface to the test from the UI thread side AND also from the test run thread side
//
// This is intended to be as cross platform as possible for a C# module
//

// This is used to set the compilation/execution platform for the PASAT cross platform project
//
// ONLY 1 of the below platform defines should be uncommented

// #define WIN_PC_PLATFORM      // defined as compiler command line arg

// #define  WINDOWS_PHONE       // defined as compiler command line arg

// #define  MONO_PC_PLATFORM	// defined as compiler command line arg

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if WIN_PC_PLATFORM
namespace PASATTest
#endif

#if WINDOWS_PHONE
namespace PASATTest_WP7
#endif

#if MONO_PC_PLATFORM
namespace PASAT_Mono
#endif
{
    class PasatTest
    {
//
// Public constants
//
        // Number of number pairs in a given test
        // Practice tests may be up to 3 x DEFAULT_PRACTICE_TEST_LENGTH
        public const int DEFAULT_TEST_LENGTH = 60;
        public const int DEFAULT_PRACTICE_TEST_LENGTH = 10;

        public const int DEFAULT_NUM_TESTS = 1;
        public const int MIN_NUM_PRACTICE_TESTS = 1;
        public const int MAX_NUM_PRACTICE_TESTS = 3;

        // Delay between numbers and pairs of numbers in milliseconds
        public const int MIN_DELAY_BETWEEN_PAIRS = 2000;    // 2 Seconds
        public const int MAX_DELAY_BETWEEN_PAIRS = 3000;    // 3 Seconds
        
        //public const int DEFAULT_RATE_INCREMENT = 400;

//
// Private data elements
//
        // Tables copied from:
        // 
        //
        // Form  A  built in table values
        // Each line is: 
        // the first number, the expected sum
        // second number (spoken by program) =  expected sum - first number
        // the A1 and B1 tables should have 3 seconds between numbers
        // the A2 and B2 tables should have 2 seconds between numbers
        // there can be up to 3 runs of the same Practice table before the following Rate table
        private int[] practiceA1 = { // 3 Seconds
            9, 10,
            3, 4,
            5, 8,
            2, 7,
            6, 8, 
            4, 10,
            9, 13,
            7, 16,
            1, 8,
            4, 5
        };

        private int[] rateA1 = { // 3 Seconds
            1 , 5 ,
            8 , 12,
            1 , 9 ,
            5 , 6 ,
            1 , 6 ,
            3 , 4 ,
            7 , 10,
            2 , 9 ,
            6 , 8 ,
            9 , 15,
            4 , 13,
            7 , 11,
            3 , 10,
            5 , 8 ,
            3 , 8 ,
            6 , 9 ,
            8 , 14,
            2 , 10,
            5 , 7 ,
            1 , 6 ,
            5 , 6 ,
            4 , 9 ,
            6 , 10,
            3 , 9 ,
            8 , 11,
            1 , 9 ,
            7 , 8 ,
            4 , 11,
            9 , 13,
            3 , 12,
            7 , 10,
            2 , 9 ,
            6 , 8 ,
            9 , 15,
            5 , 14,
            2 , 7 ,
            4 , 6 ,
            8 , 12,
            3 , 11,
            1 , 4 ,
            8 , 9 ,
            5 , 13,
            7 , 12,
            1 , 8 ,
            8 , 9 ,
            2 , 10,
            4 , 6 ,
            9 , 13,
            7 , 16,
            9 , 16,
            3 , 12,
            1 , 4 ,
            5 , 6 ,
            7 , 12,
            4 , 11,
            8 , 12,
            1 , 9 ,
            3 , 4 ,
            8 , 11,
            2 , 10
        };

        private int[] practiceA2 = { // 2 Seconds
            3, 11,
            2, 10,
            7, 9,
            9, 16,
            1, 10, 
            8, 9,
            5, 13,
            2, 7,
            6, 8,
            4, 10
        };

        private int[] rateA2 = { // 2 Seconds
            4 , 7 ,
            7 , 10,
            2 , 9 ,
            5 , 7 ,
            1 , 6 ,
            8 , 9 ,
            6 , 14,
            9 , 15,
            1 , 10,
            7 , 8 ,
            9 , 16,
            4 , 13,
            6 , 10,
            3 , 9 ,
            5 , 8 ,
            8 , 13,
            1 , 9 ,
            6 , 7 ,
            2 , 8 ,
            7 , 9 ,
            5 , 12,
            9 , 14,
            4 , 13,
            5 , 9 ,
            2 , 7 ,
            6 , 8 ,
            4 , 10,
            8 , 12,
            3 , 11,
            5 , 8 ,
            9 , 14,
            7 , 16,
            4 , 11,
            2 , 6 ,
            8 , 10,
            5 , 13,
            2 , 7 ,
            1 , 3 ,
            6 , 7 ,
            4 , 10,
            7 , 11,
            3 , 10,
            5 , 8 ,
            9 , 14,
            6 , 15,
            4 , 10,
            5 , 9 ,
            3 , 8 ,
            9 , 12,
            4 , 13,
            1 , 5 ,
            8 , 9 ,
            3 , 11,
            1 , 4 ,
            6 , 7 ,
            8 , 14,
            5 , 13,
            4 , 9 ,
            2 , 6 ,
            6 , 8
        };


        // Form  B  built in table values
        // Each line is: 
        // the first number, the expected sum
        // second number (spoken by program) =  expected sum - first number
        // the A1 and B1 tables should have 3 seconds between numbers
        // the A2 and B2 tables should have 2 seconds between numbers
        // there can be up to 3 runs of the same Practice table before the following Rate table
        private int[] practiceB1 = { // 3 Seconds
            9 , 10,
            3 , 4 ,
            5 , 8 ,
            2 , 7 ,
            6 , 8 ,
            4 , 10,
            9 , 13,
            7 , 16,
            1 , 8 ,
            4 , 5
        };

        private int[] rateB1 = { // 3 Seconds
            2 , 9 ,
            5 , 12,
            8 , 13,
            2 , 10,
            9 , 11,
            6 , 15,
            4 , 10,
            1 , 5 ,
            3 , 4 ,
            6 , 9 ,
            3 , 9 ,
            6 , 9 ,
            2 , 8 ,
            8 , 10,
            4 , 12,
            9 , 13,
            1 , 10,
            6 , 7 ,
            7 , 13,
            2 , 9 ,
            4 , 6 ,
            1 , 5 ,
            5 , 6 ,
            7 , 12,
            3 , 10,
            9 , 12,
            7 , 16,
            2 , 9 ,
            6 , 8 ,
            8 , 14,
            4 , 12,
            2 , 6 ,
            5 , 7 ,
            8 , 13,
            5 , 13,
            9 , 14,
            3 , 12,
            7 , 10,
            1 , 8 ,
            4 , 5 ,
            2 , 6 ,
            4 , 6 ,
            3 , 7 ,
            6 , 9 ,
            1 , 7 ,
            7 , 8 ,
            3 , 10,
            8 , 11,
            3 , 11,
            9 , 12,
            1 , 10,
            3 , 4 ,
            5 , 8 ,
            2 , 7 ,
            6 , 8 ,
            4 , 10,
            9 , 13,
            7 , 16,
            1 , 8 ,
            4 , 5 ,
        };

        private int[] practiceB2 = { // 2 Seconds
            3, 11,
            2, 10,
            7, 9,
            9, 16,
            1, 10, 
            8, 9,
            5, 13,
            2, 7,
            6, 8,
            4, 10
        };

        private int[] rateB2 = { // 2 Seconds
            7 , 15,
            6 , 14,
            3 , 9 ,
            7 , 10,
            5 , 12,
            9 , 14,
            1 , 10,
            2 , 3 ,
            6 , 8 ,
            8 , 14,
            3 , 11,
            6 , 9 ,
            2 , 8 ,
            5 , 7 ,
            9 , 14,
            7 , 16,
            1 , 8 ,
            8 , 9 ,
            3 , 11,
            6 , 9 ,
            7 , 13,
            4 , 11,
            2 , 6 ,
            5 , 7 ,
            3 , 8 ,
            8 , 11,
            6 , 14,
            2 , 8 ,
            3 , 5 ,
            7 , 10,
            3 , 10,
            5 , 8 ,
            2 , 7 ,
            8 , 10,
            5 , 13,
            3 , 8 ,
            7 , 10,
            4 , 11,
            1 , 5 ,
            5 , 6 ,
            2 , 7 ,
            4 , 6 ,
            1 , 5 ,
            6 , 7 ,
            3 , 9 ,
            9 , 12,
            7 , 16,
            1 , 8 ,
            8 , 9 ,
            4 , 12,
            6 , 10,
            2 , 8 ,
            5 , 7 ,
            8 , 13,
            1 , 9 ,
            9 , 10,
            7 , 16,
            2 , 9 ,
            8 , 10,
            3 , 11  
        };

        private bool isFormA = true;

        private bool isPracticeTest = true;
        
        private int numTests = DEFAULT_NUM_TESTS;

        private int delayBetweenPairs = MIN_DELAY_BETWEEN_PAIRS;   // in milliseconds


        // It is possible isTestDone changes from one thread while being read by another thread in the same process
        private static bool isTestDone = false;

        private Object isTestDoneLock = new Object();	// used to briefly lock isTestDone bool during changes
        

// 
// Public member functions
//
        public PasatTest()      // Constructor
        {
            isTestDone = false;
            numTests = DEFAULT_NUM_TESTS;
        }

        public PasatTest(int numTests)   // Constructor with args
        {
            isTestDone = false;
            this.numTests = numTests;
        }

        // returns previous value
        public bool SetFormAFlag(bool isFormA)
        {
            bool retVal = this.isFormA;
            this.isFormA = isFormA;
            return retVal;
        }

        public bool GetFormAFlag()
        {
            return this.isFormA;
        }

        // returns previous value
        public bool SetPracticeTestFlag(bool isPractice)
        {
            bool retVal = this.isPracticeTest;
            this.isPracticeTest = isPractice;
            return retVal;
        }

        public bool GetPracticeTestFlag()
        {
            return this.isPracticeTest;
        }

        public int SetNumTests(int numTestsWanted)
        {
            int numToSet = DEFAULT_NUM_TESTS;
            if ( true == this.isPracticeTest)
            {
                numToSet = numTestsWanted;
                if (MIN_NUM_PRACTICE_TESTS > numTestsWanted)
                    numToSet = MIN_NUM_PRACTICE_TESTS;

                if (numTestsWanted > MAX_NUM_PRACTICE_TESTS)
                    numToSet = MAX_NUM_PRACTICE_TESTS;
            }
            this.numTests = numToSet;
            return this.numTests;
        }

        public int GetNumTests()
        {
            return this.numTests;
        }

        // returns value set
        public int SetDelayBetweenPairs(int delayInMilliSec)
        {
            int delayToSet = delayInMilliSec;
            if (MIN_DELAY_BETWEEN_PAIRS > delayToSet)  // minimum 2 Seconds
                delayToSet = MIN_DELAY_BETWEEN_PAIRS;
            else
            {
                if (delayToSet > MAX_DELAY_BETWEEN_PAIRS)  // maximum 3 seconds
                    delayToSet = MAX_DELAY_BETWEEN_PAIRS;
            }
            this.delayBetweenPairs = delayToSet;
            return this.delayBetweenPairs;
        }

        public int GetDelayBetweenPairs()
        {
            return this.delayBetweenPairs;
        }

        // Use current settings to determine the data table for the test
        public int[] GetTestTable(out int tableLength)
        {
            int[] retVal = null;
            tableLength = 0;

            if (true == this.isFormA)
            {
                // Form  A
                if ( true == this.isPracticeTest )
                {
                    // Practice
                    if ( MAX_DELAY_BETWEEN_PAIRS == delayBetweenPairs )
                    {
                        retVal = practiceA1;
                        tableLength = practiceA1.Length;
                    }
                    else
                    {
                        retVal = practiceA2;
                        tableLength = practiceA2.Length;
                    }
                }
                else
                {
                    // Actual
                    if ( MAX_DELAY_BETWEEN_PAIRS == delayBetweenPairs )
                    {
                        retVal = rateA1;
                        tableLength = rateA1.Length;
                    }
                    else
                    {
                        retVal = rateA2;
                        tableLength = rateA2.Length;
                    }
                }
            }
            else
            {
                // Form  B
                if (true == this.isPracticeTest)
                {
                    // Practice
                    if (MAX_DELAY_BETWEEN_PAIRS == delayBetweenPairs)
                    {
                        retVal = practiceB1;
                        tableLength = practiceB1.Length;
                    }
                    else
                    {
                        retVal = practiceB2;
                        tableLength = practiceB2.Length;
                    }
                }
                else
                {
                    // Actual
                    if (MAX_DELAY_BETWEEN_PAIRS == delayBetweenPairs)
                    {
                        retVal = rateB1;
                        tableLength = rateB1.Length;
                    }
                    else
                    {
                        retVal = rateB2;
                        tableLength = rateB2.Length;
                    }
                }
            }

            return retVal;
        }

        public string GetTestTimeEstimate( out int minutes, out int seconds )
        {
            string strTimeEst = "";
            minutes = 1;
            seconds = 10;

            int numTests = GetNumTests();
            int delay = GetDelayBetweenPairs();
            int tableLength = 0;
            int[] table = GetTestTable( out tableLength );

            int totalSeconds = ( tableLength / 2 + 1 ) * 2000;  // Estimate 2 seconds to say each number

            // Add time of pauses between numbers
            totalSeconds += ( tableLength / 2 ) * delay;

            // Times number of tests + delay between tests
            if ( 1 < numTests )
            {
                totalSeconds = ( totalSeconds * numTests ) + ( ( numTests - 1 ) * delay );
            }

            int roundUp = 0;
            if ( ( totalSeconds % 1000 ) >= 500 )
                roundUp = 1;
            totalSeconds = ( totalSeconds / 1000 ) + roundUp;     // change from Milliseconds to Seconds
            minutes = totalSeconds / 60;
            seconds = totalSeconds % 60;

            // Format the string with Minutes and Seconds
            if (0 != minutes)
            {
                strTimeEst += minutes.ToString() + "  Minute";
                if (2 <= minutes)
                {
                    strTimeEst += "s";
                }
            }
            if (0 != seconds)
            {
                strTimeEst += "  " + seconds.ToString() + "  Second";
                if (2 <= seconds)
                {
                    strTimeEst += "s";
                }
            }

            return strTimeEst;
        }

        public void SetTestDoneFlag(bool isTestDone)
        {
            lock (isTestDoneLock)
            {
                PasatTest.isTestDone = isTestDone;
            }
        }

        public bool GetTestDoneFlag()
        {
            return PasatTest.isTestDone;
        }

    }
}
