using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName = "Eşya", menuName = "Eşyalar/Eşya", order = 1)]
[System.Serializable]
public class Eşya:ScriptableObject {
    [SerializeField]
    string isim;
    [SerializeField]
    int iD;
    [SerializeField]
    string açıklama;
    [SerializeField]
    Texture2D ikon;
    [SerializeField]
    EşyaTürü tür;
    [SerializeField]
    int etkiGücü;
    [SerializeField]
    EtkiAlanı etkiliAlan;

    public string Isim
    {
        get
        {
            return isim;
        }

        set
        {
            isim = value;
        }
    }

    public int ID
    {
        get
        {
            return iD;
        }

        set
        {
            iD = value;
        }
    }

    public string Açıklama
    {
        get
        {
            return açıklama;
        }

        set
        {
            açıklama = value;
        }
    }

    public Texture2D Ikon
    {
        get
        {
            return ikon;
        }

        set
        {
            ikon = value;
        }
    }

    public EşyaTürü Tür
    {
        get
        {
            return tür;
        }

        set
        {
            tür = value;
        }
    }

    public int EtkiGücü
    {
        get
        {
            return etkiGücü;
        }

        set
        {
            etkiGücü = value;
        }
    }

    public EtkiAlanı EtkiliAlan
    {
        get
        {
            return etkiliAlan;
        }

        set
        {
            etkiliAlan = value;
        }
    }

    public Eşya(string isim, int iD, string açıklama, Texture2D ikon, EşyaTürü tür, int etkiGücü)
    {
        this.isim = isim;
        this.iD = iD;
        this.açıklama = açıklama;
        this.ikon = ikon;
        this.tür = tür;
        this.etkiGücü = etkiGücü;
    }

    public Eşya()
    {
    }

    public enum EşyaTürü
    {
        Kıyafet,
        Tüketilebilir
    }
    public enum EtkiAlanı
    {
        Yok,
        Sağlık,
        Enerji,
        Açlık
    }
}
