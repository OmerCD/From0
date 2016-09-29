using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;

public class EnvanterEşyaDüzenleyicisi : EditorWindow {
    //public Envanter envanterListesi;
    //int bakılanIndex = 1;
    //[MenuItem("Window/Envanter Eşya Düzenleyicisi %@e")]
    //static void Init()
    //{
    //    GetWindow(typeof(EnvanterEşyaDüzenleyicisi));
    //}
    //void OnEnable()
    //{
    //    if (EditorPrefs.HasKey("ObjectPath"))
    //    {
    //        string dosyaYolu = EditorPrefs.GetString("ObjectPath");
    //        envanterListesi = AssetDatabase.LoadAssetAtPath(dosyaYolu, typeof(Envanter)) as Envanter;
    //    }
    //}
    //void OnGUI()
    //{
    //    GUILayout.BeginHorizontal();
    //    GUILayout.Label("Envanter Eşya Düzenleyici", EditorStyles.boldLabel);
    //    if (envanterListesi!=null)
    //    {
    //        if (GUILayout.Button("Eşya Listesini Göster"))
    //        {
    //            EditorUtility.FocusProjectWindow();
    //            Selection.activeObject = envanterListesi;
    //        }
    //    }
    //    if (GUILayout.Button("Eşya Listesini Aç"))
    //    {
    //        EşyaListesiAç();
    //    }
    //    GUILayout.EndHorizontal();
    //    if (envanterListesi==null)
    //    {
    //        GUILayout.BeginHorizontal();
    //        GUILayout.Space(10);
    //        if (GUILayout.Button("Yeni Eşya Listesi Oluştur", GUILayout.ExpandWidth(false)))
    //        {
    //            YeniEşyaListesiOluştur();
    //        }
    //        if (GUILayout.Button("Varolan Listeyi Aç",GUILayout.ExpandWidth(false)))
    //        {
    //            EşyaListesiAç();
    //        }
    //        GUILayout.EndHorizontal();
    //    }
    //    GUILayout.Space(20);
    //    if (envanterListesi!=null)
    //    {
    //        GUILayout.BeginHorizontal();
    //        GUILayout.Space(10);
    //        if (GUILayout.Button("Önceki",GUILayout.ExpandWidth(false)))
    //        {
    //            if (bakılanIndex>1)
    //            {
    //                bakılanIndex--;
    //            }
    //        }
    //        GUILayout.Space(5);
    //        if (GUILayout.Button("Sonraki",GUILayout.ExpandWidth(false)))
    //        {
    //            if (bakılanIndex<envanterListesi.Eşyalar.Count)
    //            {
    //                bakılanIndex++;
    //            }
    //        }
    //        GUILayout.Space(60);

    //        if (GUILayout.Button("Eşya Ekle", GUILayout.ExpandWidth(false)))
    //        {
    //            EşyaEkle();
    //        }
    //        if (GUILayout.Button("Eşya Sil", GUILayout.ExpandWidth(false)))
    //        {
    //            EşyaSil(bakılanIndex - 1);
    //        }
    //        GUILayout.EndHorizontal();
    //        if (envanterListesi.Eşyalar==null)
    //        {
    //            Debug.Log("WTF!?");
    //        }
    //        if (envanterListesi.Eşyalar.Count>0)
    //        {
    //            GUILayout.BeginHorizontal();
    //            bakılanIndex = Mathf.Clamp(EditorGUILayout.IntField("Şu anki Eşya", bakılanIndex, GUILayout.ExpandWidth(false)), 1, envanterListesi.Eşyalar.Count);
    //            //Mathf.Clamp (bakılanIndex, 1, envanterListesi.Eşyalar.Count);
    //            EditorGUILayout.LabelField("of   " + envanterListesi.Eşyalar.Count.ToString() + "  items", "", GUILayout.ExpandWidth(false));
    //            GUILayout.EndHorizontal();

