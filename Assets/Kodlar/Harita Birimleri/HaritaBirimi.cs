using UnityEngine;
using System.Collections;

public abstract class HaritaBirimi : MonoBehaviour {
    public UnityEngine.UI.Image aktiviteTuşu;
    protected bool etkileşimAçık = false;
    void OnTriggerEnter(Collider obje)
    {if(obje.tag=="Oyuncu")
        aktiviteTuşu.enabled = etkileşimAçık=true;
    }
    void OnTriggerExit(Collider obje)
    {
        if (obje.tag == "Oyuncu")
        aktiviteTuşu.enabled = etkileşimAçık= false;
    }
    void Update()
    {
        if (etkileşimAçık)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Oldu");
            }
        }
    }
}
