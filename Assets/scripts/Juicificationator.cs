using UnityEngine;
using System.Collections;
using System;

public class Juicificationator : MonoBehaviour {

    public void onTheBeat()
    {
        beatThePulsars();
        beatTheBackground();
    }

    private void beatTheBackground()
    {
        BackgroundColorPulsar[] pulsars = GameObject.FindObjectsOfType<BackgroundColorPulsar>();
        foreach (BackgroundColorPulsar pulsee in pulsars)
        {
            pulsee.startPulse();
        }
    }

    private void beatThePulsars()
    {
        SizePulsar[] pulsars = GameObject.FindObjectsOfType<SizePulsar>();
        foreach (SizePulsar pulsee in pulsars)
        {
            pulsee.startPulse();
        }
    }



}
