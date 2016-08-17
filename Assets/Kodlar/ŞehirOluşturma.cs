using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ŞehirOluşturma : MonoBehaviour
{
    enum Yön
    {
        Yukarı,
        Aşağı,
        Sağ,
        Sol
    }
    Yön sonYön;
    public GameObject yol;
    int alanX, alanY;
    Alan alanS;
    Nokta[,] alan;
    bool[,] yolOlanYerler;
    System.Random r;
    void Start()
    {
        r = new System.Random();
        sonYön = Yön.Sağ;
        alanS = GetComponent<Alan>();
        alan = alanS.alan;
        Vector2 büyüklük = alanS.alanGenelBüyüklüğü;
        alanX = (int)büyüklük.x;
        alanY = (int)büyüklük.y;
        yolOlanYerler = new bool[alanX, alanY];
        YollarıOluştur();
    }
    //public int işyeriSayısı,evSayısı,apartmanSayısı,hastaneSayısı;
    void YollarıOluştur()
    {
        int çıkacakYolSayısı = (int)(alanY * 0.3f);
        int başlangıçYol = 0;
        YolAdres eklenecekYol;
        while (çıkacakYolSayısı > 0)
        {
            while (true)
            {
                eklenecekYol = new YolAdres(0, r.Next(1, alanY - 1), Yön.Sağ);
                if (!yolOlanYerler[eklenecekYol.x, eklenecekYol.y - 1] && !yolOlanYerler[eklenecekYol.x, eklenecekYol.y + 1])
                    break;
            }
            eklenecekYol=YolEkle(eklenecekYol);
            eklenecekYol = YolEkle(eklenecekYol);
            YolAdres[] mümkünEklemeler = MümkünEklemeler(eklenecekYol);
            while (true)
            {
                int yolŞansı = r.Next(0, 6);
                if (yolŞansı<2)
                {
                    Yön yeniYön;
                        yeniYön = mümkünEklemeler[r.Next(mümkünEklemeler.Length)].yön;
                    eklenecekYol.yön = yeniYön;
                    eklenecekYol = YolEkle(eklenecekYol);
                    if (MümkünEklemeler(eklenecekYol).Length < 3)
                    {
                        break;
                    }
                    eklenecekYol = YolEkle(eklenecekYol);
                    sonYön = yeniYön;
                }
                else
                {
                    eklenecekYol = YolEkle(eklenecekYol);
                }
                mümkünEklemeler = MümkünEklemeler(eklenecekYol);
                if (mümkünEklemeler.Length<3)
                {
                    break;
                }
            }
            çıkacakYolSayısı--;
        }
    }
    private YolAdres YolEkle(YolAdres eklenecekYol)
    {

        int x = eklenecekYol.x, y = eklenecekYol.y;
        Yön yön = eklenecekYol.yön;
        if (yön == Yön.Yukarı)
        {
            y++;
        }
        else if (yön == Yön.Sol)
        {
            x--;
        }
        else if (yön == Yön.Sağ)
        {
            x++;
        }
        else
        {
            y--;
        }
        alan[x, y].geçilebilir = true;
        yolOlanYerler[x, y] = true;
        Instantiate(yol, alan[x, y].genelPozisyon, Quaternion.identity);
        return new YolAdres(x, y, yön);
    }
    private YolAdres YolEkle(int X, int Y,Yön yön)
    {
        int x = X, y = Y;
        if (yön==Yön.Yukarı)
        {
            y++;
        }
        else if (yön==Yön.Sol)
        {
            x--;
        }
        else if(yön==Yön.Sağ)
        {
            x++;
        }
        else
        {
            y--;
        }
        alan[x,y].geçilebilir = true;
        yolOlanYerler[x,y] = true;
        Instantiate(yol, alan[x,y].genelPozisyon, Quaternion.identity);
        return new YolAdres(x, y,yön);
    }
    private bool YolKontrol(int X, int Y)
    {
        return yolOlanYerler[X, Y];
    }
    YolAdres[] MümkünEklemeler(YolAdres şuankiYol)
    {
        List<YolAdres> gidilebilecekYollar = new List<YolAdres>();
        int x = şuankiYol.x, y = şuankiYol.y;
        sonYön = şuankiYol.yön;
        if (y < alanY - 1)
        {
            if (!yolOlanYerler[x, y + 1] && sonYön != Yön.Aşağı) //Yukarı
            {
                gidilebilecekYollar.Add(new YolAdres(x, y + 1, Yön.Yukarı));
            }
        }
        if (x > 0)
        {
            if (!yolOlanYerler[x - 1, y] && sonYön != Yön.Sağ) // Sola
            {
                gidilebilecekYollar.Add(new YolAdres(x - 1, y, Yön.Sol));
            }
        }
        if (y > 0)
        {
            if (!yolOlanYerler[x, y - 1] && sonYön != Yön.Yukarı) // Aşağı
            {
                gidilebilecekYollar.Add(new YolAdres(x, y - 1, Yön.Aşağı));
            }
        }
        if (x < alanX - 1)
        {
            if (!yolOlanYerler[x + 1, y] && sonYön != Yön.Sol) // Sağa
            {
                gidilebilecekYollar.Add(new YolAdres(x + 1, y, Yön.Sağ));
            }
        }
        return gidilebilecekYollar.ToArray();
    }
    struct YolAdres
    {
        public int x, y;
        public Yön yön;
        public YolAdres(int x, int y, Yön yön)
        {
            this.x = x;
            this.y = y;
            this.yön = yön;
        }
    }
}
