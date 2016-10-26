using UnityEngine;
using System.Collections;

public abstract class Ev : Bina {
    [SerializeField]
    private Durum evDurumu;
    public enum Durum
    {
        Kiracı,
        Sahip,
        Yok
    }
    public int metreKare;
    public float haftalıkÜcret,satınAlmaÜcreti;
    Enerji enerji;
    protected void DurumKontrol()
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
    protected void UykuModu()
    {
        Enerji.uyunuyor = true;
        OyunHızAyarları.oyunHızlandır(true);

        Zaman.saatDeğişti += UykuKontrol;
        enerji = GameObject.Find("Oyuncu Enerji Sistemleri").GetComponent<Enerji>();
    }
    void UykuKontrol()
    {
        
        if (enerji.Değer>=enerji.MaksimumDeğer)
        {
            UykudanÇık();
        }
    }
    protected void UykudanÇık()
    {
        DurumKontrol();
        OyunHızAyarları.oyunNormalleştir(true);
        Enerji.uyunuyor = false;
        Zaman.saatDeğişti -= UykuKontrol;
        enerji= null;

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
