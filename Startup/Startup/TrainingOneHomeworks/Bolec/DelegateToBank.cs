using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Startup.TrainingOneHomeworks.Bolec.Interface;

namespace Startup.TrainingOneHomeworks.Bolec
{
    class DelegateToBank : TransferTransaction
    {
        public void Debit(string senderAccountNo, int amount, string whichSenderBank)
        {
            // klasa odpowiada za wydelegowanie żądania obciążenia/uznania do właściwego banku
            // to chciałem zrobić refleksyjnie, tj. przekształcając nazwę stringa whichSenderBank na nazwę metody do uruchomienia, ale to zbyt trudne.
            // Pozwoliłoby to na uniknięcie tylu potencjalnych ifów pod spodem
            if (whichSenderBank == "PKO BP S.A.")
            {
                PKObp PKObp1 = new PKObp();
                PKObp1.PKObp_Debit(senderAccountNo, amount);
            }
        }

        public void Credit(string receiverAccountNo, int amount, string whichReceiverBank)
        {
            if (whichReceiverBank == "PKO BP S.A.")
            {
                PKObp PKObp2 = new PKObp();
                PKObp2.PKObp_Credit(receiverAccountNo, amount);
            }
        }
    }
}
