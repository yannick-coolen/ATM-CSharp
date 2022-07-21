using System;

namespace ATM.Service
{
    internal class Service
    {
        private readonly bool insufficient = false;
        private readonly string yes = "Y", no = "N";

        /// <summary>
        /// The whole ATM function, it starts asking to enter a pin. If true, the main menu appears. 
        /// <br />
        /// If false, the user get another chance to re-enter the valid pincode. 
        /// <br />
        /// After three tries, the pin will be blocked and the process stops as well.
        /// </summary>
        /// <param name="budget"></param>
        /// <param name="currentService"></param>
        public void UseService(int budget, bool currentService)
        {
            Console.WriteLine("Select an option and press enter to procees:");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(
                "Option 1: Withdraw\n" +
                "Option 2: Deposit\n" +
                "Option 3: Check amount\n" +
                "Option 4: Quit");

            SelectInput(budget, currentService);
        }

        /// <summary>
        /// Allows the user to select an option in the main menu of the pin project.
        /// </summary>
        /// <param name="budget"></param>
        /// <param name="currentService"></param>
        public void SelectInput(int budget, bool currentService)
        {
            #region
            while (!currentService)
            {
                try
                {
                    string select = Console.ReadLine();
                    int selectInt = int.Parse(select);

                    // Cases of which the user can choose from.
                    switch (selectInt)
                    {
                        // This allows the user to withdraw from its bank account.
                        case 1:
                            WithdrawAmount(budget, currentService);
                            currentService = true;
                            break;
                        // This allows the user to deposit a amount of budget to its bank account.
                        case 2:
                            // Try to run the code snippet as long no errors has been met.
                            try
                            {
                                Console.WriteLine("How much would you like to deposit?");
                                string amountValue = Console.ReadLine();
                                int amountInt = int.Parse(amountValue);
                                budget += amountInt;
                                Console.WriteLine(
                                    $"You have deposit {amountInt}. The current amount is {budget} euro.\n");
                                Receipt(budget, currentService);
                                currentService = true;
                            }
                            // Catches the error and will give the user feedback why an error has been occurred.
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid input, please use digits only.");
                                continue;
                            }
                            break;
                        // Allows the user to check the amount of money the user has at the current point. 
                        case 3:
                            Console.WriteLine(
                                $"The current amount is: {budget} euro.\n\n" +
                                $"Would you like to proceed?\n" +
                                $"Write down \"Y\" for yes or \"N\" for no.");
                            // Asks if the user wishes to proceed
                            RequestToProceed(budget, currentService);
                            break;
                        case 4:
                            // User has chosen to quit the whole process
                            Console.WriteLine("Proces has stopped. Thank you for coming.");
                            Console.ReadKey();
                            break;
                    }
                    // Check if the user has entered an invalid value.
                    if (selectInt <= 0 || selectInt >= 5)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                        continue;
                    }
                }
                // Catch the error and will give the user 
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                    continue;
                }
                currentService = true;
            }
            #endregion
        }

        /// <summary>
        /// Shows the current amount of budget that the user owns.
        /// </summary>
        /// <param name="budget"></param>
        /// <param name="currentService"></param>
        public void WithdrawAmount(int budget, bool currentService)
        {
            Console.WriteLine("How much would you like to withdraw?");
            while (!insufficient)
            {
                // Try to run the code snippet as long no errors has been met.
                try
                {
                    string amountValue = Console.ReadLine();
                    int amountInt = int.Parse(amountValue);

                    // The requested amount is insufficient.
                    if (amountInt > budget)
                    {
                        Console.WriteLine($"Insufficient amount. Please choose a budget that is lower or equal as {budget}.");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"You have withdrawn {amountInt} euro, and an amount of {budget -= amountInt} euro is left on your bank account.\n");
                        // System will ask the user would like to have a printed receipt
                        Receipt(amountInt, currentService);
                        break;
                    }
                }
                // Catches the error and will give the user feedback why an error has been occurred.
                catch (Exception)
                {
                    Console.WriteLine("Invalid value. Please enter a valid value.");
                }
            }
        }

        /// <summary>
        /// Asks if the user wishes to proceed (this only appears on the check amount menu of the ATM project).
        /// </summary>
        /// <param name="budget"></param>
        /// <param name="currentService"></param>
        public void RequestToProceed(int budget, bool currentService)
        {
            while (!currentService)
            {
                string answer = Console.ReadLine();
                // Checks if the user has decided to proceed with the process
                if (answer == yes.ToLower())
                {
                    // User will be redirected to the main menu
                    UseService(budget, currentService);
                }
                // Checks if the user has decided to quit with the process
                else if (answer == no.ToLower())
                {
                    Console.WriteLine("Process has stopped. Thank you for coming.");
                    Console.ReadKey();
                }
                else
                {
                    // Checks if the user has entered more than one character
                    if (answer.Length > 1)
                    {
                        Console.WriteLine("Invalid input. Only one digit between 1 or 4 is allowed.\n" +
                            "\n" +
                            "Please try again.");
                        continue;
                    }

                    // Checks if the user has entered an invalid value
                    if (answer != yes || answer != no)
                    {
                        Console.WriteLine("Invalid input. Only one digit between 1 or 4 is allowed.\n" +
                            "\n" +
                            "Please try again.");
                        continue;
                    }
                }
                currentService = true;
            }
        }

        /// <summary>
        /// Asks if the user wishes to print a receipt.
        /// </summary>
        /// <param name="budget"></param>
        /// <param name="currentService"></param>
        public void Receipt(int budget, bool currentService)
        {
            Console.WriteLine("Would you like to receive a receipt?");

            while (!currentService)
            {
                Console.WriteLine("Fill in Y for Yes or N for No:");
                string printReceipt = Console.ReadLine();
                Console.WriteLine("----------------------------------------");

                // Checks if the user has entered more than one character
                if (printReceipt.Length > 1)
                {
                    Console.WriteLine("Invalid");
                    continue;
                }
                else
                {
                    // User has decided to receive a receipt
                    if (printReceipt == yes || printReceipt == yes.ToLower())
                    {
                        Console.WriteLine(
                            $"Receipt has been printed.\n" +
                            $"\n" +
                            $"Have a nice day.");
                        Console.ReadKey();
                    }
                    // User has decided not to receive a receipt
                    else if (printReceipt == no || printReceipt == no.ToLower())
                    {
                        Console.WriteLine("Have a nice day.");
                    }
                    // User has entered a wrong value
                    else
                    {
                        Console.WriteLine("Invalid");
                        continue;
                    }
                }
                currentService = true;
            }
        }
    }
}
