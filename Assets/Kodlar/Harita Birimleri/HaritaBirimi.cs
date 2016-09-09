using UnityEngine;
using System.Collections;

public abstract class HaritaBirimi : MonoBehaviour
{
    UnityEngine.UI.Image aktiviteTuşu;
    protected bool etkileşimAçık = false;
    public string isim;

    void Start()
    {
        aktiviteTuşu = GameObject.Find("E Tuşu").GetComponent<UnityEngine.UI.Image>();
    }
    void OnTriggerEnter(Collider obje)
    {
        if (obje.tag == "Oyuncu")
        {
            if (aktiviteTuşu==null)
            {
                aktiviteTuşu = GameObject.Find("E Tuşu").GetComponent<UnityEngine.UI.Image>();
            }
            aktiviteTuşu.enabled = etkileşimAçık = true;
        }
    }
    void OnTriggerExit(Collider obje)
    {
        if (obje.tag == "Oyuncu")
        {
            aktiviteTuşu.enabled = etkileşimAçık = false;
            BilgiPaneli.gösterim(false,this);
        }
    }
    void Update()
    {
        if (etkileşimAçık)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                BilgiPaneli.gösterim(true,this);
                aktiviteTuşu.enabled = etkileşimAçık = false;
                Debug.Log("Oldu");
            }
        }
    }
}
