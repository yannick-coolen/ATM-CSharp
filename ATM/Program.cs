using System;
using System.Collections;
using System.Collections.Generic;

using ATM.Service;
using ATM.Hidden;
using ATM.Person;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ATMFunction atm = new();

            Hidden.Hidden[] pin = new Hidden.Hidden[5];

            pin[0] = new("1234", 200);
            pin[1] = new("9876", 400);

            Person.Person[] persons = new Person.Person[5];

            persons[0] = new(1, "John", "test");
            persons[1] = new(2, "Sarah", "test");

            Person.Person.CheckUser(pin, atm, persons);
        }
    }
}
