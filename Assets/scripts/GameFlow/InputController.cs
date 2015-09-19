using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class InputController : MonoBehaviour {
    private List<Note> notesInside = new List<Note>();
   

    private static bool[] inputPressed = new bool[GameProperties.NUMBER_OF_COLORS];
    private static bool[] inputDown = new bool[GameProperties.NUMBER_OF_COLORS];
    private static bool[] inputUp = new bool[GameProperties.NUMBER_OF_COLORS];

    public static void SetPress(SolarColor color, bool value)
    {

        if ((inputPressed[(int)color] ^ value)) {
            Debug.Log(5);
            inputPressed[(int)color] = value;
            if (value)
            {
                inputDown[(int)color] = true;

            }
            else
            {
                inputUp[(int)color] = true;
            }
        }
    }
    public static bool GetPress(SolarColor color) {
        return inputPressed[(int)color];
    }
    private static void ResetFrame() {
        for (int i = 0; i < GameProperties.NUMBER_OF_COLORS; i++)
        {
            inputDown[i]  = false;
            inputUp[i] = false;
        }
    }
	
	void Update () {
        for (int i = 0; i < GameProperties.NUMBER_OF_COLORS; i++)
        {
            if (inputDown[i]) {
                if (notesInside.Exists(e => e.ColorOfNote == (SolarColor) i )) {

                    notesInside
                        .FindAll(e => e.ColorOfNote == (SolarColor)i)
                        .ForEach(e => e.Activate());
                    //Debug.Log(keys[i] + "hit succesfull");
                } else
                {
                    //Debug.Log(keys[i] + "hit failed");
                    //todo: you pressed wrong
                }
            }
        }
        //Debug.Log(inputDown[0]+" "+ inputDown[1] + " " + inputDown[2] + " " + inputDown[3] + " " + inputDown[4] + " " + inputDown[5] + " " + inputDown[6] + " " + inputDown[7] + " ");
        ResetFrame();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<Note>()) {
            notesInside.Add(col.gameObject.GetComponent<Note>());
        }
    }

    public void Remove(Note note)
    {
            notesInside.Remove(note);
    }
}
