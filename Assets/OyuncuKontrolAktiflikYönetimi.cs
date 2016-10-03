using UnityEngine;
using System.Collections;
using System;

public class OyuncuKontrolAktiflikYönetimi : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Zaman.zamanDurdu += ZamanDurdu;
        Zaman.zamanHızlandı += ZamanDurdu;
        Zaman.zamanNormal += ZamanNormal;
	}

    private void ZamanDurdu()
    {
        GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
        GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
        GetComponent<Animator>().enabled = false;
    }

    private void ZamanNormal()
    {
        GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
        GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
        GetComponent<Animator>().enabled = true;
    }
}
