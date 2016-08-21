using UnityEngine;
public class Para : MonoBehaviour
{
    private float para;
    public UnityEngine.UI.Text paraGöstergesi,giderGöstergesi,gelirGöstergesi;
    float gider;
    float gelir;
    public float ParaBirim
    {
        get
        {
            return para;
        }

        set
        {
            para = value;
            ParaGöster(para,paraGöstergesi);
        }
    }

    public float Gider
    {
        get
        {
            return gider;
        }

        set
        {
            gider = value;
            ParaGöster(para, giderGöstergesi);
        }
    }

    public float Gelir
    {
        get
        {
            return gelir;
        }

        set
        {
            gelir = value;
            ParaGöster(para, gelirGöstergesi);
        }
    }

    void ParaGöster(float yeniPara, UnityEngine.UI.Text paraYazı)
    {
        paraYazı.text = yeniPara.ToString();
    }
}
