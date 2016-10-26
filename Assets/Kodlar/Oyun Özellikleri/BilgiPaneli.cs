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
    bool tuşGöster,panelGösterilecek;
    GameObject geçTuş;


    void Start () {
        gösterim = new Göster(BilgiPanelGöster);
        Aktif =panelGösterilecek= false;
        tuşGöster = true;
        Zaman.zamanHızlandı += ZamanDeğişti;
        Zaman.zamanDurdu += ZamanDeğişti;
        Zaman.zamanNormal += ZamanNormal;
	}
    void ZamanDeğişti()
    {
        panelGösterilecek = Aktif;
        Aktif = tuşGöster = Enerji.uyunuyor;
        Destroy(geçTuş);
    }
    void ZamanNormal()
    {
        tuşGöster = true;
        if (panelGösterilecek)
        {
            BilgiPanelGöster(true, referansBirimi);
        }
        panelGösterilecek = false;
    }
    void BilgiPanelGöster(bool aktiflik,HaritaBirimi birim)
    {
        if (tuşGöster)
        {
            referansBirimi = birim;
            if (!aktiflik)
            {
                Aktif = false;
                return;
            }

            if (birim is Bina)
            {
                TuşTemizle();
                isimAlanı.text = birim.isim;
                Bina geçBina = (Bina)birim;
                fiyatAlanı.text = geçBina.değer.ToString();

                for (int i = 0; i < geçBina.Seçenekler.Length; i++)
                {
                    geçTuş = Instantiate(tuş);
                    geçTuş.transform.SetParent(tuşAlanı);
                    geçTuş.GetComponentInChildren<Text>().text = geçBina.Seçenekler[i];
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

            Aktif = true;
        }
    }
    void TuşTemizle()
    {
        for (int i = 0; i < tuşAlanı.childCount; i++)
        {
            Destroy(tuşAlanı.GetChild(i).gameObject);
        }
    }
   public bool Aktif
    {
        set
        {
            gameObject.SetActive(value);
            if (!value)
            {
                TuşTemizle();
            }
        }
        get
        {
            return gameObject.activeSelf;
        }
    }
}
