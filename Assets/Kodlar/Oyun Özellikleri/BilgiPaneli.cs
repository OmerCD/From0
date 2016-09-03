using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BilgiPaneli : MonoBehaviour {
    public delegate void Göster(bool aktif,HaritaBirimi birim);
    public static Göster gösterim;
    public Text isimAlanı, durumAlanı, fiyatAlanı;
	void Start () {
        gösterim = new Göster(BilgiPanelGöster);
        Aktif = false;
	}
    void BilgiPanelGöster(bool aktiflik,HaritaBirimi birim)
    {
        if (!aktiflik)
        {
            Aktif = false;
            return;
        }
        if (birim is Bina)
        {
            if (birim is Ev) //Bina durum göstermi koyulmadı
            {
                Ev gösterilecekEv = (Ev)birim;
                isimAlanı.text = gösterilecekEv.isim;
                fiyatAlanı.text = gösterilecekEv.değer.ToString();
            }
        }
        Aktif=true;
    }
   public bool Aktif
    {
        set
        {
            gameObject.SetActive(value);
        }
        get
        {
            return gameObject.activeSelf;
        }
    }
}
