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
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu
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
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkGray;
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
                menuChoice = Console.ReadLine();
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
                        DisplayDataRecorderScreen(finchRobot);
                        break;

                    case "d":

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

        #region TALENT SHOW

        static void DisplayDataRecorderScreen(Finch finchRobot)
        {
            double finchTemp;
            DisplayScreenHeader("Data Recording from Finch Sensors");
            DisplayContinuePrompt();
            Console.WriteLine();
            Console.WriteLine("\tGetting data...");
            finchRobot.noteOn(165);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(2489);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchTemp = finchRobot.getTemperature();
            Console.WriteLine();
            Console.WriteLine($"Temp Recorded by Finch in Celsius: {finchTemp:n2}");
            Console.WriteLine();
            DisplayMenuPrompt("Main Menu");


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

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Driving Around");
                Console.WriteLine("\tc) Smart Driving");
                Console.WriteLine("\td) Testing Area");
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
                        TalentShowDisplayDrivingAround(finchRobot);
                        break;

                    case "c":
                        TalentShowDisplaySmartDriving(finchRobot);
                        break;

                    case "d":
                        TestingArea(finchRobot);
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

        static void TestingArea(Finch finchRobot)
        {
            DisplayScreenHeader("This area is for debugging issues on the Finch Robot and to check all sensors");
            Console.WriteLine();
            Console.WriteLine();
            DisplayContinuePrompt();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Testing Object sensors");
            Console.WriteLine();
            Console.WriteLine("Right Sensor");
            do
            {
                if (finchRobot.isObstacleRightSide())
                {
                    finchRobot.setLED(0, 255, 0);
                    Console.WriteLine("Detected Right Side");
                }
                else
                {
                    finchRobot.setLED(255, 0, 0);
                    Console.WriteLine("Not Detecting");
                }
            } while (finchRobot.getYAcceleration() < 1);
            finchRobot.setLED(0, 0, 0);
            Console.WriteLine();
            Console.WriteLine("Left Sensor");
            do
            {
                if (finchRobot.isObstacleLeftSide())
                {
                    finchRobot.setLED(0, 255, 0);
                    Console.WriteLine("Detected left Side");
                }
                else
                {
                    finchRobot.setLED(255, 0, 0);
                    Console.WriteLine("Not Detecting");
                }
            } while (finchRobot.getYAcceleration() < 1);
            finchRobot.setLED(0, 0, 0);
            DisplayMenuPrompt("Main Menu");

        }

        static void TalentShowDisplaySmartDriving(Finch finchRobot)
        {
            //
            bool objectLeft;
            bool objectRight;


            DisplayScreenHeader("Smart Driving");
            Console.WriteLine();
            Console.WriteLine("\tPlease place your Finch Robot onto the ground as it will begin to move.");
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
            Console.WriteLine();
            Console.WriteLine("\t!Finch is now moving! You can shake the finch to stop it.");
            Console.WriteLine();
            //TODO Create loop for avoiding objects without stopping.
            //PLAN: Drive forward. OBJECT!! Check left or right, turn opsite direction. Continue if clear, else perform 180. Continue.
            //TODO Adding the ability for user to stop the finch without closing.


            do
            {
                objectLeft = finchRobot.isObstacleLeftSide();
                objectRight = finchRobot.isObstacleRightSide();

                if (!objectLeft || !objectRight)
                {
                    finchRobot.setMotors(left: 255, right: 255);
                }
                else
                {
                    if (objectLeft)
                    {
                        finchRobot.setMotors(left: 0, right: 0);
                        finchRobot.wait(2000);
                        finchRobot.setMotors(left: 100, right: -100);
                        finchRobot.wait(500);
                    }
                    if (objectRight)
                    {
                        finchRobot.setMotors(left: 0, right: 0);
                        finchRobot.wait(2000);
                        finchRobot.setMotors(left: -100, right: 100);
                        finchRobot.wait(500);

                    }
                }

            } while (finchRobot.getYAcceleration() < 1);

            //Simply for testing object detection
            //do
            //{
            //    finchRobot.setMotors(left: 255, right: 255);

            //} while (!objectLeft || !objectRight);
            //finchRobot.setMotors(left: 0, right: 0);
            //Console.WriteLine();
            //Console.WriteLine("\tObject Detected! Stopping Finch");
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

            Console.WriteLine("\tThe Finch robot will not show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 100);
            }
            finchRobot.wait(1000);
            finchRobot.noteOff();
            DisplayMenuPrompt("Talent Show Menu");
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

            if (robotConnected == true)
            {
                finchRobot.setLED(0, 0, 0);
                finchRobot.noteOff();
                finchRobot.wait(500);
                for (int blinks = 0; blinks < 3; blinks++)
                {
                    finchRobot.setLED(255, 0, 0);
                    finchRobot.wait(500);
                    finchRobot.setLED(0, 0, 0);
                    finchRobot.wait(500);
                }
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

        #endregion



    }
}
