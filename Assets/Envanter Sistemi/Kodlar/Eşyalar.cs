using UnityEngine;
using System.Collections;
using UnityEditor;

public class Eşyalar  {

	public Eşya this[int eşyaSırası]
    {
        get
        {
            string yol = EditorPrefs.GetString("ObjectPath") + eşyaSırası+".asset";
            return AssetDatabase.LoadAssetAtPath(yol, typeof(Eşya)) as Eşya;
        }
    }
}
