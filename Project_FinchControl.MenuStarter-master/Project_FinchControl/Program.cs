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
                        DisplayDataRecorderScreen(finchRobot);
                        break;

                    case "d":

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


        #region SMALL METHODS
        /// <summary>
        /// Displays a tone to warn the user
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
        static (bool isObject, string where) IsObject(Finch finchRobot)
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
        #endregion


        #region TALENT SHOW
        /// <summary>
        /// Records the temp from the finch robot and displays it to the user.
        /// </summary>
        /// <param name="finchRobot">Finch robot.</param>
        static void DisplayDataRecorderScreen(Finch finchRobot)
        {
            double finchTemp;
            DisplayScreenHeader("Data Recording from Finch Sensors");
            DisplayContinuePrompt();
            Console.WriteLine();
            Console.WriteLine("\tGetting data...");
            //
            //Indicating the finch is doing something.
            //
            finchRobot.noteOn(165);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(2489);
            finchRobot.wait(500);
            finchRobot.noteOff();
            //
            //Recording temp
            //
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

                        break;

                    case "c":

                        break;

                    case "d":
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    case "e":
                        TalentShowDisplaySmartDriving(finchRobot); break;

                    case "f":
                        TalentShowDisplayDrivingAround(finchRobot);
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
        /// Displays the smart driving loop screen.
        /// </summary>
        /// <param name="finchRobot">Finch robot.</param>
        static void TalentShowDisplaySmartDriving(Finch finchRobot)
        {
            //
            //bool objectLeft;
            //bool objectRight;


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
            Console.WriteLine("\t!Finch is now moving! You can shake the finch to stop it. [wheel to wheel]");
            Console.WriteLine("\tThe finch will keep moving until it is shaked.");
            Console.WriteLine();
            //TODO Create loop for avoiding objects without stopping.
            //PLAN: Drive forward. OBJECT!! Check left or right, turn opsite direction. Continue if clear, else perform 180. Continue.
            //TODO Adding the ability for user to stop the finch without closing.
            //
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
            } while (finchRobot.getYAcceleration() < 1);
            //
            // Old Code
            //
            //do
            //{
            //    //
            //    // Checks the sensors each loop
            //    //
            //    objectLeft = finchRobot.isObstacleLeftSide();
            //    objectRight = finchRobot.isObstacleRightSide();

            //    finchRobot.setMotors(left: 150,right: 150);
            //        //
            //        //Actions for when an object is detected.
            //        //
            //        if (objectLeft)
            //        {
            //            Console.WriteLine();
            //            Console.WriteLine("Object detected on the left");
            //            Console.WriteLine();
            //            finchRobot.setMotors(left: 0, right: 0);
            //            finchRobot.wait(2000);
            //            finchRobot.setMotors(left: 100, right: -100);
            //            finchRobot.wait(500);
            //        }
            //        if (objectRight)
            //        {
            //            Console.WriteLine();
            //            Console.WriteLine("Object detected on the right");
            //            Console.WriteLine();
            //            finchRobot.setMotors(left: 0, right: 0);
            //            finchRobot.wait(2000);
            //            finchRobot.setMotors(left: -100, right: 100);
            //            finchRobot.wait(500);

            //        }


            //} while (finchRobot.getYAcceleration() < 1);
            finchRobot.setMotors(left: 0, right: 0);
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

            //
            // Old Test
            //
            //do
            //{
            //    if (finchRobot.isObstacleRightSide())
            //    {
            //        finchRobot.setLED(0, 255, 0);
            //        Console.WriteLine("!! Detected Right Side !!");
            //    }
            //    else
            //    {
            //        finchRobot.setLED(255, 0, 0);
            //        Console.WriteLine("Not Detecting on Right");
            //    }
            //} while (finchRobot.getYAcceleration() < 1);
            //finchRobot.setLED(0, 0, 0);
            //Console.WriteLine("\tDone with Right Sensor");
            //Console.WriteLine();
            //Console.WriteLine("\tNext Sensor is the Left");
            //Console.WriteLine();
            //Console.WriteLine("To end the test shake the finch front to back. [tail to beak]");
            //DisplayContinuePrompt();
            //do
            //{
            //    if (finchRobot.isObstacleLeftSide())
            //    {
            //        finchRobot.setLED(0, 255, 0);
            //        Console.WriteLine("!! Detected Left Side !!");
            //    }
            //    else
            //    {
            //        finchRobot.setLED(255, 0, 0);
            //        Console.WriteLine("Not Detecting on Left");
            //    }
            //} while (finchRobot.getXAcceleration() < 1);
            //finchRobot.setLED(0, 0, 0);

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
