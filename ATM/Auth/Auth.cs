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

        public static void CheckUser(Hidden[] pin, ATMFunction atm, Auth[] persons)
        {
            Console.WriteLine("What is your number a number?");
            string stringIndex = Console.ReadLine();
            int intIndex = int.Parse(stringIndex);

            for (int i = 0; i < persons.Length; i++)
            {
                if (persons[i] == persons[intIndex])
                {
                    atm.ATMFunc(pin[i].GetPin().ToString(), pin[i].GetAmount());
                    break;
                }
            }
        }
    }
}
