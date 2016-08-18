using UnityEngine;
using System.Collections;

public class HaritaKamerası : MonoBehaviour {
    public Transform oyuncu;
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(oyuncu.position.x, transform.position.y, oyuncu.position.z),.3f);
    }
}
