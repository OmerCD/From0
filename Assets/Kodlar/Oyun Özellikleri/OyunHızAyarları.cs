using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class OyunHızAyarları : MonoBehaviour {
    public delegate void HızDeğişimi(bool değişimeİzinVer);
    public static HızDeğişimi oyunHızlandır, oyunNormalleştir, oyunDurdur;
    [SerializeField]
    Button durdur, normal, hızlandır;
    bool tuşAktifliği;
    void Start()
    {
        tuşAktifliği = true;
        normal.interactable = false;
        oyunDurdur = ZamanDurdur;
        oyunHızlandır = ZamanHızlandır;
        oyunNormalleştir = ZamanNormal;
    }
    void Update()
    {
        if (tuşAktifliği)
        {
            if (Input.GetKeyDown(KeyCode.BackQuote) || Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
            {
                ZamanDurdur(true);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                ZamanNormal(true);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                ZamanHızlandır(true);
            }
        }
    }
    void TuşlarıDeaktiveEt()
    {
        durdur.interactable = normal.interactable = hızlandır.interactable =tuşAktifliği= false;
    }
	public void ZamanDurdur(bool değişim)
    {
        Zaman.zamanHızKatSayısı = 0;
        Zaman.zamanDurdu();
        if (değişim)
        {
            durdur.interactable = false;
            normal.interactable = hızlandır.interactable = true;
            tuşAktifliği = true;
        }
        else
        {
            TuşlarıDeaktiveEt();
        }
    }
    public void ZamanNormal(bool değişim)
    {
        Zaman.zamanHızKatSayısı = 1;
        Zaman.zamanNormal();
        if(değişim){
            normal.interactable = false;
            durdur.interactable = hızlandır.interactable = true;
            tuşAktifliği = true;
        }
        else
        {
            TuşlarıDeaktiveEt();
        }
    }
    public void ZamanHızlandır(bool değişim)
    {
        Zaman.zamanHızKatSayısı = 100;
        Zaman.zamanHızlandı();
        if (değişim)
        {
            hızlandır.interactable = false;
            normal.interactable = durdur.interactable = true;
            tuşAktifliği = true;
        }
        else
        {
            TuşlarıDeaktiveEt();
        }
    }
}
