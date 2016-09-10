using UnityEngine;
using System.Collections;

public abstract class  Bina : HaritaBirimi {
    public float değer;
    protected string[] seçenekler;
    protected string[] durumAdları;
    public string[] Seçenekler
    {
        get
        {
            BilgiPaneli.tıklandı = SeçenekSeçildi;
            return seçenekler;
        }
    }
    public string[] DurumAdları
    {
        get
        {
            return durumAdları;
        }
    }
    void SeçenekSeçildi(string verilenKomut)// Verilen komutlar burada işlenecek
    {
        if (verilenKomut== "İşe Başvur")
        {
            IşYeri geç = (IşYeri)this;
            geç.İşeBaşvur();
        }
        else if (verilenKomut=="Çalış")
        {
            IşYeri geç = (IşYeri)this;
            geç.ÇalışmayaBaşla();
        }
    }
}
