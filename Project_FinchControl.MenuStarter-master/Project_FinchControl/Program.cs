using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;
using System.Windows.Input;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: An application to control the finch robot
    // Application Type: Console
    // Author: Havenga, Michael
    // Dated Created: 1/22/2020
    //
    // **************************************************

    class Program
    {
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
        /// All Main Menus are located here
        /// </summary>
        #region MAIN MENUS

        /// <summary>
        /// Displays the Applications Main Menu
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
                Console.WriteLine("\te) Sensor Testing");
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
                        DataRecorderDisplayMenu(finchRobot);
                        break;

                    case "d":
                        AlarmSystemDisplayMenu(finchRobot);
                        break;

                    case "e":
                        DisplayUserProgramming(finchRobot);
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
        /// <summary>
        /// Data Recording Main Menu Screen
        /// </summary>
        /// <param name="finchRobot">Finch robot.</param>
        static void DataRecorderDisplayMenu(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitDataRecorderMenu = false;
            string menuChoice;

            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] tempertures = null;

            do
            {
                DisplayScreenHeader("Data Recording Menu");
                Console.WriteLine();
                Console.WriteLine("\t\tPlease note that this section is under development.");
                Console.WriteLine("\t\t Some things here may be incompleate or missing");
                Console.WriteLine();

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Display Temp Data");
                Console.WriteLine("\te) ");
                Console.WriteLine("\tf) ");
                Console.WriteLine("\tg) ");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();
                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderDisplayGetDataPointFrequency();
                        break;

                    case "c":
                        tempertures = DataRecorderDisplayGetData(numberOfDataPoints, dataPointFrequency, finchRobot);
                        break;

                    case "d":
                        DataRecorderDisplayData(tempertures);
                        break;

                    case "q":
                        quitDataRecorderMenu = true;
                        break;

                    case "e":

                        break;

                    case "f":

                        break;

                    case "g":
                        // TalentShowDisplayManualDrivng(finchRobot);
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!quitDataRecorderMenu);
        }
        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void TalentShowDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");
                Console.WriteLine();
                Console.WriteLine("\t\tPlease note that this section is under development.");
                Console.WriteLine("\t\t Some things here may be incompleate or missing");
                Console.WriteLine();

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mix it up");
                Console.WriteLine("\td) ");
                Console.WriteLine("\te) Smart Driving");
                Console.WriteLine("\tf) Driving Around");
                Console.WriteLine("\tg) ");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();
                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        TalentShowDisplayLightAndSound(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayDance(finchRobot);
                        break;

                    case "c":
                        TalentShowDisplayMixItUp(finchRobot);
                        break;

                    case "d":
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    case "e":
                        TalentShowDisplaySmartDriving(finchRobot);
                        break;

                    case "f":
                        TalentShowDisplayDrivingAround(finchRobot);
                        break;

                    case "g":
                        // TalentShowDisplayManualDrivng(finchRobot);
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
        /// Menu screen for Testing Sensors
        /// </summary>
        /// <param name="finchRobot">Finch robot.</param>
        static void DisplayUserProgramming(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitUserProgramming = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Sensor Testing Menu");
                Console.WriteLine();
                Console.WriteLine("\t\t!!This area is for debugging the finch!!");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Object Sensor Test");
                Console.WriteLine("\tb) Accelerometer Test");
                Console.WriteLine("\tc) Light Sensor Test");
                Console.WriteLine("\td) ");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        ObjectTesting(finchRobot);
                        break;

                    case "b":
                        AccelerometerTesting(finchRobot);
                        break;

                    case "c":
                        LightSensorTesting(finchRobot);
                        break;

                    case "d":
                        break;

                    case "q":
                        quitUserProgramming = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitUserProgramming);

        }
        /// <summary>
        /// Data Recording Main Menu Screen
        /// </summary>
        /// <param name="finchRobot">Finch robot.</param>
        static void AlarmSystemDisplayMenu(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitDataRecorderMenu = false;
            string menuChoice;

            string sensorsToMonitor = "";
            string rangeType = "";
            int minMaxThresholdValue = 0;
            double timeToMonitor = 0;


            do
            {
                DisplayScreenHeader("Alarm System Menu");
                Console.WriteLine();
                Console.WriteLine("\t\tPlease note that this section is under development.");
                Console.WriteLine("\t\t Some things here may be incompleate or missing");
                Console.WriteLine();

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Sensors to Monitor");
                Console.WriteLine("\tb) Set Range Type");
                Console.WriteLine("\tc) Set Min/Max Threshold Value");
                Console.WriteLine("\td) Set Time to Monitor");
                Console.WriteLine("\te) Set Alarm");
                Console.WriteLine("\tf) N/A");
                Console.WriteLine("\tg) N/A");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();
                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        sensorsToMonitor = AlarmSystemDisplaySetSensors();
                        break;

                    case "b":
                        rangeType = AlarmSystemDisplayRangeType();
                        break;

                    case "c":
                        minMaxThresholdValue = AlarmSystemDisplayThresholdValue(sensorsToMonitor, rangeType, finchRobot);
                        break;

                    case "d":
                        timeToMonitor = AlarmSystemDisplayTimeToMonitor();
                        break;

                    case "q":
                        quitDataRecorderMenu = true;
                        break;

                    case "e":
                        AlarmSystemDisplaySetAlarm(finchRobot, sensorsToMonitor, rangeType, minMaxThresholdValue, timeToMonitor);
                        break;

                    case "f":

                        break;

                    case "g":

                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!quitDataRecorderMenu);
        }

        #endregion

        /// <summary>
        /// Small or general use methods are located here
        /// </summary>
        #region SMALL METHODS

        /// <summary>
        /// Plays a warning tone to the user
        /// </summary>
        /// <param name="finchRobot">Finch robot.</param>
        static void WarningBeep(Finch finchRobot) 
        {
            finchRobot.noteOn(262);
            finchRobot.wait(300);
            finchRobot.noteOff();
            finchRobot.wait(200);
            finchRobot.noteOn(262);
            finchRobot.wait(300);
            finchRobot.noteOff();
            finchRobot.wait(200);
            finchRobot.noteOn(262);
            finchRobot.wait(1000);
            finchRobot.noteOff();
            finchRobot.wait(500);
        }
        /// <summary>
        /// Warning Light Blink loop
        /// </summary>
        /// <param name="finchRobot">Finch robot.</param>
        /// <param name="loops">Number of loops.</param>
        static void WarningBlink(Finch finchRobot, int loops)
        {
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
            for (int i = 0; i < loops; i++)
            {
                finchRobot.setLED(255, 0, 0);
                finchRobot.wait(500);
                finchRobot.setLED(0, 0, 0);
                finchRobot.wait(300);
            }
        }
        /// <summary>
        /// Rests the finch.
        /// </summary>
        /// <param name="finchRobot">Finch robot.</param>
        static void RestFinch(Finch finchRobot)
        {
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(left: 0, right: 0);
            finchRobot.noteOff();
        }
        /// <summary>
        /// Checks for an object, returns if clear or not and where object is
        /// </summary>
        /// <returns>isObject, where (bool), (string) left, right, clear</returns>
        /// <param name="finchRobot">Finch robot.</param>
        static (bool isObject, string where)IsObject(Finch finchRobot)
        {
            bool left;
            bool right;
            bool isObject = false;
            string where = "null";
                left = finchRobot.isObstacleLeftSide();
                right = finchRobot.isObstacleRightSide();
                if (left == true)
                {
                    isObject = true;
                    where = "left";
                    return (isObject, where);
                }
                if (right == true)
                {
                    isObject = true;
                    where = "right";
                    return (isObject, where);
                }
                isObject = false;
                where = "clear";
                return (isObject, where);
        }
        /// <summary>
        /// Takes a string and parses it into an int value;
        /// </summary>
        /// <returns>sting to int</returns>
        static int ValidateIntValue()
        {
            int validatedIntValue;
            bool validResponse;
            string userInput;
            do
            {
                validResponse = true;
                userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out validatedIntValue))
                {
                    Console.WriteLine();
                    Console.Write("\t Please enter a number a whole number [eg. 1, 5, 20]: ");
                    validResponse = false;
                }
            } while (!validResponse);
            return validatedIntValue;
        }
        /// <summary>
        /// Takes a string and converts it to a double value
        /// </summary>
        /// <returns>string to double</returns>
        static double ValidateDoubleValue()
        {
            double validatedDoubleValue;
            string userInput;
            bool validResponse;
            do
            {
                validResponse = true;
                userInput = Console.ReadLine();

                if (!double.TryParse(userInput, out validatedDoubleValue))
                {
                    Console.WriteLine();
                    Console.Write("\tPlease enter a number [eg. 1, .5, 130]: ");
                    validResponse = false;
                }
            } while (!validResponse);
            return validatedDoubleValue;
        }
        /// <summary>
        /// Validates a string value by returning true if valid false if invalid
        /// </summary>
        /// <returns><c>true</c>, if string is valid, <c>false</c> otherwise.</returns>
        /// <param name="unvalidatedString">Unvalidated string.</param>
        /// <param name="validAnwser">Valid anwser.</param>
        static bool IsStringValid(string unvalidatedString, string validAnwser)
        {
            bool validatedStringValue;
            unvalidatedString = unvalidatedString.ToLower();

            if (unvalidatedString == validAnwser)
            {
                validatedStringValue = true;
            }
            else
            {
                validatedStringValue = false;
            }

            return validatedStringValue;
        }

        static void PrintFinchImage()
        {
            Console.WriteLine();
            Console.WriteLine("\t         *  *  "         );
            Console.WriteLine("\t     * *         *     *");
            Console.WriteLine("\t   *                ** *");
            Console.WriteLine("\t *  *                  *");
            Console.WriteLine("\t**    **************** *");
            Console.WriteLine("\t  ***                 * ");
            Console.WriteLine();
        }

        #endregion

        /// <summary>
        /// Methods relating to the Alarm System menu are located here
        /// </summary>
        #region ALARM SYSTEM

        /// <summary>
        /// Gets the desired sensor to monitor from user.
        /// </summary>
        /// <returns>'left', 'right', or 'both' string</returns>
        static string AlarmSystemDisplaySetSensors()
        {
            string sensorsToMonitor = "null";
            bool validResponse;

            DisplayScreenHeader("Sensors To Monitor");
            Console.WriteLine();
            Console.WriteLine("\tSelectable sesors are the left, right, or both light sensors, the temperature sensor or all sensors." );
            Console.WriteLine();
            do
            {
                validResponse = true;
                Console.Write("\tSensors to Monitor [left, right, both, temp, all]: ");
                sensorsToMonitor = Console.ReadLine().ToLower();
                Console.WriteLine();
                //
                // Validate and echo user selection
                //
                switch (sensorsToMonitor)
                {
                    case "left":
                        Console.WriteLine("\tLeft Sensor Selected");
                        validResponse = true;
                        break;

                    case "right":
                        Console.WriteLine("\tRight Sensor Selected");
                        validResponse = true;
                        break;

                    case "both":
                        Console.WriteLine("\tBoth Sensors Selected");
                        validResponse = true;
                        break;

                    case "temp":
                        Console.WriteLine("\tTemperature Sensor Selected");
                        validResponse = true;
                        break;

                    case "all":
                        Console.WriteLine("\tAll Sensors Selected for monitoring");
                        validResponse = true;
                        break;
                    default:
                        Console.WriteLine("\tUnknown Sensor value, available values: left, right, both, temp, or all");
                        validResponse = false;
                        break;
                }
            } while (!validResponse);
            DisplayMenuPrompt("Alarm System Menu");
            return sensorsToMonitor;
        }
        /// <summary>
        /// Gets the range type from the user
        /// </summary>
        /// <returns>Min or Max</returns>
        static string AlarmSystemDisplayRangeType()
        {
            string rangeType;
            bool validResponse = false;

                DisplayScreenHeader("Range Type");
                Console.WriteLine();
                Console.WriteLine("\tPlease choose if you want the finch to stop on a max value or min value");
                Console.WriteLine();
                //
                // Validates and echos range selection
                //
                do
                {
                    Console.Write("\tEnter Range Type [Min or Max]: ");
                    rangeType = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    switch (rangeType)
                    {
                        case "min":
                            Console.WriteLine("\tMin selected for range type");
                            validResponse = true;
                            break;
                        case "max":
                            Console.WriteLine("\tMax Selected for range type");
                            validResponse = true;
                            break;
                        default:
                            validResponse = false;
                            Console.WriteLine("\tPlease enter a value of [ Min or Max ]");
                            break;
                    }
                } while (!validResponse);
            DisplayMenuPrompt("Alarm System Menu");
            return rangeType;
        }
        /// <summary>
        /// Gets the threshold value from user.
        /// </summary>
        /// <returns>Threshold value between 0 to 255</returns>
        /// <param name="sensorsToMonitor">Sensors to monitor.</param>
        /// <param name="rangeType">Range type.</param>
        /// <param name="finchRobot">Finch robot.</param>
        static int AlarmSystemDisplayThresholdValue(string sensorsToMonitor, string rangeType, Finch finchRobot)
        {
            int thresholdValue = -1;
            int currentLeftSensorValue = finchRobot.getLeftLightSensor();
            int currentRightSensorValue = finchRobot.getRightLightSensor();
            double currentTemp = finchRobot.getTemperature();
            bool sensorSet;

            DisplayScreenHeader("Threshold Value");
            Console.WriteLine();
            Console.WriteLine();

            //
            // Display current values from selected sensors
            //
            switch (sensorsToMonitor)
            {
                case "left":
                    Console.WriteLine($"\tCurrent selected Range Type: {rangeType}");
                    Console.WriteLine($"\tCurrent Left Sensor Value: {currentLeftSensorValue}");
                    sensorSet = true;
                    break;

                case "right":
                    Console.WriteLine($"\tCurrent selected Range Type: {rangeType}");
                    Console.WriteLine($"\tCurrent Right Sensor Value: {currentRightSensorValue}");
                    sensorSet = true;
                    break;

                case "both":
                    Console.WriteLine($"\tCurrent selected Range Type: {rangeType}");
                    Console.WriteLine($"\tCurrent Right Sensor Value: {currentRightSensorValue}");
                    Console.WriteLine($"\tCurrent Left Sensor Value: {currentLeftSensorValue}");
                    sensorSet = true;
                    break;

                case "temp":
                    Console.WriteLine($"\tCurrent selected Range Type: {rangeType}");
                    Console.WriteLine($"\tCurrent Temperature Value: {currentTemp:n1}° C");
                    sensorSet = true;
                    break;

                case "all":
                    Console.WriteLine($"\tCurrent Range Type: {rangeType}");
                    Console.WriteLine($"\tCurrent Temerature Value: {currentTemp:n1}° C");
                    Console.WriteLine($"\tCurrent Right Light Sensor Value: {currentRightSensorValue}");
                    Console.WriteLine($"\tCurrent Left Light Sensor Value: {currentLeftSensorValue}");
                    sensorSet = true;

                    break;

                default:
                    Console.WriteLine("\tUnknown Sensor Reference");
                    sensorSet = false;
                    break;
            }
            //
            // Get threshold for user, only if a sensor has been set
            //


                if (sensorSet == true)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease note the light sensors of the finch robot supports values of 0(dark) to 255(bright)");
                    Console.WriteLine("\tand the temprature recorded from the finch is in C°");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("\tEnter Threshold Value: ");
                    bool validResponse;
                    //
                    // Checks to make sure user set a correct value.
                    //
                    do
                    {
                        //
                        // Gets valid int value.
                        //
                        thresholdValue = ValidateIntValue();

                        if (thresholdValue < 0)
                        {
                            Console.WriteLine("\tThe finch robot only supports values between 0 and 255");
                            validResponse = false;
                        }
                        if (thresholdValue > 255)
                        {
                            Console.WriteLine("\tThe finch robot only supports values between 0 and 255");
                            validResponse = false;
                        }
                        else
                        {
                            validResponse = true;
                        }

                    } while (!validResponse);
                }
                else
                {
                    Console.WriteLine("\tNo data recorded, please set a sensor to monitor");
                }

            DisplayMenuPrompt("Alarm System Menu");
            return thresholdValue;
        }
        /// <summary>
        /// Gets the time to monitor from the user
        /// </summary>
        /// <returns>double value for seconds</returns>
        static double AlarmSystemDisplayTimeToMonitor()
        {
            double timeToMonitor = 0;

            DisplayScreenHeader("Time to Monitor");
            Console.Write("\tEnter Time to Monitor in seconds: ");
            //
            // Gets a valid double value from method
            //
            timeToMonitor = ValidateDoubleValue();

            Console.WriteLine();
            Console.WriteLine($"\tYou have entered {timeToMonitor} seconds for Time to Record");

            DisplayMenuPrompt("Alarm System Menu");
            return timeToMonitor;
        }
        /// <summary>
        /// Sets an alarm based on set values
        /// </summary>
        /// <param name="finchRobot">Finch robot.</param>
        /// <param name="sensorsToMonitor">Sensors to monitor.</param>
        /// <param name="rangeType">Range type.</param>
        /// <param name="minMaxThresholdValue">Minimum max threshold value.</param>
        /// <param name="timeToMonitor">Time to monitor.</param>
        static void AlarmSystemDisplaySetAlarm(Finch finchRobot, string sensorsToMonitor, string rangeType, int minMaxThresholdValue, double timeToMonitor)
        {
            bool thresholdExceeded = false;
            int secondsElapsed = 0;
            int leftLightSensor;
            int rightLightSensor;
            bool isValuesSet = true;
            double tempSensor;
            DisplayScreenHeader("Set Alarm");
            //
            // Check for default values, warn user that values are not set.
            //
            if (sensorsToMonitor == "null")
            {
                isValuesSet = false;
                Console.WriteLine("\tNo Sensor selected");
            }
            if (rangeType == "null")
            {
                isValuesSet = false;
                Console.WriteLine("\tNo Range Type set");
            }
            if (minMaxThresholdValue == -1)
            {
                isValuesSet = false;
                Console.WriteLine("\tNo Threshold Value set");
            }
            if (timeToMonitor == 0)
            {
                isValuesSet = false;
                Console.WriteLine("\tNo Time to Monitor value set");
            }
            //
            // Proceeds if required values are set.
            //
            if (isValuesSet == true)
            {
                Console.WriteLine();
                Console.WriteLine($"\tMonitored Sensor: {sensorsToMonitor}");
                Console.WriteLine($"\tRange Type: {rangeType}");
                Console.WriteLine($"\tThreshold Value: {minMaxThresholdValue}");
                Console.WriteLine($"\tMonitoring Time: {timeToMonitor} seconds");
                Console.WriteLine();
                Console.WriteLine();

                //prompting to start
                Console.WriteLine("\tPress any key to start");
                Console.ReadKey();
                Console.WriteLine();

                //
                // Threshold Check
                //
                do
                {
                    leftLightSensor = finchRobot.getLeftLightSensor();
                    rightLightSensor = finchRobot.getRightLightSensor();
                    tempSensor = finchRobot.getTemperature();
                    //
                    // Records data based on selected sensor and checks against time value and threshold, falls out if either exceed.
                    //
                    switch (sensorsToMonitor)
                    {
                        case "left":

                            Console.WriteLine($"\tCurrent Recorded Value on Left Sensor: {leftLightSensor}");
                            //
                            // This is a really bad way to do this, but it might work for now.
                            //
                            Console.SetCursorPosition(1, 12);
                            secondsElapsed++;
                            if (rangeType == "min")
                            {
                                thresholdExceeded = (leftLightSensor <= minMaxThresholdValue);
                            }
                            else // Max
                            {
                                if (leftLightSensor > minMaxThresholdValue)
                                {
                                    thresholdExceeded = true;
                                }
                            }
                            break;

                        case "right":
                            Console.WriteLine($"\tCurrent Recorded Value on Right Sensor: {rightLightSensor}");
                            Console.SetCursorPosition(1, 12);
                            secondsElapsed++;
                            if (rangeType == "min")
                            {
                                thresholdExceeded = (rightLightSensor <= minMaxThresholdValue);
                            }
                            else // Max
                            {
                                if (rightLightSensor > minMaxThresholdValue)
                                {
                                    thresholdExceeded = true;
                                }
                            }
                            break;

                        case "both":
                            Console.WriteLine($"\tCurrent Recorded Value: Left: {leftLightSensor} Right: {rightLightSensor}");
                            Console.SetCursorPosition(1, 12);
                            secondsElapsed++;
                            if (rangeType == "min")
                            {
                                if ((leftLightSensor <= minMaxThresholdValue) || (rightLightSensor <= minMaxThresholdValue))
                                {
                                    thresholdExceeded = true;
                                }
                            }
                            else // Max
                            {
                                if ((leftLightSensor > minMaxThresholdValue) || (rightLightSensor > minMaxThresholdValue))
                                {
                                    thresholdExceeded = true;
                                }
                            }
                            break;

                        case "temp":
                            Console.WriteLine($"\tCurrent Recorded Temperature: {tempSensor:n1}");
                            Console.SetCursorPosition(1, 12);
                            secondsElapsed++;
                            if (rangeType == "min")
                            {
                                thresholdExceeded = (tempSensor <= minMaxThresholdValue);
                            }
                            else // Max
                            {
                                if (tempSensor > minMaxThresholdValue)
                                {
                                    thresholdExceeded = true;
                                }
                            }
                            break;

                        case "all":
                            Console.WriteLine($"\tCurrent Recorded Values: Temp-{tempSensor:n1}° C, R-Light Sensor-{rightLightSensor}, L-Light Sensor-{leftLightSensor}");
                            Console.SetCursorPosition(1, 12);
                            if (rangeType == "min")
                            {
                                if ( (leftLightSensor <= minMaxThresholdValue) || (rightLightSensor <= minMaxThresholdValue) || (tempSensor <= minMaxThresholdValue) )
                                {
                                    thresholdExceeded = true;
                                }
                            }
                            else // Max
                            {
                                if ( (leftLightSensor > minMaxThresholdValue) || (rightLightSensor > minMaxThresholdValue) || (tempSensor > minMaxThresholdValue) )
                                {
                                    thresholdExceeded = true;
                                }
                            }
                            break;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("\tError, did you set a sensor to monitor?");
                            Console.WriteLine();
                            isValuesSet = false;
                            break;
                    }
                    finchRobot.wait(1000);

                } while (!thresholdExceeded && secondsElapsed < timeToMonitor && isValuesSet == true);
                //
                // Exit output based on Alarm trip reason
                //
                if (thresholdExceeded)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"\t!Threshold Exceeded! The recorded value surpassed the set Threshold");
                    WarningBeep(finchRobot);
                    WarningBlink(finchRobot, 2);
                    Console.WriteLine();
                }
                if (secondsElapsed >= timeToMonitor)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("\tTime limit reached, stopping recording");
                    Console.WriteLine();
                }
            }

            DisplayMenuPrompt("Alarm System Menu");
        }

        #endregion

        #region DATA RECORDER

        /// <summary>
        /// Displays the temp data in a table.
        /// </summary>
        /// <param name="temperatures">Temperatures.</param>
        static void DisplayDataRecorderDataTable(double[] temperatures)
        {
            Console.WriteLine(
                "Reading #".PadLeft(20) +
                "Temperature".PadLeft(15)
                );
            Console.WriteLine(
                "---------".PadLeft(20) +
                "-----------".PadLeft(15)
                );
            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine(
                (index + 1).ToString().PadLeft(20) +
                ("C°".PadLeft(5), (temperatures[index]).ToString("n1").PadLeft(0)) + 
                ("F°", (temperatures[index] * 1.8) + 32).ToString().PadLeft(5)
                );

            }
        }
        /// <summary>
        /// Displays the last data recording to the user
        /// </summary>
        /// <param name="tempertures">Tempertures.</param>
        static void DataRecorderDisplayData(double[] tempertures)
        {
            DisplayScreenHeader("Tempertures");
            Console.WriteLine();
            DisplayDataRecorderDataTable(tempertures);
            Console.WriteLine();
            DisplayMenuPrompt("Data Recorder Menu");
        }
        /// <summary>
        /// Records temp data using user's settings
        /// </summary>
        /// <returns>The recorder display get data.</returns>
        /// <param name="numberOfDataPoints">Number of data points.</param>
        /// <param name="dataPointFrequency">Data point frequency.</param>
        /// <param name="finchRobot">Finch robot.</param>
        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
        {
            double[] temperatures = new double[numberOfDataPoints];
            int dataPointFreqMs;
            //
            // Convert the freq in seconds to ms
            //
            dataPointFreqMs = (int)(dataPointFrequency * 1000);
            DisplayScreenHeader("Temperatures");
            Console.WriteLine();
            Console.WriteLine($"\tThe Finch robot will now record {numberOfDataPoints} temperatures {dataPointFrequency} seconds apart");
            Console.WriteLine("Press any key to being");
            Console.ReadLine();

            for (int i = 0; i < numberOfDataPoints; i++)
            {
                temperatures[i] = finchRobot.getTemperature();
                //
                // Echo new temp
                //
                Console.WriteLine($"\tTemperature {i + 1}: {temperatures[i]:n1}");
                finchRobot.wait(dataPointFreqMs);

            }

            //
            // Display table of temps
            //
            Console.WriteLine();
            DisplayDataRecorderDataTable(temperatures);
            DisplayMenuPrompt("Data Recorder Menu");

            return temperatures;
        }
        /// <summary>
        /// Gets the freq timing for data recording from user
        /// </summary>
        /// <returns>The recorder display get data point frequency.</returns>
        static double DataRecorderDisplayGetDataPointFrequency()
        {
            double dataPointFrequency;
            bool validResponse;
            string userResponse;
            DisplayScreenHeader("Data Point Frequency");
            Console.WriteLine();
            do
            {
                validResponse = true;
                Console.Write("Data Point Frequency: ");
                userResponse = Console.ReadLine();
                if (!double.TryParse(userResponse, out dataPointFrequency))
                {
                    Console.WriteLine();
                    Console.WriteLine("\t Please enter a number (eg: 12, 1.5, .25)");
                    Console.WriteLine();
                    validResponse = false;
                }
            } while (!validResponse);
            Console.WriteLine();
            Console.WriteLine($"\tYou chose {dataPointFrequency} as the data point frequency");

            DisplayMenuPrompt("Data Recorder Menu");


            return dataPointFrequency;
        }
        /// <summary>
        /// Gets the amount of data points from the user
        /// </summary>
        /// <returns>The recorder display get number of data points.</returns>
        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;
            bool validResponse;
            string userResponse;

            DisplayScreenHeader("Number of Data Points");
            do
            {
                validResponse = true;

                Console.Write("\tNumber of Data points: ");
                userResponse = Console.ReadLine();

                if (!int.TryParse(userResponse, out numberOfDataPoints))
                {
                    Console.WriteLine("\t Please enter whole number");
                    validResponse = false;
                }
            } while (!validResponse);

            Console.WriteLine();
            Console.WriteLine($"\tYou chose {numberOfDataPoints} as the number of data points.");

            DisplayMenuPrompt("Data Recorder Menu");

            return numberOfDataPoints;
        }

        #endregion

        #region TALENT SHOW

        /// <summary>
        /// Displays the Mix it Up Talent
        /// </summary>
        /// <param name="finchRobot">Finch robot.</param>
        static void TalentShowDisplayMixItUp(Finch finchRobot)
        {
            RestFinch(finchRobot);
            DisplayScreenHeader("Mixing it up");
            Console.WriteLine();
            Console.WriteLine("\tThe finch will dance and beep");
            Console.WriteLine();
            DisplayContinuePrompt();
            WarningBeep(finchRobot);
            for (int i = 0; i < 3; i++)
            {
                finchRobot.noteOn(500);
                finchRobot.wait(500);
                finchRobot.noteOn(600);
                finchRobot.wait(500);
                finchRobot.noteOn(750);
                finchRobot.wait(500);
                finchRobot.noteOff();
                finchRobot.setMotors(-255, 255);
                finchRobot.setLED(255, 0, 0);
                finchRobot.noteOn(400);
                finchRobot.wait(1500);
                finchRobot.setMotors(255, -255);
                finchRobot.setLED(0, 255, 0);
                finchRobot.noteOn(350);
                finchRobot.wait(1500);
                finchRobot.setMotors(255, 255);
                finchRobot.setLED(0, 0, 255);
                finchRobot.noteOn(300);
                finchRobot.wait(1000);
                finchRobot.setMotors(-255, -255);
                finchRobot.setLED(255, 0, 255);
                finchRobot.noteOn(250);
                finchRobot.wait(1000);
                finchRobot.noteOff();
            }
            RestFinch(finchRobot);
            DisplayMenuPrompt("Talent Show");
        }
        /// <summary>
        /// Displays the Dance Talent
        /// </summary>
        /// <param name="finchRobot">Finch robot.</param>
        static void TalentShowDisplayDance(Finch finchRobot)
        {
            RestFinch(finchRobot);
            DisplayScreenHeader("Dancing Finch");
            Console.WriteLine();
            Console.WriteLine("The finch will do a little dance.");
            Console.WriteLine();
            DisplayContinuePrompt();
            WarningBeep(finchRobot);
            for (int i = 0; i < 4; i++)
            {
                finchRobot.setMotors(255, 255);
                finchRobot.wait(500);
                finchRobot.setMotors(-255, 255);
                finchRobot.wait(300);
                finchRobot.setMotors(-255, 0);
                finchRobot.wait(200);
                finchRobot.setMotors(0, -255);
                finchRobot.wait(200);
                finchRobot.setMotors(255, -255);
                finchRobot.wait(300);
            }
            finchRobot.setMotors(0, 255);
            finchRobot.wait(600);
            RestFinch(finchRobot);
            finchRobot.noteOn(246);
            finchRobot.wait(500);
            finchRobot.noteOn(311);
            finchRobot.wait(1000);
            RestFinch(finchRobot);
            DisplayMenuPrompt("Talent Show Menu");
            
        }

        /// <summary>
        /// Allows the user to manually drive the finch robot.
        /// </summary>
        /// <param name="finchRobot">Finch robot.</param>
        static void TalentShowDisplayManualDrivng(Finch finchRobot)
        {
            //
            //TODO Check key press without waiting
            //This Currently is broken as key's will queue
            //
            DisplayScreenHeader("Manual Drivng");
            Console.WriteLine();
            Console.WriteLine("\t Controls: W: forward | S: backwards | A: left | D: right");
            Console.WriteLine();
            Console.WriteLine("Shake finch to stop. [wheel to weel]");
            DisplayContinuePrompt();
            do
            {

                finchRobot.setMotors(0, 0);
                if (Console.KeyAvailable)
                {
                    finchRobot.setMotors(0, 0);
                }
                else
                {
                    do
                    {
                        var userInput = Console.ReadKey(true);

                        if (userInput.Key == ConsoleKey.W)
                        {
                            finchRobot.setMotors(255, 255);
                            finchRobot.wait(100);
                        }
                        if (userInput.Key == ConsoleKey.S)
                        {
                            finchRobot.setMotors(-255, -255);
                            finchRobot.wait(100);
                        }
                        if (userInput.Key == ConsoleKey.A)
                        {
                            finchRobot.setMotors(-255, 255);
                            finchRobot.wait(100);
                        }
                        if (userInput.Key == ConsoleKey.D)
                        {
                            finchRobot.setMotors(255, -255);
                            finchRobot.wait(100);
                        }
                        else
                        {
                            finchRobot.setMotors(0, 0);
                        }
                    } while (!Console.KeyAvailable);
                }

            } while (finchRobot.getYAcceleration() < 1);
            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// Displays the smart driving loop screen.
        /// </summary>
        /// <param name="finchRobot">Finch robot.</param>
        static void TalentShowDisplaySmartDriving(Finch finchRobot)
        {
            DisplayScreenHeader("Smart Driving");
            Console.WriteLine();
            Console.WriteLine("\tThe Finch will forward until it detects an object blocking it's path.");
            Console.WriteLine();
            Console.WriteLine("\tPlease place your Finch Robot onto the ground as it will begin to move.");
            Console.WriteLine();
            DisplayContinuePrompt();

            // Warning user that finch is going to move
            WarningBeep(finchRobot);
            Console.WriteLine();
            Console.WriteLine("\t!Finch is now moving! Press any key to stop it.");
            Console.WriteLine("\tThe finch will keep moving until told to stop.");
            Console.WriteLine();
            do
            {
                var (isObject, where) = IsObject(finchRobot);
                if (isObject)
                {
                    finchRobot.setMotors(0, 0);
                    if (where == "left")
                    {
                        finchRobot.setMotors(75, -75);
                        finchRobot.wait(1000);
                    }
                    if (where == "right")
                    {
                        finchRobot.setMotors(-75, 75);
                        finchRobot.wait(1000);
                    }
                }
                else
                {
                    finchRobot.setMotors(100, 100);
                }
            } while (!Console.KeyAvailable);
            finchRobot.setMotors(left: 0, right: 0);
            Console.ReadKey();
            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// show display driving around.
        /// </summary>
        /// <param name="finchRobot">Finch robot.</param>
        static void TalentShowDisplayDrivingAround(Finch finchRobot)
        {
            DisplayScreenHeader("Driving Around");
            Console.WriteLine();
            Console.WriteLine("\tPlease set your Finch Robot on the ground as it will begin to move");
            Console.WriteLine();
            DisplayContinuePrompt();

            // Warning user that finch is going to move
            finchRobot.noteOn(262);
            finchRobot.wait(300);
            finchRobot.noteOff();
            finchRobot.wait(200);
            finchRobot.noteOn(262);
            finchRobot.wait(300);
            finchRobot.noteOff();
            finchRobot.wait(200);
            finchRobot.noteOn(262);
            finchRobot.wait(1000);
            finchRobot.noteOff();
            finchRobot.wait(500);

            //Moving finch around
            finchRobot.setMotors(right: 255, left: 255);
            finchRobot.wait(3000);
            finchRobot.setMotors(right: 0, left: 0);
            finchRobot.wait(500);
            finchRobot.setMotors(left: -255, right: 255);
            finchRobot.wait(2000);
            finchRobot.setMotors(left: 0, right: 0);

            DisplayMenuPrompt("Main Menu");
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

            Console.WriteLine("\tThe Finch robot will play a tune and light up.");
            DisplayContinuePrompt();
            //
            //Song section 1 loop
            //
            for (int i = 0; i < 4; i++)
            {
                finchRobot.setLED(0, 0, 0);
                finchRobot.noteOn(495);
                finchRobot.wait(300);
                finchRobot.setLED(0, 255, 0);
                finchRobot.noteOn(463);
                finchRobot.wait(300);
                finchRobot.setLED(0, 0, 0);
                finchRobot.noteOff();
                finchRobot.noteOn(366);
                finchRobot.setLED(255, 0, 0);
                finchRobot.wait(300);
                finchRobot.setLED(0, 0, 0);
                finchRobot.noteOff();
                finchRobot.noteOn(310);
                finchRobot.setLED(0, 0, 255);
                finchRobot.wait(300);
            }
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
            //
            //Song Section 2 loop
            //
            for (int i = 0; i < 2; i++)
            {
                finchRobot.setLED(230, 0, 230);
                finchRobot.noteOn(328);
                finchRobot.wait(300);
                finchRobot.setLED(0, 0, 0);
                finchRobot.noteOff();
                finchRobot.setLED(155, 0, 230);
                finchRobot.noteOn(310);
                finchRobot.wait(300);
                finchRobot.setLED(0, 0, 0);
                finchRobot.noteOff();
                finchRobot.setLED(17, 0, 102);
                finchRobot.noteOn(328);
                finchRobot.wait(300);
                finchRobot.setLED(0, 0, 0);
                finchRobot.noteOff();
                finchRobot.setLED(0, 102, 204);
                finchRobot.noteOn(248);

                finchRobot.wait(300);
                finchRobot.noteOff();
                finchRobot.setLED(255, 191, 0);
                finchRobot.noteOn(328);
                finchRobot.wait(300);
                finchRobot.setLED(0,0,0);
                finchRobot.noteOff();
                finchRobot.setLED(255, 255, 128);
                finchRobot.noteOn(310);
                finchRobot.wait(300);
                finchRobot.setLED(0, 0, 0);
                finchRobot.noteOff();
                finchRobot.setLED(255, 255, 204);
                finchRobot.noteOn(328);
                finchRobot.wait(300);
                finchRobot.setLED(0, 0, 0);
                finchRobot.noteOff();
                finchRobot.setLED(255, 25, 25);
                finchRobot.noteOn(248);
                finchRobot.wait(300);
            }
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
            finchRobot.noteOn(416);
            finchRobot.wait(300);
            finchRobot.noteOn(369);
            finchRobot.wait(800);
            finchRobot.noteOff();
            DisplayMenuPrompt("Talent Show Menu");
        }

        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// Used to test the light sensors of the finch.
        /// </summary>
        /// <param name="finchRobot">Finch robot.</param>
        static void LightSensorTesting(Finch finchRobot)
        {
            DisplayScreenHeader("Light Sensor Testing");
            Console.WriteLine();
            Console.WriteLine("\tTesting the light sensors and outputting values");
            Console.WriteLine();
            Console.WriteLine("\tShake the finch robot side to side [wheel to wheel] to stop test.");
            Console.WriteLine();
            DisplayContinuePrompt();
            int left;
            int right;
            do
            {
                left = finchRobot.getLeftLightSensor();
                right = finchRobot.getRightLightSensor();
                Console.WriteLine($"Left: {left}  |Right: {right}  ");
            } while (finchRobot.getYAcceleration() < 1);

            Console.WriteLine();
            Console.WriteLine("Done with Light Sensor Test");
            Console.WriteLine();
            DisplayMenuPrompt("Sensor Menu");
        }

        /// <summary>
        /// Dumping Data from Accelerometer sensor for testing.
        /// </summary>
        /// <param name="finchRobot">Finch robot.</param>
        static void AccelerometerTesting(Finch finchRobot)
        {
            DisplayScreenHeader("\tAccelerometer Testing");
            Console.WriteLine();
            Console.WriteLine("\tOutputs Finch Acceleromerter data in X, Y, Z planes");
            Console.WriteLine();
            Console.WriteLine("Cover the Finch Object sensors to stop the recording");
            Console.WriteLine();
            DisplayContinuePrompt();
            double X;
            double Y;
            double Z;
            do
            {
                X = finchRobot.getXAcceleration(); 
                Y = finchRobot.getYAcceleration();
                Z = finchRobot.getZAcceleration();
                Console.WriteLine($"X:{X:n3}|Y:{Y:n3}|Z:{Z:n3}");
            } while (!finchRobot.isObstacleLeftSide());
            Console.WriteLine();
            Console.WriteLine("Done with Sensor Test");
            DisplayMenuPrompt("Sensor Menu");
        }
        /// <summary>
        /// Tests the IR sensors of the finch Robot
        /// </summary>
        /// <param name="finchRobot">Finch robot.</param>
        static void ObjectTesting(Finch finchRobot)
        {
            DisplayScreenHeader("\tThis will test the object detection sensors");
            Console.WriteLine();
            Console.WriteLine("\tThe first sensor test is on the left object sensor");
            Console.WriteLine();
            Console.WriteLine("To end the test shake the finch robot side to side [wheel to wheel]");
            Console.WriteLine();
            DisplayContinuePrompt();
            Console.Clear();


            do
            {
                var (isObject, where) = IsObject(finchRobot);
                if (isObject)
                {
                    if (where == "left")
                    {
                        Console.WriteLine("Detecting Left");
                    }
                    if (where == "right")
                    {
                        Console.WriteLine("Detecting Right");
                    }
                }
                else
                {
                    Console.WriteLine("All Clear");
                }

            } while (finchRobot.getYAcceleration() < 1);
            Console.WriteLine();
            Console.WriteLine("Done with Sensor Test");
            DisplayMenuPrompt("Sensor Menu");

        }

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

            if (robotConnected == true)
            {
                finchRobot.setLED(0, 0, 0);
                finchRobot.noteOff();
                finchRobot.wait(400);
                finchRobot.setLED(0, 255, 0);
                finchRobot.noteOn(165);
                finchRobot.wait(200);
                finchRobot.noteOff();
                finchRobot.noteOn(784);
                finchRobot.wait(200);
                finchRobot.noteOff();
                finchRobot.noteOn(4500);
                finchRobot.wait(300);
                finchRobot.noteOff();
                Console.WriteLine();
                Console.WriteLine("\tYour Finch Robot has been connected!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("\tUnable to connect to Finch Robot. Are you sure it's plugged in?");
                Console.WriteLine();
            }


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
            PrintFinchImage();
            Console.WriteLine("\tCreated by: Michael Havenga");

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
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
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
        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkGray;
        }
        #endregion
    }
}
