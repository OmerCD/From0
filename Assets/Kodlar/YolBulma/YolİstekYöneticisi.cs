using UnityEngine;
using System.Collections.Generic;
using System;
public class YolİstekYöneticisi : MonoBehaviour {
    Queue<Yolİstek> yolİstekSırası = new Queue<Yolİstek>();
    Yolİstek şuankiYolİstek;
    static YolİstekYöneticisi işlem;
    YolBulucu yolBulucu;
    bool yolİşleniyor;
    void Awake()
    {
        işlem = this;
        yolBulucu = GetComponent<YolBulucu>();
    }
	public static void  Yolİste(Vector3 yolBaşlangıç,Vector3 yolBitiş,Action<Vector3[],bool> geriBildirim)
    {
        Yolİstek yeniİstek = new Yolİstek(yolBaşlangıç, yolBitiş, geriBildirim);
        işlem.yolİstekSırası.Enqueue(yeniİstek);
        işlem.SonrakiİşlemiDene();
    }

    private void SonrakiİşlemiDene()
    {
        if (!yolİşleniyor && yolİstekSırası.Count>0)
        {
            şuankiYolİstek = yolİstekSırası.Dequeue();
            yolİşleniyor = true;
            yolBulucu.YolBulmayaBaşla(şuankiYolİstek.yolBaşlangıç, şuankiYolİstek.yolBitiş);
        }
    }
    public void BitenYolİşlemi(Vector3[] yol, bool tamamlandı)
    {
        şuankiYolİstek.geriBildirim(yol, tamamlandı);
        yolİşleniyor = false;
        SonrakiİşlemiDene();
    }
    struct Yolİstek
    {
        public Vector3 yolBaşlangıç;
        public Vector3 yolBitiş;
        public Action<Vector3[], bool> geriBildirim;

        public Yolİstek(Vector3 yolBaşlangıç, Vector3 yolBitiş, Action<Vector3[], bool> geriBildirim)
        {
            this.yolBaşlangıç = yolBaşlangıç;
            this.yolBitiş = yolBitiş;
            this.geriBildirim = geriBildirim;
        }
    }
}
