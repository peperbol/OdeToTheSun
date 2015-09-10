using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Transform))]
public class SizePulsar : Pulsar
{
    [Range(0, 4)]
    public float maxSizePulse = 1.25f;
    [NonSerialized]
    public Vector3 initialScale;
    void Start()
    {
        initialScale = transform.localScale;
    }
    override public void startPulse()
    {
        Transform t = GetComponent<Transform>();
        StartCoroutine(pulseSize(t, 0.02f, maxSizePulse, GameProperties.SecondsPerBeat - 0.05f));
    }

    private IEnumerator pulseSize(Transform target, float widenTime, float maxSize, float shrinkTime)
    {
        float currTime = 0;
         initialScale = target.localScale;

        while (currTime < widenTime && target != null)
        {
            float scale = Mathf.Lerp(1, maxSize, currTime / widenTime);
            target.localScale = initialScale * scale;

            currTime += Time.deltaTime;
            yield return null;
        }

        while (currTime < shrinkTime && target != null)
        {
            float scale = Mathf.Lerp(maxSize, 1, (currTime - widenTime) / shrinkTime);
            target.localScale = initialScale * scale;

            currTime += Time.deltaTime;
            yield return null;
        }

        if (target != null)
        {
            target.localScale = initialScale;
        }

        yield return null;
    }
}
