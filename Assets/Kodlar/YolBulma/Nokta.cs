using UnityEngine;
using System.Collections;

public class Nokta : IYığınItem<Nokta> {
    public bool geçilebilir;
    public Vector3 genelPozisyon;
    public int gCost, hCost;
    public int alanX, alanY;
    public Nokta kaynak;
    int yığınSırası;
    public int hareketYavaşlatıcı;
    public Nokta(bool geçilebilir, Vector3 genelPozisyon,int alanX,int alanY,int hareketYavaşlatıcı)
    {
        this.alanX = alanX;
        this.alanY = alanY;
        this.geçilebilir = geçilebilir;
        this.genelPozisyon = genelPozisyon;
        this.hareketYavaşlatıcı = hareketYavaşlatıcı;
    }
    public int FCost
    {
        get
        {
            return gCost + hCost;
        }
    }
    public int YığınSıra
    {
        get
        {
            return yığınSırası;
        }
        set{ yığınSırası = value; }
    }
    public int CompareTo(Nokta karşılaştırılacakNokta)
    {
        int karşılaştırma = FCost.CompareTo(karşılaştırılacakNokta.FCost);
        if (karşılaştırma==0)
        {
            karşılaştırma = hCost.CompareTo(karşılaştırılacakNokta.hCost);
        }
        return -karşılaştırma;
    }
}
