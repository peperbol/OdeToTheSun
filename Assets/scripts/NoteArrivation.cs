using UnityEngine;
using System.Collections;

public class NoteArrivation : MonoBehaviour {

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.GetComponent<Note>()) {
            col.GetComponent<Note>().Arrive();
            Debug.Log(1);
        }
        Debug.Log(2);
    }
}
