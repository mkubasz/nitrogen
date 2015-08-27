using System;
using System.IO;

namespace Startup.TrainingOneHomeworks.Mati.GeneratorClass
{
    //using System;
    //using Startup.TrainingOneHomeworks.Mati;

    //namespace Startup.TrainingOneHomeworks.GroupMati.Banks
    //{
    //    public sealed class AliorTransactionBank : BankTransaction
    //    {
    //        public AliorTransactionBank() : base("Alior Bank")
    //        {

    //        }

    //        public void DescriptionTransaction()
    //        {
    //            base.DescriptionTransaction();
    //        }

    //        public string GetBankName(string name)
    //        {
    //            return BankName;
    //        }
    //        public override void IncommingTransaction()
    //        {
    //            throw new NotImplementedException();
    //        }

    //        public override void OutCommingTransaction()
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }
    //}
    public class GeneratorClass : IGeneratorClass
    {
        string[] templateClass = new string[]
        {
            "using System;\n",
            "using Startup.TrainingOneHomeworks.Mati;\n" ,
            "namespace Startup.TrainingOneHomeworks.GroupMati.Banks\n" ,
            "{ \n" ,
            "public sealed class {0}TransactionBank : BankTransaction\n" ,
            "{\n" ,
            "public {0}TransactionBank() : base(\"{0} Bank\")\n" ,
            "{ \n" ,
            "} \n" ,
            "public void DescriptionTransaction()\n" ,
            "{\n" ,
            "base.DescriptionTransaction();\n" ,
            "}\n" ,
            "public string GetBankName(string name)\n" ,
            "{\n" ,
            "return BankName;\n" ,
            "}\n" ,
            "public override void IncommingTransaction()\n" ,
            "{\n" ,
            "throw new NotImplementedException();\n" ,
            "}\n" ,
            "public override void OutCommingTransaction()\n" ,
            "{\n" ,
            "throw new NotImplementedException();\n" ,
            "}\n}\n}"
        };
        public GeneratorClass()
        {
            CreateClass();
        }

        public void CreateClass()
        {
            StreamWriter file = new StreamWriter("Generator.cs");
            foreach (var item in templateClass)
            {
                file.WriteLine(string.Format(item, "Alior"));
            }
            
            
            file.Close();

        }

    }
}