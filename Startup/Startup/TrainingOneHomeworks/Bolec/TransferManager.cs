using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Startup.TrainingOneHomeworks.Bolec.Interface
{
    public class TransferManager : TransferInfo
    {

        // tworzy oraz zwraca dla kolejnych metod słownik z z numerami ident. oraz nazwami banków w parach klucz, wartość
        public string whichSenderBank = String.Empty;
        public string whichReceiverBank = String.Empty;
        public Hashtable bankslistHashtable = new Hashtable();
        public Hashtable BanksHashtable()
        {
            Hashtable bankslistHashtable = new Hashtable();
            bankslistHashtable.Add(101, "Narodowy Bank Polski");
            bankslistHashtable.Add(102, "PKO BP S.A.");
            return bankslistHashtable;
        }

        // rozpoznaje i zwraca wyjątek lub nazwę banku nadawcy
        public string WhoIsTheSender()
        {
            string bankidentificationNo = senderAccountNo.Substring(2, 4);
            bool bankName = bankslistHashtable.ContainsValue(bankidentificationNo); 
            if (bankName == false)
            {
                throw new ArgumentException("Nieznany numer identyfikacyjny banku");
            }
            else
            {
                string whichSenderBank = bankslistHashtable[senderAccountNo].ToString();
                return whichSenderBank;
            }
        }
        // rozpoznaje i zwraca wyjątek lub nazwę banku odbiorcy
        public string WhoIsTheReceiver()
        {
            string bankidentificationNo = receiverAccountNo.Substring(2, 4);
            bool bankName = bankslistHashtable.ContainsValue(bankidentificationNo);
            if (bankName == false)
            {
                throw new ArgumentException("Nieznany numer identyfikacyjny banku");
            }
            else
            {
                string whichReceiverBank = bankslistHashtable[receiverAccountNo].ToString();
                return whichReceiverBank;
            }
        }
}
}
