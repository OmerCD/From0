using UnityEngine;
using System.Collections;
using System;

public class Enerji : EnerjiSistemi
{
    public override void DeğerAzalması()
    {
        Değer -= 5;
    }

    public override string DeğerSıfırlandı()
    {
        return "Enerji";
    }
}
