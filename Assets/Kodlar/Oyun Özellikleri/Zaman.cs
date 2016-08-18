using UnityEngine;
using System.Collections;

public class Zaman : MonoBehaviour {
    public Transform ışık;
    const float katFarkı = 0.125f;
    float saat;
    float dakika;
    public UnityEngine.UI.Text saatGöstergesi;
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
	}
	
	// Update is called once per frame
	void Update () {
        dakika += Time.deltaTime;
        if (dakika>59)
        {
            dakika = 0;
            saat++;
            
            if (saat>=24)
            {
                saat = 0;
            }
            
        }
        string gösterilecekSaat = saat < 10 ? '0' + saat.ToString() + ':': saat.ToString() + ':';
        gösterilecekSaat += dakika < 10 ? '0' + dakika.ToString() : dakika.ToString();
        saatGöstergesi.text = gösterilecekSaat;
        ışık.rotation = Quaternion.Euler(((60 * saat + dakika) * katFarkı), 0, 0);
    }
}
