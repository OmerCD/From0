using UnityEngine;
using System.Collections;

public class HaritaİmleçKontrolcüsü : MonoBehaviour {
    public Transform gösterge, oyuncu,kamera;
	void LateUpdate () {
        Vector3 kameraAçı = gösterge.rotation.eulerAngles;
        //gösterge.rotation = Quaternion.Euler(oyuncu.eulerAngles.x, kameraAçı.y, oyuncu.eulerAngles.z);
        gösterge.rotation = Quaternion.Euler(kameraAçı.x, kameraAçı.y, -kamera.eulerAngles.y);
    }
}
