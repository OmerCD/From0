using System;
using System.Collections.Generic;
using UnityEngine;
public class Para : MonoBehaviour
{
    private static float para;
    delegate void ParaDeğişimi();
    static ParaDeğişimi paraDeğişti;
    [SerializeField]
    UnityEngine.UI.Text paraGöstergesi;
    [SerializeField]
    GameObject gelirGiderTablosu;
    bool tabloGöster;
    public Dictionary<string, float> giderler, gelirler;
    void Awake()
    {
        tabloGöster = false;
        Zaman.haftaDeğişti += HaftaDeğişimi;
        Zaman.günDeğişti += GünDeğişimi;
        giderler = new Dictionary<string, float>();
        gelirler = new Dictionary<string, float>();
        paraDeğişti = ParaGöster;
    }
    #region Gelir - Gider Hesapları
    public void GiderEkle(string giderAdı,float ücret)
    {
        giderler.Add(giderAdı, ücret);
    }
    public void GelirEkle(string gelirlerAdı, float ücret)
    {
        gelirler.Add(gelirlerAdı, ücret);
    }
    public bool GiderKontrol(string giderAdı)
    {
        return giderler.ContainsKey(giderAdı);
    }
    public bool GelirKontrol(string gelirlerAdı)
    {
        return gelirler.ContainsKey(gelirlerAdı);
    }
    public void GiderÇıkar(string giderAdı)
    {
        giderler.Remove(giderAdı);
    }
    public void GelirÇıkar(string gelirAdı)
    {
        gelirler.Remove(gelirAdı);
    }
    public float GiderAl(string giderAdı)
    {
        return giderler[giderAdı];
    }
    public float GelirAl(string gelirAdı)
    {
        return gelirler[gelirAdı];
    }
    public float ToplamGider
    {
        get
        {
            float toplamGider = 0;
            foreach (KeyValuePair<string,float> item in giderler)
            {
                toplamGider += item.Value;
            }
            return toplamGider;
        }
    }
    public float ToplamGelir
    {
        get
        {
            float toplamGelir = 0;
            foreach (KeyValuePair<string, float> item in gelirler)
            {
                toplamGelir += item.Value;
            }
            return toplamGelir;
        }
    }
    #endregion
    public static float ParaBirim
    {
        get
        {
            return para;
        }

        set
        {
            para = value;
            paraDeğişti();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            tabloGöster = !tabloGöster;
            GelirGiderTabloGöster(tabloGöster);
        }
    }

    private void GelirGiderTabloGöster(bool gösterim)
    {
        gelirGiderTablosu.SetActive(gösterim);
        if (!gösterim) return;
        string gösterilecekYazı = "<color=#FA6669>\nGiderler</color>\n\n";
        List<string> giderListesi = new List<string>(giderler.Keys);
        List<string> gelirListesi = new List<string>(gelirler.Keys);
        float netPara = 0;
        for (int i = 0; i < giderler.Count; i++)
        {
            float geçPara = giderler[giderListesi[i]];
            netPara -= geçPara;
            gösterilecekYazı += giderListesi[i] + " : -" + geçPara+"\n";
        }
        gösterilecekYazı += "\n\n<color=#5EFF5E>Gelirler</color>\n\n";
        for (int i = 0; i < gelirler.Count; i++)
        {
            float geçPara = gelirler[gelirListesi[i]];
            netPara += geçPara;
            gösterilecekYazı += gelirListesi[i] + " : +" + geçPara + "\n";
        }
        gösterilecekYazı += "\n<color=#F3FF0A>Net</color> : ";
        if (netPara > 0) gösterilecekYazı += '+';
        gösterilecekYazı += netPara;
        gelirGiderTablosu.GetComponentInChildren<UnityEngine.UI.Text>().text = gösterilecekYazı;
    }

    void ParaGöster()
    {
        paraGöstergesi.text = para.ToString();
    }
    void HaftaDeğişimi() // Haftalık gelir - gider hesapları burada olacak
    {
        ParaBirim += ToplamGelir - ToplamGider;
    }
    void GünDeğişimi()// Günlük gelir - gider hesapları burada olacak
    {

    }
}
