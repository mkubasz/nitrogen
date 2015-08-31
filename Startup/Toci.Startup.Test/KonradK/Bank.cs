using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci
{
    public abstract class Bank
    {
        public string fstrClientNumber;
        public static string fstrNumber;
        public Bank()
        {

        }
        public Bank(string fstrClientNumber)
        {
            this.fstrClientNumber = fstrClientNumber;
        }
        public bool transaction(Bank reciver, int fintDolars)
        {
            Console.WriteLine("Begin transaction from " + this.ToString() + " to " + reciver.ToString());

            if (this.WebSendingTransaction(reciver, fintDolars) && reciver.WebRecivingTransaction(this, fintDolars))
            {
                Console.WriteLine("Transaction completed!");
                return true;
            }
            else
            {
                this.WebrollBack();
                reciver.WebrollBack();
                return false;
            }
        }

        private void WebrollBack()
        {
            try
            {
                Console.WriteLine("Transaction rollback!");
            }
            catch (Exception)
            {
                this.WebrollBack();
            }
        }

        public abstract bool WebSendingTransaction(Bank reciver, int fintDolars);
        public abstract bool WebRecivingTransaction(Bank sender, int fintDolars);
        public abstract int saldo();

        public override string ToString()
        {
            return base.ToString().Substring(5);
        }
    }
    public class NarodowyBankPolski : Bank
    {
        public static int Number = 1010;
        
        public NarodowyBankPolski(string fstrClientNumber) :base(fstrClientNumber)
        {
          
        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class PKOBP : Bank
    {
        public PKOBP(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class CitybankHandlowy : Bank
    {
        public CitybankHandlowy(string fstrClientNumber) :base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class ING : Bank
    {
        public ING(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class BPH : Bank
    {
        public BPH(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class BZWBK : Bank
    {
        public BZWBK(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class BGK : Bank
    {
        public BGK(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class mBank : Bank
    {
        public mBank(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class BankMillennium : Bank
    {
        public BankMillennium(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class Pekao : Bank
    {
        public Pekao(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class HSBC : Bank
    {
        public HSBC(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class MeritumBank : Bank
    {
        public MeritumBank(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class BankPocztowy : Bank
    {
        public BankPocztowy(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class NordeaBank : Bank
    {
        public NordeaBank(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class EuroBank : Bank
    {
        public EuroBank(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class BOŚ : Bank
    {
        public BOŚ(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class MercedesBenzBankPolska : Bank
    {
        public MercedesBenzBankPolska(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class BNPParibasFortis : Bank
    {
        public BNPParibasFortis(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class SGBBank : Bank
    {
        public SGBBank(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class RBSBank : Bank
    {
        public RBSBank(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class PlusBank : Bank
    {
        public PlusBank(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class RaiffeisenBank : Bank
    {
        public RaiffeisenBank(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class SocieteGenerale : Bank
    {
        public SocieteGenerale(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class FMBankPBP : Bank
    {
        public FMBankPBP(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class DeutscheBankPolska : Bank
    {

        public DeutscheBankPolska(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class BankPolskiejSpółdzielczości : Bank
    {
        public BankPolskiejSpółdzielczości(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class CreditAgricoleBankPolska : Bank
    {
        public CreditAgricoleBankPolska(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class IdeaBank : Bank
    {
        public IdeaBank(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class RabobankPolska : Bank
    {
        public RabobankPolska(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class BGŻ : Bank
    {
        public BGŻ(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class FCEBankPolska : Bank
    {
        public FCEBankPolska(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class SantanderConsumerBank : Bank
    {
        public SantanderConsumerBank(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class VolkswagenBank : Bank
    {
        public VolkswagenBank(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class ToyotaBank : Bank
    {
        public ToyotaBank(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class DnBNord : Bank
    {
        public DnBNord(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class GetinNobleBank : Bank
    {
        public GetinNobleBank(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }
    public class AliorBank : Bank
    {
        public AliorBank(string fstrClientNumber) : base(fstrClientNumber)
        {

        }

        public override int saldo()
        {
            throw new NotImplementedException();
        }

        public override bool WebRecivingTransaction(Bank sender, int fintDolars)
        {
            throw new NotImplementedException();
        }

        public override bool WebSendingTransaction(Bank reciver, int fintDolars)
        {
            throw new NotImplementedException();
        }
    }

}
