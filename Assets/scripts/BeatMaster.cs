using UnityEngine;
using System.Collections;
using System;

public class BeatMaster : MonoBehaviour {

    private float lastBeat;
    private float nextBeat;
    private int beatNumber;

    // Use this for initialization
    void Start () {
        lastBeat = 0;
        nextBeat = GameProperties.NoteDuration;
        beatNumber = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Time.time > nextBeat)
        {
            nextBeat = nextBeat + GameProperties.SecondsPerBeat;
            beat();
        }
    }

    void beat()
    {
        Debug.Log("Beat!");
        beatNumber++;

        if(shouldSpawnNewNote())
        {
            spawnNewNote();
        }
        //TODO: juicify things

        GameObject.FindObjectOfType <Juicificationator>().onTheBeat();
    }

    private void spawnNewNote()
    {
        Debug.Log("Note!");
        GameObject.FindObjectOfType<NoteSpawner>().spawn2RandomNotesWithRing();
    }

    private bool shouldSpawnNewNote()
    {
        return beatNumber % 2 == 0;
    }
}
