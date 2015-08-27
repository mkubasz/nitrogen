using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup.TrainingOneHomeworks.Bolec.Interface
{
    public class TransferTransaction : TransferManager
    {
        public void Debit()
            // ta metoda tworzy słownik z numerami id banków, patrzy po autorze przelewu do jakiego banku przynależy, a następnie 
            // razem z uzyskanymi w ten sposob informacjami przesyla żądanie do klasy DelegateToBank. I tam dopiero odbywa się rozdelegowanie
            // żądania obciążenia rachunku do konkretnych banków, które robią to już według własnego uznania, ja zakodowałem tylko pko.
        {
            BanksHashtable();
            WhoIsTheSender();
            DelegateToBank DelegateToBank1 = new DelegateToBank();
            DelegateToBank1.Debit(senderAccountNo, amount, whichSenderBank);

        }
        public void Credit()
        {
            BanksHashtable();
            WhoIsTheReceiver();
            DelegateToBank DelegateToBank2 = new DelegateToBank();
            DelegateToBank2.Debit(senderAccountNo, amount, whichReceiverBank);
        }
    }
}
