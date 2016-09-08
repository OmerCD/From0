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
            isimAlanı.text = birim.isim;
            fiyatAlanı.text = ((Bina)birim).değer.ToString();
            if (birim is Ev)
            {
                Ev gösterilecekEv = (Ev)birim;
                durumAlanı.text = gösterilecekEv.durumAdları[(int)gösterilecekEv.evDurumu];
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
