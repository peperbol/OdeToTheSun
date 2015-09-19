using UnityEngine;
using System.Collections;
using System;

public class StartGame : MonoBehaviour {
    SolarColor[] c;
    public bool debugSkip;
    public GameObject StartVisual;
    // Use this for initialization
    void Start () {

        c = (SolarColor[])Enum.GetValues(typeof(SolarColor));
    }
	
	// Update is called once per frame
	void Update () {
        bool start = true;
		
        for (int i = 0; i < c.Length; i++)
        {
            start &= InputController.GetPress((SolarColor )i);
        }
        
        if (start || debugSkip || Input.GetKeyDown(KeyCode.Space)) {
            GameObject.FindObjectOfType<SongPlayer>().Play();
            Destroy(StartVisual);
            Destroy(this);
        }
	}
}
