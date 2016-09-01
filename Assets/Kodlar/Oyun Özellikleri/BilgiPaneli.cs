using UnityEngine;
using System.Collections;

public class BilgiPaneli : MonoBehaviour {
    public delegate void Göster(bool aktif);
    public static Göster gösterim;
	// Use this for initialization
	void Start () {
        gösterim = new Göster((aktiflik)=>Aktif=aktiflik);
        gösterim(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   public bool Aktif // Panelin nasıl kapatılığ açılacağı yapılmadı
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
