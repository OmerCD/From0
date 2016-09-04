using UnityEngine;
using System.Collections;
using System;

public class Zaman : MonoBehaviour {
    public Transform ışık;
    const float katFarkı = 0.125f;
    float saat;
    float dakika;
    public UnityEngine.UI.Text saatGöstergesi,tarihGöstergesi;
    DateTime tarih;
    public float Saat
    {
        get { return saat; }
    }
    public float Dakika
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
        saat = 0;
        dakika = 0;
        tarih = DateTime.Parse("01.01.2015");
        tarihGöstergesi.text = "01.01.2015";
    }
	
	// Update is called once per frame
	void Update () {
        dakika += Time.deltaTime*150;
        if (dakika>59)
        {
            dakika = 0;
            saat++;
            
            if (saat>=24)
            {
                saat = 0;
                tarih=tarih.AddDays(1);
                tarihGöstergesi.text = tarih.ToString("dd.MM.yyyy");
            }
            
        }
        //string gösterilecekSaat = saat < 10 ? '0' + saat.ToString() + ':': saat.ToString() + ':';
        //gösterilecekSaat += dakika < 10 ? '0' + dakika.ToString() : dakika.ToString();
        saatGöstergesi.text = saat.ToString("00")+':'+dakika.ToString("00");
        ışık.rotation = Quaternion.Euler(((60 * saat + dakika) * katFarkı), 0, 0);
    }
}
