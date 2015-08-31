using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banki.ClientClass;
using Banki.Interfaces;
using System.Numerics;

namespace Banki.Banks
{
    public abstract class Bank : IBanks
    {
        protected string name;
        protected int id;
        protected List<Transaction> history;
        protected List<Bank> banks;

        public virtual int getID()
        {
            return id;
        }

        public virtual string getName()
        {
            return name;
        }

        public abstract List<string> showHistory();

        public abstract bool Transfer(Transaction transfer);

        public abstract List<Transaction> getHistory();

        public virtual bool addTransactionToHistory(Transaction transaction)
        {
            if (transaction != null)
            {
                this.history.Add(transaction);
                return true;
            }
            else return false;
        }

        public virtual int getInstytutionId(string cardNumber)
        {
            return Convert.ToInt32(cardNumber.Substring(4, 4));
        }

        public virtual bool checkIfNumberIsCorrect(string cardNumber)
        {
            if (cardNumber.Length > 9)
            {
                string cardNumberType = (cardNumber.Length > 26 ? "IBAN" : "NRB");

                if (cardNumberType.Equals("NRB"))
                    cardNumber = "PL" + cardNumber;

                BigInteger test = new BigInteger();
                string sCopy = cardNumber.Substring(4, cardNumber.Length - 4) + cardNumber.Substring(0, 4);

                for (int a = 0; a <= sCopy.Length - 1; a++)
                {
                    if (sCopy[a] >= 'A' && sCopy[a] <= 'Z')
                        sCopy = sCopy.Replace(sCopy[a].ToString(), ((int)(sCopy[a]) - 55).ToString());
                    if (sCopy[a] >= 'a' && sCopy[a] <= 'z')
                        sCopy = sCopy.Replace(sCopy[a].ToString(), ((int)(sCopy[a]) - 87).ToString());
                }

                test = BigInteger.Parse(sCopy);

                test %= 97;
                return (test.ToString().Equals("1") ? true : false);
            }
            else return false;
        }

        public virtual Bank getBank(string cardNumber)
        {
            Bank ret = null;
            string cardNumberType;

            for (int a = 0; a <= banks.Count - 1; a++)
            {
                cardNumberType = (cardNumber.Length > 26 ? "IBAN" : "NRB");
                if (cardNumberType.Equals("NRB"))
                    cardNumber = "PL" + cardNumber;
                if (banks[a].getID() == getInstytutionId(cardNumber)) ret = banks[a];
            }

            return ret;
        }
    }
}
