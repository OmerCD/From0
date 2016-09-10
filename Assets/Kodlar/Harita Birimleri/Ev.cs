using UnityEngine;
using System.Collections;

public abstract class Ev : Bina {
    private Durum evDurumu;

    public enum Durum
    {
        Kiracı,
        Sahip,
        Yok
    }
    public int metreKare;
    public float haftalıkÜcret,satınAlmaÜcreti;
    void DurumKontrol()
    {
        if (EvDurumu == Durum.Kiracı)
        {
            seçenekler = new string[] { "Kal", "Satın Al", "Evden Çık" };
        }
        else if (EvDurumu == Durum.Sahip)
        {
            seçenekler = new string[] { "Kal", "Kiraya Ver", "Sat" };
        }
        else
        {
            seçenekler = new string[] { "Kirala", "Satın Al" };
        }
    }
    void Start()
    {
        durumAdları = new string[] { "Kiracı", "Sahip", "Yok" };
        DurumKontrol();
    }


    public Durum EvDurumu
    {
        get
        {
            return evDurumu;
        }

        set
        {
            evDurumu = value;
            DurumKontrol();
        }
    }
}
