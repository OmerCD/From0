using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class OyunHızAyarları : MonoBehaviour {
    [SerializeField]
    Button durdur, normal, hızlandır;
    void Start()
    {
        normal.interactable = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote)||Input.GetKeyDown(KeyCode.Alpha0) ||Input.GetKeyDown(KeyCode.Keypad0))
        {
            ZamanDurdur();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            ZamanNormal();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            ZamanHızlandır();
        }
    }
	public void ZamanDurdur()
    {
        Zaman.zamanHızKatSayısı = 0;
        Zaman.zamanDurdu();
        durdur.interactable = false;
        normal.interactable = hızlandır.interactable = true;
    }
    public void ZamanNormal()
    {
        Zaman.zamanHızKatSayısı = 1;
        Zaman.zamanNormal();
        normal.interactable = false;
        durdur.interactable = hızlandır.interactable = true;
    }
    public void ZamanHızlandır()
    {
        Zaman.zamanHızKatSayısı = 100;
        Zaman.zamanHızlandı();
        hızlandır.interactable = false;
        normal.interactable = durdur.interactable = true;
    }
}
