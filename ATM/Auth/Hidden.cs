using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Auth
{
    internal class Hidden
    {
        private readonly string pin;
        private readonly int amount;

        public string Pin { get => pin; }
        public int Amount { get => amount; }

        public Hidden(string pin, int amount)
        {
            this.pin = pin;
            this.amount = amount;
        }

        public string GetPin()
        {
            return Pin;
        }

        public int GetAmount()
        {
            return Amount;
        }
    }
}
