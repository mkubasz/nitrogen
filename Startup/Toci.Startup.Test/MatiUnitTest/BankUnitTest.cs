using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLlib.SQL;
using Startup.TrainingOneHomeworks.GroupMati.Bank.Factory;
using Startup.TrainingOneHomeworks.GroupMati.Banks;
using Startup.TrainingOneHomeworks.Mati;
using Startup.TrainingOneHomeworks.Mati.Banks;
using Startup.TrainingOneHomeworks.Mati.GeneratorClass;
using Startup.TrainingOneHomeworks.Mati.Messages;


namespace Toci.Startup.Test.MatiUnitTest
    {
        [TestClass]
        public class BankUnitTest
        {
            [TestMethod]
            public void CheckSearchAccount()
            {
                ClientTransaction transaction = new ClientTransaction();
                //  Assert.IsInstanceOfType(new AliorTransactionBank(), transaction.SearchAccount("1111").GetType());
                //     Assert.IsInstanceOfType(new BgzTransactionBank(), transaction.SearchAccount("1112").GetType());
            }
            [TestMethod]
            public void GetListTransactionIsNull()
            {
                ClientTransaction transaction = new ClientTransaction();
                Assert.IsNull(transaction.GetTransactions());
                //   Assert.IsNull(transaction.GetTransactions()[1].GetType());
            }
            [TestMethod]
            public void GetListTransaction()
            {
                ClientTransaction transaction = new ClientTransaction();
                Assert.IsInstanceOfType(new AliorTransactionBank(), transaction.GetTransactions()[0].GetType());
                //  Assert.IsInstanceOfType(new BgzTransactionBank(), transaction.GetTransactions()[1].GetType());
            }

            [TestMethod]
            public void IsCreatedDocumentXml()
            {
                BankTransaction bank1 = new AliorTransactionBank();

                bank1.DescriptionTransaction();
            }

            [TestMethod]
            public void CheckTransactionInstant()
            {
            FactoryBankTransaction<BankTransaction> factory1 = new FactoryBankTransaction<BankTransaction>();
                  
            }
            [TestMethod]
            public void CheckMailMessage()
            {
                MailMessages mail = new AliorMailMessages();
                mail.SendMail(BankMailEnum.INCOMINGTRANSFER, "adam.kuba21@gmail.com");
            }

            [TestMethod]
            public void GenerateClassCheck()
            {
                GeneratorClass generator = new GeneratorClass();

            }

        [TestMethod]
        public void SQLExampleTable()
        {
            SqlMenager menager = new SqlMenager();

        }

        [TestMethod]
        public void SqlMenagerCheck()
        {
            SqlMenager menager = new SqlMenager();
            
        }
        [TestMethod]
            public void CheckValidationNumber()
            {
                Assert.IsTrue(ValidationNumber.Validation("36249010440000420057684506"));
            }
              //protected List<BankTransaction> GetAllBankTransactions()
              //{
              //    var result = Assembly.GetCallingAssembly().GetTypes().Where(item => item.IsSubclassOf(typeof (BankTransaction)));

              //    foreach (var item in result)
              //    {
              //        //item.
              //    }
              //}
        }
    }



