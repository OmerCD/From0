using UnityEngine;
using System.Collections;
using System;

public class Zaman : MonoBehaviour {
    public delegate void TarihDeğişimi();
    public static TarihDeğişimi günDeğişti,haftaDeğişti,saatDeğişti;
    public Transform ışık;
    const float katFarkı = 0.125f;
    static float saat;
    static float dakika;
    public UnityEngine.UI.Text saatGöstergesi,tarihGöstergesi;
    byte yediGünKontrol = 1;
    DateTime tarih;
    public static float Saat
    {
        get { return saat; }
    }
    public static float Dakika
    {
        get { return dakika; }
    }
    public void SüreEkle(float eklenecekDakika)
    {
        saat += eklenecekDakika / 60;
        dakika += eklenecekDakika % 60;
    }
	// Use this for initialization
	void Start () {
        günDeğişti = new TarihDeğişimi(GünDeğişimi);
        saat = 0;
        dakika = 0;
        tarih = DateTime.Parse("01.01.2015");
        tarihGöstergesi.text = "01.01.2015";
    }
	void GünDeğişimi()
    {
        yediGünKontrol++;
        if (yediGünKontrol == 7)
        {
            haftaDeğişti();
            yediGünKontrol = 1;
        }
        saat = 0;
        tarih = tarih.AddDays(1);
        tarihGöstergesi.text = tarih.ToString("dd.MM.yyyy");
    }
	// Update is called once per frame
	void Update () {
        dakika += Time.deltaTime*50;
        if (dakika>59)
        {
            dakika = 0;
            saat++;
            saatDeğişti();
            if (saat>=24)
            {
                günDeğişti();
                
            }
        }
        saatGöstergesi.text = saat.ToString("00")+':'+dakika.ToString("00");
        ışık.rotation = Quaternion.Euler(((60 * saat + dakika) * katFarkı), 0, 0);
    }
}
