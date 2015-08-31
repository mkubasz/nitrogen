using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLlib.SQL;
using Startup.TrainingOneHomeworks.GroupMati.Bank;
using Startup.TrainingOneHomeworks.GroupMati.Bank.GeneratorClass;
using Startup.TrainingOneHomeworks.GroupMati.Bank.Messages;

namespace Toci.Startup.Test.MatiUnitTest
{
    [TestClass]
    public class BankUnitTest
    {
        [TestMethod]
        public void CheckSearchAccount()
        {
            var transaction = new ClientTransaction();
            //  Assert.IsInstanceOfType(new AliorTransactionBank(), transaction.SearchAccount("1111").GetType());
            //     Assert.IsInstanceOfType(new BgzTransactionBank(), transaction.SearchAccount("1112").GetType());
        }

        [TestMethod]
        public void GetListTransactionIsNull()
        {
            var transaction = new ClientTransaction();
            //Assert.IsNull(transaction.GetTransactions());
            //   Assert.IsNull(transaction.GetTransactions()[1].GetType());
        }

        [TestMethod]
        public void GetListTransaction()
        {
            var transaction = new ClientTransaction();
            //  Assert.IsInstanceOfType(new AliorTransactionBank(), transaction.GetTransactions()[0].GetType());
            //  Assert.IsInstanceOfType(new BgzTransactionBank(), transaction.GetTransactions()[1].GetType());
        }

        [TestMethod]
        public void IsCreatedDocumentXml()
        {
            //  BankTransaction bank1 = new AliorTransactionBank();

            // bank1.DescriptionTransaction();
        }

        [TestMethod]
        public void CheckMailMessage()
        {
            MailMessages mail = new AliorMailMessages();
            mail.SendMail(BankMailEnum.Incomingtransfer, "adam.kuba21@gmail.com");
        }

        [TestMethod]
        public void GenerateClassCheck()
        {
            var generator = new GeneratorClass();
        }

        [TestMethod]
        public void CheckList()
        {
            var bank =
                new BankTransactionMenager(new ClientTransaction {IncomingNumber = "212", OutcomingNumber = "dsd"});
            bank.ClientTransactions.Add(new ClientTransaction {IncomingNumber = "222", OutcomingNumber = "535"});
        }

        [TestMethod]
        public void SqlMenagerCheck()
        {
            var menager = new SqlMenager();
        }

        [TestMethod]
        public void IsSearchBankTransaction()
        {
            var btm = new BankTransactionMenager(new ClientTransaction {IncomingNumber = "111", OutcomingNumber = "222"});
            BankTransaction bt;
            //  bt = btm.SearchAccount("36249010440000420057684506");
        }

        [TestMethod]
        public void CheckVerificationListOfClient()
        {
            var btm =
                new BankTransactionMenager(new ClientTransaction
                {
                    IncomingNumber = "36249010440000420057684506",
                    OutcomingNumber = "36249010440000420057684506"
                });
            btm.ClientTransactions.Add(new ClientTransaction {IncomingNumber = "222", OutcomingNumber = "535"});
            btm.ClientTransactions.Add(new ClientTransaction
            {
                IncomingNumber = "28203000451130000012129130",
                OutcomingNumber = "28203000451130000012129130"
            });
            btm.ClientTransactions.Add(new ClientTransaction
            {
                IncomingNumber = "28203000451130000012129130",
                OutcomingNumber = "535"
            });
            btm.ClientTransactions.Add(new ClientTransaction
            {
                IncomingNumber = "535",
                OutcomingNumber = "28203000451130000012129130"
            });
            btm.ClientTransactions.Add(new ClientTransaction
            {
                IncomingNumber = "28203000451130000012129130",
                OutcomingNumber = "36249010440000420057684506"
            });

            var listOfVeryfied = btm.VerifiedClientTransactions;
        }

        [TestMethod]
        public void CheckValidationNumber()
        {
            Assert.IsTrue(ValidationNumber.Validation("36249010440000420057684506"));
        }

        //}
        //    }
        //        //item.
        //    {

        //    foreach (var item in result)
        //    var result = Assembly.GetCallingAssembly().GetTypes().Where(item => item.IsSubclassOf(typeof (BankTransaction)));
        //{
        //protected List<BankTransaction> GetAllBankTransactions()
    }
}