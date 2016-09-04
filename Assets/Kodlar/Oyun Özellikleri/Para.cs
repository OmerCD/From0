using System.Collections.Generic;
using UnityEngine;
public class Para : MonoBehaviour
{
    private float para;
    public UnityEngine.UI.Text paraGöstergesi,giderGöstergesi,gelirGöstergesi;
    public Dictionary<string, float> giderler, gelirler;
    void Awake()
    {
        giderler = new Dictionary<string, float>();
        gelirler = new Dictionary<string, float>();
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
    #endregion
    public float ParaBirim
    {
        get
        {
            return para;
        }

        set
        {
            para = value;
            ParaGöster(para,paraGöstergesi);
        }
    }
    void ParaGöster(float yeniPara, UnityEngine.UI.Text paraYazı)
    {
        paraYazı.text = yeniPara.ToString();
    }
}
