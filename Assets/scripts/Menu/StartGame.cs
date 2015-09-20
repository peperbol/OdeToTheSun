using UnityEngine;
using System.Collections;
using System;

public class StartGame : MonoBehaviour {
    SolarColor[] c;
    public bool debugSkip;
    public bool debugTest;
    public GameObject StartVisual;
    // Use this for initialization
    void Start () {

        c = (SolarColor[])Enum.GetValues(typeof(SolarColor));
    }
	
	private float debugTimer =0;
	void Update () {
        bool start = true;
		
        for (int i = 0; i < c.Length; i++)
        {
            start &= InputController.GetPress((SolarColor )i);
        }

        if (debugTest && Input.GetMouseButton(0)) {
            debugTimer += Time.deltaTime;
            if (debugTimer > 5) {
                start = true;
            }
        }
        else{
            debugTimer = 0;
        }
        if (start || debugSkip || (debugTest && Input.GetKeyDown(KeyCode.Space))) {
            GameObject.FindObjectOfType<SongPlayer>().Play();
            Destroy(StartVisual);
            Destroy(this);
        }
	}
}
