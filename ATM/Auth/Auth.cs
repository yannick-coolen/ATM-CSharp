using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ATM.Service;

namespace ATM.Auth
{
    internal class Auth
    {
        private readonly int id;
        private readonly string firstname;
        private readonly string lastname;

        public Auth(int id, string firstname, string lastname)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public int Id { get { return id; } }
        public string Username { get { return firstname; } }
        public string Password { get { return lastname; } }

        /// <summary>
        /// Checks if the index is equal as the entered index (which is refference to the use).
        /// <br /> 
        /// If True, the process will be redirected to section where the system asks for the user's pin
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="atm"></param>
        /// <param name="persons"></param>
        public static void CheckUser(Hidden[] pin, ATMFunction atm, Auth[] persons)
        {
            Console.WriteLine("What is your number a number?");
            
            while (true)
            {
                string stringIndex = Console.ReadLine();
                int intIndex = int.Parse(stringIndex);
                try
                {
                    for (int i = 0; i < persons.Length; i++)
                    {
                        if (persons[i] == persons[intIndex])
                        {
                            atm.ATMFunc(pin[i].GetPin().ToString(), pin[i].GetAmount());
                            break;
                        }

                    }
                    break;
                }

                catch (Exception)
                {
                    Console.WriteLine($"Index value is out of range.\n\nIndex value cannot be higher than {persons.Length - 1}");
                    continue;
                }
            }
        }
    }
}
