using UnityEngine;
using System.Collections;

public class Market : IşYeri {
    [SerializeField]
    SatışSistemi[] satılıkEşyalar = new SatışSistemi[20];
    public SatışSistemi[] SatılıkEşyalar { get { return satılıkEşyalar; } }
    [System.Serializable]
    public class SatışSistemi
    {
        public int adet;
        public float fiyat;
        public Eşya eşya;
    }
    protected override void İşDurumKontrol()
    {
        base.İşDurumKontrol();
        System.Array.Resize(ref seçenekler, seçenekler.Length + 1);
        seçenekler[seçenekler.Length-1] = "Alış-Veriş";
    }
}
