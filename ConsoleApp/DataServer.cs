using System.ServiceModel;
using DatabaseLib;

namespace ConsoleApp
{
    [ServiceBehavior(
        ConcurrencyMode = ConcurrencyMode.Multiple,
        UseSynchronizationContext = false)]
    internal class DataServer : DataServerInterface
    {
        private Library_Project.DatabaseClass db;
        public DataServer()
        {
            db = new Library_Project.DatabaseClass(100);
        }
        public int GetNumEntries()
        {
            return db.GetNumRecords();
        }
        public void GetValuesForEntry(
            int index,
            out uint acctNo,
            out uint pin,
            out int bal,
            out string fName,
            out string lName)
        {
            acctNo = db.GetAcctNoByIndex(index);
            pin = db.GetPinByIndex(index);
            bal = db.GetBalanceByIndex(index);
            fName = db.GetFirstNameByIndex(index);
            lName = db.GetLastNameByIndex(index);
        }
    }
}
