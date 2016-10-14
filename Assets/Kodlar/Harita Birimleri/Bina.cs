using UnityEngine;
using System.Collections;

public abstract class  Bina : HaritaBirimi {
    public uint değer;
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
    abstract protected void SeçenekSeçildi(string verilenKomut);// Verilen komutlar burada işlenecek
}
