using UnityEngine;
using System.Collections;

public class ŞehirOluştur : MonoBehaviour
{

    public EtkileşimliBina[] özelBinalar;
    public GameObject[] binalar;
    public GameObject ayarlarObjesi;
    public GameObject xYol, zYol, dörtYol;
    int[,] haritaAlanı;
    public int haritaGenişlik = 20, haritaYükseklik = 20;
    int binaİzi = 3;
    void Awake()
    {
        bool[,] binaKoyululabilirlik = new bool[haritaGenişlik, haritaYükseklik];
        Vector2 alanGenelBüyüklüğü = new Vector2(haritaGenişlik, haritaYükseklik);
        Vector3 genelSolAlt = transform.position - Vector3.right * alanGenelBüyüklüğü.x * 0.5f * binaİzi - Vector3.forward * alanGenelBüyüklüğü.y * 0.5f * binaİzi;
        float kaynak = Random.Range(0, 100);
        haritaAlanı = new int[haritaGenişlik, haritaYükseklik];
        for (int x = 0; x < haritaGenişlik; x++)
        {
            for (int y = 0; y < haritaYükseklik; y++)
            {
                haritaAlanı[x, y] = (int)(Mathf.PerlinNoise(x * 0.1f + kaynak, y * 0.1f + kaynak) * 10);
            }
        }
        int x1 = 0;
        for (int n = 0; n < haritaGenişlik * .5f; n++)
        {
            for (int y = 0; y < haritaYükseklik; y++)
            {
                haritaAlanı[x1, y] = -1;
            }
            x1 += Random.Range(3, 4);
            if (x1 >= haritaGenişlik) break;
        }
        int z1 = 0;
        for (int n = 0; n < haritaYükseklik * .1f; n++)
        {
            for (int x = 0; x < haritaGenişlik; x++)
            {
                if (haritaAlanı[x, z1] == -1)
                {
                    haritaAlanı[x, z1] = -3;
                }
                else
                {
                    haritaAlanı[x, z1] = -2;
                }
            }
            z1 += Random.Range(2, 20);
            if (z1 >= haritaYükseklik) break;
        }
        EtkileşimliBinalar özelKoyulacakBinalar = new EtkileşimliBinalar(özelBinalar, haritaAlanı);
        for (int i = 0; i < özelBinalar.Length; i++)
        {
            Vector2[] koyulacakYerler = özelKoyulacakBinalar[i];
            for (int q = 0; q < koyulacakYerler.Length; q++)
            {
                Vector3 poz = genelSolAlt + Vector3.right * (koyulacakYerler[q].x * binaİzi) + Vector3.forward * (koyulacakYerler[q].y * binaİzi);
                poz.y = 0;
                Instantiate(özelBinalar[i].bina, poz, Quaternion.identity);
                haritaAlanı[(int)koyulacakYerler[q].x, (int)koyulacakYerler[q].y] = 42;
            }

        }
        for (int x = 0; x < haritaGenişlik; x++)
        {
            for (int y = 0; y < haritaYükseklik; y++)
            {
                int sonuç = haritaAlanı[x, y];
                if (sonuç == 42) continue;
                int binaSırası = 0;
                if (sonuç <= 0)
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
                Vector3 poz = genelSolAlt + Vector3.right * (x * binaİzi) + Vector3.forward * (y * binaİzi);
                poz.y = 0;
                if (binaSırası < binalar.Length && binaSırası >= 0)
                {
                    Instantiate(binalar[binaSırası], poz, Quaternion.identity);
                }
                else if (binaSırası < -2)
                {
                    poz = new Vector3(poz.x, dörtYol.transform.position.y, poz.z);
                    Instantiate(dörtYol, poz, dörtYol.transform.rotation);
                }
                else if (binaSırası < -1)
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
        Instantiate(ayarlarObjesi);
    }
    [System.Serializable]
    public class EtkileşimliBina
    {
        public GameObject bina;
        public int adet;
    }
    class EtkileşimliBinalar
    {
        EtkileşimliBina[] özelBinalar;
        int[,] yerleştirilebilirlikHaritası;

        public EtkileşimliBinalar(EtkileşimliBina[] özelBinalar, int[,] yerleştirilebilirlikHaritası)
        {
            this.özelBinalar = özelBinalar;
            this.yerleştirilebilirlikHaritası = yerleştirilebilirlikHaritası;
        }

        public Vector2[] this[int i]
        {
            get
            {
                int adet = özelBinalar[i].adet;
                Vector2[] koyulabilecekYerler = new Vector2[adet];
                int index = 0;
                while (adet > 0)
                {
                    int genişlik = yerleştirilebilirlikHaritası.GetLength(0), yükseklik = yerleştirilebilirlikHaritası.GetLength(0);
                    int x = Random.Range(0, genişlik), y = Random.Range(0, yükseklik);
                    if (yerleştirilebilirlikHaritası[x, y] > 0)
                    {
                        koyulabilecekYerler[index] = new Vector2(x, y);
                        index++;
                        adet--;
                    }
                }
                return koyulabilecekYerler;
            }
        }
    }
}
