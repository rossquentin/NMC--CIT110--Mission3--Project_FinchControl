using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu
    // Application Type: Console
    // Author: Velis, John
    // Fork Author: Ross, Quentin
    // Dated Created: 1/22/2020
    // Last Modified: 1/25/2020
    //
    // **************************************************

    class Program
    {
        #region MAIN
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(finchRobot);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(finchRobot);
                        break;

                    case "d":
                        LightAlarmDisplayMenuScreen(finchRobot);

                        break;

                    case "e":

                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        
        #endregion

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void TalentShowDisplayMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mixing it Up");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        TalentShowDisplayLightAndSound(myFinch);
                        break;

                    case "b":
                        TalentShowDisplayDance(myFinch);
                        break;

                    case "c":
                        TalentShowDisplayMixingItUp(myFinch);
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will now show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel);
            }

            for (int lightSoundLevel = 255; lightSoundLevel > 0; lightSoundLevel--)
            {
                finchRobot.setLED(255, lightSoundLevel, lightSoundLevel);
            }

            for (int lightSoundLevel = 255; lightSoundLevel > 0; lightSoundLevel--)
            {
                finchRobot.setLED(lightSoundLevel, 0, 0);
                finchRobot.noteOn(lightSoundLevel);
            }

            DisplayMenuPrompt("Talent Show Menu");
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
        }


        static void TalentShowDisplayDance(Finch finchRobot)
        {
            DisplayScreenHeader("Dance");

            Console.WriteLine("\tThe Finch robot will now show off its dancing talent!");
            DisplayContinuePrompt();

            for (int lines = 0; lines < 8; lines++)
            {
                finchRobot.setMotors(200, 200);
                finchRobot.wait(1000);
                finchRobot.setMotors(200, -200);
                finchRobot.wait(400);
            }
            finchRobot.setMotors(0, 0);

            DisplayMenuPrompt("Talent Show Menu");
        }


        static void TalentShowDisplayMixingItUp(Finch finchRobot)
        {
            DisplayScreenHeader("Mixing it Up");

            Console.WriteLine("\tThe Finch robot will now begin mixing it up!");
            DisplayContinuePrompt();

            finchRobot.noteOff();
            for (int lines = 0; lines < 8; lines++)
            {
                finchRobot.setLED(255, 0, 0);
                finchRobot.noteOn(912);
                finchRobot.setMotors(200, 200);
                finchRobot.wait(1000);

                finchRobot.setLED(0, 0, 255);
                finchRobot.noteOn(635);
                finchRobot.setMotors(-200, -200);
                finchRobot.wait(1000);

                finchRobot.setLED(255, 0, 0);
                finchRobot.noteOn(912);
                finchRobot.setMotors(200, -200);
                finchRobot.wait(400);

                finchRobot.setMotors(0, 0);
                finchRobot.wait(600);

                finchRobot.setLED(0, 0, 255);
                finchRobot.noteOn(635);
                finchRobot.wait(1000);
            }
        }

        #endregion

        #region DATA RECORDER

        /// <summary>
        /// *****************************************************************
        /// *                     Data Recorder Menu                        *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        static void DataRecorderDisplayMenuScreen(Finch finchRobot)
        {
            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] dataArr = {};
            string dataType = "none";

            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Data Collection Type: {0}", dataType);
                Console.WriteLine("\tb) Number of Data Points: {0} points", numberOfDataPoints);
                Console.WriteLine("\tc) Frequency of Data Points: {0} seconds", dataPointFrequency);
                Console.WriteLine("\td) Get Data");
                Console.WriteLine("\te) Show Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        dataType = DataRecorderDisplayGetDataType();
                        break;
                    case "b":
                        numberOfDataPoints = DataRecorderDisplayGetNumbeOfDataPoints();
                        break;

                    case "c":
                        dataPointFrequency = DataRecorderDisplayGetDataPointFrequency();
                        break;

                    case "d":
                        dataArr = DataRecorderDisplayGetData(numberOfDataPoints, dataPointFrequency, finchRobot, dataType);
                        break;

                    case "e":
                        DataRecorderDisplayShowData(dataArr, dataType);
                        break;
                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }
        /// <summary>
        /// gets the data type from the user
        /// </summary>
        /// <returns>data type</returns>
        static string DataRecorderDisplayGetDataType()
        {
            string dataType = "none";

            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Data Collection Type Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Temperature");
                Console.WriteLine("\tb) Light");
                Console.WriteLine("\tq) Data Recorder Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        dataType = "temperature";
                        quitMenu = true;
                        break;
                    case "b":
                        dataType = "light";
                        quitMenu = true;
                        break;
                    case "q":
                        quitMenu = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);

            return dataType;
        }
        /// <summary>
        /// converts celsius temp to fahrenheit
        /// </summary>
        /// <param name="temp">input temp</param>
        /// <returns>temp in fahrenheit</returns>
        static double DataRecorderDisplayConvertCelsiusToFahrenheit(double temp)
        {
            temp = (temp * 9 / 5) + 32;
            return temp;
        }

        /// <summary>
        /// creates a table for all data recorded
        /// </summary>
        /// <param name="dataArr"> array for all data </param>
        /// <param name="dataType"> type of data recorded </param>
        static void DataRecorderDisplayShowData(double[] dataArr, string dataType)
        {
            DisplayScreenHeader("Show Data");

            // display table headers
            Console.WriteLine(
                "RECORDING NUM".PadLeft(15) +
                dataType.ToUpper().PadLeft(15)
                );
            Console.WriteLine(
               "-------------".PadLeft(15) +
               "-------------".PadLeft(15)
               );

            for (int i = 0; i < dataArr.Length; i++)
            {
                Console.WriteLine(
               (i+1).ToString().PadLeft(15) +
               dataArr[i].ToString("n2").PadLeft(15)
               );
            }

            Console.WriteLine("\n\tAverage: {0}", DataRecorderDisplayGetAverage(dataArr).ToString("n2"));

            DisplayContinuePrompt();
        }

        /// <summary>
        /// computes the average given an array
        /// </summary>
        /// <param name="dataArr"> array to calculate an average </param>
        /// <returns> average of all data points </returns>
        static double DataRecorderDisplayGetAverage(double[] dataArr)
        {
            double average = 0;
            double sum = 0;

            for (int i = 0; i < dataArr.Length; i++)
            {
                sum += dataArr[i];
            }

            average = sum / dataArr.Length;

            return average;
        }



        /// <summary>
        /// gets the data from the robot with all parameters given from user
        /// </summary>
        /// <param name="numberOfDataPoints">number of data points to record</param>
        /// <param name="dataPointFrequency">distance between two data point recordings</param>
        /// <param name="finchRobot">finch robot object</param>
        /// <param name="dataType">data type to record</param>
        /// <returns>data array</returns>
        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot, string dataType)
        {
            double[] dataArr = new double[numberOfDataPoints];
            int waitInMilliseconds = (int)(dataPointFrequency * 1000);

            DisplayScreenHeader("Get Data");

            Console.WriteLine("\tNumber of data points: {0} points", numberOfDataPoints);
            Console.WriteLine("\tData point frequency: {0} seconds", dataPointFrequency);
            Console.WriteLine("\tData type: {0}", dataType);

            Console.WriteLine("\nThe Finch robot is ready to begin recording the data.");
            DisplayContinuePrompt();

            if(dataType == "temperature")
            {
                for (int i = 0; i < numberOfDataPoints; i++)
                {
                    dataArr[i] = finchRobot.getTemperature();
                    dataArr[i] = DataRecorderDisplayConvertCelsiusToFahrenheit(dataArr[i]);
                    Console.WriteLine("Temperature Reading {0}: {1}", i+1 ,dataArr[i].ToString("n2"));
                    finchRobot.wait(waitInMilliseconds);
                }
            }
            else if (dataType == "light")
            {
                for (int i = 0; i < numberOfDataPoints; i++)
                {
                    dataArr[i] = (finchRobot.getRightLightSensor() + finchRobot.getLeftLightSensor()) / 2;
                    Console.WriteLine("Light Reading {0}: {1}", i + 1, dataArr[i].ToString("n2"));
                    finchRobot.wait(waitInMilliseconds);
                }
            }

            DisplayContinuePrompt();

            return dataArr;
        }

        /// <summary>
        /// get the number of data points from the user
        /// </summary>
        /// <returns>number of data points</returns>
        static int DataRecorderDisplayGetNumbeOfDataPoints()
        {
            int numberOfDataPoints;
            bool isValid = true;

            // validate user input
            do
            {
                DisplayScreenHeader("Number of Data Points");

                Console.Write("\tEnter the number of data points you wish to capture: ");
                isValid = int.TryParse(Console.ReadLine(), out numberOfDataPoints);

                if(!isValid)
                {
                    Console.WriteLine("\tPlease enter an integer response.");
                }

                DisplayContinuePrompt();                
            } while (!isValid);

            return numberOfDataPoints;
        }

        /// <summary>
        /// get the frequency of data points from the user
        /// </summary>
        /// <returns>frequency of data points</returns>
        static double DataRecorderDisplayGetDataPointFrequency()
        {

            double dataPointFrequency;
            bool isValid = true;

            // validate user input
            do
            {
                DisplayScreenHeader("Number of Data Points");

                Console.Write("\tEnter how often (in seconds) you would like to check for data points: ");
                isValid = double.TryParse(Console.ReadLine(), out dataPointFrequency);

                if (!isValid)
                {
                    Console.WriteLine("\tPlease enter an integer or decimal response.");
                }

                DisplayContinuePrompt();
            } while (!isValid);

            return dataPointFrequency;
        }

        #endregion

        #region ALARM SYSTEM
        private static void LightAlarmDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;
            string sensorsToMonitor;
            string rangeType;
            int mixMaxThresholdValue;
            int timeToMonitor;

            do
            {
                DisplayScreenHeader("Alarm System Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Senors to Monitor");
                Console.WriteLine("\tb) Set Range Type");
                Console.WriteLine("\tc) Set Minimum/Maximum Threshold Values");
                Console.WriteLine("\td) Set Time to Monitor");
                Console.WriteLine("\te) Set Alarm");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        sensorsToMonitor = LightAlarmDisplaySetSensorsToMonitor();
                        break;

                    case "b":
                        ;
                        break;

                    case "c":
                        ;
                        break;

                    case "d":
                        ;
                        break;

                    case "e":
                        ;
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        private static string LightAlarmDisplaySetSensorsToMonitor()
        {
            string sensorsToMonitor;

            DisplayScreenHeader("Sensors To Monitor");

            Console.Write("\tSensors to Monitor (left, right, both): ");
            sensorsToMonitor = Console.ReadLine();

            DisplayMenuPrompt("Alarm System");
            return sensorsToMonitor;
        }

        private static string LightAlarmDisplaySetRangeType()
        {
            string rangeType;

            DisplayScreenHeader("Range Type");

            Console.Write("\tRange Type (minimum, maximum): ");
            rangeType = Console.ReadLine();

            DisplayMenuPrompt("Alarm System");
            return rangeType;
        }



        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName}.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}