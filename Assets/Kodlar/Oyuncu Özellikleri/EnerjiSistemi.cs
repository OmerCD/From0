﻿using UnityEngine;
using System.Collections;
using System;

public abstract class EnerjiSistemi : MonoBehaviour{
    private float maksimumDeğer;
    protected float anlıkDeğer;
    public RectTransform enerjiBarı;
    public float Değer
    {
        get
        {
            return anlıkDeğer;
        }
        protected set
        {
            if (value > maksimumDeğer)
                anlıkDeğer = maksimumDeğer;
            else anlıkDeğer = value;
            EnerjiSistemBarıDeğişimi();
            if (anlıkDeğer<=0)
            {
                DeğerSıfırlandı(); // Herhangi bir değer sıfıra ulaşınca yapılacak işlemler delegate ile gereken yerde işlenecek
            }
        }
    }

    public float MaksimumDeğer
    {
        get
        {
            return maksimumDeğer;
        }

        protected set
        {
            maksimumDeğer = value;
        }
    }

    protected virtual void Start()
    {
        maksimumDeğer = 100;
        anlıkDeğer = maksimumDeğer;
        Zaman.saatDeğişti += DeğerAzalması;
    }
    public void DeğerEkle(float değer)
    {
        Değer += değer;
        Değer = anlıkDeğer > maksimumDeğer ? maksimumDeğer : anlıkDeğer;
    }
    public abstract void DeğerAzalması();
    public abstract string DeğerSıfırlandı();
    void EnerjiSistemBarıDeğişimi()
    {
        enerjiBarı.sizeDelta = new Vector2(anlıkDeğer * 3, enerjiBarı.sizeDelta.y);
    }
}

