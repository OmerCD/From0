using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Kodlar.Harita_Birimleri
{
    public class Apartman : Ev
    {
        public int kalanKişiSayısı,boşDaireSayısı,toplamDaireSayısı;

        protected override void SeçenekSeçildi(string verilenKomut)
        {
            throw new NotImplementedException();
        }
    }
}
