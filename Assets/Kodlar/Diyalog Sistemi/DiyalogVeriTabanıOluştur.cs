using UnityEngine;
using System.Collections;
using UnityEditor;

public class DiyalogVeriTabanıOluştur {
    [MenuItem("Assets/Create/Diyalog Veri Tabanı")]
    public static DiyalogVeriTabanı Oluştur()
    {
        DiyalogVeriTabanı asset = ScriptableObject.CreateInstance<DiyalogVeriTabanı>();
        AssetDatabase.CreateAsset(asset, "Assets/Kodlar/Diyalog Sistemi/VeriTabanı/DiyalogVT.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}
