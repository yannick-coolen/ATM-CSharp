using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ATM.Auth;
using ATM.Service;

namespace ATM.Service
{
    internal class ATMFunction
    {
        private byte attempts = 3;
        private bool usingService = false;
        private Hidden user;      
        readonly Service service = new();

        /// <summary>
        /// A simple ATM function
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="amount"></param>
        public void ATMFunc(string pin, int amount)
        {
            user = new(pin, amount);

            Console.WriteLine("Please enter your PIN, or press q to quit.");

            #region
            while(!usingService)
            {
                pin = Console.ReadLine();
                Console.WriteLine("----------------------------------------");
                if (pin.All(char.IsDigit))
                {
                    if (pin.Length != 4)
                    {
                        Console.WriteLine("Invald input. Only 4 digits are allowed.");
                        continue;
                    }
                    else
                    {
                        // Checks the amount of attempts that are left
                        if (pin != user.GetPin().ToString())
                        {
                            attempts--;
                            
                            if (attempts == 0)
                            {
                                Console.WriteLine("Access denied. Your pin card has been blocked.");
                            }
                            else
                            {   
                                if (attempts == 1)
                                {
                                    Console.WriteLine($"Try again, you have {attempts} attempt left.");
                                }
                                else
                                {
                                    Console.WriteLine($"Try again, you have {attempts} attempts left.");
                                }
                                continue;
                            }
                        }
                        // On this case the entered pin value is correct and will redirect the user to the main menu.
                        else
                        {
                            Console.WriteLine("Welcome");
                            
                            // Initiated object uses the ATM Method
                            service.UseService(user.GetAmount(), usingService);
                            usingService = true;
                        }
                    }
                }
                // Allow the user to quit the process at the very beginning by entering the q key followed by pressing the enter key
                else if ((pin.Contains("q") || pin.Contains("Q")) && pin.Length <= 1)
                {
                    Console.WriteLine("Process has stopped. Thank you for coming.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Only digits (0 - 9) or q key are allowed.");
                    continue;
                }
                // Process is completed
                usingService = true;
            }
            #endregion
        }
    }
}
