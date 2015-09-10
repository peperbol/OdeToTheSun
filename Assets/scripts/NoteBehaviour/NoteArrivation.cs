using UnityEngine;
using System.Collections;

public class NoteArrivation : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Note>()) {
            col.GetComponent<Note>().Arrive();
        }
    }
}
