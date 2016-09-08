using UnityEngine;
using System.Collections;
using System;

public class YetenekYönetim : MonoBehaviour
{
    Yetenekler oyuncuYetenekleri;
    public string[] yetenekAdları;
    public GameObject yetenekObjesi;
    public GameObject yeteneklerAlanı;
    public Transform yetenekEklenecekAlan;
    class Yetenekler
    {
        const int YETENEK_ZORLUK_KATSAYISI = 2;
        Yetenek[] sYetenekler;
        public Yetenekler(string[] yetenekAdları)
        {
            sYetenekler = new Yetenek[yetenekAdları.Length];
            for (int i = 0; i < yetenekAdları.Length; i++)
            {
                sYetenekler[i] = new Yetenek(yetenekAdları[i]);
            }
        }
        public void YetenekArttır(string yetenekAdı,float değer)
        {
            this[yetenekAdı].SeviyeArttır(YETENEK_ZORLUK_KATSAYISI, değer);
        }
        public void YetenekArttır(int yetenekSıra, float değer)
        {
           this[yetenekSıra].SeviyeArttır(YETENEK_ZORLUK_KATSAYISI, değer);
        }
        public Yetenek this[string yetenekAdı]
        {
            get
            {
                foreach (Yetenek item in sYetenekler)
                {
                    if (item.YetenekAdı==yetenekAdı)
                    {
                        return item;
                    }
                }
                return null;
            }
            set
            {
                for (int i = 0; i < sYetenekler.Length; i++)
                {
                    if (sYetenekler[i].YetenekAdı==yetenekAdı)
                    {
                        sYetenekler[i] = value;
                    }
                }
            }
        }
        public Yetenek this[int sıra]
        {
            get
            {
                if (sıra>-1 && sıra<sYetenekler.Length)
                {
                    return sYetenekler[sıra];
                }
                return null;
            }
            set
            {
                if (sıra > -1 && sıra < sYetenekler.Length)
                {
                    sYetenekler[sıra]=value;
                }
            }
        }
        public int Adet
        {
            get
            {
                return sYetenekler.Length;
            }
        }
    }
    class Yetenek
    {
        string yetenekAdı;
        float yetenekSeviyesi;
        public void SeviyeArttır(int zorlukKatSayısı,float değer)
        {
            yetenekSeviyesi += değer / (zorlukKatSayısı * (int)yetenekSeviyesi);
        }
        public Yetenek(string yetenekAdı)
        {
            this.yetenekAdı = yetenekAdı;
            yetenekSeviyesi = 0;
        }

        public Yetenek(string yetenekAdı, float yetenekSeviyesi)
        {
            this.yetenekAdı = yetenekAdı;
            this.yetenekSeviyesi = yetenekSeviyesi;
        }

        public string YetenekAdı
        {
            get
            {
                return yetenekAdı;
            }

            set
            {
                yetenekAdı = value;
            }
        }

        public float YetenekSeviyesi
        {
            get
            {
                return yetenekSeviyesi;
            }

            set
            {
                yetenekSeviyesi = value;
            }
        }
    }
    void Start()
    {
        Zaman.haftaDeğişti += HaftaDeğişimi;
        oyuncuYetenekleri = new Yetenekler(yetenekAdları);
    }
    void HaftaDeğişimi() //Çalışılmayan yetenekler her hafta geçtiğinde burada körertilebilir
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            YetenekleriGöster();
        }
    }

    private void YetenekleriGöster() // Yetenek Bilgi ekranı göstertilecek
    {
        yeteneklerAlanı.SetActive(!yeteneklerAlanı.activeSelf);
        if (!yeteneklerAlanı.activeSelf)
        {
            for (int i = 0; i < yetenekEklenecekAlan.childCount; i++)
            {
                Destroy(yetenekEklenecekAlan.GetChild(i).gameObject);
            }
            return;
        }
        for (int i = 0; i < oyuncuYetenekleri.Adet; i++)
        {
            GameObject geç = Instantiate(yetenekObjesi);
            geç.transform.parent = yetenekEklenecekAlan;
            geç.GetComponentInChildren<UnityEngine.UI.Text>().text = oyuncuYetenekleri[i].YetenekAdı + " - " + ((int)oyuncuYetenekleri[i].YetenekSeviyesi).ToString();
        }
    }
}
