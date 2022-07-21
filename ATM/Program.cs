using System;
using System.Collections;
using System.Collections.Generic;

using ATM.Service;
using ATM.Auth;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ATMFunction atm = new();

            Hidden[] pin = new Hidden[2];

            pin[0] = new("1234", 200);
            pin[1] = new("9876", 400);
                        
            Auth.Auth[] auth = new Auth.Auth[2];

            auth[0] = new(1, "John", "test");
            auth[1] = new(2, "Sarah", "test");

            Auth.Auth.CheckUser(pin, atm, auth);
        }
    }
}
