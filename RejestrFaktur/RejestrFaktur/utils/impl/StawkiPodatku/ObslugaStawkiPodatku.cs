using RejestrFaktur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrFaktur.utils
{
    public class ObslugaStawkiPodatku
    {
        private Opakowanie<StawkaPodatku> opak;

        public ObslugaStawkiPodatku(Opakowanie<StawkaPodatku> opak)
        {
            this.opak = opak;
        }

        public void DoUsuniencia(int i, Stany stan)
        {
            if (stan == Stany.DO_USUNIECIA) opak.UstawDoUsuniecia(i);
        }

        public void DoEdycji(int i, Stany stan)
        {
            if (stan == Stany.DO_EDYCJI) opak.UstawDoEdycji(i);
        }

        public void DoPodgladu(int i, Stany stan)
        {
            if (stan == Stany.SZCZEGOLY) opak.UstawDoPodgladu(i);
        }

        public void Nowy(int i, Stany stan)
        {
            if (stan == Stany.NOWY) opak.UstawNowy();
        }
    }
}