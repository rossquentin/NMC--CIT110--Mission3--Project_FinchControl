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

    public enum Command
    {
        NONE,
        MOVEFORWARD,
        MOVEBACKWARD,
        STOPMOTORS,
        WAIT,
        TURNRIGHT,
        TURNLEFT,
        LEDON,
        LEDOFF,
        GETTEMPURATURE,
        DONE
    }

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
                        AlarmSystemDisplayMenuScreen(finchRobot);

                        break;

                    case "e":
                        UserProgrammingDisplayMenuScreen(finchRobot);
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
        private static void AlarmSystemDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;
            string sensorsToMonitor = "";
            string rangeType = "";
            int minMaxThresholdValue = 0;
            int timeToMonitor = 0;

            do
            {
                DisplayScreenHeader("Alarm System");

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
                        sensorsToMonitor = AlarmSystemDisplaySetSensorsToMonitor();
                        break;

                    case "b":
                        rangeType = AlarmSystemDisplaySetRangeType();
                        break;

                    case "c":
                        if (rangeType == "")
                        {
                            rangeType = "minimum";
                        }
                        minMaxThresholdValue = AlarmSystemDisplaySetMinMaxThresholdValue(rangeType, finchRobot);
                        break;

                    case "d":
                        timeToMonitor = AlarmSystemDisplaySetTimeToMonitor();
                        break;

                    case "e":
                        AlarmSystemDisplaySetAlarm(sensorsToMonitor, rangeType, minMaxThresholdValue, timeToMonitor, finchRobot);
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
        /// Gives user opportunity to enter which light sensor to monitor
        /// </summary>
        /// <returns></returns>
        private static string AlarmSystemDisplaySetSensorsToMonitor()
        {
            string sensorsToMonitor;
            bool isValidInput;

            do
            {
                DisplayScreenHeader("Sensors To Monitor");

                Console.Write("\tSensors to Monitor (left, right, both): ");
                sensorsToMonitor = Console.ReadLine();

                if (sensorsToMonitor.ToLower() == "left" || sensorsToMonitor.ToLower() == "right" || sensorsToMonitor.ToLower() == "both")
                {
                    isValidInput = true;
                }else
                {
                    isValidInput = false;

                    Console.WriteLine("\tPlease enter left, right, or both for the sensors to monitor.");

                    DisplayContinuePrompt();
                }

            } while (!isValidInput);

            DisplayMenuPrompt("Alarm System");

            return sensorsToMonitor;
        }

        /// <summary>
        /// Allows user to set the range type from minimum or maximum
        /// </summary>
        /// <returns></returns>
        private static string AlarmSystemDisplaySetRangeType()
        {
            string rangeType;
            bool isValidInput;

            do
            {
                DisplayScreenHeader("Range Type");

                Console.Write("\tRange Type (minimum, maximum): ");

                rangeType = Console.ReadLine();

                if (rangeType.ToLower() == "minimum" || rangeType.ToLower() == "maximum")
                {
                    isValidInput = true;
                }else{
                    isValidInput = false;

                    Console.WriteLine("\n\tPlease enter minimum or maximum for the range type.");

                    DisplayContinuePrompt();
                }

            } while (!isValidInput);
            
            DisplayMenuPrompt("Alarm System");

            return rangeType.ToUpper();
        }

        /// <summary>
        /// Sets the threshold bounds for monitoring
        /// </summary>
        /// <param name="rangeType"></param>
        /// <param name="finchRobot"></param>
        /// <returns></returns>
        private static int AlarmSystemDisplaySetMinMaxThresholdValue(string rangeType, Finch finchRobot)
        {
            int minMaxThresholdValue;
            bool isValidInput = true;

            do
            {
                DisplayScreenHeader("Minimum/Maximum Threshold Value");

                Console.WriteLine("\tCurrent left light sensor ambient value: {0}", finchRobot.getLeftLightSensor());
                Console.WriteLine("\tCurrent right light sensor ambient value: {0}", finchRobot.getRightLightSensor());
                Console.WriteLine();

                Console.Write("\tEnter the {0} light sensor threshold value: ", rangeType.ToUpper());

                isValidInput = int.TryParse(Console.ReadLine(), out minMaxThresholdValue);
                if (!isValidInput || minMaxThresholdValue < 0)
                {
                    Console.WriteLine("Please enter a positive integer value.");
                    DisplayContinuePrompt();
                }
            } while (!isValidInput);

            DisplayScreenHeader("Minimum/Maximum Threshold Value");

            Console.WriteLine("\t{0} light sensor threshold value: {1}", rangeType.ToUpper(), minMaxThresholdValue);

            DisplayMenuPrompt("Alarm System");

            return minMaxThresholdValue;
        }

        /// <summary>
        /// Sets the time limit to continue monitoring
        /// </summary>
        /// <returns></returns>
        private static int AlarmSystemDisplaySetTimeToMonitor()
        {
            DisplayScreenHeader("Set Time to Monitor");
            int timeToMonitor = 0;
            bool isValidInput;

            do
            {
                Console.Write("\tEnter the time to monitor the light sensors in seconds: ");
                isValidInput = int.TryParse(Console.ReadLine(), out timeToMonitor);

                if (!isValidInput || timeToMonitor <= 0)
                {
                    Console.WriteLine("\tPlease enter a positive non-zero integer value");
                    DisplayContinuePrompt();
                }
            } while (!isValidInput);

            DisplayMenuPrompt("Alarm System");

            return timeToMonitor;
        }

        /// <summary>
        /// Executes the alarm system commands
        /// </summary>
        /// <param name="sensorsToMonitor"></param>
        /// <param name="rangeType"></param>
        /// <param name="minMaxThresholdValue"></param>
        /// <param name="timeToMonitor"></param>
        /// <param name="finchRobot"></param>
        private static void AlarmSystemDisplaySetAlarm(string sensorsToMonitor, string rangeType, int minMaxThresholdValue, int timeToMonitor, Finch finchRobot)
        {
            int secondsElapsed = 0;
            int currentLightSensorValue = 0;
            bool thresholdExceeded = false;

            DisplayScreenHeader("Set Alarm");
            Console.WriteLine("\tLight Sensors Monitoring: {0}", sensorsToMonitor);
            Console.WriteLine("\tLight Sensors Range Type: {0}", rangeType);
            Console.WriteLine("\tLight Sensors {0} Threshold: {1}", rangeType, minMaxThresholdValue);
            Console.WriteLine("\tLight Sensors Time to Monitor {0}", timeToMonitor);
            Console.WriteLine();

            Console.WriteLine("Press any key to begin monitoring");
            Console.ReadKey();
            Console.WriteLine();

            while (secondsElapsed < timeToMonitor && !thresholdExceeded)
            {
                currentLightSensorValue = AlarmSystemDisplayGetLightSensorValue(finchRobot, sensorsToMonitor);

                switch (rangeType.ToLower())
                {
                    case "minimum":
                        if (currentLightSensorValue < minMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                        break;
                    case "maximum":
                        if (currentLightSensorValue > minMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                        break;
                }
                finchRobot.wait(1000);
                secondsElapsed++;
            }

            if(thresholdExceeded)
            {
                Console.WriteLine("\tThe {0} threshold value was exceeded by the current light sensor of {1}", rangeType.ToUpper(), currentLightSensorValue);
            }
            else
            {
                Console.WriteLine("\tThe {0} threshold value of {1} was not exceeded.", rangeType.ToUpper(),minMaxThresholdValue);
            }
            DisplayMenuPrompt("Alarm System");
        }

        /// <summary>
        /// Gets all light sensor values depending on which sensor user selected to monitor
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="sensorsToMonitor"></param>
        /// <returns></returns>
        private static int AlarmSystemDisplayGetLightSensorValue(Finch finchRobot, string sensorsToMonitor)
        {
            int currentLightSensorValue = 0;

            switch (sensorsToMonitor)
            {
                case "left":
                    currentLightSensorValue = finchRobot.getLeftLightSensor();
                    break;
                case "right":
                    currentLightSensorValue = finchRobot.getRightLightSensor();
                    break;
                case "both":
                    currentLightSensorValue = (finchRobot.getLeftLightSensor() + finchRobot.getRightLightSensor())/2;
                    break;
            }

            return currentLightSensorValue;
        }

        #endregion

        #region USER PROGRAMMING

        static void UserProgrammingDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            List<Command> commands = new List<Command>();
            int userProfile = 1;

            do
            {
                DisplayScreenHeader("User Programming Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Select User Profile");
                Console.WriteLine("\tb) Load User Profile (Profile: {0})", userProfile);
                Console.WriteLine("\tc) Save User Profile (Profile: {0})", userProfile);
                Console.WriteLine("\td) Set Command Parameters");
                Console.WriteLine("\te) Add Commands");
                Console.WriteLine("\tf) View Commands");
                Console.WriteLine("\tg) Execute Commands");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        userProfile = UserProgrammingDisplayGetUserProfile();
                        break;
                    case "b":
                        UserProgrammingDisplayShowLoadScreen(userProfile);
                        commandParameters = UserProgrammingDisplayReadUserParameterProfile(2);
                        commands = UserProgrammingDisplayReadUserCommandProfile(2);
                        break;
                    case "c":
                        UserProgrammingDisplayShowSaveScreen(userProfile);
                        UserProgrammingDisplayWriteUserProfile(userProfile, commands, commandParameters);
                        break;
                    case "d":
                        commandParameters = UserProgrammingDisplayGetCommandParameters();
                        break;

                    case "e":
                        UserProgrammingDisplayGetFinchCommands(commands);
                        break;

                    case "f":
                        UserProgrammingDisplayFinchCommands(commands, commandParameters);
                        break;

                    case "g":
                        UserProgrammingDisplayExecuteCommands(finchRobot, commands, commandParameters);
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
        /// Gives user feedback that program is saving
        /// </summary>
        /// <param name="userProfile">user profile</param>
        private static void UserProgrammingDisplayShowSaveScreen(int userProfile)
        {
            DisplayScreenHeader("Save Profile");

            Console.Write("\tSaving to profile {0}... ", userProfile);
            Console.WriteLine();

            DisplayMenuPrompt("User Programming");
        }
        /// <summary>
        /// Gives user feedback that program is loading
        /// </summary>
        /// <param name="userProfile">user profile</param>
        private static void UserProgrammingDisplayShowLoadScreen(int userProfile)
        {
            DisplayScreenHeader("Load Profile");

            Console.Write("\tLoading profile {0}... ", userProfile);
            Console.WriteLine();

            DisplayMenuPrompt("User Programming");
        }

        /// <summary>
        /// Gets command parameters from the user
        /// </summary>
        /// <returns></returns>
        private static (int motorSpeed, int ledBrightness, double waitSeconds) UserProgrammingDisplayGetCommandParameters()
        {
            DisplayScreenHeader("Command Parameters");

            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            GetValidInteger("\tEnter Motor Speed (1-255): ", 1, 255, out commandParameters.motorSpeed);
            GetValidInteger("\tEnter LED Brightness (1-255): ", 1, 255, out commandParameters.ledBrightness);
            GetValidDouble("\tEnter Wait in Seconds (0-10): ", 0, 10, out commandParameters.waitSeconds);

            Console.WriteLine();
            Console.WriteLine("\tMotor Speed: {0}", commandParameters.motorSpeed);
            Console.WriteLine("\tLED Brightness: {0}", commandParameters.ledBrightness);
            Console.WriteLine("\tWait command duration {0}", commandParameters.waitSeconds);

            DisplayMenuPrompt("User Programming");

            return commandParameters;
        }

        /// <summary>
        /// Gets the profile the user wish's to use from the user
        /// </summary>
        /// <returns></returns>
        static int UserProgrammingDisplayGetUserProfile()
        {
            int userProfile;
            bool isValidInput = true;

            do
            {
                DisplayScreenHeader("User Profile");

                GetValidInteger("\tEnter Profile Number (1-3): ", 1, 3, out userProfile);
            } while (!isValidInput);


            DisplayMenuPrompt("User Programming");
            return userProfile;
        }

        /// <summary>
        /// Gets the commands the user wish's to use
        /// </summary>
        /// <param name="commands"></param>
        private static void UserProgrammingDisplayGetFinchCommands(List<Command> commands)
        {
            Command command = Command.NONE;

            DisplayScreenHeader("Finch Robot Command Editor");

            int commandCount = 1;
            Console.WriteLine("\tList of Available Commands");
            Console.WriteLine();
            Console.Write("\t");

            foreach (string commandName in Enum.GetNames(typeof(Command)))
            {
                Console.Write("-- {0}   ", commandName.ToLower());
                if (commandCount % 5 == 0) Console.Write("\n\t");
                commandCount++;
            }
            Console.WriteLine();

            while (command != Command.DONE)
            {
                Console.Write("\tEnter Command: ");

                if(Enum.TryParse(Console.ReadLine().ToUpper(), out command))
                {
                    commands.Add(command);
                }
                else
                {
                    Console.WriteLine("\t\t**********************************************");
                    Console.WriteLine("\t\tPlease enter a command from the list above.");
                    Console.WriteLine("\t\t**********************************************");
                }
            }

            DisplayMenuPrompt("User Programming");
        }

        /// <summary>
        /// Displays the commands for the user to view
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="commandParameters"></param>
        private static void UserProgrammingDisplayFinchCommands(List<Command> commands, (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters)
        {
            DisplayScreenHeader("Finch Robot Command Viewer");

            Console.WriteLine("\tMotor Speed: {0}", commandParameters.motorSpeed);
            Console.WriteLine("\tLED Brightness: {0}", commandParameters.ledBrightness);
            Console.WriteLine("\tWait command duration {0}", commandParameters.waitSeconds);

            Console.WriteLine("\t\nCommands");

            foreach (Command command in commands)
            {
                Console.WriteLine("\t{0}", command);
            }

            DisplayMenuPrompt("User Programming");
        }

        /// <summary>
        /// Executes the commands given to by the user in previous steps
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="commands"></param>
        /// <param name="commandParameters"></param>
        private static void UserProgrammingDisplayExecuteCommands(Finch finchRobot, List<Command> commands, (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters)
        {

            int motorSpeed = commandParameters.motorSpeed;
            int ledBrightness = commandParameters.ledBrightness;
            int waitMilliSeconds = (int) (commandParameters.waitSeconds * 1000);
            string commandFeedback = "";
            const int TURNING_MOTOR_SPEED = 100;

            foreach(Command command in commands)
            {
                switch (command)
                {
                    case Command.NONE:
                        break;

                    case Command.MOVEFORWARD:
                        finchRobot.setMotors(motorSpeed, motorSpeed);
                        commandFeedback = Command.MOVEFORWARD.ToString();
                        break;

                    case Command.MOVEBACKWARD:
                        finchRobot.setMotors(-motorSpeed, -motorSpeed);
                        commandFeedback = Command.MOVEBACKWARD.ToString();
                        break;

                    case Command.STOPMOTORS:
                        finchRobot.setMotors(0, 0);
                        commandFeedback = Command.STOPMOTORS.ToString();
                        break;

                    case Command.WAIT:
                        finchRobot.wait(waitMilliSeconds);
                        commandFeedback = Command.WAIT.ToString();
                        break;

                    case Command.TURNRIGHT:
                        finchRobot.setMotors(0, TURNING_MOTOR_SPEED);
                        commandFeedback = Command.TURNRIGHT.ToString();
                        break;

                    case Command.TURNLEFT:
                        finchRobot.setMotors(TURNING_MOTOR_SPEED, 0);
                        commandFeedback = Command.TURNLEFT.ToString();
                        break;

                    case Command.LEDON:
                        finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                        commandFeedback = Command.LEDON.ToString();
                        break;

                    case Command.LEDOFF:
                        finchRobot.setLED(0, 0, 0);
                        commandFeedback = Command.LEDOFF.ToString();
                        break;

                    case Command.GETTEMPURATURE:
                        commandFeedback = $"Tempurature: {finchRobot.getTemperature()}";
                        break;

                    case Command.DONE:
                        commandFeedback = Command.DONE.ToString();
                        break;

                    default:
                        break;
                }
                Console.WriteLine("\t{0}", commandFeedback);
            }
        }

        /// <summary>
        /// Reads data from text file for command parameter data
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        static (int motorSpeed, int ledBrightness, double waitSeconds) UserProgrammingDisplayReadUserParameterProfile(int userProfile)
        {
            string dataPath = @"Data\User" + userProfile + ".txt";
            string[] dataCommands;

            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;


            dataCommands = File.ReadAllLines(dataPath);

            commandParameters.motorSpeed = int.Parse(dataCommands[0]);
            commandParameters.ledBrightness = int.Parse(dataCommands[1]);
            commandParameters.waitSeconds = double.Parse(dataCommands[2]);

            return commandParameters;
        }

        /// <summary>
        /// Reads data from text file for command list data
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        static List<Command> UserProgrammingDisplayReadUserCommandProfile(int userProfile)
        {
            string dataPath = @"Data\User" + userProfile + ".txt";

            
            string[] dataCommands;

            dataCommands = File.ReadAllLines(dataPath);
            List<Command> commands = new List<Command>();

            

            for (int i = 3; i < dataCommands.Length; i++)
            {
                commands.Add((Command) Enum.Parse(typeof(Command), dataCommands[i]));
            }
            return commands;
        }

        /// <summary>
        /// Writes data to text file including command parameter and list data
        /// </summary>
        /// <param name="userProfile"></param>
        /// <param name="commands"></param>
        /// <param name="commandParameters"></param>
        static void UserProgrammingDisplayWriteUserProfile(int userProfile, List<Command> commands, (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters)
        {
            string dataPath = @"Data\User" + userProfile +".txt";

            string[] commandArray = new string[commands.Count];

            for (int i = 0; i < commandArray.Length; i++)
            {
                commandArray[i] = commands[i].ToString();

            }

            File.WriteAllText(dataPath, commandParameters.motorSpeed.ToString() + "\n");
            File.AppendAllText(dataPath, commandParameters.ledBrightness.ToString() + "\n");
            File.AppendAllText(dataPath, commandParameters.waitSeconds.ToString() + "\n");
            File.AppendAllLines(dataPath, commandArray);
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

        #region HELPER METHODS

        private static int GetValidInteger(string prompt, int minimumValue, int maximumValue, out int validInteger)
        {
            bool isValid;

            do
            {
                Console.Write(prompt);
                if ((minimumValue == 0  && maximumValue == 0) || maximumValue - minimumValue == 0)
                {
                    isValid = int.TryParse(Console.ReadLine(), out validInteger);
                    if (!isValid)
                    {
                        Console.WriteLine("Please enter a valid integer value.");
                    }
                }
                else
                {
                    isValid = int.TryParse(Console.ReadLine(), out validInteger);
                    if (!isValid)
                    {
                        Console.WriteLine("Please enter a valid integer value");
                    }
                    else if (validInteger < minimumValue)
                    {
                        isValid = false;
                        Console.WriteLine("Please enter a valid integer greater than {0}.", minimumValue);

                    }
                    else if (validInteger > maximumValue)
                    {
                        isValid = false;
                        Console.WriteLine("Please enter a valid integer less than {0}.", maximumValue);
                    }
                }
            } while (!isValid);

            return validInteger;
        }

        private static double GetValidDouble(string prompt, double minimumValue, double maximumValue, out double validDouble)
        {
            bool isValid;

            do
            {
                Console.Write(prompt);
                if (maximumValue - minimumValue == 0)
                {
                    isValid = double.TryParse(Console.ReadLine(), out validDouble);
                    if (!isValid)
                    {
                        Console.WriteLine("Please enter a valid integer value.");

                    }
                }
                else
                {
                    isValid = double.TryParse(Console.ReadLine(), out validDouble);
                    if (!isValid)
                    {
                        Console.WriteLine("Please enter a valid integer value");
                    }
                    else if (validDouble < minimumValue)
                    {
                        isValid = false;
                        Console.WriteLine("Please enter a valid integer greater than {0}.", minimumValue);

                    }
                    else if (validDouble > maximumValue)
                    {
                        isValid = false;
                        Console.WriteLine("Please enter a valid integer less than {0}.", maximumValue);
                    }
                }
            } while (!isValid);

            return validDouble;
        }

        #endregion
    }
}