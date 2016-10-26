using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AnaMenüTuşlar : MonoBehaviour {
    public void YeniOyun()
    {
        SceneManager.LoadScene("Oyun");
    }
}