    //            envanterListesi.Eşyalar[bakılanIndex - 1].Isim = EditorGUILayout.TextField("Eşya Adı", envanterListesi.Eşyalar[bakılanIndex - 1].Isim as string);
    //            envanterListesi.Eşyalar[bakılanIndex - 1].Açıklama = EditorGUILayout.TextField("Eşya Açıklaması", envanterListesi.Eşyalar[bakılanIndex - 1].Açıklama as string);
    //            envanterListesi.Eşyalar[bakılanIndex - 1].Ikon = EditorGUILayout.ObjectField("Eşya İkonu", envanterListesi.Eşyalar[bakılanIndex - 1].Ikon, typeof(Texture2D), false) as Texture2D;
    //            envanterListesi.Eşyalar[bakılanIndex - 1].ID = EditorGUILayout.IntField("Eşya ID", envanterListesi.Eşyalar[bakılanIndex - 1].ID);
    //            envanterListesi.Eşyalar[bakılanIndex - 1].Tür = (Eşya.EşyaTürü)EditorGUILayout.EnumPopup("Eşya Türü", envanterListesi.Eşyalar[bakılanIndex - 1].Tür);
    //            envanterListesi.Eşyalar[bakılanIndex - 1].EtkiGücü = EditorGUILayout.IntField("Eşya Etki Gücü", envanterListesi.Eşyalar[bakılanIndex - 1].EtkiGücü);
    //            //envanterListesi.Eşyalar[bakılanIndex - 1].itemObject = EditorGUILayout.ObjectField("Item Object", envanterListesi.Eşyalar[bakılanIndex - 1].itemObject, typeof(Rigidbody), false) as Rigidbody;

    //            GUILayout.Space(10);

    //            //GUILayout.BeginHorizontal();
    //            //envanterListesi.Eşyalar[bakılanIndex - 1].isUnique = (bool)EditorGUILayout.Toggle("Unique", envanterListesi.Eşyalar[bakılanIndex - 1].isUnique, GUILayout.ExpandWidth(false));
    //            //envanterListesi.Eşyalar[bakılanIndex - 1].isIndestructible = (bool)EditorGUILayout.Toggle("Indestructable", envanterListesi.Eşyalar[bakılanIndex - 1].isIndestructible, GUILayout.ExpandWidth(false));
    //            //envanterListesi.Eşyalar[bakılanIndex - 1].isQuestItem = (bool)EditorGUILayout.Toggle("QuestItem", envanterListesi.Eşyalar[bakılanIndex - 1].isQuestItem, GUILayout.ExpandWidth(false));
    //            //GUILayout.EndHorizontal();

    //            //GUILayout.Space(10);

    //            //GUILayout.BeginHorizontal();
    //            //envanterListesi.Eşyalar[bakılanIndex - 1].isStackable = (bool)EditorGUILayout.Toggle("Stackable ", envanterListesi.Eşyalar[bakılanIndex - 1].isStackable, GUILayout.ExpandWidth(false));
    //            //envanterListesi.Eşyalar[bakılanIndex - 1].destroyOnUse = (bool)EditorGUILayout.Toggle("Destroy On Use", envanterListesi.Eşyalar[bakılanIndex - 1].destroyOnUse, GUILayout.ExpandWidth(false));
    //            //envanterListesi.Eşyalar[bakılanIndex - 1].encumbranceValue = EditorGUILayout.FloatField("Encumberance", envanterListesi.Eşyalar[bakılanIndex - 1].encumbranceValue, GUILayout.ExpandWidth(false));
    //            //GUILayout.EndHorizontal();

    //            //GUILayout.Space(10);

    //        }
    //        else
    //        {
    //            GUILayout.Label("Envanter Listesi Boş");
    //        }
    //    }
    //    if (GUI.changed)
    //    {
    //        EditorUtility.SetDirty(envanterListesi);
    //    }
    //}

    //private void EşyaSil(int v)
    //{
    //    envanterListesi.Eşyalar.RemoveAt(v);
    //}

    //private void EşyaEkle()
    //{
    //    Eşya yeniEşya = new Eşya();
    //    yeniEşya.Isim = "Yeni Eşya";
    //    envanterListesi.Eşyalar.Add(yeniEşya);
    //    bakılanIndex = envanterListesi.Eşyalar.Count;
    //}

    //private void YeniEşyaListesiOluştur()
    //{
    //    bakılanIndex = 1;
    //    envanterListesi = EnvanterListesiOluştur.Oluştur();
    //    if (envanterListesi)
    //    {
    //        envanterListesi.Eşyalar = new List<Eşya>();
    //        string dosyaYolu = AssetDatabase.GetAssetPath(envanterListesi);
    //        EditorPrefs.SetString("ObjectPath", dosyaYolu);
    //    }
    //}

    //private void EşyaListesiAç()
    //{
    //    string envYolu = EditorUtility.OpenFilePanel("Envanter Listesi Seç", "", "");
    //    if (envYolu.StartsWith(Application.dataPath))
    //    {
    //        string dsyYolu = envYolu.Substring(Application.dataPath.Length - "Assets".Length);
    //        envanterListesi = AssetDatabase.LoadAssetAtPath(dsyYolu, typeof(Envanter)) as Envanter;
    //        if (envanterListesi.Eşyalar == null)
    //            envanterListesi.Eşyalar = new List<Eşya>();
    //        if (envanterListesi)
    //        {
    //            EditorPrefs.SetString("ObjectPath", dsyYolu);
    //        }
    //    }
    //}
}
