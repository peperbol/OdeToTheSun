using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class InputController : MonoBehaviour {
    private List<Note> notesInside = new List<Note>();
	private KeyCode[] keys = new KeyCode[GameProperties.NUMBER_OF_COLORS];
	// Use this for initialization
	void Start () {
       
        for (int i = 0; i < GameProperties.NUMBER_OF_COLORS; i++)
        {
            keys[i] = ((Colors)i).GetKey();
        }
	}
	
	void Update () {
        for (int i = 0; i < GameProperties.NUMBER_OF_COLORS; i++)
        {
            if (Input.GetKeyDown(keys[i])) {
                if (notesInside.Exists(e => e.ColorOfNote.GetKey() == keys[i])) {
                    notesInside.FindAll(e => e.ColorOfNote.GetKey() == keys[i]).ForEach(e => e.Activate());
                    Debug.Log(keys[i] + "hit succesfull");
                } else
                {
                    Debug.Log(keys[i] + "hit failed");
                    //todo: you pressed wrong
                }
            }
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<Note>()) {
            notesInside.Add(col.gameObject.GetComponent<Note>());
        }
    }
    void OnTriggerLeave2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<Note>())
        {
            notesInside.Remove(col.gameObject.GetComponent<Note>());

        }
    }
}
