using UnityEngine;
using System.Collections;
using System;

public class Juicificationator : MonoBehaviour {

    public void onTheBeat()
    {
        beatThePulsars();
    }

    private void beatThePulsars()
    {
        Pulsar[] pulsars = GameObject.FindObjectsOfType<Pulsar>();
        foreach (Pulsar pulsee in pulsars)
        {
            pulsee.startPulse();
        }
    }



}
