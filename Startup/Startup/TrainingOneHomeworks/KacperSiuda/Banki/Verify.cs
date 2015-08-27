using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup.TrainingOneHomeworks.KacperSiuda.Banki
{
    public class Verify
    {
        public int TotalBank = 2;
        
        public List<Bank> GenerateBankList()
        {
            List<Bank> bankList = new List<Bank>();
            
                Nbp bank1 = new Nbp("Narodowy Bank Polski", 1110);
                PkoBp bank2 = new PkoBp("PKO BP", 1120);

            bankList.Add(bank1);
            bankList.Add(bank2);


            return bankList;
        }

        public string VerifyBankName(List<Bank> listOfAllBank ,string creditCardNumber)
        {
            
            for (int i = 0; i < listOfAllBank.Count; i++)
            {
                
                if (creditCardNumber.Remove(4) == Convert.ToString(listOfAllBank[i].ReturnBankId())  )
                {
                  
                    return listOfAllBank[i].ReturnBankName();
                }
                else
                {
                    return "wrong card number";
                }
            }
            return "method fail";

        }
        


        




    }
}
