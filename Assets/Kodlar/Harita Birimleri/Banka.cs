using UnityEngine;
using System.Collections;

public class Banka : IşYeri {
    protected override void SeçenekSeçildi(string verilenKomut)
    {
        base.SeçenekSeçildi(verilenKomut);
        if (verilenKomut=="Banka İşlemleri")
        {
            seçenekler = new string[] { "Para Yatır", "Para Çek", "Kredi Al","Geri" };
        }
        else if (verilenKomut=="Geri")
        {
            İşDurumKontrol();
        }
    }
    protected override void İşDurumKontrol()
    {
        base.İşDurumKontrol();
        System.Array.Resize(ref seçenekler, seçenekler.Length + 1);
        seçenekler[seçenekler.Length - 1] = "Banka İşlemleri";
    }
}
