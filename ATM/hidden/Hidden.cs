using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Hidden
{
    internal class Hidden
    {
        private readonly string pin;
        private readonly int amount;

        public Hidden(string pin, int amount)
        {
            this.pin = pin;
            this.amount = amount;
        }

        public string GetPin()
        {
            return pin;
        }

        public int GetAmount()
        {
            return amount;
        }
    }
}
