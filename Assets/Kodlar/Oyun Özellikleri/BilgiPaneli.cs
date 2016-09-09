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
                durumAlanı.text = gösterilecekEv.DurumAdları[(int)gösterilecekEv.evDurumu];
                for (int i = 0; i < gösterilecekEv.Seçenekler.Length; i++)
                {
                    GameObject geç = Instantiate(tuş);
                    geç.transform.SetParent(tuşAlanı);
                    geç.GetComponentInChildren<Text>().text = gösterilecekEv.Seçenekler[i];
                }
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
