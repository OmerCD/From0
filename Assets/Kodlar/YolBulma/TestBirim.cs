using UnityEngine;
using System.Collections;
using System;

public class TestBirim : MonoBehaviour
{
    public Transform hedef;
    public float hız = 20;
    Vector3[] yol;
    int hedefSırası;
    void Start()
    {
        YolİstekYöneticisi.Yolİste(transform.position, hedef.position, YolBulunduğunda);
    }

    public void YolBulunduğunda(Vector3[] yeniYol, bool yolBaşarılı)
    {
        if (yolBaşarılı)
        {
            yol = yeniYol;
            StopCoroutine("Yolİzle");
            StartCoroutine("Yolİzle");
        }
    }
    IEnumerator Yolİzle()
    {
        Vector3 şuankiYolNoktası = yol[0];
        while (true)
        {
            if (transform.position == şuankiYolNoktası)
            {
                hedefSırası++;
                if (hedefSırası >= yol.Length)
                {
                    yield break;
                }
                şuankiYolNoktası = yol[hedefSırası];
            }
            transform.position = Vector3.MoveTowards(transform.position, şuankiYolNoktası, hız*Time.deltaTime);
            yield return null;
        }
    }
    public void OnDrawGizmos()
    {
        if (yol != null)
        {
            Gizmos.color = Color.black;
            for (int i = hedefSırası; i < yol.Length; i++)
            {
                Gizmos.DrawCube(yol[i], Vector3.one);
                if (i==hedefSırası)
                {
                    Gizmos.DrawLine(transform.position, yol[i]);
                }
                else
                {
                    Gizmos.DrawLine(yol[i - 1], yol[i]);
                }
            }
        }
    }
}
