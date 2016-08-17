using UnityEngine;
using System.Collections;

public abstract class Ev : Bina {
    public Durum evDurumu;
    public enum Durum
    {
        Kiralık,
        Satılık,
        Yok
    }
    public int metreKare;
    public float aylıkÜcret,satınAlmaÜcreti;
}
