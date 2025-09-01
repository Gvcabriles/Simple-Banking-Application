using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLib
{
    public class AccountGenerator
    {

        private static readonly Random Random = new Random();

        private string GetFirstName()
        {
            string[] firstNames = { "John", "Jane", "Alice", "Bob", "Charlie", "Diana", "Eve", "Frank", "Grace", "Hank" };
            return firstNames[Random.Next(firstNames.Length)];
        }

        private string GetLastName()
        {
            string [] lastNames = { "Doe", "Smith", "Johnson", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson" };
            return lastNames[Random.Next(lastNames.Length)];
        }

        private uint GetPIN()
        {
            return (uint)Random.Next(1000, 10000);
        }

        private uint GetAcctNo()
        {
            return (uint)Random.Next(10000000, 100000000);
        }

        private int GetBalance()
        {
            return Random.Next(0, 10001);
        }

        public void GetNextAccount(out uint pin, out uint acctNo, out string firstName, out string lastName, out int balance)
        {
            pin = GetPIN();
            acctNo = GetAcctNo();
            firstName = GetFirstName();
            lastName = GetLastName();
            balance = GetBalance();
        }
    }

    
}
   

