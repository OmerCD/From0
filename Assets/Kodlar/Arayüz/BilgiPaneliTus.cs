using UnityEngine;
using System.Collections;

public class BilgiPaneliTus : MonoBehaviour {
    
    public void TusTıklama()
    {
        string komut = GetComponentInChildren<UnityEngine.UI.Text>().text;
        BilgiPaneli.tıklandı(komut);
        BilgiPaneli.gösterim(false, BilgiPaneli.referansBirimi);
        BilgiPaneli.gösterim(true, BilgiPaneli.referansBirimi);
    }
}
