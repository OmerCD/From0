using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class YolBulucu : MonoBehaviour
{
    YolİstekYöneticisi istekYöneticisi;
    Alan alan;
    void Awake()
    {
        alan = GetComponent<Alan>();
        istekYöneticisi = GetComponent<YolİstekYöneticisi>();
    }
    public void YolBulmayaBaşla(Vector3 başlangıçPoz, Vector3 hedefPoz)
    {
        StartCoroutine(YolBul(başlangıçPoz, hedefPoz));
    }
    IEnumerator YolBul(Vector3 başlangıçPoz, Vector3 hedefPoz)
    {
        Vector3[] yolNoktaları = new Vector3[0];
        bool yolBulmaBaşarılı=false;
        Nokta başlangıçNoktası = alan.GenelPozisyondanNokta(başlangıçPoz);
        Nokta hedefNoktası = alan.GenelPozisyondanNokta(hedefPoz);
        if (başlangıçNoktası.geçilebilir && hedefNoktası.geçilebilir)
        {
            YığınlamaSıralaması<Nokta> açıkYerler = new YığınlamaSıralaması<Nokta>(alan.MakBüyüklük);
            HashSet<Nokta> kapalıYerler = new HashSet<Nokta>();
            açıkYerler.Ekle(başlangıçNoktası);
            while (açıkYerler.Adet > 0)
            {
                Nokta şuankiNokta = açıkYerler.İlkiniSil();
                kapalıYerler.Add(şuankiNokta);
                if (şuankiNokta == hedefNoktası)
                {
                    yolBulmaBaşarılı = true;
                    break;
                }
                foreach (Nokta komşu in alan.KomşularıAl(şuankiNokta))
                {
                    if (!komşu.geçilebilir || kapalıYerler.Contains(komşu))
                    {
                        continue;
                    }
                    int yeniKomşuHareketMaliyeti = şuankiNokta.gCost + MesafeAl(şuankiNokta, komşu)+ komşu.hareketYavaşlatıcı;
                    if (yeniKomşuHareketMaliyeti < komşu.gCost || !açıkYerler.Sahip(komşu))
                    {
                        komşu.gCost = yeniKomşuHareketMaliyeti;
                        komşu.hCost = MesafeAl(komşu, hedefNoktası);
                        komşu.kaynak = şuankiNokta;
                        if (!açıkYerler.Sahip(komşu))
                        {
                            açıkYerler.Ekle(komşu);
                        }
                        else
                        açıkYerler.ItemGüncelle(komşu);
                    }
                }
            }
        }
        yield return null;
        if (yolBulmaBaşarılı)
        {
            yolNoktaları = GeriTakip(başlangıçNoktası, hedefNoktası);
        }
        istekYöneticisi.BitenYolİşlemi(yolNoktaları, yolBulmaBaşarılı);
    }


    Vector3[] GeriTakip(Nokta başlangıçNoktası, Nokta bitişNoktası)
    {
        List<Nokta> yol = new List<Nokta>();
        Nokta şuankiNokta = bitişNoktası;
        while (şuankiNokta != başlangıçNoktası)
        {
            yol.Add(şuankiNokta);
            şuankiNokta = şuankiNokta.kaynak;
        }
        Vector3[] yolnoktaları=YolBasitleştir(yol);
        Array.Reverse(yolnoktaları);
        return yolnoktaları;
    } 
    Vector3[] YolBasitleştir(List<Nokta> yol)
    {
        List<Vector3> yolnoktaları = new List<Vector3>();
        Vector2 eskiYön = Vector2.zero;
        for (int i = 1; i < yol.Count; i++)
        {
            //Vector2 yeniYön = new Vector2(yol[i - 1].alanX - yol[i].alanX, yol[i - 1].alanY - yol[i].alanY);
            Vector2 yeniYön = new Vector2(yol[i - 1].genelPozisyon.x - yol[i].genelPozisyon.x, yol[i - 1].genelPozisyon.z - yol[i].genelPozisyon.z);
            if (yeniYön!=eskiYön)
            {
                yolnoktaları.Add(yol[i].genelPozisyon);
            }
            eskiYön = yeniYön;
        }
        return yolnoktaları.ToArray();
    }
    int MesafeAl(Nokta A, Nokta B)
    {
        int msfX = Mathf.Abs(A.alanX - B.alanX);
        int msfY = Mathf.Abs(A.alanY - B.alanY);
        if (msfX > msfY)
        {
            return 14 * msfY + 10 * (msfX - msfY);
        }
        return 14 * msfX + 10 * (msfY - msfX);
    }
}
