using UnityEngine;
using System.Collections;
using System;

public class StartGame : MonoBehaviour {
    Colors[] c;
    // Use this for initialization
    void Start () {

        c = (Colors[])Enum.GetValues(typeof(Colors));
    }
	
	// Update is called once per frame
	void Update () {
        bool start = true;
        for (int i = 0; i < c.Length; i++)
        {
            start &= Input.GetKey(c[i].GetKey());
            Debug.Log(c[i].GetKey() + " " + Input.GetKey(c[i].GetKey()));
        }
        Debug.Log(start);
        if (start) {
            GameObject.FindObjectOfType<SongPlayer>().Play();
            Destroy(this);
        }
	}
}
