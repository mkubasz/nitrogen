using System;
using System.Collections.Generic;
using System.IO;

namespace Startup.TrainingOneHomeworks.Erloon
{
    public static class BamkList
    {
        public static List<Bank> ListAllBank => ImportListFromText();


        public static List<Bank> ImportListFromText()
        {
            var banks = new List<Bank>();

            foreach (var line in File.ReadAllLines(@"C:\Moje Pliki\Repozytoria\Szkolenia\PraireDog\one\Startup\Startup\TrainingOneHomeworks\Erloon\NbpList.txt"))
            {
                var columns = line.Split('\t');
                banks.Add(new Bank
                {
                    AppliedIdeniyfiers = columns[0],
                    BankName = columns[1],
                    InstytutinName = columns[2], //nazwa centrali
                    RangeIdInstitutions = columns[3], //zakres id instytucji
                    BranchBankId = columns[4],
                    BranchBankName = columns[5],
                    ShortBranchName = columns[6],
                    City = columns[7],
                    Street = columns[8],
                    PostalCode = columns[9],
                    Pob = columns[10],
                    AreaNumber = columns[11],
                    PhoneNumber1 = columns[12],
                    PhoneNumber2 = columns[13],
                    FaxNumber1 = columns[14],
                    FaxNumber2 = columns[15],
                    CreateDate = columns[16],
                    Bic = columns[16],
                    SepaBic = columns[17],
                    Website = columns[18],
                    Province = columns[19],
                    HomeCity = columns[20],
                    CorrespondenceCity = columns[21],
                    CorrespondenceStreet = columns[22],
                    CorrespondencePostalCode = columns[23],
                    CorrespondenceCity2 = columns[24],
                    unidentified1 = columns[25],
                    unidentified2 = columns[26],
                    unidentified3 = columns[27],
                    SortCode = columns[28]
                });
            }

            return banks;
        }
    }
}