using UnityEngine;
using System.Collections;

public class ŞehirOluştur : MonoBehaviour
{

    public GameObject[] binalar;
    public GameObject xYol, zYol, dörtYol;
    int[,] haritaAlanı;
    public int haritaGenişlik = 20, haritaYükseklik = 20;
    int binaİzi = 3;
    void Awake()
    {
        float kaynak = Random.Range(0, 100);
        haritaAlanı = new int[haritaGenişlik, haritaYükseklik];
        for (int x = 0; x < haritaGenişlik; x++)
        {
            for (int y = 0; y < haritaYükseklik; y++)
            {
                haritaAlanı[x, y] = (int)(Mathf.PerlinNoise(x * 0.1f+kaynak, y * 0.1f+kaynak) * 10);
            }
        }
        int x1 = 0;
        for (int n = 0; n < haritaGenişlik*.5f; n++)
        {
            for (int y = 0; y < haritaYükseklik; y++)
            {
                haritaAlanı[x1, y] = -1;
            }
            x1 += Random.Range(3, 4);
            if (x1 >= haritaGenişlik) break;
        }
        int z1 = 0;
        for (int n = 0; n < haritaYükseklik*.1f; n++)
        {
            for (int x = 0; x < haritaGenişlik; x++)
            {
                if (haritaAlanı[x,z1]==-1)
                {
                    haritaAlanı[x, z1] =-3;
                }
                else
                {
                    haritaAlanı[x, z1] = -2;
                }
            }
            z1 += Random.Range(2, 20);
            if (z1 >= haritaYükseklik) break;
        }
        //float kaynak= Random.Range(0, 100);
        for (int x = 0; x < haritaGenişlik; x++)
        {
            for (int y = 0; y < haritaYükseklik; y++)
            {
                int sonuç = haritaAlanı[x, y];
                int binaSırası = 0;
                if (sonuç<=0)
                {
                    binaSırası = sonuç;
                }
                else if (sonuç < 2)
                {
                    binaSırası = 0;
                }
                else if (sonuç < 4)
                {
                    binaSırası = 1;
                }
                else if (sonuç < 5)
                {
                    binaSırası = 2;
                }
                else if (sonuç < 6)
                {
                    binaSırası = 3;
                }
                else if (sonuç < 7)
                {
                    binaSırası = 4;
                }
                else if (sonuç < 10)
                {
                    binaSırası = 5;
                }
                Vector3 poz = new Vector3(x * binaİzi, 0, y * binaİzi);
                if (binaSırası < binalar.Length && binaSırası>=0)
                    Instantiate(binalar[binaSırası], poz, Quaternion.identity);
                else if (binaSırası<-2)
                {
                    poz = new Vector3(poz.x, dörtYol.transform.position.y, poz.z);
                    Instantiate(dörtYol, poz, dörtYol.transform.rotation);
                }
                else if (binaSırası<-1)
                {
                    poz = new Vector3(poz.x, xYol.transform.position.y, poz.z);
                    Instantiate(xYol, poz, xYol.transform.rotation);
                }
                else if (binaSırası < 0)
                {
                    poz = new Vector3(poz.x, zYol.transform.position.y, poz.z);
                    Instantiate(zYol, poz, zYol.transform.rotation);
                }
            }
        }
    }
}
