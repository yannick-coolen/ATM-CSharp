using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ATM.Service;

namespace ATM.Person
{
    internal class Person
    {
        private readonly int id;
        private readonly string username;
        private readonly string password;

        public Person(int id, string username, string password)
        {
            this.id = id;
            this.username = username;
            this.password = password;
        }

        public int Id { get { return id; } }
        public string Username { get { return username; } }
        public string Password { get { return password; } }

        public static void CheckUser(Hidden.Hidden[] pin, ATMFunction atm, Person[] persons)
        {
            Console.WriteLine("Write down a number");
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
