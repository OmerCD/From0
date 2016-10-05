using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

public class DiyalogYöneticisi : EditorWindow
{
    Diyalog diyalog;
    DiyalogVeriTabanı diyalogVT;
    int bakılanDiyalogID = 0;
    int diyalogSayısı;
    string yol = "Assets/Kodlar/Diyalog Sistemi/VeriTabanı/DiyalogVT.asset";
    Vector2 scrollBarPozisyonu;
    int BakılanDiyalogID
    {
        get
        {
            return bakılanDiyalogID;
        }

        set
        {
            bakılanDiyalogID = value;
            diyalog = diyalogVT[bakılanDiyalogID];
        }
    }
    [MenuItem("Window/Diyalog Yöneticisi %@t")]
    static void Init()
    {
        GetWindow<DiyalogYöneticisi>();
    }
    void OnEnable()
    {
        
        if (EditorPrefs.HasKey("DiyalogVT"))
        {
            diyalogVT = AssetDatabase.LoadAssetAtPath<DiyalogVeriTabanı>(yol);
            if (diyalogVT.Adet > 0)
            {
                diyalog = diyalogVT[0];
                BakılanDiyalogID = 0;
                diyalogSayısı = diyalogVT.Adet;
            }
        }
    }
    void OnGUI()
    {
        EditorGUIUtility.fieldWidth = 250;
        GUILayout.BeginHorizontal();
        GUILayout.Label("Diyalog Yöneticisi", EditorStyles.boldLabel);
        GUILayout.EndHorizontal();
        if (diyalog == null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            if (GUILayout.Button("Yeni Diyalog Oluştur", GUILayout.ExpandWidth(false)))
            {
                YeniDiyalogOluştur();
            }
            if (GUILayout.Button("DiyalogVT Aç", GUILayout.ExpandWidth(false)))
            {
                DiyaloglarıAç();
            }
            GUILayout.EndHorizontal();
        }

        GUILayout.Space(20);
        if (diyalog != null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            if (GUILayout.Button("Önceki", GUILayout.ExpandWidth(false)))
            {
                if (BakılanDiyalogID > 0)
                {
                    BakılanDiyalogID--;
                }
            }
            GUILayout.Space(5);
            if (GUILayout.Button("Sonraki", GUILayout.ExpandWidth(false)))
            {
                if (BakılanDiyalogID < diyalogSayısı - 1)
                {
                    BakılanDiyalogID++;
                }
            }
            if (GUILayout.Button("Yeni Diyalog Oluştur", GUILayout.ExpandWidth(false)))
            {
                YeniDiyalogOluştur();
            }

            GUILayout.Space(60);
            if (GUILayout.Button("Diyalog Sil", GUILayout.ExpandWidth(false)))
            {
                DiyalogSil(BakılanDiyalogID);
            }
            GUILayout.EndHorizontal();
            if (diyalogSayısı > 0)
            {
                GUILayout.BeginHorizontal();
                GUILayout.EndHorizontal();
                GUILayout.Space(20);
                GUILayout.BeginHorizontal();
                int konuşmaSayısı = diyalog.konuşmalar.Count;
                if (GUILayout.Button("Yeni Konuşma Oluştur", GUILayout.ExpandWidth(false)))
                {
                    YeniKonuşmaOluştur();
                }
                
                GUILayout.EndHorizontal();
                scrollBarPozisyonu= EditorGUILayout.BeginScrollView(scrollBarPozisyonu);
                for (int i = 0; i < konuşmaSayısı; i++)
                {
                    GUILayout.BeginVertical(GUILayout.Width(70));
                    GUILayout.Space(20); GUILayout.Label("Konuşma " + i,EditorStyles.boldLabel);
                    

                    GUILayout.BeginHorizontal();
                    diyalog.konuşmalar[i].npcYazısı = EditorGUILayout.TextField("NPC Yazısı", diyalog.konuşmalar[i].npcYazısı);
                    GUILayout.EndHorizontal();

                    if (GUILayout.Button("Yeni Cevap Oluştur", GUILayout.ExpandWidth(true)))
                    {
                        YeniCevapOluştur(i);
                    }
                    for (int q = 0; q < diyalog.konuşmalar[i].cevaplar.Count; q++)
                    {
                        GUILayout.Space(10);
                        GUILayout.BeginHorizontal();
                        GUILayout.Label("Cevap " + q,EditorStyles.boldLabel);
                        if (GUILayout.Button("Cevabı Sil", GUILayout.ExpandWidth(false)))
                        {
                            CevabıSil(i,q);
                        }
                        GUILayout.EndHorizontal();
                        Cevap cevap = diyalog.konuşmalar[i].cevaplar[q];
                        cevap.yazı = EditorGUILayout.TextField("Cevap Yazısı", cevap.yazı);
                        cevap.ödülAçlık = EditorGUILayout.FloatField("Yemek Ödülü", cevap.ödülAçlık);
                        cevap.ödülEnerji = EditorGUILayout.FloatField("Enerji Ödülü", cevap.ödülEnerji);
                        cevap.ödülEşya = (Eşya)EditorGUILayout.ObjectField("Ödül Eşya", cevap.ödülEşya, typeof(Eşya), false);
                        cevap.ödülPara = EditorGUILayout.FloatField("Para Ödülü", cevap.ödülPara);
                        cevap.ödülSağlık = EditorGUILayout.FloatField("Sağlık Ödülü", cevap.ödülSağlık);
                        cevap.verilecekEşya = (Eşya)EditorGUILayout.ObjectField("Verilecek Eşya", cevap.verilecekEşya, typeof(Eşya), false);
                        cevap.gerekenYetenek.yetenekAdı = EditorGUILayout.TextField("Gerekli Yetenek Adı", cevap.gerekenYetenek.yetenekAdı);
                        cevap.gerekenYetenek.gerekenSeviye = EditorGUILayout.IntField("Gerekli Yetenek Seviyesi", cevap.gerekenYetenek.gerekenSeviye);
                        cevap.konuşmaSıra = EditorGUILayout.IntField("Konuşma Sırası", cevap.konuşmaSıra);
                        diyalog.konuşmalar[i].cevaplar[q] = cevap;
                    }
                    GUILayout.EndVertical();
                }
                EditorGUILayout.EndScrollView();
                GUILayout.Space(10);
            }
            else
            {
                GUILayout.Label("Diyalog Listesi Boş");
            }
        }
        if (GUI.changed)
        {
            EditorUtility.SetDirty(diyalogVT);
        }
    }

    private void CevabıSil(int konuşmaSırası, int CevapSırası)
    {
        diyalogVT[bakılanDiyalogID].konuşmalar[konuşmaSırası].cevaplar.RemoveAt(CevapSırası);
    }

    private void YeniCevapOluştur(int i)
    {
        Cevap c = new Cevap();
        diyalogVT[bakılanDiyalogID].konuşmalar[i].cevaplar.Add(c);
    }

    private void YeniKonuşmaOluştur()
    {
        Konuşma k = new Konuşma();
        diyalogVT[bakılanDiyalogID].konuşmalar.Add(k);
    }

    private void DiyalogSil(int bakılanDiyalogID)
    {
        diyalogVT.RemoveAt(bakılanDiyalogID);
        diyalogSayısı = diyalogVT.Adet;
        BakılanDiyalogID = bakılanDiyalogID - 1;
    }

    private void DiyaloglarıAç()
    {
        throw new NotImplementedException();
    }

    private void YeniDiyalogOluştur()
    {
        diyalog = new Diyalog();
        diyalogVT.Add(diyalog);
        diyalogSayısı = diyalogVT.Adet;
    }
}
