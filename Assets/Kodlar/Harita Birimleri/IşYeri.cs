using UnityEngine;
using System.Collections;

public class IşYeri : Bina {
    public enum İşDurum
    {
        Calışıyor,
        Sahip,
        Yok
    }
    [SerializeField]
    İşDurum işDurum;

    public İşDurum İşDurumu
    {
        get
        {
            return işDurum;
        }

        set
        {
            işDurum = value;
            İşDurumKontrol();
        }
    }
    void İşDurumKontrol()
    {
        if (İşDurumu == İşDurum.Calışıyor)
        {
            seçenekler = new string[] { "Ayrıl", "Satın Al" };
        }
        else if (İşDurumu == İşDurum.Sahip)
        {
            seçenekler = new string[] { "Kiraya Ver", "Sat" };
        }
        else if (İşDurumu == İşDurum.Yok)
        {
            seçenekler = new string[] { "İşe Başvur", "Satın Al" };
        }
    }

    void Start()
    {
        durumAdları = new string[] { "Çalışılınıyor", "Sahip", "Başvurulabilir" };
        İşDurumKontrol();
    }
}
