using DatabaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Project
{
    public class DatabaseClass
    {
        List<DataStruct> dataStruct;

        public DatabaseClass(int numberOfRecords = 100)
        {
            dataStruct = new List<DataStruct>();

            AccountGenerator generator = new AccountGenerator();
            for (int i = 0; i < numberOfRecords; i++)
            {
                generator.GetNextAccount(
                    out uint pin,
                    out uint acctNo,
                    out string firstName,
                    out string lastName,
                    out int balance);
                var ds = new DataStruct
                {
                    acctNo = acctNo,
                    pin = pin,
                    firstName = firstName,
                    lastName = lastName,
                    balance = balance
                };

                dataStruct.Add(ds);
                
            }
        }

        public uint GetAcctNoByIndex(int index) => dataStruct[index].acctNo;
        public uint GetPinByIndex(int index) => dataStruct[index].pin;
        public string GetFirstNameByIndex(int index) => dataStruct[index].firstName;
        public string GetLastNameByIndex(int index) => dataStruct[index].lastName;
        public int GetBalanceByIndex(int index) => dataStruct[index].balance;
        public int GetNumRecords() => dataStruct.Count;
    }
}
