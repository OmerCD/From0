using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Konuşma  {
    [SerializeField]
    string npcYazısı;
    [SerializeField]
    List<Cevap> cevaplar = new List<Cevap>();
}
[System.Serializable]
public struct Cevap
{
    [SerializeField]
    string yazı;
    [SerializeField]
    int konuşmaSıra;
    [SerializeField]
    Eşya verilecekEşya,ödülEşya; 
    [SerializeField]
    float ödülSağlık, ödülEnerji, ödülAçlık, ödülPara;
    [SerializeField]
    GerekliYetenek gerekenYetenek; // Bu cevap için sahip olunması gereken yetenek ve en az seviyesi
    public struct GerekliYetenek // yetenekAdı=="" ise boş kabul etmek gerekiyor
    {
        string yetenekAdı;
        int gerekenSeviye;
    }
}
