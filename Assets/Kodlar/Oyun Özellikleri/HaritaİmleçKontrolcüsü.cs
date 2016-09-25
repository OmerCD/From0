using UnityEngine;
using System.Collections;

public class HaritaİmleçKontrolcüsü : MonoBehaviour {
    public Transform gösterge,kamera;
	void LateUpdate () {
        Vector3 kameraAçı = gösterge.rotation.eulerAngles;
        gösterge.rotation = Quaternion.Euler(kameraAçı.x, kameraAçı.y, -kamera.eulerAngles.y);
    }
}
