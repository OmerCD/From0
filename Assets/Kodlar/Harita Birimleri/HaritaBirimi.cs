using UnityEngine;
using System.Collections;

public abstract class HaritaBirimi : MonoBehaviour
{
    UnityEngine.UI.Image aktiviteTuşu;
    protected bool etkileşimAçık = false;
    void Start()
    {
        aktiviteTuşu = GameObject.Find("E Tuşu").GetComponent<UnityEngine.UI.Image>();
    }
    void OnTriggerEnter(Collider obje)
    {
        if (obje.tag == "Oyuncu")
            aktiviteTuşu.enabled = etkileşimAçık = true;
    }
    void OnTriggerExit(Collider obje)
    {
        if (obje.tag == "Oyuncu")
            aktiviteTuşu.enabled = etkileşimAçık = false;
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
