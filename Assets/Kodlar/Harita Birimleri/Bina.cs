using UnityEngine;
using System.Collections;

public abstract class  Bina : HaritaBirimi {
    public float değer;
    protected string[] seçenekler;

    public string[] Seçenekler
    {
        get
        {
            BilgiPaneli.tıklandı = SeçenekSeçildi;
            return seçenekler;
        }
    }
    void SeçenekSeçildi(string verilenKomut)
    {
        Debug.Log(verilenKomut); // Verilen komutlar burada işlenecek
    }
}
