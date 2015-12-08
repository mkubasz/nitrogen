using RejestrFaktur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrFaktur.utils
{
    public class ObslugaJednostkiMiary
    {
        private Opakowanie<JednostkaMiary> opak;

        public ObslugaJednostkiMiary(Opakowanie<JednostkaMiary> opak)
        {
            this.opak = opak;
        }
   
        public void DoUsuniencia(int i, Stany stan)
        {
            if (stan == Stany.DO_USUNIECIA) opak.UstawDoUsuniecia(i);
        }

        public void DoEdycji(int i, Stany stan)
        {
            if (stan == Stany.DO_EDYCJI)  opak.UstawDoEdycji(i);
        }

        public void DoPodgladu (int i, Stany stan)
        {
           if (stan ==Stany.SZCZEGOLY) opak.UstawDoPodgladu(i);
        }

        public void Nowy(int i, Stany stan)
        {
            if (stan == Stany.NOWY) opak.UstawNowy();
        }


    }
}