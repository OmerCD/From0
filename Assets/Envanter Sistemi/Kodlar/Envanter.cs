using UnityEngine;
using System.Collections.Generic;

public class Envanter : ScriptableObject {
    List<Eşya> eşyalar = new List<Eşya>();
    public List<Eşya> Eşyalar
    {
        get
        {
            return eşyalar;
        }

        set
        {
            eşyalar = value;
        }
    }
}
