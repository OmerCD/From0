using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using System.IO;

public class EşyaDüzenleyici : EditorWindow {
    public Eşya eşya;
    int bakılanİndex = 1;
    int eşyaSayısı;
    [MenuItem("Window/Eşya Düzenleyici %@e")]
    static void Init()
    {
        GetWindow(typeof(EşyaDüzenleyici));
        EditorPrefs.SetString("ObjectPath", "Assets/Envanter Sistemi/SO Eşyalar/");
    }
    void OnEnable()
    {
        if (EditorPrefs.HasKey("ObjectPath"))
        {
            string yol = EditorPrefs.GetString("ObjectPath") + "1.asset";
            eşya = AssetDatabase.LoadAssetAtPath(yol,typeof(Eşya)) as Eşya;

            string[] aMaterialFiles = Directory.GetFiles(Application.dataPath + "/Envanter Sistemi/SO Eşyalar/", "*.asset", SearchOption.AllDirectories);
            eşyaSayısı = aMaterialFiles.Length;
        }
        
    }
    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Eşya Düzenleyici", EditorStyles.boldLabel);
        if (eşya != null)
        {
            if (GUILayout.Button("Eşyayı Göster"))
            {
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = eşya;
            }
        }
        if (GUILayout.Button("Eşya Aç"))
        {
            EşyaAç();
        }
        GUILayout.EndHorizontal();
        if (eşya == null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            if (GUILayout.Button("Yeni Eşya Oluştur", GUILayout.ExpandWidth(false)))
            {
                YeniEşyaOluştur();
            }
            if (GUILayout.Button("Varolan Eşya Aç", GUILayout.ExpandWidth(false)))
            {
                EşyaAç();
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.Space(20);
        if (eşya != null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            if (GUILayout.Button("Önceki", GUILayout.ExpandWidth(false)))
            {
                if (bakılanİndex > 1)
                {
                    bakılanİndex--;
                    eşya = AssetDatabase.LoadAssetAtPath<Eşya>(EditorPrefs.GetString("ObjectPath") + bakılanİndex + ".asset");
                }
            }
            GUILayout.Space(5);
            if (GUILayout.Button("Sonraki", GUILayout.ExpandWidth(false)))
            {
                if (bakılanİndex < eşyaSayısı )
                {
                    bakılanİndex++;
                    eşya = AssetDatabase.LoadAssetAtPath<Eşya>(EditorPrefs.GetString("ObjectPath") + bakılanİndex + ".asset");
                }
            }
            GUILayout.Space(60);

            if (GUILayout.Button("Eşya Ekle", GUILayout.ExpandWidth(false)))
            {
                EşyaEkle();
            }
            if (GUILayout.Button("Eşya Sil", GUILayout.ExpandWidth(false)))
            {
                EşyaSil(bakılanİndex);
            }
            GUILayout.EndHorizontal();
            if (eşyaSayısı > 0)
            {
                GUILayout.BeginHorizontal();
                bakılanİndex = Mathf.Clamp(EditorGUILayout.IntField("Şu anki Eşya", bakılanİndex, GUILayout.ExpandWidth(false)), 1, eşyaSayısı);
                //Mathf.Clamp (bakılanİndex, 1, eşya.Eşyalar.Count);
                EditorGUILayout.LabelField("--   " + eşyaSayısı + "  eşya", "", GUILayout.ExpandWidth(false));
                GUILayout.EndHorizontal();

                eşya.Isim = EditorGUILayout.TextField("Eşya Adı", eşya.Isim as string);
                eşya.Açıklama = EditorGUILayout.TextField("Eşya Açıklaması", eşya.Açıklama as string);
                eşya.Ikon = EditorGUILayout.ObjectField("Eşya İkonu", eşya.Ikon, typeof(Texture2D), false) as Texture2D;
                eşya.ID = EditorGUILayout.IntField("Eşya ID", eşya.ID);
                eşya.Tür = (Eşya.EşyaTürü)EditorGUILayout.EnumPopup("Eşya Türü", eşya.Tür);
                eşya.EtkiliAlan = (Eşya.EtkiAlanı)EditorGUILayout.EnumPopup("Etki Alanı", eşya.EtkiliAlan);
                eşya.EtkiGücü = EditorGUILayout.IntField("Eşya Etki Gücü", eşya.EtkiGücü);
                eşya.Değer = EditorGUILayout.FloatField("Eşya Değeri", eşya.Değer);
                //eşya.itemObject = EditorGUILayout.ObjectField("Item Object", eşya.itemObject, typeof(Rigidbody), false) as Rigidbody;

                GUILayout.Space(10);

                //GUILayout.BeginHorizontal();
                //eşya.isUnique = (bool)EditorGUILayout.Toggle("Unique", eşya.isUnique, GUILayout.ExpandWidth(false));
                //eşya.isIndestructible = (bool)EditorGUILayout.Toggle("Indestructable", eşya.isIndestructible, GUILayout.ExpandWidth(false));
                //eşya.isQuestItem = (bool)EditorGUILayout.Toggle("QuestItem", eşya.isQuestItem, GUILayout.ExpandWidth(false));
                //GUILayout.EndHorizontal();

                //GUILayout.Space(10);

                //GUILayout.BeginHorizontal();
                //eşya.isStackable = (bool)EditorGUILayout.Toggle("Stackable ", eşya.isStackable, GUILayout.ExpandWidth(false));
                //eşya.destroyOnUse = (bool)EditorGUILayout.Toggle("Destroy On Use", eşya.destroyOnUse, GUILayout.ExpandWidth(false));
                //eşya.encumbranceValue = EditorGUILayout.FloatField("Encumberance", eşya.encumbranceValue, GUILayout.ExpandWidth(false));
                //GUILayout.EndHorizontal();

                //GUILayout.Space(10);

            }
            else
            {
                GUILayout.Label("Eşya Listesi Boş");
            }
        }
        if (GUI.changed)
        {
            EditorUtility.SetDirty(eşya);
        }
    }
    private void EşyaSil(int v)
    {
        AssetDatabase.DeleteAsset(EditorPrefs.GetString("ObjectPath") + (bakılanİndex) + ".asset");
        eşyaSayısı--;
        if (bakılanİndex>1)
        {
            eşya = AssetDatabase.LoadAssetAtPath<Eşya>(EditorPrefs.GetString("ObjectPath") + "1.asset");
        }
        else
        {
            eşya = null;
        }
    }

    private void EşyaEkle()
    {
        bakılanİndex++;
        eşya = new Eşya();
        eşyaSayısı++;
        eşya = EşyaOluştur.Oluştur((eşyaSayısı).ToString());
    }

    private void YeniEşyaOluştur()
    {
        bakılanİndex = 1;
        eşya = new Eşya();
        eşyaSayısı++;
        eşya = EşyaOluştur.Oluştur("1");
    }

    private void EşyaAç()
    {
        throw new NotImplementedException();
    }
}
