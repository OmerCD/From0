using UnityEngine;
using System.Collections;

public abstract class Ev : Bina {
    public Durum evDurumu;
    string[] durumAdları = new string[] { "Kiracı", "Sahip", "Yok" };
    public enum Durum
    {
        Kiracı,
        Sahip,
        Yok
    }
    public int metreKare;
    public float haftalıkÜcret,satınAlmaÜcreti;
    void Start()
    {
        if (evDurumu==Durum.Kiracı)
        {
            seçenekler = new string[] { "Kal", "Satın Al", "Evden Çık" };
        }
        else if (evDurumu==Durum.Sahip)
        {
            seçenekler = new string[] { "Kal", "Kiraya Ver", "Sat" };
        }
        else
        {
            seçenekler = new string[] { "Kirala", "Satın Al" };
        }
    }
    public string[] DurumAdları
    {
        get
        {
            return durumAdları;
        }
    }

}
