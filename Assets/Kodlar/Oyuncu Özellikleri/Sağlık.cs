using UnityEngine;
using System.Collections;
using System;

public class Sağlık : EnerjiSistemi {
    Açlık açlık;
    Enerji enerji;

    public override void DeğerAzalması()
    {
        if (açlık.Değer < 15)
        {
            Değer -= 3;
        }
        if (enerji.Değer < 15)
        {
            Değer -= 3;
        }
    }

    public override string DeğerSıfırlandı()
    {
        return "Sağlık";
    }

    protected override void Start()
    {
        base.Start();
        açlık = GetComponent<Açlık>();
        enerji = GetComponent<Enerji>();
    }
}
