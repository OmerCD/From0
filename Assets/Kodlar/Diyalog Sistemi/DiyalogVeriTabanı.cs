using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiyalogVeriTabanı : ScriptableObject {
    [SerializeField]
    List<Diyalog> diyaloglar = new List<Diyalog>();
    public void RemoveAt(int index)
    {
        diyaloglar.RemoveAt(index);
    }
    public void Add(Diyalog diyalog)
    {
        diyaloglar.Add(diyalog);
    }
    public Diyalog this[int index]
    {
        get
        {
            return diyaloglar[index];
        }
        set
        {
            diyaloglar[index] = value;
        }
    }
    public int Adet {
        get
        {
            return diyaloglar.Count;
        }
    }
}
