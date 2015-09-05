using UnityEngine;
using System.Collections;
using System;

public class Juicificationator : MonoBehaviour {
    [Range(0, 4)]
    public float maxColorPulse = 1.05f;

    public void onTheBeat()
    {
        beatThePulsars();
        beatTheBackground();
    }

    private void beatTheBackground()
    {
        StartCoroutine(pulseBackgroundColor(Camera.main, 0.1f, maxColorPulse, 0.5f));
    }

    private void beatThePulsars()
    {
        SizePulsar[] pulsars = GameObject.FindObjectsOfType<SizePulsar>();
        foreach (SizePulsar pulsee in pulsars)
        {
            pulsee.startPulse();
        }
    }


    private IEnumerator pulseBackgroundColor(Camera target, float widenTime, float maxBrightness, float shrinkTime)
    {
        float currTime = 0;
        Color initial = target.backgroundColor;

        while (currTime < widenTime && target != null)
        {
            float scale = Mathf.Lerp(1, maxBrightness, currTime / widenTime);
            target.backgroundColor = initial * scale;

            currTime += Time.deltaTime;
            yield return null;
        }

        while (currTime < shrinkTime && target != null)
        {
            float scale = Mathf.Lerp(maxBrightness, 1, (currTime - widenTime) / shrinkTime);
            target.backgroundColor = initial * scale;

            currTime += Time.deltaTime;
            yield return null;
        }

        if (target != null)
        {
            target.backgroundColor = initial;
        }

        yield return null;
    }

}
