using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(MeshRenderer))]
public class ColorPulsar : Pulsar
{
    [Range(0, 20)]
    public float maxColorPulse = 1.05f;

    override public void startPulse()
    {
        Material target = GetComponent<MeshRenderer>().material;
        StartCoroutine(pulseColor(target, 0.1f, maxColorPulse, GameProperties.SecondsPerBeat - 0.05f));
    }

    private IEnumerator pulseColor(Material target, float widenTime, float maxBrightness, float shrinkTime)
    {
        float currTime = 0;
        Color initial = target.color;

        while (currTime < widenTime && target != null)
        {
            float scale = Mathf.Lerp(1, maxBrightness, currTime / widenTime);
            copyNonAlpha(initial * scale, target);

            currTime += Time.deltaTime;
            yield return null;
        }

        while (currTime < shrinkTime && target != null)
        {
            float scale = Mathf.Lerp(maxBrightness, 1, (currTime - widenTime) / shrinkTime);
            copyNonAlpha(initial * scale, target);

            currTime += Time.deltaTime;
            yield return null;
        }

        if (target != null)
        {
            copyNonAlpha(initial, target);
        }

        yield return null;
    }

    private void copyNonAlpha(Color color, Material target)
    {
        float alpha = target.color.a;
        color.a = alpha;
        target.color = color;
    }

}
