using UnityEngine;
using System.Collections;

public class IşYeri : Bina
{
    public float işSaatiBaşlangıç, işSaatiBitiş;
    public float işYeriİlişkisi = 50f;
    public bool işeGeldi = false;
    int çalışılanSaat;
    float günlükMaaş;
    [SerializeField]
    Para para;
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
            seçenekler = new string[] { "Çalış", "Ayrıl", "Satın Al" };
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
    public void ÇalışmayaBaşla()
    {
        if (Zaman.Saat >= işSaatiBaşlangıç - 1 && Zaman.Saat < işSaatiBitiş)
        {

            OyunHızAyarları.oyunHızlandır(false);
            işeGeldi = true;
        }
        else
        {
            UyarıMesaj.mesajGD("Çalışma saatlerinde gelin\n" + işSaatiBaşlangıç + " - " + işSaatiBitiş, 5);
        }
    }
    public void ÇalışmayıBitir() // Otomatik olarak saati geldiğinde çalışma bitecek
    {
        işeGeldi = false;
        günlükMaaş = çalışılanSaat * 15;
        Para.ParaBirim += günlükMaaş;
        // Çalışılan saate göre maaş hesaplanacak
        çalışılanSaat = 0;
        OyunHızAyarları.oyunNormalleştir(true);
    }
    public void İşeBaşvur() // Başvurunun kabul edilme şansı ve yetenekler burada kontrol edilecek
    {
        İşDurumu = İşDurum.Calışıyor;
    }
    void Start()
    {
        çalışılanSaat = 0;
        durumAdları = new string[] { "Çalışılınıyor", "Sahip", "Başvurulabilir" };
        Zaman.saatDeğişti += SaatKontrol;
        İşDurumKontrol();
    }
    void SaatKontrol() // İşe geç kalınıp kalınmadığı kontrol edilecek
    {
        if (işDurum == İşDurum.Calışıyor)
        {
            if (işeGeldi)
            {
                çalışılanSaat++;
                işYeriİlişkisi ++;
                işYeriİlişkisi = işYeriİlişkisi > 100 ? 100 : işYeriİlişkisi;
            }
            else if (Zaman.Saat >= işSaatiBaşlangıç && Zaman.Saat < işSaatiBitiş)
            {
                işYeriİlişkisi -= 10; // Eğer sıfıra düşerse kovulacak
            }
            if (Zaman.Saat > işSaatiBitiş - 1 && işeGeldi)
            {
                ÇalışmayıBitir();
            }
        }
    }
}
