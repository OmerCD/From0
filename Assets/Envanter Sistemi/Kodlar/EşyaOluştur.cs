using UnityEngine;
using System.Collections;
using UnityEditor;

public class EşyaOluştur  {
    [MenuItem("Assets/Create/Eşya")]
    public static Eşya Oluştur(string eşyaID)
    {
        Eşya asset = ScriptableObject.CreateInstance<Eşya>();
        AssetDatabase.CreateAsset(asset, "Assets/Envanter Sistemi/SO Eşyalar/"+eşyaID+".asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}
