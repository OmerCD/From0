using UnityEngine;
using System.Collections.Generic;
using System;

public class Alan : MonoBehaviour
{
    public bool alanıGöster;
    public LayerMask yürünemezMaske;
    public LayerMask yolMaske;
    public Vector2 alanGenelBüyüklüğü;
    public float noktaYarıçap;
    public ZeminTipi[] yürüneblirAlanlar;
    LayerMask geçilebilirMaske;
    Dictionary<int, int> geçilebilirAlanlarSözlüğü = new Dictionary<int, int>();
    public Nokta[,] alan;

    float noktaÇap;
    int alanBüyüklüğüX, alanBüyüklüğüY;
    void Start()
    {
        noktaÇap = noktaYarıçap * 2;
        alanBüyüklüğüX = Mathf.RoundToInt(alanGenelBüyüklüğü.x / noktaÇap);
        alanBüyüklüğüY = Mathf.RoundToInt(alanGenelBüyüklüğü.y / noktaÇap);
        foreach (ZeminTipi alan in yürüneblirAlanlar)
        {
            geçilebilirMaske.value |= alan.zeminMaskesi.value;
            geçilebilirAlanlarSözlüğü.Add((int)Mathf.Log(alan.zeminMaskesi.value, 2), alan.zeminYavaşlığı);
        }
        AlanYarat();
    }
    public int MakBüyüklük
    {
        get
        {
            return alanBüyüklüğüX * alanBüyüklüğüY;
        }
    }
    private void AlanYarat()
    {
        alan = new Nokta[alanBüyüklüğüX, alanBüyüklüğüY];
        Vector3 genelSolAlt = transform.position - Vector3.right * alanGenelBüyüklüğü.x * 0.5f - Vector3.forward * alanGenelBüyüklüğü.y * 0.5f;
        for (int x = 0; x < alanBüyüklüğüX; x++)
        {
            for (int y = 0; y < alanBüyüklüğüY; y++)
            {
                Vector3 genelNokta = genelSolAlt + Vector3.right * (x * noktaÇap + noktaYarıçap) + Vector3.forward * (y * noktaÇap + noktaYarıçap);
                bool geçilebilir = !(Physics.CheckSphere(genelNokta, noktaYarıçap, yürünemezMaske));
                int hareketYavaşlatıcı = 0;

                if (geçilebilir)
                {
                    Ray ışın = new Ray(genelNokta + Vector3.up * 50, Vector3.down);
                    RaycastHit darbe;
                    if (Physics.Raycast(ışın,out darbe,100,geçilebilirMaske))
                    {
                        geçilebilirAlanlarSözlüğü.TryGetValue(darbe.collider.gameObject.layer, out hareketYavaşlatıcı);
                    }
                }

                alan[x, y] = new Nokta(geçilebilir, genelNokta, x, y,hareketYavaşlatıcı);
            }
        }
    }
    public List<Nokta> KomşularıAl(Nokta nokta)
    {
        List<Nokta> komşular = new List<Nokta>();
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) continue;
                int kontrolX = nokta.alanX + x;
                int kontrolY = nokta.alanY + y;
                if (kontrolX >= 0 && kontrolX < alanBüyüklüğüX && kontrolY >= 0 && kontrolY < alanBüyüklüğüY)
                {
                    komşular.Add(alan[kontrolX, kontrolY]);
                }
            }
        }
        return komşular;
    }
    public Nokta GenelPozisyondanNokta(Vector3 genelPozisyon)
    {
        float yüzdeX = (genelPozisyon.x + alanGenelBüyüklüğü.x * 0.5f) / alanGenelBüyüklüğü.x;
        float yüzdeY = (genelPozisyon.z + alanGenelBüyüklüğü.y * 0.5f) / alanGenelBüyüklüğü.y;
        yüzdeX = Mathf.Clamp01(yüzdeX);
        yüzdeY = Mathf.Clamp01(yüzdeY);
        int x = Mathf.RoundToInt((alanBüyüklüğüX - 1) * yüzdeX);
        int y = Mathf.RoundToInt((alanBüyüklüğüY - 1) * yüzdeY);
        return alan[x, y];
    }
    void OnDrawGizmos()
    {
        if (alan != null && alanıGöster)
        {
            foreach (Nokta item in alan)
            {
                Gizmos.color = item.geçilebilir ? Color.white : Color.red;
                Gizmos.DrawCube(item.genelPozisyon, Vector3.one * (noktaÇap - .1f));
            }
        }
    }
    [System.Serializable]
    public class ZeminTipi
    {
        public LayerMask zeminMaskesi;
        public int zeminYavaşlığı;
    }
}
