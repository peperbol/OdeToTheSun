using UnityEngine;
using System.Collections;

public class HandAnimation : MonoBehaviour
{
    public Vector3 openL;
    public Vector3 openR;
    public Vector3 closeL;
    public Vector3 closeR;
    public Transform L;
    public Transform R;
    // Use this for initialization
    void Start()
    {

        StartCoroutine(Anim());
    }

    private IEnumerator Anim()
    {
        float animTime = GameProperties.SecondsPerBeat /2;
        float t = animTime;
        while (true)
        {
            t -= animTime;
            while (t < animTime)
            {
                yield return null;
                t += Time.deltaTime;
                L.localPosition = Vector3.Lerp(openL, closeL, t / animTime);
                R.localPosition = Vector3.Lerp(openR, closeR, t / animTime);
            }

            t -= animTime;
            while (t < animTime)
            {
                yield return null;
                t += Time.deltaTime;
                L.localPosition = Vector3.Lerp(closeL, openL, t / animTime);
                R.localPosition = Vector3.Lerp(closeR, openR,  t / animTime);
            }

        }
    }
}
