using UnityEngine;
using System.Collections.Generic;

public class Envanter : MonoBehaviour
{
    [SerializeField]
    int yuvaX, yuvaY;
    [SerializeField]
    GUISkin yüzey;
    [SerializeField]
    List<Eşya> eşyalar = new List<Eşya>(), yuvalar = new List<Eşya>();
    [SerializeField]
    Açlık açlık;
    [SerializeField]
    Enerji enerji;
    [SerializeField]
    Sağlık sağlık;
    bool envanterGöster;
    bool ttGöster;
    string ttYazı;
    bool eşyaSürükleniyor;
    Eşya sürüklenenEşya;
    int öncekiEşyaIndex;
    void Start()
    {
        envanterGöster = false;
        for (int i = 0; i < (yuvaX * yuvaY); i++)
        {
            yuvalar.Add(new Eşya());
            eşyalar.Add(new Eşya());
        }
        EşyaEkle(2);
        EşyaEkle(1);
    }
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
    void OnGUI()
    {
        ttYazı = "";
        GUI.skin = yüzey;
        if (envanterGöster)
        {
            EnvanterÇiz();
            if (ttGöster)
            {
                GUI.Box(new Rect(Event.current.mousePosition.x + 15, Event.current.mousePosition.y + 10, 200, 200), ttYazı, yüzey.GetStyle("TT_Arkaplan"));
            }
        }
        if (eşyaSürükleniyor)
        {
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), sürüklenenEşya.Ikon);
        }

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            envanterGöster = !envanterGöster;
        }
    }
    void EnvanterÇiz()
    {
        Event e = Event.current;
        int i = 0;
        for (int y = 0; y < yuvaY; y++)
        {
            for (int x = 0; x < yuvaX; x++)
            {
                Rect yuvaDörtgen = new Rect(x * 60+15, y * 60+150, 50, 50);
                GUI.Box(yuvaDörtgen, "", yüzey.GetStyle("Yuva_Arkaplan"));
                yuvalar[i] = eşyalar[i];
                Eşya eşya = yuvalar[i];
                if (eşya.Açıklama != null)
                {
                    GUI.DrawTexture(new Rect(yuvaDörtgen.x + 5, yuvaDörtgen.y + 5, yuvaDörtgen.width - 10, yuvaDörtgen.height - 10), yuvalar[i].Ikon);
                    if (yuvaDörtgen.Contains(e.mousePosition))
                    {
                        ttYazı = TTOluştur(yuvalar[i]);
                        ttGöster = true;
                        if (e.button == 0 && e.type == EventType.mouseDrag && !eşyaSürükleniyor)
                        {
                            eşyaSürükleniyor = true;
                            öncekiEşyaIndex = i;
                            sürüklenenEşya = eşya;
                            eşyalar[i] = new Eşya();
                        }
                        if (e.type == EventType.mouseUp && eşyaSürükleniyor)
                        {
                            eşyalar[öncekiEşyaIndex] = eşyalar[i];
                            eşyalar[i] = sürüklenenEşya;
                            eşyaSürükleniyor = false;
                            sürüklenenEşya = null;
                        }
                        if (!eşyaSürükleniyor)
                        {
                            ttYazı = TTOluştur(eşyalar[i]);
                            ttGöster = true;
                        }
                        if (e.isMouse && e.type == EventType.mouseDown && e.button == 1)
                        {
                            if (eşya.Tür==Eşya.EşyaTürü.Tüketilebilir)
                            {
                                TüketilebilirEşyaKullan(eşya, i, true);
                            }
                        }
                    }

                }
                else
                {
                    if (yuvaDörtgen.Contains(e.mousePosition))
                    {
                        if (e.type == EventType.mouseUp && eşyaSürükleniyor)
                        {
                            eşyalar[i] = sürüklenenEşya;
                            eşyaSürükleniyor = false;
                            sürüklenenEşya = null;
                        }
                    }
                }
                if (ttYazı == "")
                {
                    ttGöster = false;
                }
                i++;
            }
        }
    }
    string TTOluştur(Eşya eşya)
    {
        string tYazı = "<color=#b8c7ff>" + eşya.Isim + "</color>\n\n" + "<color=#e3cele>" + eşya.Açıklama + "</color>";
        return tYazı;
    }
    Eşya EşyaAl(int eşyaSırası)
    {
        string yol = UnityEditor.EditorPrefs.GetString("ObjectPath") + eşyaSırası + ".asset";
        return UnityEditor.AssetDatabase.LoadAssetAtPath(yol, typeof(Eşya)) as Eşya;
    }
    void EşyaEkle(int eşyaSırası)
    {
        for (int i = 0; i < eşyalar.Count; i++)
        {
            if (eşyalar[i].Açıklama == null)
            {
                eşyalar[i] = EşyaAl(eşyaSırası);
                break;
            }
        }
    }
    void TüketilebilirEşyaKullan(Eşya eşya,int yuva,bool eşyayıSil)
    {
        switch (eşya.EtkiliAlan)
        {
            case Eşya.EtkiAlanı.Açlık:
                {
                    açlık.DeğerEkle(eşya.EtkiGücü);
                    break;
                }
            case Eşya.EtkiAlanı.Enerji:
                {
                    enerji.DeğerEkle(eşya.EtkiGücü);
                    break;
                }
            case Eşya.EtkiAlanı.Sağlık:
                {
                    sağlık.DeğerEkle(eşya.EtkiGücü);
                    break;
                }
        }
        if (eşyayıSil)
        {
            eşyalar[yuva] = new Eşya();
        }
    }
    bool EşyaEnvanterKontrol(int eşyaSırası)
    {
        for (int i = 0; i < eşyalar.Count; i++)
        {
            if (eşyalar[i].ID == eşyaSırası)
            {
                return true;
            }
        }
        return false;
    }
    void EşyaÇıkar(int eşyaSırası)
    {
        for (int i = 0; i < eşyalar.Count; i++)
        {
            if (eşyalar[i].ID == eşyaSırası)
            {
                eşyalar[i] = new Eşya();
                break;
            }
        }
    }
}
