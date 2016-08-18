using UnityEngine;
using System.Collections;

public class HaritaGösterimi : MonoBehaviour {
    public RenderTexture haritaResmi;
    public Material haritaMateryal;
	// Use this for initialization
	void OnGUI()
    {
        if(Event.current.type==EventType.Repaint)
        Graphics.DrawTexture(new Rect(Screen.width - 256 - 10, Screen.height + 256 + 10, 256, 256), haritaResmi, haritaMateryal);
    }
}
