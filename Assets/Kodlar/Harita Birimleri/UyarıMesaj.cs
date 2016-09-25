using UnityEngine;
using System.Collections;

public class UyarıMesaj : MonoBehaviour {
    float gösterilecekSüre;
    bool kontrolEt = false;
    [SerializeField]
    GameObject mesajObjesi;
    public void MesajGöster(string Mesaj,float Süre)
    {
        gösterilecekSüre = Süre;
        GetComponentInChildren<UnityEngine.UI.Text>().text = Mesaj;
        gameObject.SetActive(true);
        kontrolEt = true;
    }
    void Update()
    {
        if (kontrolEt)
        {
            gösterilecekSüre -= Time.deltaTime;
            if (gösterilecekSüre<=0)
            {
                kontrolEt = false;
                gameObject.SetActive(false);
            }
        }
    }
}
