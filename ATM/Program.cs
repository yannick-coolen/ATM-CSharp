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

            Hidden[] hidden = {
                new Hidden("1234", 200),
                new Hidden("9876", 400),
                new Hidden("4512", 600),
            };

            Dictionary<string, Hidden> keyValuePairs = new();

            foreach (Hidden hide in keyValuePairs.Values)
            {
                keyValuePairs.Add(hide.GetPin().ToString(), hide);
            }

            Auth.Auth[] auths = {
                new Auth.Auth(1, "John", "test"),
                new Auth.Auth(2, "Sarah", "test"),
                new Auth.Auth(3, "Mike", "test"),
            };

            Dictionary<int, Auth.Auth> authenticate = new();

            foreach (Auth.Auth auth in authenticate.Values)
            {
                authenticate.Add(auth.ID, auth);
            }

            Auth.Auth.CheckUser(hidden, atm, auths);
        }
    }
}
