using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BilgiPaneli : MonoBehaviour {
    public delegate void Tıklama(string Komut);
    public static Tıklama tıklandı;
    public delegate void Göster(bool aktif,HaritaBirimi birim);
    public static Göster gösterim;
    public GameObject tuş;
    public Transform tuşAlanı;
    public Text isimAlanı, durumAlanı, fiyatAlanı;
    public static HaritaBirimi referansBirimi;
	void Start () {
        gösterim = new Göster(BilgiPanelGöster);
        Aktif = false;
	}
    void BilgiPanelGöster(bool aktiflik,HaritaBirimi birim)
    {
        referansBirimi = birim;
        if (!aktiflik)
        {
            Aktif = false;
            return;
        }
        if (birim is Bina)
        {
            isimAlanı.text = birim.isim;
            Bina geçBina = (Bina)birim;
            fiyatAlanı.text = geçBina.değer.ToString();

            for (int i = 0; i < geçBina.Seçenekler.Length; i++)
            {
                GameObject geç = Instantiate(tuş);
                geç.transform.SetParent(tuşAlanı);
                geç.GetComponentInChildren<Text>().text = geçBina.Seçenekler[i];
            }
            if (birim is Ev)
            {
                durumAlanı.text = geçBina.DurumAdları[(int)((Ev)birim).EvDurumu];
            }
            else if (birim is IşYeri)
            {
                durumAlanı.text = geçBina.DurumAdları[(int)((IşYeri)birim).İşDurumu];
            }
        }
        Aktif=true;
    }
   public bool Aktif
    {
        set
        {
            gameObject.SetActive(value);
            if (!value)
            {
                for (int i = 0; i < tuşAlanı.childCount; i++)
                {
                    Destroy(tuşAlanı.GetChild(i).gameObject);
                }
            }
        }
        get
        {
            return gameObject.activeSelf;
        }
    }
}
