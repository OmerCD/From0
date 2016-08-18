using UnityEngine;
using System.Collections;

public class KameraAyarları : MonoBehaviour {
    public Transform oyuncu;
    public float kameraAçıHızı = 30f;
    Camera kamera;
	// Use this for initialization
	void Start () {
        kamera = transform.gameObject.GetComponent<Camera>();

    }
	// Update is called once per frame
	void FixedUpdate () {
        float kameraAçıDeğişimi = -Input.GetAxis("Mouse ScrollWheel");
        if (kameraAçıDeğişimi!=0)
        {
            if ((kamera.fieldOfView>1.7f && kameraAçıDeğişimi<0) || (kamera.fieldOfView < 35f && kameraAçıDeğişimi > 0))
            {
                kamera.fieldOfView += kameraAçıDeğişimi * kameraAçıHızı * Time.deltaTime;
            }
        }
        
        Vector3 kameraAçı = transform.rotation.eulerAngles;
        transform.position = Vector3.Lerp(transform.position,new Vector3(oyuncu.position.x, 15f, oyuncu.position.z),.3f);
        transform.rotation = Quaternion.Euler(kameraAçı.x, oyuncu.eulerAngles.y, kameraAçı.z);
	}
}
