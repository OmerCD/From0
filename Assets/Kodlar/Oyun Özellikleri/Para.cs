using UnityEngine;
public class Para : MonoBehaviour
{
    private float para;
    public UnityEngine.UI.Text paraGöstergesi;
    public float ParaBirim
    {
        get
        {
            return para;
        }

        set
        {
            para = value;
            ParaGöster(para);
        }
    }
    void ParaGöster(float yeniPara)
    {
        paraGöstergesi.text = yeniPara.ToString();
    }
}
