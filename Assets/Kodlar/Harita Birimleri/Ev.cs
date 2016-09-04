using UnityEngine;
using System.Collections;

public abstract class Ev : Bina {
    public Durum evDurumu;
    public string[] durumAdları = new string[] { "Kiralık", "Satılık", "Kiracı", "Sahip", "Yok" };
    public enum Durum
    {
        Kiralık,
        Satılık,
        Kiracı,
        Sahip,
        Yok
    }
    public int metreKare;
    public float haftalıkÜcret,satınAlmaÜcreti;
}
