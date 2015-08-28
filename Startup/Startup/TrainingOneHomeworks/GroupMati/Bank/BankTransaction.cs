using System.IO;
using System.Xml.Serialization;
using Startup.TrainingOneHomeworks.GroupMati.Bank.InterfaceBanks;

namespace Startup.TrainingOneHomeworks.GroupMati.Bank
{

    public abstract class BankTransaction : IBankTransaction
    {
        protected string BankName { get; private set; }
        public abstract void IncommingTransaction();
        public abstract void OutCommingTransaction();
       
        protected BankTransaction(string name)
        {
                BankName = name;
        }

        public virtual BankTransaction GetObject()
        {
            return this;
        }
        public virtual void DescriptionTransaction()
        {
            string path = @"\plik.xml";
            FileStream file = new FileStream( @"M:" + path, FileMode.Create);
            XmlSerializer xml = new XmlSerializer(typeof(ClientTransaction));
            xml.Serialize(file, new ClientTransaction() {IncomingNumber = "11111114234234",OutcomingNumber = "11111235325325"});
            file.Close();
        }
    }
}