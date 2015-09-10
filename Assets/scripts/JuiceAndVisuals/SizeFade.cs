using UnityEngine;
using System.Collections;
public class SizeFade : MonoBehaviour
{
    public Vector3 Size1;
    public Vector3 Size2;
    public bool isFirstSize;
    public float timeToResize = 1;
    private float val;
    SizePulsar pulsar;
    void Start()
    {
        Val = (isFirstSize) ? 0 : 1;
        pulsar = GetComponent<SizePulsar>();
    }
    private float Val
    {
        get { return val; }
        set
        {
            if (val != Mathf.Clamp(value, 0, 1))
            {
                val = Mathf.Clamp(value, 0, 1);
                if (pulsar == null)
                {
                    transform.localScale = Vector3.Lerp(Size1, Size2, val);
                }
                else {
                    pulsar.initialScale = Vector3.Lerp(Size1, Size2, val);
                }
                //Debug.Log(val + " " + Vector3.Lerp(Size1, Size2, val).ToString());
            }
        }
    }
    void Update()
    {
        Val += (isFirstSize ? -1 : 1) * Time.deltaTime / timeToResize;
    }
}
