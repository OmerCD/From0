using UnityEngine;
using System.Collections;

public class BilgiPaneliTus : MonoBehaviour {
    
    public void TusTıklama()
    {
        string komut = GetComponentInChildren<UnityEngine.UI.Text>().text;
        BilgiPaneli.tıklandı(komut);
    }
}
