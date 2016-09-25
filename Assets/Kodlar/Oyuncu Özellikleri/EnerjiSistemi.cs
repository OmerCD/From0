using UnityEngine;
using System.Collections;
using System;

public abstract class EnerjiSistemi : MonoBehaviour{
    protected float maksismumDeğer;
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
            anlıkDeğer = value;
            EnerjiSistemBarıDeğişimi();
            if (anlıkDeğer<=0)
            {
                DeğerSıfırlandı(); // Herhangi bir değer sıfıra ulaşınca yapılacak işlemler delegate ile gereken yerde işlenecek
            }
        }
    }
    protected virtual void Start()
    {
        maksismumDeğer = 100;
        anlıkDeğer = maksismumDeğer;
        Zaman.saatDeğişti += DeğerAzalması;
    }
    public void DeğerEkle(float değer)
    {
        anlıkDeğer += değer;
        anlıkDeğer = anlıkDeğer > maksismumDeğer ? maksismumDeğer : anlıkDeğer;
    }
    public abstract void DeğerAzalması();
    public abstract string DeğerSıfırlandı();
    void EnerjiSistemBarıDeğişimi()
    {
        enerjiBarı.sizeDelta = new Vector2(anlıkDeğer * 3, enerjiBarı.sizeDelta.y);
    }
}

