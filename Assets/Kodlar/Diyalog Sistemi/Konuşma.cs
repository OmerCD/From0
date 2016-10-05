using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Konuşma  {
    [SerializeField]
    public string npcYazısı;
    [SerializeField]
    public List<Cevap> cevaplar = new List<Cevap>();
}
[System.Serializable]
public class Cevap
{
    [SerializeField]
    public string yazı;
    [SerializeField]
    public int konuşmaSıra=-1;
    [SerializeField]
    public Eşya verilecekEşya,ödülEşya; 
    [SerializeField]
    public float ödülSağlık, ödülEnerji, ödülAçlık, ödülPara;
    [SerializeField]
    public GerekliYetenek gerekenYetenek; // Bu cevap için sahip olunması gereken yetenek ve en az seviyesi
    public struct GerekliYetenek // yetenekAdı=="" ise boş kabul etmek gerekiyor
    {
        public string yetenekAdı;
        public int gerekenSeviye;
    }
}
