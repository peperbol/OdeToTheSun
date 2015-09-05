using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

	private Colors color;

    public Colors ColorOfNote {
        get { return color; }
    }
    private bool activated;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Activate(){
		activated = true;
	}
	void OnCollisionEnter2D(Collision2D col){

	}

}
