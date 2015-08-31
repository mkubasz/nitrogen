using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Banki.Banks;
using Banki.Interfaces;
using Banki.Transactions;

namespace Banki.ClientClass
{
    public class Client : IBanks
    {
        protected List<Bank> banks;
        protected List<Transaction> history;

        public Client()
        {
            banks = new List<Bank>();
            history = new List<Transaction>();

            banks.Add(new Bank_AliorBank(banks));
            banks.Add(new Bank_Bank_Pocztowy(banks));
            banks.Add(new Bank_BankMillennium(banks));
            banks.Add(new Bank_BGK(banks));
            banks.Add(new Bank_BGZ(banks));
            banks.Add(new Bank_BNP_ParibasFortis(banks));
            banks.Add(new Bank_Bos(banks));
            banks.Add(new Bank_BPH(banks));
            banks.Add(new Bank_BZ_WBK(banks));
            banks.Add(new Bank_CitybankHandlowy(banks));
            banks.Add(new Bank_CreditAgrecoleBankPolska(banks));
            banks.Add(new Bank_DeutscheBankPolska(banks));
            banks.Add(new Bank_DnB_Nord(banks));
            banks.Add(new Bank_EuroBank(banks));
            banks.Add(new Bank_FCE_BankPolska(banks));
            banks.Add(new Bank_FiatBankPolska(banks));
            banks.Add(new Bank_FM_BankPBP(banks));
            banks.Add(new Bank_GetinNobleBank(banks));
            banks.Add(new Bank_HSBC(banks));
            banks.Add(new Bank_IdeaBank(banks));
            banks.Add(new Bank_ING(banks));
            banks.Add(new Bank_mBank(banks));
            banks.Add(new Bank_MercedesBenzBankPolska(banks));
            banks.Add(new Bank_MeritumBank(banks));
            banks.Add(new Bank_NarOdowyBankPolski(banks));
            banks.Add(new Bank_NordeaBank(banks));
            banks.Add(new Bank_Pekao(banks));
            banks.Add(new Bank_PKO_BP(banks));
            banks.Add(new Bank_PlusBank(banks));
            banks.Add(new Bank_PlusBank(banks));
            banks.Add(new Bank_PolskiejSpoldzielczosci(banks));
            banks.Add(new Bank_RaiffeisenBank(banks));
            banks.Add(new Bank_RBS_BankPolska(banks));
            banks.Add(new Bank_RobobankPolska(banks));
            banks.Add(new Bank_SantanderConsumerBank(banks));
            banks.Add(new Bank_SGB_Bank(banks));
            banks.Add(new Bank_SocieteGenerale(banks));
            banks.Add(new Bank_ToyotaBank(banks));
            banks.Add(new Bank_ToyotaBank(banks));
            banks.Add(new Bank_VolkswagenBank(banks));
        }

        public bool payin(string sender, int amount)
        {
            sender = sender.Replace(" ", "");
            Bank bank = getBank(sender);
            if (bank != null)
            {
                Transaction transaction = new PayIn(sender, amount, bank);
                history.Add(transaction);
                if (!bank.Transfer(transaction)) return false;
                else return true;
            }
            else return false;
        }

        public bool payout(string receiver, int amount)
        {
            receiver = receiver.Replace(" ", "");
            Bank bank = getBank(receiver);
            if(bank!=null)
            {
                Transaction transaction = new PayOut(receiver, amount, bank);
                history.Add(transaction);
                if (!bank.Transfer(transaction)) return false;
                else return true;
            }
            else return false;
        }

        public bool transfer(string sender, string receiver, int amount)
        {
            sender = sender.Replace(" ", "");
            receiver = receiver.Replace(" ", "");
            Bank bank = getBank(sender);
            if(bank!=null)
            {
                Transaction transaction = new Transfer(sender, receiver, amount, bank);
                history.Add(transaction);
                if (!bank.Transfer(transaction)) return false;
                else return true;
            }
            else return false;
        }

        public List<string> showBankHistory(string cardNumber)
        {
            cardNumber = cardNumber.Replace(" ", "");
            List<string> ret = null;
            Bank bank = getBank(cardNumber);
            if(bank!=null)
            {
                ret = bank.showHistory();
            }
            return ret;
        }

        public List<string> showNumberHistory(string cardNumber)
        {
            cardNumber = cardNumber.Replace(" ", "");
            Bank bank = getBank(cardNumber);
            List<string> ret = new List<string>();
            if (bank != null)
            {
                ret.Add("----------------------");
                ret.Add("Client transaction history : ");
                foreach(var obj in history)
                {
                    if(obj.getSender().Equals(cardNumber) || obj.getReceiver().Equals(cardNumber))
                        ret.Add("Operation: " + obj.operationType + " From: " + obj.getSender() + " (Bank : " + obj.senderBankName + ")" + " To: " + obj.getReceiver() + " (Bank : " + obj.receiverBankName + ")" + " Amount: " + obj.getAmount());
                }
            }
            return ret;
        }

        public List<string> showAllHistory()
        {
            List<string> ret = new List<string>();
            ret.Add("----------------------");
            ret.Add("All transaction history : ");
            foreach(var obj in history)
            {
                ret.Add("Operation: " + obj.operationType + " From: " + obj.getSender() + " (Bank : " + obj.senderBankName + ")" + " To: " + obj.getReceiver() + " (Bank : " + obj.receiverBankName + ")" + " Amount: " + obj.getAmount());
            }
            return ret;
        }

        public string getBankName(string cardNumber)
        {
            Bank bank = getBank(cardNumber);
            if (bank != null)
            {
                return bank.getName();
            }
            else return "error";
        }

        public int getInstytutionId(string cardNumber)
        {
            return Convert.ToInt32(cardNumber.Substring(4, 4));
        }

        public bool checkIfNumberIsCorrect(string cardNumber)
        {
            cardNumber = cardNumber.Replace(" ", "");
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

        public Bank getBank(string cardNumber)
        {
            Bank ret = null;
            if(checkIfNumberIsCorrect(cardNumber))
            {
                string cardNumberType;

                for (int a = 0; a <= banks.Count - 1; a++)
                {
                    cardNumber = cardNumber.Replace(" ", "");
                    cardNumberType = (cardNumber.Length > 26 ? "IBAN" : "NRB");
                    if (cardNumberType.Equals("NRB"))
                        cardNumber = "PL" + cardNumber;
                    if (banks[a].getID() == getInstytutionId(cardNumber)) ret = banks[a];
                }
            }

            return ret;
        }
    }
}
