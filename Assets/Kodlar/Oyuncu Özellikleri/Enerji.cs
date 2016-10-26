using UnityEngine;
using System.Collections;
using System;

public class Enerji : EnerjiSistemi
{
    public static bool uyunuyor=false;
    public override void DeğerAzalması()
    {
        if (uyunuyor)
        {
            Değer += 15;
        }
        else {
            Değer -= 5;
        }
    }

    public override string DeğerSıfırlandı()
    {
        return "Enerji";
    }
}
